namespace ProductBot
{
    partial class ProductBot
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Search_Btn = new System.Windows.Forms.Button();
            this.Search_Textbox = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Platform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search_GridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Percent_TextBox = new System.Windows.Forms.TextBox();
            this.Email_TextBox = new System.Windows.Forms.TextBox();
            this.Kaydet_Btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Start_Btn = new System.Windows.Forms.Button();
            this.Stop__Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search_GridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search_Btn);
            this.groupBox1.Controls.Add(this.Search_Textbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arama";
            // 
            // Search_Btn
            // 
            this.Search_Btn.Location = new System.Drawing.Point(476, 55);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(94, 29);
            this.Search_Btn.TabIndex = 1;
            this.Search_Btn.Text = "Ara";
            this.Search_Btn.UseVisualStyleBackColor = true;
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // Search_Textbox
            // 
            this.Search_Textbox.Location = new System.Drawing.Point(27, 55);
            this.Search_Textbox.Name = "Search_Textbox";
            this.Search_Textbox.Size = new System.Drawing.Size(414, 27);
            this.Search_Textbox.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Search
            // 
            this.Search.DataPropertyName = "Name";
            this.Search.HeaderText = "Arama";
            this.Search.MinimumWidth = 6;
            this.Search.Name = "Search";
            this.Search.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Platform
            // 
            this.Platform.DataPropertyName = "Platform";
            this.Platform.HeaderText = "Platform";
            this.Platform.MinimumWidth = 6;
            this.Platform.Name = "Platform";
            this.Platform.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // UrlName
            // 
            this.UrlName.DataPropertyName = "UrlName";
            this.UrlName.HeaderText = "URL Adı";
            this.UrlName.MinimumWidth = 6;
            this.UrlName.Name = "UrlName";
            this.UrlName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "URL";
            this.Url.MinimumWidth = 6;
            this.Url.Name = "Url";
            this.Url.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Fiyat";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Search_GridView
            // 
            this.Search_GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Search_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Search,
            this.Platform,
            this.UrlName,
            this.Url,
            this.Price});
            this.Search_GridView.Location = new System.Drawing.Point(13, 148);
            this.Search_GridView.Name = "Search_GridView";
            this.Search_GridView.RowHeadersWidth = 51;
            this.Search_GridView.Size = new System.Drawing.Size(1230, 347);
            this.Search_GridView.TabIndex = 1;
            this.Search_GridView.Text = "dataGridView1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Percent_TextBox);
            this.groupBox2.Controls.Add(this.Email_TextBox);
            this.groupBox2.Location = new System.Drawing.Point(638, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 110);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bilgiler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fiyat Yüzdesi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mail Adresi:";
            // 
            // Percent_TextBox
            // 
            this.Percent_TextBox.Location = new System.Drawing.Point(401, 55);
            this.Percent_TextBox.Name = "Percent_TextBox";
            this.Percent_TextBox.Size = new System.Drawing.Size(185, 27);
            this.Percent_TextBox.TabIndex = 0;
            // 
            // Email_TextBox
            // 
            this.Email_TextBox.Location = new System.Drawing.Point(17, 55);
            this.Email_TextBox.Name = "Email_TextBox";
            this.Email_TextBox.Size = new System.Drawing.Size(354, 27);
            this.Email_TextBox.TabIndex = 0;
            // 
            // Kaydet_Btn
            // 
            this.Kaydet_Btn.Location = new System.Drawing.Point(376, 529);
            this.Kaydet_Btn.Name = "Kaydet_Btn";
            this.Kaydet_Btn.Size = new System.Drawing.Size(151, 36);
            this.Kaydet_Btn.TabIndex = 1;
            this.Kaydet_Btn.Text = "KAYDET";
            this.Kaydet_Btn.UseVisualStyleBackColor = true;
            this.Kaydet_Btn.Click += new System.EventHandler(this.Kaydet_Btn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(569, 529);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(151, 36);
            this.Start_Btn.TabIndex = 2;
            this.Start_Btn.Text = "KONTROL BAŞLAT";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // Stop__Btn
            // 
            this.Stop__Btn.Location = new System.Drawing.Point(760, 529);
            this.Stop__Btn.Name = "Stop__Btn";
            this.Stop__Btn.Size = new System.Drawing.Size(151, 36);
            this.Stop__Btn.TabIndex = 2;
            this.Stop__Btn.Text = "KONTROL DURDUR";
            this.Stop__Btn.UseVisualStyleBackColor = true;
            this.Stop__Btn.Click += new System.EventHandler(this.Stop__Btn_Click);
            // 
            // ProductBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 589);
            this.Controls.Add(this.Stop__Btn);
            this.Controls.Add(this.Start_Btn);
            this.Controls.Add(this.Kaydet_Btn);
            this.Controls.Add(this.Search_GridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductBot";
            this.Text = "Product Bot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search_GridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Search_Btn;
        private System.Windows.Forms.TextBox Search_Textbox;
        private System.Windows.Forms.DataGridView Search_GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Platform;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Percent_TextBox;
        private System.Windows.Forms.TextBox Email_TextBox;
        private System.Windows.Forms.Button Kaydet_Btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Start_Btn;
        private System.Windows.Forms.Button Stop__Btn;
    }
}

