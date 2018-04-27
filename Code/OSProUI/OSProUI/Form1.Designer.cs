namespace OSProUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNoOfProcesses = new System.Windows.Forms.TextBox();
            this.SchedTypeCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No of Processes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scheduling Type";
            // 
            // txtBoxNoOfProcesses
            // 
            this.txtBoxNoOfProcesses.Location = new System.Drawing.Point(183, 129);
            this.txtBoxNoOfProcesses.Name = "txtBoxNoOfProcesses";
            this.txtBoxNoOfProcesses.Size = new System.Drawing.Size(121, 20);
            this.txtBoxNoOfProcesses.TabIndex = 4;
            // 
            // SchedTypeCombo
            // 
            this.SchedTypeCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "FCFS",
            "SJF (NonPr)",
            "SJF (Pr)",
            "Priority (NonPr)",
            "Priority (Pr)",
            "RR"});
            this.SchedTypeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SchedTypeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SchedTypeCombo.FormattingEnabled = true;
            this.SchedTypeCombo.Items.AddRange(new object[] {
            "FCFS",
            "SJF (NonPr)",
            "SJF (Pr)",
            "Priority (NonPr)",
            "Priority (Pr)",
            "RR"});
            this.SchedTypeCombo.Location = new System.Drawing.Point(183, 92);
            this.SchedTypeCombo.Name = "SchedTypeCombo";
            this.SchedTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.SchedTypeCombo.TabIndex = 6;
            this.SchedTypeCombo.Text = "FCFS";
            this.SchedTypeCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.SchedTypeCombo.TextChanged += new System.EventHandler(this.SchedTypeCombo_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantum Time";
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 326);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SchedTypeCombo);
            this.Controls.Add(this.txtBoxNoOfProcesses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNoOfProcesses;
        private System.Windows.Forms.ComboBox SchedTypeCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

