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
            button3 = new Button();
            DriveComboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(82, 93);
            button1.Name = "button1";
            button1.Size = new Size(224, 28);
            button1.TabIndex = 0;
            button1.Text = "Take  Current Company Backup";
            button1.UseVisualStyleBackColor = true;
            button1.Click += takebackup;
            // 
            // button2
            // 
            button2.Location = new Point(82, 152);
            button2.Name = "button2";
            button2.Size = new Size(351, 30);
            button2.TabIndex = 1;
            button2.Text = "Take  All Company Backup";
            button2.UseVisualStyleBackColor = true;
            button2.Click += takebackupall;
            // 
            // DatabaseComboBox
            // 
            DatabaseComboBox.FormattingEnabled = true;
            DatabaseComboBox.Location = new Point(312, 93);
            DatabaseComboBox.Name = "DatabaseComboBox";
            DatabaseComboBox.Size = new Size(121, 23);
            DatabaseComboBox.TabIndex = 2;
            DatabaseComboBox.SelectedIndexChanged += DatabaseComboBox_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(82, 50);
            button3.Name = "button3";
            button3.Size = new Size(224, 28);
            button3.TabIndex = 3;
            button3.Text = "Choose the Drive to take Backup";
            button3.UseVisualStyleBackColor = true;
            // 
            // DriveComboBox
            // 
            DriveComboBox.FormattingEnabled = true;
            DriveComboBox.ItemHeight = 15;
            DriveComboBox.Location = new Point(312, 55);
            DriveComboBox.Name = "DriveComboBox";
            DriveComboBox.Size = new Size(121, 23);
            DriveComboBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 330);
            Controls.Add(DriveComboBox);
            Controls.Add(button3);
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
        private Button button3;
        private ComboBox DriveComboBox;
    }
}