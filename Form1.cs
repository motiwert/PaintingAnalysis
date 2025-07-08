using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

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
            cmbAnswers.Enabled = false;
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
                cmbAnswers.Enabled = true;
                if (answers.TryGetValue(item, out var ans))
                    cmbAnswers.SelectedItem = ans;
                else
                    cmbAnswers.SelectedIndex = -1;
            }
            else
            {
                cmbAnswers.Enabled = false;
                cmbAnswers.SelectedIndex = -1;
            }
        }

        private void cmbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeQuestions.SelectedNode?.Tag is DrawingItem item && cmbAnswers.SelectedIndex >= 0)
            {
                answers[item] = cmbAnswers.SelectedItem.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var grouped = answers
                .Where(p => p.Value != "לא מופיע")
                .GroupBy(p => p.Key.Category)
                .ToDictionary(g => g.Key, g => g.Select(p => $"- {p.Key.Detail}: {p.Key.Explanation} ({p.Value})"));

            string outputPath = txtTxtOutput.Text;
            using (var writer = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
            {
                foreach (var category in grouped.Keys)
                {
                    writer.WriteLine($"תחום: {category}");
                    foreach (var line in grouped[category])
                        writer.WriteLine(line);
                    writer.WriteLine();
                }
            }

            MessageBox.Show($"הסיכום נשמר כקובץ {outputPath}");
        }

        private void btnShowTable_Click(object sender, EventArgs e)
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
