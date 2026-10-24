namespace WWMM
{
    partial class MainForm
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
            invincibilityCheckBox = new CheckBox();
            infiniteSandCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // invincibilityCheckBox
            // 
            invincibilityCheckBox.AutoSize = true;
            invincibilityCheckBox.Location = new Point(12, 12);
            invincibilityCheckBox.Name = "invincibilityCheckBox";
            invincibilityCheckBox.Size = new Size(87, 19);
            invincibilityCheckBox.TabIndex = 0;
            invincibilityCheckBox.Text = "Invincibility";
            invincibilityCheckBox.UseVisualStyleBackColor = true;
            invincibilityCheckBox.CheckedChanged += invincibilityCheckBox_CheckedChanged;
            // 
            // infiniteSandCheckBox
            // 
            infiniteSandCheckBox.AutoSize = true;
            infiniteSandCheckBox.Location = new Point(12, 37);
            infiniteSandCheckBox.Name = "infiniteSandCheckBox";
            infiniteSandCheckBox.Size = new Size(92, 19);
            infiniteSandCheckBox.TabIndex = 1;
            infiniteSandCheckBox.Text = "Infinite Sand";
            infiniteSandCheckBox.UseVisualStyleBackColor = true;
            infiniteSandCheckBox.CheckedChanged += infiniteSandCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(528, 256);
            Controls.Add(infiniteSandCheckBox);
            Controls.Add(invincibilityCheckBox);
            Name = "MainForm";
            Text = "WWMM - Warrior Within Mod Menu";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox invincibilityCheckBox;
        private CheckBox infiniteSandCheckBox;
    }
}
