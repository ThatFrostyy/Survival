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
            components = new System.ComponentModel.Container();
            recipeGrid = new DataGridView();
            consoleBox = new TextBox();
            craftButton = new Button();
            craftTimer = new System.Windows.Forms.Timer(components);
            craftTextBox = new TextBox();
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
            recipeGrid.Location = new Point(16, 40);
            recipeGrid.Name = "recipeGrid";
            recipeGrid.ReadOnly = true;
            recipeGrid.RowHeadersVisible = false;
            recipeGrid.RowHeadersWidth = 62;
            recipeGrid.Size = new Size(736, 358);
            recipeGrid.TabIndex = 0;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(17, 407);
            consoleBox.Margin = new Padding(4, 5, 4, 5);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(897, 147);
            consoleBox.TabIndex = 0;
            // 
            // craftButton
            // 
            craftButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            craftButton.Location = new Point(761, 348);
            craftButton.Name = "craftButton";
            craftButton.Size = new Size(154, 50);
            craftButton.TabIndex = 2;
            craftButton.Text = "Craft";
            craftButton.UseVisualStyleBackColor = true;
            craftButton.Click += craftButton_Click;
            // 
            // craftTimer
            // 
            craftTimer.Interval = 1000;
            craftTimer.Tick += craftTimer_Tick;
            // 
            // craftTextBox
            // 
            craftTextBox.Location = new Point(765, 178);
            craftTextBox.Name = "craftTextBox";
            craftTextBox.Size = new Size(150, 31);
            craftTextBox.TabIndex = 3;
            // 
            // CraftForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 577);
            Controls.Add(craftTextBox);
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
        public DataGridView recipeGrid;
        public Button craftButton;
        public System.Windows.Forms.Timer craftTimer;
        public TextBox craftTextBox;
    }
}