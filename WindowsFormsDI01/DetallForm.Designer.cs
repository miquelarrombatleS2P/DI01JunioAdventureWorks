
namespace WindowsFormsDI01
{
    partial class DetallForm
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
            this.Name = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.decription = new System.Windows.Forms.Label();
            this.productSelected = new System.Windows.Forms.Label();
            this.flowLayoutPanelSize = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelColor = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileNametextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.writeImgtoDBButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(25, 19);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(95, 36);
            this.Name.TabIndex = 0;
            this.Name.Text = "label1";
            // 
            // Price
            // 
            this.Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(801, 19);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(95, 36);
            this.Price.TabIndex = 2;
            this.Price.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Color";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(807, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // decription
            // 
            this.decription.AutoSize = true;
            this.decription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decription.Location = new System.Drawing.Point(28, 77);
            this.decription.Name = "decription";
            this.decription.Size = new System.Drawing.Size(46, 17);
            this.decription.TabIndex = 9;
            this.decription.Text = "label1";
            // 
            // productSelected
            // 
            this.productSelected.AutoSize = true;
            this.productSelected.Location = new System.Drawing.Point(34, 359);
            this.productSelected.Name = "productSelected";
            this.productSelected.Size = new System.Drawing.Size(46, 17);
            this.productSelected.TabIndex = 10;
            this.productSelected.Text = "label3";
            this.productSelected.TextChanged += new System.EventHandler(this.productSelected_TextChanged);
            // 
            // flowLayoutPanelSize
            // 
            this.flowLayoutPanelSize.Location = new System.Drawing.Point(96, 150);
            this.flowLayoutPanelSize.Name = "flowLayoutPanelSize";
            this.flowLayoutPanelSize.Size = new System.Drawing.Size(452, 66);
            this.flowLayoutPanelSize.TabIndex = 11;
            // 
            // flowLayoutPanelColor
            // 
            this.flowLayoutPanelColor.Location = new System.Drawing.Point(96, 222);
            this.flowLayoutPanelColor.Name = "flowLayoutPanelColor";
            this.flowLayoutPanelColor.Size = new System.Drawing.Size(452, 66);
            this.flowLayoutPanelColor.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 399);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // fileNametextBox
            // 
            this.fileNametextBox.Location = new System.Drawing.Point(460, 381);
            this.fileNametextBox.Name = "fileNametextBox";
            this.fileNametextBox.Size = new System.Drawing.Size(341, 22);
            this.fileNametextBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Save Image to DataBase";
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(807, 374);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(92, 36);
            this.openFile.TabIndex = 16;
            this.openFile.Text = "Open FIle";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(460, 418);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(436, 203);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // writeImgtoDBButton
            // 
            this.writeImgtoDBButton.Location = new System.Drawing.Point(803, 627);
            this.writeImgtoDBButton.Name = "writeImgtoDBButton";
            this.writeImgtoDBButton.Size = new System.Drawing.Size(93, 36);
            this.writeImgtoDBButton.TabIndex = 18;
            this.writeImgtoDBButton.Text = "Write to DB";
            this.writeImgtoDBButton.UseVisualStyleBackColor = true;
            this.writeImgtoDBButton.Click += new System.EventHandler(this.writeImgtoDBButton_Click);
            // 
            // DetallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 675);
            this.Controls.Add(this.writeImgtoDBButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fileNametextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanelColor);
            this.Controls.Add(this.flowLayoutPanelSize);
            this.Controls.Add(this.productSelected);
            this.Controls.Add(this.decription);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Name);
       //     this.Name = "DetallForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label decription;
        private System.Windows.Forms.Label productSelected;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelColor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox fileNametextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button writeImgtoDBButton;
    }
}