namespace WinFormsApp3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox = new PictureBox();
            btnPaste = new Button();
            textBox = new TextBox();
            btnCopy = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(14, 14);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(350, 151);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(16, 171);
            btnPaste.Margin = new Padding(4, 3, 4, 3);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(88, 27);
            btnPaste.TabIndex = 1;
            btnPaste.Text = "Paste Image";
            btnPaste.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            textBox.Location = new Point(16, 204);
            textBox.Margin = new Padding(4, 3, 4, 3);
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.Size = new Size(212, 23);
            textBox.TabIndex = 2;
            textBox.TextChanged += textBox_TextChanged;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(236, 200);
            btnCopy.Margin = new Padding(4, 3, 4, 3);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(129, 27);
            btnCopy.TabIndex = 3;
            btnCopy.Text = "Copy CLEAR PLATE";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 238);
            Controls.Add(btnCopy);
            Controls.Add(textBox);
            Controls.Add(btnPaste);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "License Plate Recognition";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox;
        private Button btnPaste;
        private TextBox textBox;
        private Button btnCopy;
    }
}
