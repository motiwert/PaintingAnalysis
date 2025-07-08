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
        private int currentIndex = 0;
        private Dictionary<DrawingItem, string> answers = new();

        public Form1()
        {
            InitializeComponent();
            // Use the input TextBox for the XLS file path
            LoadData(txtXlsInput.Text);
            ShowCurrentItem();
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

        private void ShowCurrentItem()
        {
            if (currentIndex < items.Count)
            {
                var item = items[currentIndex];
                lblQuestion.Text = $"{item.Topic} > {item.Subtopic} > {item.Detail}";
            }
            else
            {
                MessageBox.Show("סיימת את כל הפרטים. כעת תוכל לייצא סיכום.");
            }
        }

        private void RecordAnswer(string answer)
        {
            if (currentIndex < items.Count)
            {
                answers[items[currentIndex]] = answer;
                currentIndex++;
                ShowCurrentItem();
            }
        }

        private void btnNotPresent_Click(object sender, EventArgs e) => RecordAnswer("לא מופיע");
        private void btnPresent_Click(object sender, EventArgs e) => RecordAnswer("מופיע");
        private void btnEmphasized_Click(object sender, EventArgs e) => RecordAnswer("בולט");
        private void btnMissing_Click(object sender, EventArgs e) => RecordAnswer("חסר");

        private void btnExport_Click(object sender, EventArgs e)
        {
            var grouped = answers
                .Where(p => p.Value != "לא מופיע")
                .GroupBy(p => p.Key.Category)
                .ToDictionary(g => g.Key, g => g.Select(p => $"- {p.Key.Detail}: {p.Key.Explanation} ({p.Value})"));

            // Use the output TextBox for the TXT file path
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
            // Show the summary as a table in the DataGridView
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
