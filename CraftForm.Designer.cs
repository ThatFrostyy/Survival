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
            recipeGrid = new DataGridView();
            consoleBox = new TextBox();
            craftButton = new Button();
            ((System.ComponentModel.ISupportInitialize)recipeGrid).BeginInit();
            SuspendLayout();
            // 
            // recipeGrid
            // 
            recipeGrid.AllowUserToAddRows = false;
            recipeGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            recipeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recipeGrid.Location = new Point(16, 40);
            recipeGrid.Name = "recipeGrid";
            recipeGrid.ReadOnly = true;
            recipeGrid.RowHeadersWidth = 62;
            recipeGrid.Size = new Size(397, 223);
            recipeGrid.TabIndex = 0;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(17, 272);
            consoleBox.Margin = new Padding(4, 5, 4, 5);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(558, 147);
            consoleBox.TabIndex = 0;
            // 
            // craftButton
            // 
            craftButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            craftButton.Location = new Point(423, 222);
            craftButton.Name = "craftButton";
            craftButton.Size = new Size(154, 42);
            craftButton.TabIndex = 2;
            craftButton.Text = "Begin Crafting";
            craftButton.UseVisualStyleBackColor = true;
            // 
            // CraftForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 442);
            Controls.Add(consoleBox);
            Controls.Add(recipeGrid);
            Controls.Add(craftButton);
            Name = "CraftForm";
            Text = "Crafting";
            ((System.ComponentModel.ISupportInitialize)recipeGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox consoleBox;
        private Button craftButton;
        public DataGridView recipeGrid;
    }
}