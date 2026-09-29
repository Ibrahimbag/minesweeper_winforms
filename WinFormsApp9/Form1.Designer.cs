namespace WinFormsApp9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            minesLeftLabel = new Label();
            smiley = new Button();
            TimeLabel = new Label();
            SuspendLayout();
            // 
            // minesLeftLabel
            // 
            minesLeftLabel.AutoSize = true;
            minesLeftLabel.BackColor = Color.Gainsboro;
            minesLeftLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            minesLeftLabel.ForeColor = Color.DarkBlue;
            minesLeftLabel.Location = new Point(42, 15);
            minesLeftLabel.Name = "minesLeftLabel";
            minesLeftLabel.Size = new Size(82, 50);
            minesLeftLabel.TabIndex = 0;
            minesLeftLabel.Text = "000";
            // 
            // smiley
            // 
            smiley.Image = (Image)resources.GetObject("smiley.Image");
            smiley.Location = new Point(369, 15);
            smiley.Name = "smiley";
            smiley.Size = new Size(57, 57);
            smiley.TabIndex = 2;
            smiley.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.Gainsboro;
            TimeLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            TimeLabel.ForeColor = Color.DarkBlue;
            TimeLabel.Location = new Point(666, 15);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(82, 50);
            TimeLabel.TabIndex = 3;
            TimeLabel.Text = "000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TimeLabel);
            Controls.Add(smiley);
            Controls.Add(minesLeftLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label minesLeftLabel;
        private Button smiley;
        private Label TimeLabel;
    }
}
