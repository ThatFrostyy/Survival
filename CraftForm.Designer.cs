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
            recipeGrid.AllowUserToDeleteRows = false;
            recipeGrid.AllowUserToOrderColumns = true;
            recipeGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            recipeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recipeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recipeGrid.Location = new Point(11, 24);
            recipeGrid.Margin = new Padding(2);
            recipeGrid.Name = "recipeGrid";
            recipeGrid.ReadOnly = true;
            recipeGrid.RowHeadersVisible = false;
            recipeGrid.RowHeadersWidth = 62;
            recipeGrid.Size = new Size(515, 215);
            recipeGrid.TabIndex = 0;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(12, 244);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(629, 90);
            consoleBox.TabIndex = 0;
            // 
            // craftButton
            // 
            craftButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            craftButton.Location = new Point(533, 209);
            craftButton.Margin = new Padding(2);
            craftButton.Name = "craftButton";
            craftButton.Size = new Size(108, 30);
            craftButton.TabIndex = 2;
            craftButton.Text = "Craft";
            craftButton.UseVisualStyleBackColor = true;
            craftButton.Click += craftButton_Click;
            // 
            // CraftForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 346);
            Controls.Add(consoleBox);
            Controls.Add(recipeGrid);
            Controls.Add(craftButton);
            Margin = new Padding(2);
            Name = "CraftForm";
            Text = "Crafting";
            ((System.ComponentModel.ISupportInitialize)recipeGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox consoleBox;
        public DataGridView recipeGrid;
        public Button craftButton;
    }
}