namespace DrawingDiagnosisTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtXlsInput;
        private System.Windows.Forms.TextBox txtTxtOutput;
        private System.Windows.Forms.Label lblXlsInput;
        private System.Windows.Forms.Label lblTxtOutput;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.TreeView treeQuestions;
        private System.Windows.Forms.ComboBox cmbAnswers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnExport = new System.Windows.Forms.Button();
            this.txtXlsInput = new System.Windows.Forms.TextBox();
            this.txtTxtOutput = new System.Windows.Forms.TextBox();
            this.lblXlsInput = new System.Windows.Forms.Label();
            this.lblTxtOutput = new System.Windows.Forms.Label();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.treeQuestions = new System.Windows.Forms.TreeView();
            this.cmbAnswers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // treeQuestions
            // 
            this.treeQuestions.Location = new System.Drawing.Point(30, 20);
            this.treeQuestions.Name = "treeQuestions";
            this.treeQuestions.Size = new System.Drawing.Size(500, 250);
            this.treeQuestions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeQuestions_AfterSelect);
            // 
            // cmbAnswers
            // 
            this.cmbAnswers.Location = new System.Drawing.Point(550, 20);
            this.cmbAnswers.Name = "cmbAnswers";
            this.cmbAnswers.Size = new System.Drawing.Size(200, 31);
            this.cmbAnswers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnswers.Items.AddRange(new object[] { "לא מופיע", "מופיע", "בולט", "חסר" });
            this.cmbAnswers.SelectedIndexChanged += new System.EventHandler(this.cmbAnswers_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(30, 300);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.Text = "שמור סיכום";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblXlsInput
            // 
            this.lblXlsInput.Location = new System.Drawing.Point(620, 300);
            this.lblXlsInput.Name = "lblXlsInput";
            this.lblXlsInput.Size = new System.Drawing.Size(120, 25);
            this.lblXlsInput.Text = "קובץ קלט XLS:";
            this.lblXlsInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXlsInput
            // 
            this.txtXlsInput.Location = new System.Drawing.Point(400, 300);
            this.txtXlsInput.Name = "txtXlsInput";
            this.txtXlsInput.Size = new System.Drawing.Size(210, 31);
            this.txtXlsInput.Text = "מילון ציורים גירסה 2.xlsx";
            // 
            // lblTxtOutput
            // 
            this.lblTxtOutput.Location = new System.Drawing.Point(620, 340);
            this.lblTxtOutput.Name = "lblTxtOutput";
            this.lblTxtOutput.Size = new System.Drawing.Size(120, 25);
            this.lblTxtOutput.Text = "קובץ פלט TXT:";
            this.lblTxtOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTxtOutput
            // 
            this.txtTxtOutput.Location = new System.Drawing.Point(400, 340);
            this.txtTxtOutput.Name = "txtTxtOutput";
            this.txtTxtOutput.Size = new System.Drawing.Size(210, 31);
            this.txtTxtOutput.Text = "סיכום.txt";
            // 
            // btnShowTable
            // 
            this.btnShowTable.Location = new System.Drawing.Point(30, 360);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(150, 40);
            this.btnShowTable.Text = "הצג טבלה";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Click += new System.EventHandler(this.btnShowTable_Click);
            // 
            // dgvSummary
            // 
            this.dgvSummary.Location = new System.Drawing.Point(30, 420);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.Size = new System.Drawing.Size(710, 200);
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 650);
            this.Controls.Add(this.treeQuestions);
            this.Controls.Add(this.cmbAnswers);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblXlsInput);
            this.Controls.Add(this.txtXlsInput);
            this.Controls.Add(this.lblTxtOutput);
            this.Controls.Add(this.txtTxtOutput);
            this.Controls.Add(this.btnShowTable);
            this.Controls.Add(this.dgvSummary);
            this.Name = "Form1";
            this.Text = "אבחון ציורים";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
