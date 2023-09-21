namespace Backup
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            DatabaseComboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(149, 100);
            button1.Name = "button1";
            button1.Size = new Size(224, 28);
            button1.TabIndex = 0;
            button1.Text = "Take  Current Company Backup";
            button1.UseVisualStyleBackColor = true;
            button1.Click += takebackup;
            // 
            // button2
            // 
            button2.Location = new Point(149, 159);
            button2.Name = "button2";
            button2.Size = new Size(224, 30);
            button2.TabIndex = 1;
            button2.Text = "Take  All Company Backup";
            button2.UseVisualStyleBackColor = true;
            button2.Click += takebackupall;
            // 
            // DatabaseComboBox
            // 
            DatabaseComboBox.FormattingEnabled = true;
            DatabaseComboBox.Location = new Point(379, 100);
            DatabaseComboBox.Name = "DatabaseComboBox";
            DatabaseComboBox.Size = new Size(121, 23);
            DatabaseComboBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 330);
            Controls.Add(DatabaseComboBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox DatabaseComboBox;
    }
}