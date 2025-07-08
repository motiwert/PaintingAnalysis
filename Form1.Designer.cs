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
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.TreeView treeQuestions;
        private System.Windows.Forms.GroupBox answerGroup;
        private System.Windows.Forms.RadioButton radioNotPresent;
        private System.Windows.Forms.RadioButton radioPresent;
        private System.Windows.Forms.RadioButton radioProminent;
        private System.Windows.Forms.RadioButton radioMissing;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnExport = new Button();
            txtXlsInput = new TextBox();
            txtTxtOutput = new TextBox();
            lblXlsInput = new Label();
            lblTxtOutput = new Label();
            dgvSummary = new DataGridView();
            treeQuestions = new TreeView();
            answerGroup = new GroupBox();
            radioNotPresent = new RadioButton();
            radioPresent = new RadioButton();
            radioProminent = new RadioButton();
            radioMissing = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
            answerGroup.SuspendLayout();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.Location = new Point(561, 449);
            btnExport.Margin = new Padding(2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(105, 24);
            btnExport.TabIndex = 2;
            btnExport.Text = "שמור סיכום";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // txtXlsInput
            // 
            txtXlsInput.Location = new Point(12, 451);
            txtXlsInput.Margin = new Padding(2);
            txtXlsInput.Name = "txtXlsInput";
            txtXlsInput.Size = new Size(148, 23);
            txtXlsInput.TabIndex = 4;
            txtXlsInput.Text = "מילון ציורים גירסה 2.xlsx";
            // 
            // txtTxtOutput
            // 
            txtTxtOutput.Location = new Point(285, 451);
            txtTxtOutput.Margin = new Padding(2);
            txtTxtOutput.Name = "txtTxtOutput";
            txtTxtOutput.Size = new Size(148, 23);
            txtTxtOutput.TabIndex = 6;
            txtTxtOutput.Text = "סיכום.txt";
            // 
            // lblXlsInput
            // 
            lblXlsInput.Location = new Point(166, 454);
            lblXlsInput.Margin = new Padding(2, 0, 2, 0);
            lblXlsInput.Name = "lblXlsInput";
            lblXlsInput.Size = new Size(84, 15);
            lblXlsInput.TabIndex = 3;
            lblXlsInput.Text = "קובץ אקסל:";
            lblXlsInput.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTxtOutput
            // 
            lblTxtOutput.Location = new Point(439, 454);
            lblTxtOutput.Margin = new Padding(2, 0, 2, 0);
            lblTxtOutput.Name = "lblTxtOutput";
            lblTxtOutput.Size = new Size(84, 15);
            lblTxtOutput.TabIndex = 5;
            lblTxtOutput.Text = "קובץ סיכום:";
            lblTxtOutput.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvSummary
            // 
            dgvSummary.AllowUserToAddRows = false;
            dgvSummary.AllowUserToDeleteRows = false;
            dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummary.Location = new Point(11, 482);
            dgvSummary.Margin = new Padding(2);
            dgvSummary.Name = "dgvSummary";
            dgvSummary.ReadOnly = true;
            dgvSummary.Size = new Size(662, 229);
            dgvSummary.TabIndex = 7;
            // 
            // treeQuestions
            // 
            treeQuestions.Location = new Point(11, 12);
            treeQuestions.Margin = new Padding(2);
            treeQuestions.Name = "treeQuestions";
            treeQuestions.Size = new Size(512, 435);
            treeQuestions.TabIndex = 0;
            treeQuestions.AfterSelect += treeQuestions_AfterSelect;
            // 
            // answerGroup
            // 
            answerGroup.Controls.Add(radioNotPresent);
            answerGroup.Controls.Add(radioPresent);
            answerGroup.Controls.Add(radioProminent);
            answerGroup.Controls.Add(radioMissing);
            answerGroup.Enabled = false;
            answerGroup.Location = new Point(533, 12);
            answerGroup.Margin = new Padding(2);
            answerGroup.Name = "answerGroup";
            answerGroup.Padding = new Padding(2);
            answerGroup.Size = new Size(140, 152);
            answerGroup.TabIndex = 1;
            answerGroup.TabStop = false;
            answerGroup.Text = "סטטוס";
            // 
            // radioNotPresent
            // 
            radioNotPresent.Checked = true;
            radioNotPresent.Location = new Point(7, 18);
            radioNotPresent.Margin = new Padding(2);
            radioNotPresent.Name = "radioNotPresent";
            radioNotPresent.Size = new Size(126, 17);
            radioNotPresent.TabIndex = 0;
            radioNotPresent.TabStop = true;
            radioNotPresent.Text = "לא מופיע";
            radioNotPresent.CheckedChanged += RadioAnswer_CheckedChanged;
            // 
            // radioPresent
            // 
            radioPresent.Location = new Point(7, 39);
            radioPresent.Margin = new Padding(2);
            radioPresent.Name = "radioPresent";
            radioPresent.Size = new Size(126, 17);
            radioPresent.TabIndex = 1;
            radioPresent.Text = "מופיע";
            radioPresent.CheckedChanged += RadioAnswer_CheckedChanged;
            // 
            // radioProminent
            // 
            radioProminent.Location = new Point(7, 60);
            radioProminent.Margin = new Padding(2);
            radioProminent.Name = "radioProminent";
            radioProminent.Size = new Size(126, 17);
            radioProminent.TabIndex = 2;
            radioProminent.Text = "בולט";
            radioProminent.CheckedChanged += RadioAnswer_CheckedChanged;
            // 
            // radioMissing
            // 
            radioMissing.Location = new Point(7, 81);
            radioMissing.Margin = new Padding(2);
            radioMissing.Name = "radioMissing";
            radioMissing.Size = new Size(126, 17);
            radioMissing.TabIndex = 3;
            radioMissing.Text = "חסר";
            radioMissing.CheckedChanged += RadioAnswer_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 722);
            Controls.Add(treeQuestions);
            Controls.Add(answerGroup);
            Controls.Add(btnExport);
            Controls.Add(lblXlsInput);
            Controls.Add(txtXlsInput);
            Controls.Add(lblTxtOutput);
            Controls.Add(txtTxtOutput);
            Controls.Add(dgvSummary);
            Margin = new Padding(2);
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            Text = "אבחון ציורים";
            ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
            answerGroup.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
