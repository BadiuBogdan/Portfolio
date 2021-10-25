namespace AplicatieClusterring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPrincipala));
            this.panelDate = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLoad2DFile = new System.Windows.Forms.Button();
            this.btnLoadNDFile = new System.Windows.Forms.Button();
            this.btnDBSCAN = new System.Windows.Forms.Button();
            this.gbDBSCAN = new System.Windows.Forms.GroupBox();
            this.lProcent = new System.Windows.Forms.Label();
            this.numMinPoints = new System.Windows.Forms.NumericUpDown();
            this.numEps = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZgomot = new System.Windows.Forms.Button();
            this.tbDistMax = new System.Windows.Forms.TextBox();
            this.lDistMax = new System.Windows.Forms.Label();
            this.gbLoadData = new System.Windows.Forms.GroupBox();
            this.gbAlgoritmi = new System.Windows.Forms.GroupBox();
            this.gbHAC = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpPreagHac = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gbTipSimilaritate = new System.Windows.Forms.GroupBox();
            this.rbCompleteLink = new System.Windows.Forms.RadioButton();
            this.rbSingleLink = new System.Windows.Forms.RadioButton();
            this.btnHAC = new System.Windows.Forms.Button();
            this.gbNormalizare = new System.Windows.Forms.GroupBox();
            this.btnNormalizare = new System.Windows.Forms.Button();
            this.rbCornelSmart = new System.Windows.Forms.RadioButton();
            this.rbMaxMin = new System.Windows.Forms.RadioButton();
            this.rbSuma = new System.Windows.Forms.RadioButton();
            this.rbNominala = new System.Windows.Forms.RadioButton();
            this.rbBinara = new System.Windows.Forms.RadioButton();
            this.btnEval = new System.Windows.Forms.Button();
            this.gbDistante = new System.Windows.Forms.GroupBox();
            this.btnCalcDist = new System.Windows.Forms.Button();
            this.rbCosinus = new System.Windows.Forms.RadioButton();
            this.numOrdin = new System.Windows.Forms.NumericUpDown();
            this.rbMinkowski = new System.Windows.Forms.RadioButton();
            this.rbEuclid = new System.Windows.Forms.RadioButton();
            this.rbManhattan = new System.Windows.Forms.RadioButton();
            this.btnGenFile = new System.Windows.Forms.Button();
            this.gbEvaluare = new System.Windows.Forms.GroupBox();
            this.btnGenerareExcel = new System.Windows.Forms.Button();
            this.btnCorespondenta = new System.Windows.Forms.Button();
            this.gbDBSCAN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).BeginInit();
            this.gbLoadData.SuspendLayout();
            this.gbAlgoritmi.SuspendLayout();
            this.gbHAC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpPreagHac)).BeginInit();
            this.gbTipSimilaritate.SuspendLayout();
            this.gbNormalizare.SuspendLayout();
            this.gbDistante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrdin)).BeginInit();
            this.gbEvaluare.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDate
            // 
            this.panelDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDate.Location = new System.Drawing.Point(17, 16);
            this.panelDate.Margin = new System.Windows.Forms.Padding(4);
            this.panelDate.MaximumSize = new System.Drawing.Size(599, 553);
            this.panelDate.MinimumSize = new System.Drawing.Size(599, 553);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(599, 553);
            this.panelDate.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(647, 54);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 44);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Graficul";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLoad2DFile
            // 
            this.btnLoad2DFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad2DFile.Location = new System.Drawing.Point(7, 27);
            this.btnLoad2DFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad2DFile.Name = "btnLoad2DFile";
            this.btnLoad2DFile.Size = new System.Drawing.Size(136, 44);
            this.btnLoad2DFile.TabIndex = 2;
            this.btnLoad2DFile.Text = "Load 2D file";
            this.btnLoad2DFile.UseVisualStyleBackColor = true;
            this.btnLoad2DFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadNDFile
            // 
            this.btnLoadNDFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadNDFile.Location = new System.Drawing.Point(149, 27);
            this.btnLoadNDFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadNDFile.Name = "btnLoadNDFile";
            this.btnLoadNDFile.Size = new System.Drawing.Size(136, 44);
            this.btnLoadNDFile.TabIndex = 3;
            this.btnLoadNDFile.Text = "Load ND file";
            this.btnLoadNDFile.UseVisualStyleBackColor = true;
            this.btnLoadNDFile.Click += new System.EventHandler(this.btnLoadNDFile_Click);
            // 
            // btnDBSCAN
            // 
            this.btnDBSCAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBSCAN.Location = new System.Drawing.Point(74, 128);
            this.btnDBSCAN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDBSCAN.Name = "btnDBSCAN";
            this.btnDBSCAN.Size = new System.Drawing.Size(107, 41);
            this.btnDBSCAN.TabIndex = 4;
            this.btnDBSCAN.Text = "Clustering";
            this.btnDBSCAN.UseVisualStyleBackColor = true;
            this.btnDBSCAN.Click += new System.EventHandler(this.btnDBSCAN_Click);
            // 
            // gbDBSCAN
            // 
            this.gbDBSCAN.Controls.Add(this.lProcent);
            this.gbDBSCAN.Controls.Add(this.numMinPoints);
            this.gbDBSCAN.Controls.Add(this.numEps);
            this.gbDBSCAN.Controls.Add(this.label2);
            this.gbDBSCAN.Controls.Add(this.label1);
            this.gbDBSCAN.Controls.Add(this.btnZgomot);
            this.gbDBSCAN.Controls.Add(this.btnDBSCAN);
            this.gbDBSCAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDBSCAN.Location = new System.Drawing.Point(5, 26);
            this.gbDBSCAN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDBSCAN.Name = "gbDBSCAN";
            this.gbDBSCAN.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDBSCAN.Size = new System.Drawing.Size(473, 183);
            this.gbDBSCAN.TabIndex = 5;
            this.gbDBSCAN.TabStop = false;
            this.gbDBSCAN.Text = "DBSCAN";
            // 
            // lProcent
            // 
            this.lProcent.AutoSize = true;
            this.lProcent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProcent.Location = new System.Drawing.Point(435, 41);
            this.lProcent.Name = "lProcent";
            this.lProcent.Size = new System.Drawing.Size(32, 26);
            this.lProcent.TabIndex = 10;
            this.lProcent.Text = "%";
            // 
            // numMinPoints
            // 
            this.numMinPoints.Location = new System.Drawing.Point(331, 83);
            this.numMinPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numMinPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinPoints.Name = "numMinPoints";
            this.numMinPoints.Size = new System.Drawing.Size(59, 27);
            this.numMinPoints.TabIndex = 9;
            this.numMinPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numEps
            // 
            this.numEps.DecimalPlaces = 4;
            this.numEps.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numEps.Location = new System.Drawing.Point(331, 40);
            this.numEps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numEps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numEps.Name = "numEps";
            this.numEps.Size = new System.Drawing.Size(98, 27);
            this.numEps.TabIndex = 8;
            this.numEps.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Numarul minim de puncte din cluster:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Distanta minima intre 2 puncte \r\ndata ca procent din distanta maxima:";
            // 
            // btnZgomot
            // 
            this.btnZgomot.Location = new System.Drawing.Point(218, 128);
            this.btnZgomot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZgomot.Name = "btnZgomot";
            this.btnZgomot.Size = new System.Drawing.Size(108, 41);
            this.btnZgomot.TabIndex = 5;
            this.btnZgomot.Text = "Zgomot";
            this.btnZgomot.UseVisualStyleBackColor = true;
            this.btnZgomot.Click += new System.EventHandler(this.btnZgomot_Click);
            // 
            // tbDistMax
            // 
            this.tbDistMax.Location = new System.Drawing.Point(103, 186);
            this.tbDistMax.Name = "tbDistMax";
            this.tbDistMax.ReadOnly = true;
            this.tbDistMax.Size = new System.Drawing.Size(228, 26);
            this.tbDistMax.TabIndex = 11;
            // 
            // lDistMax
            // 
            this.lDistMax.AutoSize = true;
            this.lDistMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDistMax.Location = new System.Drawing.Point(16, 189);
            this.lDistMax.Name = "lDistMax";
            this.lDistMax.Size = new System.Drawing.Size(81, 20);
            this.lDistMax.TabIndex = 10;
            this.lDistMax.Text = "Dist Max:";
            // 
            // gbLoadData
            // 
            this.gbLoadData.Controls.Add(this.btnLoad2DFile);
            this.gbLoadData.Controls.Add(this.btnLoadNDFile);
            this.gbLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLoadData.Location = new System.Drawing.Point(790, 27);
            this.gbLoadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLoadData.Name = "gbLoadData";
            this.gbLoadData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLoadData.Size = new System.Drawing.Size(301, 91);
            this.gbLoadData.TabIndex = 6;
            this.gbLoadData.TabStop = false;
            this.gbLoadData.Text = "Load Data";
            // 
            // gbAlgoritmi
            // 
            this.gbAlgoritmi.Controls.Add(this.gbHAC);
            this.gbAlgoritmi.Controls.Add(this.gbDBSCAN);
            this.gbAlgoritmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlgoritmi.Location = new System.Drawing.Point(633, 360);
            this.gbAlgoritmi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAlgoritmi.Name = "gbAlgoritmi";
            this.gbAlgoritmi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAlgoritmi.Size = new System.Drawing.Size(889, 219);
            this.gbAlgoritmi.TabIndex = 7;
            this.gbAlgoritmi.TabStop = false;
            this.gbAlgoritmi.Text = "Algoritmi";
            // 
            // gbHAC
            // 
            this.gbHAC.Controls.Add(this.label4);
            this.gbHAC.Controls.Add(this.numUpPreagHac);
            this.gbHAC.Controls.Add(this.label3);
            this.gbHAC.Controls.Add(this.gbTipSimilaritate);
            this.gbHAC.Controls.Add(this.btnHAC);
            this.gbHAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHAC.Location = new System.Drawing.Point(500, 26);
            this.gbHAC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbHAC.Name = "gbHAC";
            this.gbHAC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbHAC.Size = new System.Drawing.Size(369, 183);
            this.gbHAC.TabIndex = 5;
            this.gbHAC.TabStop = false;
            this.gbHAC.Text = "HAC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "%";
            // 
            // numUpPreagHac
            // 
            this.numUpPreagHac.DecimalPlaces = 4;
            this.numUpPreagHac.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpPreagHac.Location = new System.Drawing.Point(218, 83);
            this.numUpPreagHac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpPreagHac.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpPreagHac.Name = "numUpPreagHac";
            this.numUpPreagHac.Size = new System.Drawing.Size(93, 27);
            this.numUpPreagHac.TabIndex = 13;
            this.numUpPreagHac.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Prag oprire dezvoltare:";
            // 
            // gbTipSimilaritate
            // 
            this.gbTipSimilaritate.Controls.Add(this.rbCompleteLink);
            this.gbTipSimilaritate.Controls.Add(this.rbSingleLink);
            this.gbTipSimilaritate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipSimilaritate.Location = new System.Drawing.Point(6, 24);
            this.gbTipSimilaritate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTipSimilaritate.Name = "gbTipSimilaritate";
            this.gbTipSimilaritate.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTipSimilaritate.Size = new System.Drawing.Size(301, 53);
            this.gbTipSimilaritate.TabIndex = 5;
            this.gbTipSimilaritate.TabStop = false;
            this.gbTipSimilaritate.Text = "Tip Similaritate";
            // 
            // rbCompleteLink
            // 
            this.rbCompleteLink.AutoSize = true;
            this.rbCompleteLink.Location = new System.Drawing.Point(147, 24);
            this.rbCompleteLink.Name = "rbCompleteLink";
            this.rbCompleteLink.Size = new System.Drawing.Size(137, 24);
            this.rbCompleteLink.TabIndex = 12;
            this.rbCompleteLink.Text = "Complete Link";
            this.rbCompleteLink.UseVisualStyleBackColor = true;
            // 
            // rbSingleLink
            // 
            this.rbSingleLink.AutoSize = true;
            this.rbSingleLink.Checked = true;
            this.rbSingleLink.Location = new System.Drawing.Point(6, 24);
            this.rbSingleLink.Name = "rbSingleLink";
            this.rbSingleLink.Size = new System.Drawing.Size(112, 24);
            this.rbSingleLink.TabIndex = 12;
            this.rbSingleLink.TabStop = true;
            this.rbSingleLink.Text = "Single Link";
            this.rbSingleLink.UseVisualStyleBackColor = true;
            // 
            // btnHAC
            // 
            this.btnHAC.Location = new System.Drawing.Point(130, 128);
            this.btnHAC.Name = "btnHAC";
            this.btnHAC.Size = new System.Drawing.Size(108, 41);
            this.btnHAC.TabIndex = 11;
            this.btnHAC.Text = "Clustering";
            this.btnHAC.UseVisualStyleBackColor = true;
            this.btnHAC.Click += new System.EventHandler(this.btnHAC_Click);
            // 
            // gbNormalizare
            // 
            this.gbNormalizare.Controls.Add(this.btnNormalizare);
            this.gbNormalizare.Controls.Add(this.rbCornelSmart);
            this.gbNormalizare.Controls.Add(this.rbMaxMin);
            this.gbNormalizare.Controls.Add(this.rbSuma);
            this.gbNormalizare.Controls.Add(this.rbNominala);
            this.gbNormalizare.Controls.Add(this.rbBinara);
            this.gbNormalizare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNormalizare.Location = new System.Drawing.Point(989, 129);
            this.gbNormalizare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNormalizare.Name = "gbNormalizare";
            this.gbNormalizare.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNormalizare.Size = new System.Drawing.Size(301, 181);
            this.gbNormalizare.TabIndex = 8;
            this.gbNormalizare.TabStop = false;
            this.gbNormalizare.Text = "Normalizare";
            // 
            // btnNormalizare
            // 
            this.btnNormalizare.Location = new System.Drawing.Point(165, 75);
            this.btnNormalizare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNormalizare.Name = "btnNormalizare";
            this.btnNormalizare.Size = new System.Drawing.Size(120, 37);
            this.btnNormalizare.TabIndex = 5;
            this.btnNormalizare.Text = "Normalizare";
            this.btnNormalizare.UseVisualStyleBackColor = true;
            this.btnNormalizare.Click += new System.EventHandler(this.btnNormalizare_Click);
            // 
            // rbCornelSmart
            // 
            this.rbCornelSmart.AutoSize = true;
            this.rbCornelSmart.Location = new System.Drawing.Point(7, 149);
            this.rbCornelSmart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCornelSmart.Name = "rbCornelSmart";
            this.rbCornelSmart.Size = new System.Drawing.Size(130, 24);
            this.rbCornelSmart.TabIndex = 4;
            this.rbCornelSmart.Text = "Cornel-Smart";
            this.rbCornelSmart.UseVisualStyleBackColor = true;
            // 
            // rbMaxMin
            // 
            this.rbMaxMin.AutoSize = true;
            this.rbMaxMin.Location = new System.Drawing.Point(7, 119);
            this.rbMaxMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbMaxMin.Name = "rbMaxMin";
            this.rbMaxMin.Size = new System.Drawing.Size(94, 24);
            this.rbMaxMin.TabIndex = 3;
            this.rbMaxMin.Text = "Max-Min";
            this.rbMaxMin.UseVisualStyleBackColor = true;
            // 
            // rbSuma
            // 
            this.rbSuma.AutoSize = true;
            this.rbSuma.Location = new System.Drawing.Point(7, 89);
            this.rbSuma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSuma.Name = "rbSuma";
            this.rbSuma.Size = new System.Drawing.Size(82, 24);
            this.rbSuma.TabIndex = 2;
            this.rbSuma.Text = "Suma1";
            this.rbSuma.UseVisualStyleBackColor = true;
            // 
            // rbNominala
            // 
            this.rbNominala.AutoSize = true;
            this.rbNominala.Checked = true;
            this.rbNominala.Location = new System.Drawing.Point(7, 57);
            this.rbNominala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbNominala.Name = "rbNominala";
            this.rbNominala.Size = new System.Drawing.Size(100, 24);
            this.rbNominala.TabIndex = 1;
            this.rbNominala.TabStop = true;
            this.rbNominala.Text = "Nominala";
            this.rbNominala.UseVisualStyleBackColor = true;
            // 
            // rbBinara
            // 
            this.rbBinara.AutoSize = true;
            this.rbBinara.Location = new System.Drawing.Point(7, 26);
            this.rbBinara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbBinara.Name = "rbBinara";
            this.rbBinara.Size = new System.Drawing.Size(79, 24);
            this.rbBinara.TabIndex = 0;
            this.rbBinara.Text = "Binara";
            this.rbBinara.UseVisualStyleBackColor = true;
            // 
            // btnEval
            // 
            this.btnEval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEval.Location = new System.Drawing.Point(34, 100);
            this.btnEval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEval.Name = "btnEval";
            this.btnEval.Size = new System.Drawing.Size(152, 46);
            this.btnEval.TabIndex = 9;
            this.btnEval.Text = "Evaluare";
            this.btnEval.UseVisualStyleBackColor = true;
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // gbDistante
            // 
            this.gbDistante.Controls.Add(this.tbDistMax);
            this.gbDistante.Controls.Add(this.btnCalcDist);
            this.gbDistante.Controls.Add(this.lDistMax);
            this.gbDistante.Controls.Add(this.rbCosinus);
            this.gbDistante.Controls.Add(this.numOrdin);
            this.gbDistante.Controls.Add(this.rbMinkowski);
            this.gbDistante.Controls.Add(this.rbEuclid);
            this.gbDistante.Controls.Add(this.rbManhattan);
            this.gbDistante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDistante.Location = new System.Drawing.Point(633, 129);
            this.gbDistante.Margin = new System.Windows.Forms.Padding(4);
            this.gbDistante.Name = "gbDistante";
            this.gbDistante.Padding = new System.Windows.Forms.Padding(4);
            this.gbDistante.Size = new System.Drawing.Size(338, 225);
            this.gbDistante.TabIndex = 10;
            this.gbDistante.TabStop = false;
            this.gbDistante.Text = "Distanta";
            // 
            // btnCalcDist
            // 
            this.btnCalcDist.Location = new System.Drawing.Point(164, 75);
            this.btnCalcDist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcDist.Name = "btnCalcDist";
            this.btnCalcDist.Size = new System.Drawing.Size(120, 38);
            this.btnCalcDist.TabIndex = 6;
            this.btnCalcDist.Text = "Calculeaza ";
            this.btnCalcDist.UseVisualStyleBackColor = true;
            this.btnCalcDist.Click += new System.EventHandler(this.btnCalcDist_Click);
            // 
            // rbCosinus
            // 
            this.rbCosinus.AutoSize = true;
            this.rbCosinus.Location = new System.Drawing.Point(19, 143);
            this.rbCosinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCosinus.Name = "rbCosinus";
            this.rbCosinus.Size = new System.Drawing.Size(91, 24);
            this.rbCosinus.TabIndex = 5;
            this.rbCosinus.Text = "Cosinus";
            this.rbCosinus.UseVisualStyleBackColor = true;
            // 
            // numOrdin
            // 
            this.numOrdin.Location = new System.Drawing.Point(67, 111);
            this.numOrdin.Margin = new System.Windows.Forms.Padding(4);
            this.numOrdin.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numOrdin.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numOrdin.Name = "numOrdin";
            this.numOrdin.Size = new System.Drawing.Size(69, 26);
            this.numOrdin.TabIndex = 4;
            this.numOrdin.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // rbMinkowski
            // 
            this.rbMinkowski.AutoSize = true;
            this.rbMinkowski.Location = new System.Drawing.Point(19, 84);
            this.rbMinkowski.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbMinkowski.Name = "rbMinkowski";
            this.rbMinkowski.Size = new System.Drawing.Size(107, 24);
            this.rbMinkowski.TabIndex = 3;
            this.rbMinkowski.Text = "Minkowski";
            this.rbMinkowski.UseVisualStyleBackColor = true;
            // 
            // rbEuclid
            // 
            this.rbEuclid.AutoSize = true;
            this.rbEuclid.Location = new System.Drawing.Point(20, 54);
            this.rbEuclid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbEuclid.Name = "rbEuclid";
            this.rbEuclid.Size = new System.Drawing.Size(107, 24);
            this.rbEuclid.TabIndex = 2;
            this.rbEuclid.Text = "Euclidiana";
            this.rbEuclid.UseVisualStyleBackColor = true;
            // 
            // rbManhattan
            // 
            this.rbManhattan.AutoSize = true;
            this.rbManhattan.Checked = true;
            this.rbManhattan.Location = new System.Drawing.Point(20, 25);
            this.rbManhattan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbManhattan.Name = "rbManhattan";
            this.rbManhattan.Size = new System.Drawing.Size(108, 24);
            this.rbManhattan.TabIndex = 1;
            this.rbManhattan.TabStop = true;
            this.rbManhattan.Text = "Manhattan";
            this.rbManhattan.UseVisualStyleBackColor = true;
            // 
            // btnGenFile
            // 
            this.btnGenFile.Location = new System.Drawing.Point(1110, 43);
            this.btnGenFile.Name = "btnGenFile";
            this.btnGenFile.Size = new System.Drawing.Size(123, 81);
            this.btnGenFile.TabIndex = 11;
            this.btnGenFile.Text = "Generare fisier distante";
            this.btnGenFile.UseVisualStyleBackColor = true;
            this.btnGenFile.Click += new System.EventHandler(this.btnGenFile_Click);
            // 
            // gbEvaluare
            // 
            this.gbEvaluare.Controls.Add(this.btnGenerareExcel);
            this.gbEvaluare.Controls.Add(this.btnCorespondenta);
            this.gbEvaluare.Controls.Add(this.btnEval);
            this.gbEvaluare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvaluare.Location = new System.Drawing.Point(1296, 43);
            this.gbEvaluare.Name = "gbEvaluare";
            this.gbEvaluare.Size = new System.Drawing.Size(226, 229);
            this.gbEvaluare.TabIndex = 12;
            this.gbEvaluare.TabStop = false;
            this.gbEvaluare.Text = "Evaluare Algoritm";
            // 
            // btnGenerareExcel
            // 
            this.btnGenerareExcel.Location = new System.Drawing.Point(19, 166);
            this.btnGenerareExcel.Name = "btnGenerareExcel";
            this.btnGenerareExcel.Size = new System.Drawing.Size(187, 43);
            this.btnGenerareExcel.TabIndex = 11;
            this.btnGenerareExcel.Text = "Generare Excel";
            this.btnGenerareExcel.UseVisualStyleBackColor = true;
            this.btnGenerareExcel.Click += new System.EventHandler(this.btnGenerareExcel_Click);
            // 
            // btnCorespondenta
            // 
            this.btnCorespondenta.Location = new System.Drawing.Point(34, 35);
            this.btnCorespondenta.Name = "btnCorespondenta";
            this.btnCorespondenta.Size = new System.Drawing.Size(152, 46);
            this.btnCorespondenta.TabIndex = 10;
            this.btnCorespondenta.Text = "Corespondenta";
            this.btnCorespondenta.UseVisualStyleBackColor = true;
            this.btnCorespondenta.Click += new System.EventHandler(this.btnCorespondenta_Click);
            // 
            // fPrincipala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 603);
            this.Controls.Add(this.gbEvaluare);
            this.Controls.Add(this.btnGenFile);
            this.Controls.Add(this.gbDistante);
            this.Controls.Add(this.gbNormalizare);
            this.Controls.Add(this.gbAlgoritmi);
            this.Controls.Add(this.gbLoadData);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panelDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1600, 650);
            this.MinimumSize = new System.Drawing.Size(1149, 637);
            this.Name = "fPrincipala";
            this.Text = "Clustering";
            this.gbDBSCAN.ResumeLayout(false);
            this.gbDBSCAN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).EndInit();
            this.gbLoadData.ResumeLayout(false);
            this.gbAlgoritmi.ResumeLayout(false);
            this.gbHAC.ResumeLayout(false);
            this.gbHAC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpPreagHac)).EndInit();
            this.gbTipSimilaritate.ResumeLayout(false);
            this.gbTipSimilaritate.PerformLayout();
            this.gbNormalizare.ResumeLayout(false);
            this.gbNormalizare.PerformLayout();
            this.gbDistante.ResumeLayout(false);
            this.gbDistante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrdin)).EndInit();
            this.gbEvaluare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLoad2DFile;
        private System.Windows.Forms.Button btnLoadNDFile;
        private System.Windows.Forms.Button btnDBSCAN;
        private System.Windows.Forms.GroupBox gbDBSCAN;
        private System.Windows.Forms.Button btnZgomot;
        private System.Windows.Forms.GroupBox gbLoadData;
        private System.Windows.Forms.GroupBox gbAlgoritmi;
        private System.Windows.Forms.GroupBox gbNormalizare;
        private System.Windows.Forms.RadioButton rbBinara;
        private System.Windows.Forms.RadioButton rbSuma;
        private System.Windows.Forms.RadioButton rbNominala;
        private System.Windows.Forms.RadioButton rbCornelSmart;
        private System.Windows.Forms.RadioButton rbMaxMin;
        private System.Windows.Forms.Button btnNormalizare;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.NumericUpDown numEps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMinPoints;
        private System.Windows.Forms.GroupBox gbDistante;
        private System.Windows.Forms.RadioButton rbManhattan;
        private System.Windows.Forms.RadioButton rbMinkowski;
        private System.Windows.Forms.RadioButton rbEuclid;
        private System.Windows.Forms.NumericUpDown numOrdin;
        private System.Windows.Forms.RadioButton rbCosinus;
        private System.Windows.Forms.Button btnCalcDist;
        private System.Windows.Forms.Button btnGenFile;
        private System.Windows.Forms.Label lProcent;
        private System.Windows.Forms.TextBox tbDistMax;
        private System.Windows.Forms.Label lDistMax;
        private System.Windows.Forms.GroupBox gbEvaluare;
        private System.Windows.Forms.Button btnCorespondenta;
        private System.Windows.Forms.Button btnGenerareExcel;
        private System.Windows.Forms.GroupBox gbHAC;
        private System.Windows.Forms.RadioButton rbCompleteLink;
        private System.Windows.Forms.RadioButton rbSingleLink;
        private System.Windows.Forms.Button btnHAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpPreagHac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbTipSimilaritate;
    }
}

