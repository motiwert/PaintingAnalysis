namespace DrawingDiagnosisTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnNotPresent;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnEmphasized;
        private System.Windows.Forms.Button btnMissing;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtXlsInput;
        private System.Windows.Forms.TextBox txtTxtOutput;
        private System.Windows.Forms.Label lblXlsInput;
        private System.Windows.Forms.Label lblTxtOutput;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.DataGridView dgvSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnNotPresent = new System.Windows.Forms.Button();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnEmphasized = new System.Windows.Forms.Button();
            this.btnMissing = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtXlsInput = new System.Windows.Forms.TextBox();
            this.txtTxtOutput = new System.Windows.Forms.TextBox();
            this.lblXlsInput = new System.Windows.Forms.Label();
            this.lblTxtOutput = new System.Windows.Forms.Label();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(30, 20);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(720, 60);
            this.lblQuestion.Text = "פרט לצפייה";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNotPresent
            // 
            this.btnNotPresent.Location = new System.Drawing.Point(620, 100);
            this.btnNotPresent.Name = "btnNotPresent";
            this.btnNotPresent.Size = new System.Drawing.Size(130, 40);
            this.btnNotPresent.Text = "לא מופיע";
            this.btnNotPresent.UseVisualStyleBackColor = true;
            this.btnNotPresent.Click += new System.EventHandler(this.btnNotPresent_Click);
            // 
            // btnPresent
            // 
            this.btnPresent.Location = new System.Drawing.Point(470, 100);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(130, 40);
            this.btnPresent.Text = "מופיע";
            this.btnPresent.UseVisualStyleBackColor = true;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnEmphasized
            // 
            this.btnEmphasized.Location = new System.Drawing.Point(320, 100);
            this.btnEmphasized.Name = "btnEmphasized";
            this.btnEmphasized.Size = new System.Drawing.Size(130, 40);
            this.btnEmphasized.Text = "בולט";
            this.btnEmphasized.UseVisualStyleBackColor = true;
            this.btnEmphasized.Click += new System.EventHandler(this.btnEmphasized_Click);
            // 
            // btnMissing
            // 
            this.btnMissing.Location = new System.Drawing.Point(170, 100);
            this.btnMissing.Name = "btnMissing";
            this.btnMissing.Size = new System.Drawing.Size(130, 40);
            this.btnMissing.Text = "חסר";
            this.btnMissing.UseVisualStyleBackColor = true;
            this.btnMissing.Click += new System.EventHandler(this.btnMissing_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(30, 170);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.Text = "שמור סיכום";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblXlsInput
            // 
            this.lblXlsInput.Location = new System.Drawing.Point(620, 170);
            this.lblXlsInput.Name = "lblXlsInput";
            this.lblXlsInput.Size = new System.Drawing.Size(120, 25);
            this.lblXlsInput.Text = "קובץ קלט XLS:";
            this.lblXlsInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXlsInput
            // 
            this.txtXlsInput.Location = new System.Drawing.Point(400, 170);
            this.txtXlsInput.Name = "txtXlsInput";
            this.txtXlsInput.Size = new System.Drawing.Size(210, 31);
            this.txtXlsInput.Text = "מילון ציורים גירסה 2.xlsx";
            // 
            // lblTxtOutput
            // 
            this.lblTxtOutput.Location = new System.Drawing.Point(620, 210);
            this.lblTxtOutput.Name = "lblTxtOutput";
            this.lblTxtOutput.Size = new System.Drawing.Size(120, 25);
            this.lblTxtOutput.Text = "קובץ פלט TXT:";
            this.lblTxtOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTxtOutput
            // 
            this.txtTxtOutput.Location = new System.Drawing.Point(400, 210);
            this.txtTxtOutput.Name = "txtTxtOutput";
            this.txtTxtOutput.Size = new System.Drawing.Size(210, 31);
            this.txtTxtOutput.Text = "סיכום.txt";
            // 
            // btnShowTable
            // 
            this.btnShowTable.Location = new System.Drawing.Point(30, 220);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(150, 40);
            this.btnShowTable.Text = "הצג טבלה";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Click += new System.EventHandler(this.btnShowTable_Click);
            // 
            // dgvSummary
            // 
            this.dgvSummary.Location = new System.Drawing.Point(30, 280);
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
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnNotPresent);
            this.Controls.Add(this.btnPresent);
            this.Controls.Add(this.btnEmphasized);
            this.Controls.Add(this.btnMissing);
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
