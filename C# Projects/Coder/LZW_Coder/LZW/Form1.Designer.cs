namespace LZW
{
    partial class fLZW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLZW));
            this.lCoder = new System.Windows.Forms.Label();
            this.lDecoder = new System.Windows.Forms.Label();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnEncodeFile = new System.Windows.Forms.Button();
            this.btnLoadFileDecode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.numIndex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbFreeze = new System.Windows.Forms.RadioButton();
            this.rbEmpty = new System.Windows.Forms.RadioButton();
            this.cbShowIndexes = new System.Windows.Forms.CheckBox();
            this.gbIndexes = new System.Windows.Forms.GroupBox();
            this.dgIndexes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).BeginInit();
            this.gbIndexes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIndexes)).BeginInit();
            this.SuspendLayout();
            // 
            // lCoder
            // 
            this.lCoder.AutoSize = true;
            this.lCoder.BackColor = System.Drawing.Color.ForestGreen;
            this.lCoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCoder.ForeColor = System.Drawing.Color.White;
            this.lCoder.Location = new System.Drawing.Point(52, 40);
            this.lCoder.Name = "lCoder";
            this.lCoder.Size = new System.Drawing.Size(177, 36);
            this.lCoder.TabIndex = 0;
            this.lCoder.Text = "Coder LZW";
            // 
            // lDecoder
            // 
            this.lDecoder.AutoSize = true;
            this.lDecoder.BackColor = System.Drawing.Color.ForestGreen;
            this.lDecoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDecoder.ForeColor = System.Drawing.Color.White;
            this.lDecoder.Location = new System.Drawing.Point(779, 40);
            this.lDecoder.Name = "lDecoder";
            this.lDecoder.Size = new System.Drawing.Size(210, 36);
            this.lDecoder.TabIndex = 1;
            this.lDecoder.Text = "Decoder LZW";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFile.Location = new System.Drawing.Point(12, 93);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(263, 30);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnEncodeFile
            // 
            this.btnEncodeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncodeFile.Location = new System.Drawing.Point(12, 275);
            this.btnEncodeFile.Name = "btnEncodeFile";
            this.btnEncodeFile.Size = new System.Drawing.Size(263, 30);
            this.btnEncodeFile.TabIndex = 3;
            this.btnEncodeFile.Text = "Encode file";
            this.btnEncodeFile.UseVisualStyleBackColor = true;
            this.btnEncodeFile.Click += new System.EventHandler(this.btnEncodeFile_Click);
            // 
            // btnLoadFileDecode
            // 
            this.btnLoadFileDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFileDecode.Location = new System.Drawing.Point(748, 93);
            this.btnLoadFileDecode.Name = "btnLoadFileDecode";
            this.btnLoadFileDecode.Size = new System.Drawing.Size(263, 30);
            this.btnLoadFileDecode.TabIndex = 4;
            this.btnLoadFileDecode.Text = "Load encoded file ";
            this.btnLoadFileDecode.UseVisualStyleBackColor = true;
            this.btnLoadFileDecode.Click += new System.EventHandler(this.btnLoadFileDecode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.Location = new System.Drawing.Point(748, 150);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(263, 30);
            this.btnDecode.TabIndex = 5;
            this.btnDecode.Text = "Decode file";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // numIndex
            // 
            this.numIndex.Location = new System.Drawing.Point(12, 175);
            this.numIndex.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numIndex.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numIndex.Name = "numIndex";
            this.numIndex.Size = new System.Drawing.Size(120, 22);
            this.numIndex.TabIndex = 6;
            this.numIndex.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose the number of bits for INDEX:";
            // 
            // rbFreeze
            // 
            this.rbFreeze.AutoSize = true;
            this.rbFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFreeze.Location = new System.Drawing.Point(13, 231);
            this.rbFreeze.Name = "rbFreeze";
            this.rbFreeze.Size = new System.Drawing.Size(82, 24);
            this.rbFreeze.TabIndex = 8;
            this.rbFreeze.Text = "Freeze";
            this.rbFreeze.UseVisualStyleBackColor = true;
            // 
            // rbEmpty
            // 
            this.rbEmpty.AutoSize = true;
            this.rbEmpty.Checked = true;
            this.rbEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEmpty.Location = new System.Drawing.Point(165, 231);
            this.rbEmpty.Name = "rbEmpty";
            this.rbEmpty.Size = new System.Drawing.Size(77, 24);
            this.rbEmpty.TabIndex = 9;
            this.rbEmpty.TabStop = true;
            this.rbEmpty.Text = "Empty";
            this.rbEmpty.UseVisualStyleBackColor = true;
            // 
            // cbShowIndexes
            // 
            this.cbShowIndexes.AutoSize = true;
            this.cbShowIndexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowIndexes.Location = new System.Drawing.Point(308, 93);
            this.cbShowIndexes.Name = "cbShowIndexes";
            this.cbShowIndexes.Size = new System.Drawing.Size(194, 24);
            this.cbShowIndexes.TabIndex = 10;
            this.cbShowIndexes.Text = "Show emitted Indexes";
            this.cbShowIndexes.UseVisualStyleBackColor = true;
            // 
            // gbIndexes
            // 
            this.gbIndexes.Controls.Add(this.dgIndexes);
            this.gbIndexes.Location = new System.Drawing.Point(308, 124);
            this.gbIndexes.Name = "gbIndexes";
            this.gbIndexes.Size = new System.Drawing.Size(288, 303);
            this.gbIndexes.TabIndex = 11;
            this.gbIndexes.TabStop = false;
            this.gbIndexes.Text = "Indexes";
            // 
            // dgIndexes
            // 
            this.dgIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIndexes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgIndexes.Location = new System.Drawing.Point(7, 22);
            this.dgIndexes.Name = "dgIndexes";
            this.dgIndexes.RowHeadersWidth = 51;
            this.dgIndexes.RowTemplate.Height = 24;
            this.dgIndexes.Size = new System.Drawing.Size(275, 275);
            this.dgIndexes.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Index";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // fLZW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 450);
            this.Controls.Add(this.gbIndexes);
            this.Controls.Add(this.cbShowIndexes);
            this.Controls.Add(this.rbEmpty);
            this.Controls.Add(this.rbFreeze);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numIndex);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadFileDecode);
            this.Controls.Add(this.btnEncodeFile);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lDecoder);
            this.Controls.Add(this.lCoder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLZW";
            this.Text = "LZW Coder";
            ((System.ComponentModel.ISupportInitialize)(this.numIndex)).EndInit();
            this.gbIndexes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgIndexes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCoder;
        private System.Windows.Forms.Label lDecoder;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnEncodeFile;
        private System.Windows.Forms.Button btnLoadFileDecode;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.NumericUpDown numIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbFreeze;
        private System.Windows.Forms.RadioButton rbEmpty;
        private System.Windows.Forms.CheckBox cbShowIndexes;
        private System.Windows.Forms.GroupBox gbIndexes;
        private System.Windows.Forms.DataGridView dgIndexes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

