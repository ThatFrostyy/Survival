namespace Settings
{
    partial class Options
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
            components = new System.ComponentModel.Container();
            autoHeal = new CheckBox();
            save = new Button();
            healPoint = new TextBox();
            toolTip = new ToolTip(components);
            audioBox = new CheckBox();
            SuspendLayout();
            // 
            // autoHeal
            // 
            autoHeal.AutoSize = true;
            autoHeal.Location = new Point(12, 12);
            autoHeal.Name = "autoHeal";
            autoHeal.Size = new Size(79, 19);
            autoHeal.TabIndex = 0;
            autoHeal.Text = "Auto Heal";
            autoHeal.UseVisualStyleBackColor = true;
            autoHeal.CheckedChanged += autoHeal_CheckedChanged;
            // 
            // save
            // 
            save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            save.Enabled = false;
            save.Location = new Point(210, 194);
            save.Name = "save";
            save.Size = new Size(75, 23);
            save.TabIndex = 1;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // healPoint
            // 
            healPoint.Location = new Point(12, 37);
            healPoint.MaxLength = 3;
            healPoint.Name = "healPoint";
            healPoint.PlaceholderText = "Heal threshold";
            healPoint.Size = new Size(79, 23);
            healPoint.TabIndex = 2;
            healPoint.Text = "50";
            healPoint.Visible = false;
            healPoint.KeyPress += healPoint_KeyPress;
            // 
            // audioBox
            // 
            audioBox.AutoSize = true;
            audioBox.Location = new Point(12, 66);
            audioBox.Name = "audioBox";
            audioBox.Size = new Size(58, 19);
            audioBox.TabIndex = 3;
            audioBox.Text = "Audio";
            audioBox.UseVisualStyleBackColor = true;
            audioBox.CheckedChanged += audioBox_CheckedChanged;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 229);
            Controls.Add(audioBox);
            Controls.Add(healPoint);
            Controls.Add(save);
            Controls.Add(autoHeal);
            Name = "Options";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            FormClosing += Options_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button save;
        public CheckBox autoHeal;
        public TextBox healPoint;
        private ToolTip toolTip;
        public CheckBox audioBox;
    }
}