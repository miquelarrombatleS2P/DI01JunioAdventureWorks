
namespace WindowsFormsDI01
{
    partial class MainForm
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
            this.productList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.subcategoryList = new System.Windows.Forms.ComboBox();
            this.categoryList = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productList
            // 
            this.productList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productList.FormattingEnabled = true;
            this.productList.ItemHeight = 16;
            this.productList.Location = new System.Drawing.Point(12, 82);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(870, 404);
            this.productList.TabIndex = 0;
            this.productList.DoubleClick += new System.EventHandler(this.productList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Choose Subcategory";
            // 
            // subcategoryList
            // 
            this.subcategoryList.FormattingEnabled = true;
            this.subcategoryList.Location = new System.Drawing.Point(150, 40);
            this.subcategoryList.Name = "subcategoryList";
            this.subcategoryList.Size = new System.Drawing.Size(141, 24);
            this.subcategoryList.TabIndex = 19;
            this.subcategoryList.SelectedIndexChanged += new System.EventHandler(this.subcategoryList_SelectedIndexChanged);
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(12, 40);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(114, 24);
            this.categoryList.TabIndex = 20;
            this.categoryList.SelectedIndexChanged += new System.EventHandler(this.categoryList_SelectedIndexChanged);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(568, 40);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(314, 22);
            this.searchBox.TabIndex = 21;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Search Product Name or Product Model";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 495);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.subcategoryList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox productList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox subcategoryList;
        private System.Windows.Forms.ComboBox categoryList;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label2;
    }
}

