namespace Coder
{
    partial class fCoderSF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCoderSF));
            this.btnLoad = new System.Windows.Forms.Button();
            this.lCoder = new System.Windows.Forms.Label();
            this.btnEncodeFile = new System.Windows.Forms.Button();
            this.btnEncodeText = new System.Windows.Forms.Button();
            this.tbInputText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbdataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDecoder = new System.Windows.Forms.Label();
            this.btnLoadEnc = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.cbCoduri = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbdataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(12, 79);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(341, 30);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lCoder
            // 
            this.lCoder.AutoSize = true;
            this.lCoder.BackColor = System.Drawing.Color.ForestGreen;
            this.lCoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCoder.ForeColor = System.Drawing.Color.White;
            this.lCoder.Location = new System.Drawing.Point(86, 20);
            this.lCoder.Name = "lCoder";
            this.lCoder.Size = new System.Drawing.Size(167, 40);
            this.lCoder.TabIndex = 1;
            this.lCoder.Text = "Coder SF";
            this.lCoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEncodeFile
            // 
            this.btnEncodeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncodeFile.Location = new System.Drawing.Point(12, 126);
            this.btnEncodeFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEncodeFile.Name = "btnEncodeFile";
            this.btnEncodeFile.Size = new System.Drawing.Size(341, 30);
            this.btnEncodeFile.TabIndex = 2;
            this.btnEncodeFile.Text = "Encode File";
            this.btnEncodeFile.UseVisualStyleBackColor = true;
            this.btnEncodeFile.Click += new System.EventHandler(this.btnEncodeFile_Click);
            // 
            // btnEncodeText
            // 
            this.btnEncodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncodeText.Location = new System.Drawing.Point(14, 466);
            this.btnEncodeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEncodeText.Name = "btnEncodeText";
            this.btnEncodeText.Size = new System.Drawing.Size(341, 30);
            this.btnEncodeText.TabIndex = 3;
            this.btnEncodeText.Text = "Encode input text";
            this.btnEncodeText.UseVisualStyleBackColor = true;
            this.btnEncodeText.Click += new System.EventHandler(this.btnEncodeText_Click);
            // 
            // tbInputText
            // 
            this.tbInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInputText.Location = new System.Drawing.Point(12, 172);
            this.tbInputText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbInputText.Multiline = true;
            this.tbInputText.Name = "tbInputText";
            this.tbInputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInputText.Size = new System.Drawing.Size(343, 283);
            this.tbInputText.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbdataGrid);
            this.groupBox1.Location = new System.Drawing.Point(374, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 298);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encode Info";
            // 
            // cbdataGrid
            // 
            this.cbdataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cbdataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.cbdataGrid.Location = new System.Drawing.Point(0, 22);
            this.cbdataGrid.Name = "cbdataGrid";
            this.cbdataGrid.RowHeadersWidth = 51;
            this.cbdataGrid.RowTemplate.Height = 24;
            this.cbdataGrid.Size = new System.Drawing.Size(328, 261);
            this.cbdataGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Simbol";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cod binar";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // lDecoder
            // 
            this.lDecoder.AutoSize = true;
            this.lDecoder.BackColor = System.Drawing.Color.ForestGreen;
            this.lDecoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDecoder.ForeColor = System.Drawing.Color.White;
            this.lDecoder.Location = new System.Drawing.Point(813, 24);
            this.lDecoder.Name = "lDecoder";
            this.lDecoder.Size = new System.Drawing.Size(183, 36);
            this.lDecoder.TabIndex = 7;
            this.lDecoder.Text = "Decoder SF";
            // 
            // btnLoadEnc
            // 
            this.btnLoadEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadEnc.Location = new System.Drawing.Point(731, 79);
            this.btnLoadEnc.Name = "btnLoadEnc";
            this.btnLoadEnc.Size = new System.Drawing.Size(341, 30);
            this.btnLoadEnc.TabIndex = 8;
            this.btnLoadEnc.Text = "Load encoded file";
            this.btnLoadEnc.UseVisualStyleBackColor = true;
            this.btnLoadEnc.Click += new System.EventHandler(this.btnLoadEnc_Click_1);
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.Location = new System.Drawing.Point(731, 126);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(341, 30);
            this.btnDecode.TabIndex = 9;
            this.btnDecode.Text = "Decode file";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // cbCoduri
            // 
            this.cbCoduri.AutoSize = true;
            this.cbCoduri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoduri.Location = new System.Drawing.Point(374, 130);
            this.cbCoduri.Name = "cbCoduri";
            this.cbCoduri.Size = new System.Drawing.Size(125, 24);
            this.cbCoduri.TabIndex = 10;
            this.cbCoduri.Text = "Show Codes";
            this.cbCoduri.UseVisualStyleBackColor = true;
            // 
            // fCoderSF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 521);
            this.Controls.Add(this.cbCoduri);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEnc);
            this.Controls.Add(this.lDecoder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbInputText);
            this.Controls.Add(this.btnEncodeText);
            this.Controls.Add(this.btnEncodeFile);
            this.Controls.Add(this.lCoder);
            this.Controls.Add(this.btnLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1106, 568);
            this.MinimumSize = new System.Drawing.Size(1106, 568);
            this.Name = "fCoderSF";
            this.Text = "Shannon Fano Coder";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbdataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lCoder;
        private System.Windows.Forms.Button btnEncodeFile;
        private System.Windows.Forms.Button btnEncodeText;
        private System.Windows.Forms.TextBox tbInputText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lDecoder;
        private System.Windows.Forms.Button btnLoadEnc;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.CheckBox cbCoduri;
        private System.Windows.Forms.DataGridView cbdataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

