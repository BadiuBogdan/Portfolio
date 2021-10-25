namespace Coder_LZ77
{
    partial class fCoderLZ77
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCoderLZ77));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lbOffset = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbTitlu = new System.Windows.Forms.Label();
            this.btnEncodeFile = new System.Windows.Forms.Button();
            this.numUpOffset = new System.Windows.Forms.NumericUpDown();
            this.numUpLength = new System.Windows.Forms.NumericUpDown();
            this.cbShowTokens = new System.Windows.Forms.CheckBox();
            this.grTokens = new System.Windows.Forms.GroupBox();
            this.tokenDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadFileDecode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpLength)).BeginInit();
            this.grTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFile.Location = new System.Drawing.Point(15, 86);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(341, 30);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lbOffset
            // 
            this.lbOffset.AutoSize = true;
            this.lbOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOffset.Location = new System.Drawing.Point(14, 129);
            this.lbOffset.Name = "lbOffset";
            this.lbOffset.Size = new System.Drawing.Size(311, 20);
            this.lbOffset.TabIndex = 3;
            this.lbOffset.Text = "Choose the number of bits for the offset:";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLength.Location = new System.Drawing.Point(11, 188);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(314, 20);
            this.lbLength.TabIndex = 4;
            this.lbLength.Text = "Choose the number of bits for the length:";
            // 
            // lbTitlu
            // 
            this.lbTitlu.AutoSize = true;
            this.lbTitlu.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitlu.ForeColor = System.Drawing.Color.White;
            this.lbTitlu.Location = new System.Drawing.Point(81, 28);
            this.lbTitlu.Name = "lbTitlu";
            this.lbTitlu.Size = new System.Drawing.Size(189, 38);
            this.lbTitlu.TabIndex = 5;
            this.lbTitlu.Text = "Coder LZ77";
            // 
            // btnEncodeFile
            // 
            this.btnEncodeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncodeFile.Location = new System.Drawing.Point(12, 315);
            this.btnEncodeFile.Name = "btnEncodeFile";
            this.btnEncodeFile.Size = new System.Drawing.Size(341, 30);
            this.btnEncodeFile.TabIndex = 6;
            this.btnEncodeFile.Text = "Encode file";
            this.btnEncodeFile.UseVisualStyleBackColor = true;
            this.btnEncodeFile.Click += new System.EventHandler(this.btnEncodeFile_Click);
            // 
            // numUpOffset
            // 
            this.numUpOffset.Location = new System.Drawing.Point(15, 152);
            this.numUpOffset.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpOffset.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUpOffset.Name = "numUpOffset";
            this.numUpOffset.Size = new System.Drawing.Size(120, 22);
            this.numUpOffset.TabIndex = 7;
            this.numUpOffset.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numUpLength
            // 
            this.numUpLength.Location = new System.Drawing.Point(15, 212);
            this.numUpLength.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numUpLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpLength.Name = "numUpLength";
            this.numUpLength.Size = new System.Drawing.Size(120, 22);
            this.numUpLength.TabIndex = 8;
            this.numUpLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cbShowTokens
            // 
            this.cbShowTokens.AutoSize = true;
            this.cbShowTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowTokens.Location = new System.Drawing.Point(397, 86);
            this.cbShowTokens.Name = "cbShowTokens";
            this.cbShowTokens.Size = new System.Drawing.Size(136, 24);
            this.cbShowTokens.TabIndex = 9;
            this.cbShowTokens.Text = "Show  Tokens";
            this.cbShowTokens.UseVisualStyleBackColor = true;
            // 
            // grTokens
            // 
            this.grTokens.Controls.Add(this.tokenDataGrid);
            this.grTokens.Location = new System.Drawing.Point(397, 117);
            this.grTokens.Name = "grTokens";
            this.grTokens.Size = new System.Drawing.Size(432, 279);
            this.grTokens.TabIndex = 10;
            this.grTokens.TabStop = false;
            this.grTokens.Text = "Tokens";
            // 
            // tokenDataGrid
            // 
            this.tokenDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tokenDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.tokenDataGrid.Location = new System.Drawing.Point(7, 22);
            this.tokenDataGrid.Name = "tokenDataGrid";
            this.tokenDataGrid.RowHeadersWidth = 51;
            this.tokenDataGrid.RowTemplate.Height = 24;
            this.tokenDataGrid.Size = new System.Drawing.Size(419, 251);
            this.tokenDataGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Pozitie";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lungime";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Simbol";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(912, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "Decoder LZ77";
            // 
            // btnLoadFileDecode
            // 
            this.btnLoadFileDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFileDecode.Location = new System.Drawing.Point(861, 87);
            this.btnLoadFileDecode.Name = "btnLoadFileDecode";
            this.btnLoadFileDecode.Size = new System.Drawing.Size(358, 30);
            this.btnLoadFileDecode.TabIndex = 12;
            this.btnLoadFileDecode.Text = "Load encoded file ";
            this.btnLoadFileDecode.UseVisualStyleBackColor = true;
            this.btnLoadFileDecode.Click += new System.EventHandler(this.btnLoadFileDecode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.Location = new System.Drawing.Point(861, 139);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(358, 30);
            this.btnDecode.TabIndex = 13;
            this.btnDecode.Text = "Decode file";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // fCoderLZ77
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 408);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadFileDecode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grTokens);
            this.Controls.Add(this.cbShowTokens);
            this.Controls.Add(this.numUpLength);
            this.Controls.Add(this.numUpOffset);
            this.Controls.Add(this.btnEncodeFile);
            this.Controls.Add(this.lbTitlu);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.lbOffset);
            this.Controls.Add(this.btnLoadFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1249, 455);
            this.MinimumSize = new System.Drawing.Size(1249, 455);
            this.Name = "fCoderLZ77";
            this.Text = "LZ77 Coder";
            ((System.ComponentModel.ISupportInitialize)(this.numUpOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpLength)).EndInit();
            this.grTokens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label lbOffset;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbTitlu;
        private System.Windows.Forms.Button btnEncodeFile;
        private System.Windows.Forms.NumericUpDown numUpOffset;
        private System.Windows.Forms.NumericUpDown numUpLength;
        private System.Windows.Forms.CheckBox cbShowTokens;
        private System.Windows.Forms.GroupBox grTokens;
        private System.Windows.Forms.DataGridView tokenDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadFileDecode;
        private System.Windows.Forms.Button btnDecode;
    }
}

