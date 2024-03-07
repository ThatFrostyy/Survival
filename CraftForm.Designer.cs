namespace Survival
{
    partial class CraftForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            recipeGrid = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            consoleBox = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)recipeGrid).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(recipeGrid);
            flowLayoutPanel1.Location = new Point(8, 7);
            flowLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(202, 137);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // recipeGrid
            // 
            recipeGrid.AllowUserToAddRows = false;
            recipeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recipeGrid.Location = new Point(2, 2);
            recipeGrid.Margin = new Padding(2, 2, 2, 2);
            recipeGrid.Name = "recipeGrid";
            recipeGrid.ReadOnly = true;
            recipeGrid.RowHeadersWidth = 62;
            recipeGrid.Size = new Size(200, 135);
            recipeGrid.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(consoleBox);
            flowLayoutPanel2.Location = new Point(10, 148);
            flowLayoutPanel2.Margin = new Padding(2, 2, 2, 2);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(393, 90);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(3, 3);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(392, 90);
            consoleBox.TabIndex = 0;
            // 
            // CraftForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 265);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "CraftForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crafting";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)recipeGrid).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView recipeGrid;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox consoleBox;
    }
}