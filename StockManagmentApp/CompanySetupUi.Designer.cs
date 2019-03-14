namespace StockManagmentApp
{
    partial class CompanySetupUi
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
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.CompanySaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.companyShowDataGridView = new System.Windows.Forms.DataGridView();
            this.Company = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.companyShowDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new System.Drawing.Point(195, 65);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(241, 20);
            this.companyNameTextBox.TabIndex = 0;
            // 
            // CompanySaveButton
            // 
            this.CompanySaveButton.Location = new System.Drawing.Point(344, 99);
            this.CompanySaveButton.Name = "CompanySaveButton";
            this.CompanySaveButton.Size = new System.Drawing.Size(92, 31);
            this.CompanySaveButton.TabIndex = 1;
            this.CompanySaveButton.Text = "Save";
            this.CompanySaveButton.UseVisualStyleBackColor = true;
            this.CompanySaveButton.Click += new System.EventHandler(this.CompanySaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // companyShowDataGridView
            // 
            this.companyShowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyShowDataGridView.Location = new System.Drawing.Point(12, 148);
            this.companyShowDataGridView.Name = "companyShowDataGridView";
            this.companyShowDataGridView.Size = new System.Drawing.Size(531, 182);
            this.companyShowDataGridView.TabIndex = 3;
            // 
            // Company
            // 
            this.Company.AutoSize = true;
            this.Company.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Company.Location = new System.Drawing.Point(207, 9);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(127, 33);
            this.Company.TabIndex = 7;
            this.Company.Text = "Company";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 345);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(89, 31);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CompanySetupUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 397);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.Company);
            this.Controls.Add(this.companyShowDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompanySaveButton);
            this.Controls.Add(this.companyNameTextBox);
            this.Name = "CompanySetupUi";
            this.Text = "Company Setup";
            ((System.ComponentModel.ISupportInitialize)(this.companyShowDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.Button CompanySaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView companyShowDataGridView;
        private System.Windows.Forms.Label Company;
        private System.Windows.Forms.Button BackButton;
    }
}