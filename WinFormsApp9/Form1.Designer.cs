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
            SmileyButton = new Button();
            TimeLabel = new Label();
            btnEasy = new Button();
            btnMedium = new Button();
            btnHard = new Button();
            SuspendLayout();
            // 
            // minesLeftLabel
            // 
            minesLeftLabel.AutoSize = true;
            minesLeftLabel.BackColor = Color.Gainsboro;
            minesLeftLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            minesLeftLabel.ForeColor = Color.DarkBlue;
            minesLeftLabel.Location = new Point(12, 28);
            minesLeftLabel.Name = "minesLeftLabel";
            minesLeftLabel.Size = new Size(82, 50);
            minesLeftLabel.TabIndex = 0;
            minesLeftLabel.Text = "000";
            // 
            // SmileyButton
            // 
            SmileyButton.Image = (Image)resources.GetObject("SmileyButton.Image");
            SmileyButton.Location = new Point(369, 28);
            SmileyButton.Name = "SmileyButton";
            SmileyButton.Size = new Size(57, 57);
            SmileyButton.TabIndex = 2;
            SmileyButton.UseVisualStyleBackColor = true;
            SmileyButton.Click += SmileyButton_Click;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.Gainsboro;
            TimeLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            TimeLabel.ForeColor = Color.DarkBlue;
            TimeLabel.Location = new Point(706, 28);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(82, 50);
            TimeLabel.TabIndex = 3;
            TimeLabel.Text = "000";
            // 
            // btnEasy
            // 
            btnEasy.Location = new Point(2, 2);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(61, 23);
            btnEasy.TabIndex = 4;
            btnEasy.Text = "Easy";
            btnEasy.UseVisualStyleBackColor = true;
            btnEasy.MouseClick += btnDifficulty_MouseClick;
            // 
            // btnMedium
            // 
            btnMedium.Location = new Point(69, 2);
            btnMedium.Name = "btnMedium";
            btnMedium.Size = new Size(61, 23);
            btnMedium.TabIndex = 5;
            btnMedium.Text = "Medium";
            btnMedium.UseVisualStyleBackColor = true;
            btnMedium.MouseClick += btnDifficulty_MouseClick;
            // 
            // btnHard
            // 
            btnHard.Location = new Point(136, 2);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(61, 23);
            btnHard.TabIndex = 6;
            btnHard.Text = "Hard";
            btnHard.UseVisualStyleBackColor = true;
            btnHard.MouseClick += btnDifficulty_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btnHard);
            Controls.Add(btnMedium);
            Controls.Add(btnEasy);
            Controls.Add(TimeLabel);
            Controls.Add(SmileyButton);
            Controls.Add(minesLeftLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label minesLeftLabel;
        private Button SmileyButton;
        private Label TimeLabel;
        private Button btnEasy;
        private Button btnMedium;
        private Button btnHard;
    }
}
