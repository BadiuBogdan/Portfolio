
namespace Chat
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
            this.tbConnect = new System.Windows.Forms.TextBox();
            this.tbAfisareMesaj = new System.Windows.Forms.TextBox();
            this.tbScrieMesaj = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnTrimite = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clientList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConnect
            // 
            this.tbConnect.Location = new System.Drawing.Point(284, 15);
            this.tbConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbConnect.Multiline = true;
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(548, 29);
            this.tbConnect.TabIndex = 0;
            this.tbConnect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbConnect_KeyDown_1);
            // 
            // tbAfisareMesaj
            // 
            this.tbAfisareMesaj.Location = new System.Drawing.Point(284, 52);
            this.tbAfisareMesaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAfisareMesaj.Multiline = true;
            this.tbAfisareMesaj.Name = "tbAfisareMesaj";
            this.tbAfisareMesaj.ReadOnly = true;
            this.tbAfisareMesaj.Size = new System.Drawing.Size(697, 397);
            this.tbAfisareMesaj.TabIndex = 0;
            // 
            // tbScrieMesaj
            // 
            this.tbScrieMesaj.Location = new System.Drawing.Point(284, 457);
            this.tbScrieMesaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbScrieMesaj.Multiline = true;
            this.tbScrieMesaj.Name = "tbScrieMesaj";
            this.tbScrieMesaj.Size = new System.Drawing.Size(548, 29);
            this.tbScrieMesaj.TabIndex = 0;
            this.tbScrieMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScrieMesaj_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(841, 15);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 28);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Conectare";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnTrimite
            // 
            this.btnTrimite.Location = new System.Drawing.Point(841, 458);
            this.btnTrimite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTrimite.Name = "btnTrimite";
            this.btnTrimite.Size = new System.Drawing.Size(141, 28);
            this.btnTrimite.TabIndex = 1;
            this.btnTrimite.Text = "Trimite";
            this.btnTrimite.UseVisualStyleBackColor = true;
            this.btnTrimite.Click += new System.EventHandler(this.btnTrimite_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientList});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(265, 437);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // clientList
            // 
            this.clientList.HeaderText = "Participanti";
            this.clientList.MinimumWidth = 6;
            this.clientList.Name = "clientList";
            this.clientList.Width = 145;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(12, 461);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(91, 25);
            this.lName.TabIndex = 3;
            this.lName.Text = "You are: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 500);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTrimite);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbAfisareMesaj);
            this.Controls.Add(this.tbScrieMesaj);
            this.Controls.Add(this.tbConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1017, 547);
            this.MinimumSize = new System.Drawing.Size(1017, 547);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConnect;
        private System.Windows.Forms.TextBox tbAfisareMesaj;
        private System.Windows.Forms.TextBox tbScrieMesaj;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnTrimite;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientList;
        private System.Windows.Forms.Label lName;
    }
}

