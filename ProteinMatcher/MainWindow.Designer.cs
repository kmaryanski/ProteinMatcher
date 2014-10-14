namespace ProteinMatcher
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.genes_clear = new System.Windows.Forms.Button();
            this.button_browse_genes = new System.Windows.Forms.Button();
            this.genes_list = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_browse_blast = new System.Windows.Forms.Button();
            this.blast_path = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_browse_pdb = new System.Windows.Forms.Button();
            this.pdb_path = new System.Windows.Forms.TextBox();
            this.blast_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pdb_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.genes_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_browse_output_path = new System.Windows.Forms.Button();
            this.result_path_blast = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.blast_saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.genes_clear);
            this.groupBox1.Controls.Add(this.button_browse_genes);
            this.groupBox1.Controls.Add(this.genes_list);
            this.groupBox1.Location = new System.Drawing.Point(13, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sekwencje genowe";
            // 
            // genes_clear
            // 
            this.genes_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.genes_clear.Location = new System.Drawing.Point(113, 111);
            this.genes_clear.Name = "genes_clear";
            this.genes_clear.Size = new System.Drawing.Size(99, 23);
            this.genes_clear.TabIndex = 2;
            this.genes_clear.Text = "Wyczyść";
            this.genes_clear.UseVisualStyleBackColor = true;
            this.genes_clear.Click += new System.EventHandler(this.genes_clear_Click);
            // 
            // button_browse_genes
            // 
            this.button_browse_genes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_browse_genes.Location = new System.Drawing.Point(7, 111);
            this.button_browse_genes.Name = "button_browse_genes";
            this.button_browse_genes.Size = new System.Drawing.Size(100, 23);
            this.button_browse_genes.TabIndex = 1;
            this.button_browse_genes.Text = "Przeglądaj";
            this.button_browse_genes.UseVisualStyleBackColor = true;
            this.button_browse_genes.Click += new System.EventHandler(this.button_browse_genes_Click);
            // 
            // genes_list
            // 
            this.genes_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.genes_list.FormattingEnabled = true;
            this.genes_list.Location = new System.Drawing.Point(7, 20);
            this.genes_list.Name = "genes_list";
            this.genes_list.Size = new System.Drawing.Size(206, 82);
            this.genes_list.Sorted = true;
            this.genes_list.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_browse_blast);
            this.groupBox2.Controls.Add(this.blast_path);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ścieżka BLAST (blastp.exe)";
            // 
            // button_browse_blast
            // 
            this.button_browse_blast.Location = new System.Drawing.Point(6, 47);
            this.button_browse_blast.Name = "button_browse_blast";
            this.button_browse_blast.Size = new System.Drawing.Size(207, 23);
            this.button_browse_blast.TabIndex = 1;
            this.button_browse_blast.Text = "Przeglądaj";
            this.button_browse_blast.UseVisualStyleBackColor = true;
            this.button_browse_blast.Click += new System.EventHandler(this.button_browse_blast_Click);
            // 
            // blast_path
            // 
            this.blast_path.Location = new System.Drawing.Point(7, 20);
            this.blast_path.Name = "blast_path";
            this.blast_path.ReadOnly = true;
            this.blast_path.Size = new System.Drawing.Size(206, 20);
            this.blast_path.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.button_browse_pdb);
            this.groupBox3.Controls.Add(this.pdb_path);
            this.groupBox3.Location = new System.Drawing.Point(13, 326);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Baza PDB";
            // 
            // button_browse_pdb
            // 
            this.button_browse_pdb.Location = new System.Drawing.Point(6, 46);
            this.button_browse_pdb.Name = "button_browse_pdb";
            this.button_browse_pdb.Size = new System.Drawing.Size(207, 23);
            this.button_browse_pdb.TabIndex = 1;
            this.button_browse_pdb.Text = "Przeglądaj";
            this.button_browse_pdb.UseVisualStyleBackColor = true;
            this.button_browse_pdb.Click += new System.EventHandler(this.button_browse_pdb_Click);
            // 
            // pdb_path
            // 
            this.pdb_path.Location = new System.Drawing.Point(6, 19);
            this.pdb_path.Name = "pdb_path";
            this.pdb_path.ReadOnly = true;
            this.pdb_path.Size = new System.Drawing.Size(207, 20);
            this.pdb_path.TabIndex = 0;
            // 
            // genes_openFileDialog
            // 
            this.genes_openFileDialog.Multiselect = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Resize += new System.EventHandler(this.statusStrip1_Resize);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_browse_output_path);
            this.groupBox4.Controls.Add(this.result_path_blast);
            this.groupBox4.Location = new System.Drawing.Point(13, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 76);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ścieżka zapisu wyników";
            // 
            // button_browse_output_path
            // 
            this.button_browse_output_path.Location = new System.Drawing.Point(7, 47);
            this.button_browse_output_path.Name = "button_browse_output_path";
            this.button_browse_output_path.Size = new System.Drawing.Size(206, 23);
            this.button_browse_output_path.TabIndex = 1;
            this.button_browse_output_path.Text = "Przeglądaj";
            this.button_browse_output_path.UseVisualStyleBackColor = true;
            this.button_browse_output_path.Click += new System.EventHandler(this.button_browse_output_path_Click);
            // 
            // result_path_blast
            // 
            this.result_path_blast.Location = new System.Drawing.Point(7, 20);
            this.result_path_blast.Name = "result_path_blast";
            this.result_path_blast.ReadOnly = true;
            this.result_path_blast.Size = new System.Drawing.Size(206, 20);
            this.result_path_blast.TabIndex = 0;
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_start.Enabled = false;
            this.button_start.Location = new System.Drawing.Point(13, 409);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(219, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_cancel.Enabled = false;
            this.button_cancel.Location = new System.Drawing.Point(13, 439);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(219, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Anuluj";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // blast_saveFileDialog1
            // 
            this.blast_saveFileDialog1.FileName = "match_results.txt";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox1.Location = new System.Drawing.Point(238, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(654, 450);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 491);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 530);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Protein Matcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog blast_openFileDialog;
        private System.Windows.Forms.OpenFileDialog pdb_openFileDialog;
        private System.Windows.Forms.OpenFileDialog genes_openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button_browse_blast;
        private System.Windows.Forms.TextBox blast_path;
        private System.Windows.Forms.TextBox pdb_path;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.Button button_browse_genes;
        private System.Windows.Forms.ListBox genes_list;
        private System.Windows.Forms.Button button_browse_pdb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_browse_output_path;
        private System.Windows.Forms.TextBox result_path_blast;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.SaveFileDialog blast_saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button genes_clear;
    }
}

