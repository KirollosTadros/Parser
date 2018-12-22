namespace WindowsFormsApplication16
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
            this.Open = new System.Windows.Forms.Button();
            this.File_Name = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Choose = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.Location = new System.Drawing.Point(107, 53);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(176, 87);
            this.Open.TabIndex = 0;
            this.Open.Text = "Open File";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // File_Name
            // 
            this.File_Name.AutoSize = true;
            this.File_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File_Name.Location = new System.Drawing.Point(47, 162);
            this.File_Name.Name = "File_Name";
            this.File_Name.Size = new System.Drawing.Size(75, 18);
            this.File_Name.TabIndex = 1;
            this.File_Name.Text = "File Name";
            this.File_Name.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Choose
            // 
            this.Choose.AutoSize = true;
            this.Choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choose.Location = new System.Drawing.Point(83, 9);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(229, 20);
            this.Choose.TabIndex = 3;
            this.Choose.Text = "Open the file you want to Parse";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 230);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.File_Name);
            this.Controls.Add(this.Open);
            this.Name = "Form1";
            this.Text = "Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Label File_Name;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Choose;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

