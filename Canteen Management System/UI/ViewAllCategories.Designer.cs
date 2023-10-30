namespace Canteen_Management_System.UI
{
    partial class ViewAllCategories
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
            this.CategoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.CategoriesGridView = new System.Windows.Forms.DataGridView();
            this.CategoryIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoriesGroupBox
            // 
            this.CategoriesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoriesGroupBox.Controls.Add(this.CategoriesGridView);
            this.CategoriesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.CategoriesGroupBox.Name = "CategoriesGroupBox";
            this.CategoriesGroupBox.Size = new System.Drawing.Size(776, 488);
            this.CategoriesGroupBox.TabIndex = 0;
            this.CategoriesGroupBox.TabStop = false;
            this.CategoriesGroupBox.Text = "Categories";
            // 
            // CategoriesGridView
            // 
            this.CategoriesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoriesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoriesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryIDColumn,
            this.CategoryNameColumn,
            this.CategoryDescriptionColumn,
            this.ImageColumn,
            this.Active,
            this.EditColumn,
            this.DeleteColumn});
            this.CategoriesGridView.Location = new System.Drawing.Point(6, 26);
            this.CategoriesGridView.Name = "CategoriesGridView";
            this.CategoriesGridView.RowHeadersWidth = 62;
            this.CategoriesGridView.RowTemplate.Height = 28;
            this.CategoriesGridView.Size = new System.Drawing.Size(764, 456);
            this.CategoriesGridView.TabIndex = 0;
            this.CategoriesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoriesGridView_CellClick);
            // 
            // CategoryIDColumn
            // 
            this.CategoryIDColumn.HeaderText = "ID";
            this.CategoryIDColumn.MinimumWidth = 8;
            this.CategoryIDColumn.Name = "CategoryIDColumn";
            this.CategoryIDColumn.ReadOnly = true;
            // 
            // CategoryNameColumn
            // 
            this.CategoryNameColumn.HeaderText = "Category Name";
            this.CategoryNameColumn.MinimumWidth = 8;
            this.CategoryNameColumn.Name = "CategoryNameColumn";
            this.CategoryNameColumn.ReadOnly = true;
            // 
            // CategoryDescriptionColumn
            // 
            this.CategoryDescriptionColumn.HeaderText = "Description";
            this.CategoryDescriptionColumn.MinimumWidth = 8;
            this.CategoryDescriptionColumn.Name = "CategoryDescriptionColumn";
            this.CategoryDescriptionColumn.ReadOnly = true;
            // 
            // ImageColumn
            // 
            this.ImageColumn.HeaderText = "Image";
            this.ImageColumn.MinimumWidth = 8;
            this.ImageColumn.Name = "ImageColumn";
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "Edit";
            this.EditColumn.MinimumWidth = 8;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.MinimumWidth = 8;
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            // 
            // ViewAllCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.CategoriesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewAllCategories";
            this.Text = "ViewAllCategories";
            this.Load += new System.EventHandler(this.ViewAllCategories_Load);
            this.CategoriesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CategoriesGroupBox;
        private System.Windows.Forms.DataGridView CategoriesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteColumn;
    }
}