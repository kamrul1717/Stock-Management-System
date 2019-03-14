namespace StockManagmentApp
{
    partial class StockManagementAppFrontPageUi
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
            this.CategorySetupButton = new System.Windows.Forms.Button();
            this.CompanySetupButton = new System.Windows.Forms.Button();
            this.ItemSetupButton = new System.Windows.Forms.Button();
            this.StockInButton = new System.Windows.Forms.Button();
            this.StockOutButton = new System.Windows.Forms.Button();
            this.SearchViewSummaryButton = new System.Windows.Forms.Button();
            this.ViewSalesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategorySetupButton
            // 
            this.CategorySetupButton.Location = new System.Drawing.Point(12, 42);
            this.CategorySetupButton.Name = "CategorySetupButton";
            this.CategorySetupButton.Size = new System.Drawing.Size(188, 60);
            this.CategorySetupButton.TabIndex = 0;
            this.CategorySetupButton.Text = "Category Setup";
            this.CategorySetupButton.UseVisualStyleBackColor = true;
            this.CategorySetupButton.Click += new System.EventHandler(this.CategorySetupButton_Click);
            // 
            // CompanySetupButton
            // 
            this.CompanySetupButton.Location = new System.Drawing.Point(218, 42);
            this.CompanySetupButton.Name = "CompanySetupButton";
            this.CompanySetupButton.Size = new System.Drawing.Size(188, 60);
            this.CompanySetupButton.TabIndex = 0;
            this.CompanySetupButton.Text = "Company Setup";
            this.CompanySetupButton.UseVisualStyleBackColor = true;
            this.CompanySetupButton.Click += new System.EventHandler(this.CompanySetupButton_Click);
            // 
            // ItemSetupButton
            // 
            this.ItemSetupButton.Location = new System.Drawing.Point(424, 42);
            this.ItemSetupButton.Name = "ItemSetupButton";
            this.ItemSetupButton.Size = new System.Drawing.Size(188, 60);
            this.ItemSetupButton.TabIndex = 0;
            this.ItemSetupButton.Text = "Item Setup";
            this.ItemSetupButton.UseVisualStyleBackColor = true;
            this.ItemSetupButton.Click += new System.EventHandler(this.ItemSetupButton_Click);
            // 
            // StockInButton
            // 
            this.StockInButton.Location = new System.Drawing.Point(114, 138);
            this.StockInButton.Name = "StockInButton";
            this.StockInButton.Size = new System.Drawing.Size(188, 60);
            this.StockInButton.TabIndex = 0;
            this.StockInButton.Text = "Stock In";
            this.StockInButton.UseVisualStyleBackColor = true;
            this.StockInButton.Click += new System.EventHandler(this.StockInButton_Click);
            // 
            // StockOutButton
            // 
            this.StockOutButton.Location = new System.Drawing.Point(337, 138);
            this.StockOutButton.Name = "StockOutButton";
            this.StockOutButton.Size = new System.Drawing.Size(188, 60);
            this.StockOutButton.TabIndex = 0;
            this.StockOutButton.Text = "Stock Out";
            this.StockOutButton.UseVisualStyleBackColor = true;
            this.StockOutButton.Click += new System.EventHandler(this.StockOutButton_Click);
            // 
            // SearchViewSummaryButton
            // 
            this.SearchViewSummaryButton.Location = new System.Drawing.Point(114, 253);
            this.SearchViewSummaryButton.Name = "SearchViewSummaryButton";
            this.SearchViewSummaryButton.Size = new System.Drawing.Size(188, 60);
            this.SearchViewSummaryButton.TabIndex = 0;
            this.SearchViewSummaryButton.Text = "Search And View Item Summary";
            this.SearchViewSummaryButton.UseVisualStyleBackColor = true;
            this.SearchViewSummaryButton.Click += new System.EventHandler(this.SearchViewSummaryButton_Click);
            // 
            // ViewSalesButton
            // 
            this.ViewSalesButton.Location = new System.Drawing.Point(337, 253);
            this.ViewSalesButton.Name = "ViewSalesButton";
            this.ViewSalesButton.Size = new System.Drawing.Size(188, 60);
            this.ViewSalesButton.TabIndex = 0;
            this.ViewSalesButton.Text = "View Sales";
            this.ViewSalesButton.UseVisualStyleBackColor = true;
            this.ViewSalesButton.Click += new System.EventHandler(this.ViewSalesButton_Click);
            // 
            // StockManagementAppFrontPageUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ViewSalesButton);
            this.Controls.Add(this.SearchViewSummaryButton);
            this.Controls.Add(this.StockInButton);
            this.Controls.Add(this.StockOutButton);
            this.Controls.Add(this.ItemSetupButton);
            this.Controls.Add(this.CompanySetupButton);
            this.Controls.Add(this.CategorySetupButton);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "StockManagementAppFrontPageUi";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Stock Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CategorySetupButton;
        private System.Windows.Forms.Button CompanySetupButton;
        private System.Windows.Forms.Button ItemSetupButton;
        private System.Windows.Forms.Button StockInButton;
        private System.Windows.Forms.Button StockOutButton;
        private System.Windows.Forms.Button SearchViewSummaryButton;
        private System.Windows.Forms.Button ViewSalesButton;
    }
}

