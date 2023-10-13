namespace FileManager_V_2._0
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
            directoryTree = new TreeView();
            ErrorLabel = new Label();
            label1 = new Label();
            hotKeyLabel = new Label();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // directoryTree
            // 
            directoryTree.Location = new Point(12, 12);
            directoryTree.Name = "directoryTree";
            directoryTree.Size = new Size(200, 426);
            directoryTree.TabIndex = 0;
            directoryTree.AfterExpand += directoryTree_AfterExpand;
            directoryTree.AfterSelect += directoryTree_AfterSelect;
            directoryTree.NodeMouseDoubleClick += directoryTree_NodeMouseDoubleClick;
            directoryTree.DoubleClick += directoryTree_DoubleClick;
            directoryTree.KeyUp += Form1_KeyUp;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(291, 12);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(0, 15);
            ErrorLabel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 12);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "ErrorStatus:";
            // 
            // hotKeyLabel
            // 
            hotKeyLabel.AutoSize = true;
            hotKeyLabel.Location = new Point(218, 38);
            hotKeyLabel.Name = "hotKeyLabel";
            hotKeyLabel.Size = new Size(54, 15);
            hotKeyLabel.TabIndex = 3;
            hotKeyLabel.Text = "HotKeys:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(546, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 121);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(549, 164);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(239, 274);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            richTextBox1.KeyUp += Form1_KeyUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(549, 3);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 6;
            label2.Text = "Изображение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(549, 146);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 7;
            label3.Text = "Текстовый файл:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Controls.Add(hotKeyLabel);
            Controls.Add(label1);
            Controls.Add(ErrorLabel);
            Controls.Add(directoryTree);
            Name = "Form1";
            Text = "File Browser";
            Load += Form1_Load;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView directoryTree;
        private Label ErrorLabel;
        private Label label1;
        private Label hotKeyLabel;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Label label2;
        private Label label3;
    }
}