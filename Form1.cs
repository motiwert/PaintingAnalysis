using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Xceed.Words.NET;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DrawingDiagnosisTool
{
    public partial class Form1 : Form
    {
        private List<DrawingItem> items = new();
        private Dictionary<DrawingItem, string> answers = new();

        public Form1()
        {
            InitializeComponent();
            LoadData(txtXlsInput.Text);
            PopulateTreeView();
            answerGroup.Enabled = false;
            radioNotPresent.Checked = true; // Always checked by default
            UpdateSummaryTable(); // Show table at startup            
        }

        private void LoadData(string path)
        {
            items.Clear();
            var workbook = new XLWorkbook(path);
            var worksheet = workbook.Worksheet("גיליון1");
            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                items.Add(new DrawingItem
                {
                    Topic = row.Cell(1).GetString(),
                    Subtopic = row.Cell(2).GetString(),
                    Detail = row.Cell(3).GetString(),
                    Explanation = row.Cell(4).GetString(),
                    Category = row.Cell(5).GetString()
                });
            }
        }

        private void PopulateTreeView()
        {
            treeQuestions.Nodes.Clear();
            var topicGroups = items.GroupBy(i => i.Topic);
            foreach (var topicGroup in topicGroups)
            {
                var topicNode = new TreeNode(topicGroup.Key);
                var subtopicGroups = topicGroup.GroupBy(i => i.Subtopic);
                foreach (var subtopicGroup in subtopicGroups)
                {
                    var subtopicNode = new TreeNode(subtopicGroup.Key);
                    foreach (var item in subtopicGroup)
                    {
                        var detailNode = new TreeNode(item.Detail) { Tag = item };
                        subtopicNode.Nodes.Add(detailNode);
                    }
                    topicNode.Nodes.Add(subtopicNode);
                }
                treeQuestions.Nodes.Add(topicNode);
            }
            treeQuestions.ExpandAll();
        }

        private void treeQuestions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is DrawingItem item)
            {
                answerGroup.Enabled = true;
                if (answers.TryGetValue(item, out var ans))
                {
                    switch (ans)
                    {
                        case null:
                        case "":
                        case "לא מופיע": radioNotPresent.Checked = true; break;
                        case "מופיע": radioPresent.Checked = true; break;
                        case "בולט": radioProminent.Checked = true; break;
                        case "חסר": radioMissing.Checked = true; break;
                        default:
                            radioNotPresent.Checked = true;
                            radioPresent.Checked = false;
                            radioProminent.Checked = false;
                            radioMissing.Checked = false;
                            break;
                    }
                }
                else
                {
                    radioNotPresent.Checked = true;
                    radioPresent.Checked = false;
                    radioProminent.Checked = false;
                    radioMissing.Checked = false;
                }
            }
            else
            {
                answerGroup.Enabled = false;
                radioNotPresent.Checked = true;
                radioPresent.Checked = false;
                radioProminent.Checked = false;
                radioMissing.Checked = false;
            }
        }

        private void RadioAnswer_CheckedChanged(object sender, EventArgs e)
        {
            if (treeQuestions.SelectedNode?.Tag is DrawingItem item && answerGroup.Enabled)
            {
                if (radioNotPresent.Checked)
                    answers[item] = "לא מופיע";
                else if (radioPresent.Checked)
                    answers[item] = "מופיע";
                else if (radioProminent.Checked)
                    answers[item] = "בולט";
                else if (radioMissing.Checked)
                    answers[item] = "חסר";
                UpdateSummaryTable(); // Update table in real time
            }
        }

        private void UpdateSummaryTable()
        {
            var table = new DataTable();
            table.Columns.Add("קטגוריה");
            table.Columns.Add("נושא");
            table.Columns.Add("תת נושא");
            table.Columns.Add("פרט");
            table.Columns.Add("הסבר");
            table.Columns.Add("סטטוס");

            foreach (var entry in answers.Where(p => p.Value != "לא מופיע"))
            {
                table.Rows.Add(
                    entry.Key.Category,
                    entry.Key.Topic,
                    entry.Key.Subtopic,
                    entry.Key.Detail,
                    entry.Key.Explanation,
                    entry.Value
                );
            }
            dgvSummary.DataSource = table;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var grouped = answers
                .Where(p => p.Value != "לא מופיע")
                .GroupBy(p => p.Key.Category)
                .ToDictionary(g => g.Key, g => g.Select(p => $"- {p.Key.Detail}: {p.Key.Explanation} ({p.Value})"));

            string outputPath = Path.ChangeExtension(txtTxtOutput.Text, ".docx");

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(outputPath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                foreach (var category in grouped.Keys)
                {
                    // Category title (bold, larger font)
                    var categoryParagraph = new Paragraph(
                        new Run(
                            new RunProperties(
                                new Bold(),
                                new FontSize() { Val = "28" } // 14pt
                            ),
                            new Text($"תחום: {category}")
                        )
                    );
                    // Set RTL for Hebrew
                    categoryParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                    body.Append(categoryParagraph);

                    foreach (var line in grouped[category])
                    {
                        var lineParagraph = new Paragraph(
                            new Run(
                                new RunProperties(
                                    new FontSize() { Val = "24" } // 12pt
                                ),
                                new Text(line)
                            )
                        );
                        lineParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                        body.Append(lineParagraph);
                    }
                    // Add empty paragraph for spacing
                    var emptyParagraph = new Paragraph(new Run(new Text("")));
                    emptyParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                    body.Append(emptyParagraph);
                }
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            MessageBox.Show($"הסיכום נשמר כקובץ {outputPath}");
        }

        private void btnCopySummary_Click(object sender, EventArgs e)
        {
            var grouped = answers
                .Where(p => p.Value != "לא מופיע")
                .GroupBy(p => p.Key.Category)
                .ToDictionary(g => g.Key, g => g.Select(p => $"- {p.Key.Detail}: {p.Key.Explanation} ({p.Value})"));

            var summary = new System.Text.StringBuilder();
            foreach (var category in grouped.Keys)
            {
                summary.AppendLine($"תחום: {category}");
                foreach (var line in grouped[category])
                    summary.AppendLine(line);
                summary.AppendLine();
            }
            Clipboard.SetText(summary.ToString());
            MessageBox.Show("הסיכום הועתק ללוח. ניתן להדביק בתוך מסמך");
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }

        private void ClearAllInputs()
        {
            txtChildName.Text = string.Empty;
            answers.Clear();
            UpdateSummaryTable();
            treeQuestions.SelectedNode = null;
            answerGroup.Enabled = false;
            radioNotPresent.Checked = true;
            radioPresent.Checked = false;
            radioProminent.Checked = false;
            radioMissing.Checked = false;
        }

        private void btnFinishAndSave_Click(object sender, EventArgs e)
        {
            string childName = txtChildName.Text.Trim();
            if (string.IsNullOrEmpty(childName))
            {
                MessageBox.Show("אנא הזן את שם הילד.");
                return;
            }
            var grouped = answers
                .Where(p => p.Value != "לא מופיע")
                .GroupBy(p => p.Key.Category)
                .ToDictionary(g => g.Key, g => g.Select(p => $"- {p.Key.Detail}: {p.Key.Explanation} ({p.Value})"));

            string outputPath = Path.GetFullPath(Path.ChangeExtension(txtTxtOutput.Text, ".docx"));
            string reportDate = DateTime.Now.ToString("dd/MM/yyyy");

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(outputPath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                // Add child name and date at the top
                var nameParagraph = new Paragraph(
                    new Run(
                        new RunProperties(new Bold(), new FontSize() { Val = "28" }),
                        new Text($"שם הילד: {childName}")
                    )
                );
                nameParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                body.Append(nameParagraph);

                var dateParagraph = new Paragraph(
                    new Run(
                        new RunProperties(new FontSize() { Val = "24" }),
                        new Text($"תאריך הדו\"ח: {reportDate}")
                    )
                );
                dateParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                body.Append(dateParagraph);

                // Add empty paragraph for spacing
                var emptyParagraph1 = new Paragraph(new Run(new Text("")));
                emptyParagraph1.ParagraphProperties = new ParagraphProperties(new BiDi());
                body.Append(emptyParagraph1);

                foreach (var category in grouped.Keys)
                {
                    var categoryParagraph = new Paragraph(
                        new Run(
                            new RunProperties(
                                new Bold(),
                                new FontSize() { Val = "28" }
                            ),
                            new Text($"תחום: {category}")
                        )
                    );
                    categoryParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                    body.Append(categoryParagraph);

                    foreach (var line in grouped[category])
                    {
                        var lineParagraph = new Paragraph(
                            new Run(
                                new RunProperties(
                                    new FontSize() { Val = "24" }
                                ),
                                new Text(line)
                            )
                        );
                        lineParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                        body.Append(lineParagraph);
                    }
                    var emptyParagraph = new Paragraph(new Run(new Text("")));
                    emptyParagraph.ParagraphProperties = new ParagraphProperties(new BiDi());
                    body.Append(emptyParagraph);
                }
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
            ClearAllInputs();
            MessageBox.Show($"נשמר בקובץ {outputPath}");
        }
    }
    public class DrawingItem
    {
        public string Topic { get; set; }
        public string Subtopic { get; set; }
        public string Detail { get; set; }
        public string Explanation { get; set; }
        public string Category { get; set; }
    }
}
