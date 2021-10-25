namespace AlgPredictiv
{
    partial class fPrincipala
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
            this.pbOriginalImage = new System.Windows.Forms.PictureBox();
            this.pbErrorMatrix = new System.Windows.Forms.PictureBox();
            this.pbDecodedImage = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnPredict = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowErrorMatrix = new System.Windows.Forms.Button();
            this.numUpScaleError = new System.Windows.Forms.NumericUpDown();
            this.btnLoadEncoded = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnSaveDecode = new System.Windows.Forms.Button();
            this.gbPredictors = new System.Windows.Forms.GroupBox();
            this.rbPjpegLS = new System.Windows.Forms.RadioButton();
            this.rbPAB = new System.Windows.Forms.RadioButton();
            this.rbPABC3 = new System.Windows.Forms.RadioButton();
            this.rbPABC2 = new System.Windows.Forms.RadioButton();
            this.rbPABC1 = new System.Windows.Forms.RadioButton();
            this.rbPC = new System.Windows.Forms.RadioButton();
            this.rbPB = new System.Windows.Forms.RadioButton();
            this.rbPA = new System.Windows.Forms.RadioButton();
            this.rbP128 = new System.Windows.Forms.RadioButton();
            this.gbHistogram = new System.Windows.Forms.GroupBox();
            this.btnShowHistogram = new System.Windows.Forms.Button();
            this.gbChooseMatrix = new System.Windows.Forms.GroupBox();
            this.numUpScaleHistogram = new System.Windows.Forms.NumericUpDown();
            this.rbDecoded = new System.Windows.Forms.RadioButton();
            this.rbErrorPrediction = new System.Windows.Forms.RadioButton();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpScaleError)).BeginInit();
            this.gbPredictors.SuspendLayout();
            this.gbHistogram.SuspendLayout();
            this.gbChooseMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpScaleHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginalImage
            // 
            this.pbOriginalImage.Location = new System.Drawing.Point(45, 13);
            this.pbOriginalImage.Name = "pbOriginalImage";
            this.pbOriginalImage.Size = new System.Drawing.Size(328, 273);
            this.pbOriginalImage.TabIndex = 0;
            this.pbOriginalImage.TabStop = false;
            // 
            // pbErrorMatrix
            // 
            this.pbErrorMatrix.Location = new System.Drawing.Point(489, 13);
            this.pbErrorMatrix.Name = "pbErrorMatrix";
            this.pbErrorMatrix.Size = new System.Drawing.Size(328, 273);
            this.pbErrorMatrix.TabIndex = 1;
            this.pbErrorMatrix.TabStop = false;
            // 
            // pbDecodedImage
            // 
            this.pbDecodedImage.Location = new System.Drawing.Point(963, 13);
            this.pbDecodedImage.Name = "pbDecodedImage";
            this.pbDecodedImage.Size = new System.Drawing.Size(328, 273);
            this.pbDecodedImage.TabIndex = 2;
            this.pbDecodedImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Location = new System.Drawing.Point(23, 339);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(111, 39);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnPredict
            // 
            this.btnPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredict.Location = new System.Drawing.Point(149, 339);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(111, 39);
            this.btnPredict.TabIndex = 4;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(282, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save encoded";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowErrorMatrix
            // 
            this.btnShowErrorMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowErrorMatrix.Location = new System.Drawing.Point(662, 335);
            this.btnShowErrorMatrix.Name = "btnShowErrorMatrix";
            this.btnShowErrorMatrix.Size = new System.Drawing.Size(155, 38);
            this.btnShowErrorMatrix.TabIndex = 6;
            this.btnShowErrorMatrix.Text = "Show error matrix";
            this.btnShowErrorMatrix.UseVisualStyleBackColor = true;
            this.btnShowErrorMatrix.Click += new System.EventHandler(this.btnShowErrorMatrix_Click);
            // 
            // numUpScaleError
            // 
            this.numUpScaleError.DecimalPlaces = 1;
            this.numUpScaleError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpScaleError.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpScaleError.Location = new System.Drawing.Point(543, 346);
            this.numUpScaleError.Name = "numUpScaleError";
            this.numUpScaleError.Size = new System.Drawing.Size(73, 27);
            this.numUpScaleError.TabIndex = 7;
            this.numUpScaleError.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLoadEncoded
            // 
            this.btnLoadEncoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadEncoded.Location = new System.Drawing.Point(912, 336);
            this.btnLoadEncoded.Name = "btnLoadEncoded";
            this.btnLoadEncoded.Size = new System.Drawing.Size(135, 37);
            this.btnLoadEncoded.TabIndex = 8;
            this.btnLoadEncoded.Text = "Load encoded";
            this.btnLoadEncoded.UseVisualStyleBackColor = true;
            this.btnLoadEncoded.Click += new System.EventHandler(this.btnLoadEncoded_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.Location = new System.Drawing.Point(1067, 334);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(104, 38);
            this.btnDecode.TabIndex = 9;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnSaveDecode
            // 
            this.btnSaveDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDecode.Location = new System.Drawing.Point(1201, 334);
            this.btnSaveDecode.Name = "btnSaveDecode";
            this.btnSaveDecode.Size = new System.Drawing.Size(138, 37);
            this.btnSaveDecode.TabIndex = 10;
            this.btnSaveDecode.Text = "Save decode";
            this.btnSaveDecode.UseVisualStyleBackColor = true;
            this.btnSaveDecode.Click += new System.EventHandler(this.btnSaveDecode_Click);
            // 
            // gbPredictors
            // 
            this.gbPredictors.Controls.Add(this.rbPjpegLS);
            this.gbPredictors.Controls.Add(this.rbPAB);
            this.gbPredictors.Controls.Add(this.rbPABC3);
            this.gbPredictors.Controls.Add(this.rbPABC2);
            this.gbPredictors.Controls.Add(this.rbPABC1);
            this.gbPredictors.Controls.Add(this.rbPC);
            this.gbPredictors.Controls.Add(this.rbPB);
            this.gbPredictors.Controls.Add(this.rbPA);
            this.gbPredictors.Controls.Add(this.rbP128);
            this.gbPredictors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPredictors.Location = new System.Drawing.Point(23, 423);
            this.gbPredictors.Name = "gbPredictors";
            this.gbPredictors.Size = new System.Drawing.Size(363, 142);
            this.gbPredictors.TabIndex = 11;
            this.gbPredictors.TabStop = false;
            this.gbPredictors.Text = "Choose your predictor";
            // 
            // rbPjpegLS
            // 
            this.rbPjpegLS.AutoSize = true;
            this.rbPjpegLS.Location = new System.Drawing.Point(224, 88);
            this.rbPjpegLS.Name = "rbPjpegLS";
            this.rbPjpegLS.Size = new System.Drawing.Size(82, 24);
            this.rbPjpegLS.TabIndex = 8;
            this.rbPjpegLS.Text = "jpegLS";
            this.rbPjpegLS.UseVisualStyleBackColor = true;
            // 
            // rbPAB
            // 
            this.rbPAB.AutoSize = true;
            this.rbPAB.Location = new System.Drawing.Point(224, 56);
            this.rbPAB.Name = "rbPAB";
            this.rbPAB.Size = new System.Drawing.Size(89, 24);
            this.rbPAB.TabIndex = 7;
            this.rbPAB.Text = "(A+B)/2";
            this.rbPAB.UseVisualStyleBackColor = true;
            // 
            // rbPABC3
            // 
            this.rbPABC3.AutoSize = true;
            this.rbPABC3.Location = new System.Drawing.Point(224, 26);
            this.rbPABC3.Name = "rbPABC3";
            this.rbPABC3.Size = new System.Drawing.Size(107, 24);
            this.rbPABC3.TabIndex = 6;
            this.rbPABC3.Text = "B+(A-C)/2";
            this.rbPABC3.UseVisualStyleBackColor = true;
            // 
            // rbPABC2
            // 
            this.rbPABC2.AutoSize = true;
            this.rbPABC2.Location = new System.Drawing.Point(92, 86);
            this.rbPABC2.Name = "rbPABC2";
            this.rbPABC2.Size = new System.Drawing.Size(107, 24);
            this.rbPABC2.TabIndex = 5;
            this.rbPABC2.Text = "A+(B-C)/2";
            this.rbPABC2.UseVisualStyleBackColor = true;
            // 
            // rbPABC1
            // 
            this.rbPABC1.AutoSize = true;
            this.rbPABC1.Location = new System.Drawing.Point(92, 56);
            this.rbPABC1.Name = "rbPABC1";
            this.rbPABC1.Size = new System.Drawing.Size(81, 24);
            this.rbPABC1.TabIndex = 4;
            this.rbPABC1.Text = "A+B-C";
            this.rbPABC1.UseVisualStyleBackColor = true;
            // 
            // rbPC
            // 
            this.rbPC.AutoSize = true;
            this.rbPC.Location = new System.Drawing.Point(92, 26);
            this.rbPC.Name = "rbPC";
            this.rbPC.Size = new System.Drawing.Size(42, 24);
            this.rbPC.TabIndex = 3;
            this.rbPC.Text = "C";
            this.rbPC.UseVisualStyleBackColor = true;
            // 
            // rbPB
            // 
            this.rbPB.AutoSize = true;
            this.rbPB.Location = new System.Drawing.Point(6, 86);
            this.rbPB.Name = "rbPB";
            this.rbPB.Size = new System.Drawing.Size(42, 24);
            this.rbPB.TabIndex = 2;
            this.rbPB.Text = "B";
            this.rbPB.UseVisualStyleBackColor = true;
            // 
            // rbPA
            // 
            this.rbPA.AutoSize = true;
            this.rbPA.Location = new System.Drawing.Point(6, 56);
            this.rbPA.Name = "rbPA";
            this.rbPA.Size = new System.Drawing.Size(41, 24);
            this.rbPA.TabIndex = 1;
            this.rbPA.Text = "A";
            this.rbPA.UseVisualStyleBackColor = true;
            // 
            // rbP128
            // 
            this.rbP128.AutoSize = true;
            this.rbP128.Checked = true;
            this.rbP128.Location = new System.Drawing.Point(6, 26);
            this.rbP128.Name = "rbP128";
            this.rbP128.Size = new System.Drawing.Size(57, 24);
            this.rbP128.TabIndex = 0;
            this.rbP128.TabStop = true;
            this.rbP128.Text = "128";
            this.rbP128.UseVisualStyleBackColor = true;
            // 
            // gbHistogram
            // 
            this.gbHistogram.Controls.Add(this.btnShowHistogram);
            this.gbHistogram.Controls.Add(this.gbChooseMatrix);
            this.gbHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHistogram.Location = new System.Drawing.Point(432, 423);
            this.gbHistogram.Name = "gbHistogram";
            this.gbHistogram.Size = new System.Drawing.Size(429, 166);
            this.gbHistogram.TabIndex = 12;
            this.gbHistogram.TabStop = false;
            this.gbHistogram.Text = "Histogram";
            // 
            // btnShowHistogram
            // 
            this.btnShowHistogram.Location = new System.Drawing.Point(307, 69);
            this.btnShowHistogram.Name = "btnShowHistogram";
            this.btnShowHistogram.Size = new System.Drawing.Size(113, 54);
            this.btnShowHistogram.TabIndex = 1;
            this.btnShowHistogram.Text = "Show histogram";
            this.btnShowHistogram.UseVisualStyleBackColor = true;
            this.btnShowHistogram.Click += new System.EventHandler(this.btnShowHistogram_Click);
            // 
            // gbChooseMatrix
            // 
            this.gbChooseMatrix.Controls.Add(this.numUpScaleHistogram);
            this.gbChooseMatrix.Controls.Add(this.rbDecoded);
            this.gbChooseMatrix.Controls.Add(this.rbErrorPrediction);
            this.gbChooseMatrix.Controls.Add(this.rbOriginal);
            this.gbChooseMatrix.Location = new System.Drawing.Point(19, 26);
            this.gbChooseMatrix.Name = "gbChooseMatrix";
            this.gbChooseMatrix.Size = new System.Drawing.Size(270, 117);
            this.gbChooseMatrix.TabIndex = 0;
            this.gbChooseMatrix.TabStop = false;
            this.gbChooseMatrix.Text = "Choose Image and Scale";
            // 
            // numUpScaleHistogram
            // 
            this.numUpScaleHistogram.DecimalPlaces = 2;
            this.numUpScaleHistogram.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpScaleHistogram.Location = new System.Drawing.Point(174, 51);
            this.numUpScaleHistogram.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpScaleHistogram.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpScaleHistogram.Name = "numUpScaleHistogram";
            this.numUpScaleHistogram.Size = new System.Drawing.Size(90, 27);
            this.numUpScaleHistogram.TabIndex = 3;
            this.numUpScaleHistogram.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // rbDecoded
            // 
            this.rbDecoded.AutoSize = true;
            this.rbDecoded.Location = new System.Drawing.Point(7, 81);
            this.rbDecoded.Name = "rbDecoded";
            this.rbDecoded.Size = new System.Drawing.Size(97, 24);
            this.rbDecoded.TabIndex = 2;
            this.rbDecoded.Text = "Decoded";
            this.rbDecoded.UseVisualStyleBackColor = true;
            // 
            // rbErrorPrediction
            // 
            this.rbErrorPrediction.AutoSize = true;
            this.rbErrorPrediction.Location = new System.Drawing.Point(7, 51);
            this.rbErrorPrediction.Name = "rbErrorPrediction";
            this.rbErrorPrediction.Size = new System.Drawing.Size(146, 24);
            this.rbErrorPrediction.TabIndex = 1;
            this.rbErrorPrediction.Text = "Error prediction";
            this.rbErrorPrediction.UseVisualStyleBackColor = true;
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Checked = true;
            this.rbOriginal.Location = new System.Drawing.Point(7, 21);
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.Size = new System.Drawing.Size(88, 24);
            this.rbOriginal.TabIndex = 0;
            this.rbOriginal.TabStop = true;
            this.rbOriginal.Text = "Original";
            this.rbOriginal.UseVisualStyleBackColor = true;
            // 
            // fPrincipala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 591);
            this.Controls.Add(this.gbHistogram);
            this.Controls.Add(this.gbPredictors);
            this.Controls.Add(this.btnSaveDecode);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncoded);
            this.Controls.Add(this.numUpScaleError);
            this.Controls.Add(this.btnShowErrorMatrix);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pbDecodedImage);
            this.Controls.Add(this.pbErrorMatrix);
            this.Controls.Add(this.pbOriginalImage);
            this.Name = "fPrincipala";
            this.Text = "  Prediction";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpScaleError)).EndInit();
            this.gbPredictors.ResumeLayout(false);
            this.gbPredictors.PerformLayout();
            this.gbHistogram.ResumeLayout(false);
            this.gbChooseMatrix.ResumeLayout(false);
            this.gbChooseMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpScaleHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginalImage;
        private System.Windows.Forms.PictureBox pbErrorMatrix;
        private System.Windows.Forms.PictureBox pbDecodedImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShowErrorMatrix;
        private System.Windows.Forms.NumericUpDown numUpScaleError;
        private System.Windows.Forms.Button btnLoadEncoded;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnSaveDecode;
        private System.Windows.Forms.GroupBox gbPredictors;
        private System.Windows.Forms.RadioButton rbPABC1;
        private System.Windows.Forms.RadioButton rbPC;
        private System.Windows.Forms.RadioButton rbPB;
        private System.Windows.Forms.RadioButton rbPA;
        private System.Windows.Forms.RadioButton rbP128;
        private System.Windows.Forms.RadioButton rbPjpegLS;
        private System.Windows.Forms.RadioButton rbPAB;
        private System.Windows.Forms.RadioButton rbPABC3;
        private System.Windows.Forms.RadioButton rbPABC2;
        private System.Windows.Forms.GroupBox gbHistogram;
        private System.Windows.Forms.Button btnShowHistogram;
        private System.Windows.Forms.GroupBox gbChooseMatrix;
        private System.Windows.Forms.RadioButton rbDecoded;
        private System.Windows.Forms.RadioButton rbErrorPrediction;
        private System.Windows.Forms.RadioButton rbOriginal;
        private System.Windows.Forms.NumericUpDown numUpScaleHistogram;
    }
}

