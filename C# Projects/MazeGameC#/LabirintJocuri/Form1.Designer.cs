
namespace LabirintJocuri
{
    partial class Form1
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
            this.btnLoadMatrix = new System.Windows.Forms.Button();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnSolutie = new System.Windows.Forms.Button();
            this.pPrincipal = new System.Windows.Forms.Panel();
            this.lTitlu = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDFS = new System.Windows.Forms.Button();
            this.pPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadMatrix
            // 
            this.btnLoadMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMatrix.Location = new System.Drawing.Point(741, 40);
            this.btnLoadMatrix.Name = "btnLoadMatrix";
            this.btnLoadMatrix.Size = new System.Drawing.Size(119, 58);
            this.btnLoadMatrix.TabIndex = 1;
            this.btnLoadMatrix.Text = "Load matrix";
            this.btnLoadMatrix.UseVisualStyleBackColor = true;
            this.btnLoadMatrix.Click += new System.EventHandler(this.btnLoadMatrix_Click);
            // 
            // btnBFS
            // 
            this.btnBFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBFS.Location = new System.Drawing.Point(6, 26);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(119, 58);
            this.btnBFS.TabIndex = 2;
            this.btnBFS.Text = "  Rezolvare BFS";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnSolutie
            // 
            this.btnSolutie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolutie.Location = new System.Drawing.Point(741, 297);
            this.btnSolutie.Name = "btnSolutie";
            this.btnSolutie.Size = new System.Drawing.Size(119, 58);
            this.btnSolutie.TabIndex = 3;
            this.btnSolutie.Text = "Solutie";
            this.btnSolutie.UseVisualStyleBackColor = true;
            this.btnSolutie.Click += new System.EventHandler(this.btnSolutie_Click);
            // 
            // pPrincipal
            // 
            this.pPrincipal.Controls.Add(this.lTitlu);
            this.pPrincipal.Location = new System.Drawing.Point(12, 12);
            this.pPrincipal.Name = "pPrincipal";
            this.pPrincipal.Size = new System.Drawing.Size(639, 426);
            this.pPrincipal.TabIndex = 4;
            // 
            // lTitlu
            // 
            this.lTitlu.AutoSize = true;
            this.lTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitlu.Location = new System.Drawing.Point(240, 12);
            this.lTitlu.Name = "lTitlu";
            this.lTitlu.Size = new System.Drawing.Size(114, 36);
            this.lTitlu.TabIndex = 0;
            this.lTitlu.Text = "Labirint";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDFS);
            this.groupBox1.Controls.Add(this.btnBFS);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(669, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rezolvare";
            // 
            // btnDFS
            // 
            this.btnDFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDFS.Location = new System.Drawing.Point(131, 26);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(119, 58);
            this.btnDFS.TabIndex = 2;
            this.btnDFS.Text = "Rezolvare DFS";
            this.btnDFS.UseVisualStyleBackColor = true;
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pPrincipal);
            this.Controls.Add(this.btnSolutie);
            this.Controls.Add(this.btnLoadMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pPrincipal.ResumeLayout(false);
            this.pPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadMatrix;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnSolutie;
        private System.Windows.Forms.Panel pPrincipal;
        private System.Windows.Forms.Label lTitlu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDFS;
    }
}

