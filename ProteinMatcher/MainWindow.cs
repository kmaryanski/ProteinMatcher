using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;
using System.IO;


namespace ProteinMatcher
{
    public partial class MainWindow : Form
    {
        private String blast_path_value;                //scieaka do BLASTp.exe
        private String blast_dir;                       //katalog blast
        private String pdb_path_value;                  //sciezka do bazy
        private String db_name;                         //nazwa wygenerowanej bazy BLASTa
        private String blast_result_path_value;         //ściezka i plik zapisu wyjscia blasta
        private List<String> genes=new List<String>();  //lista plikow do porownania
        private String genes_dir;                       //ścieżka katalogu sekwencji

        public MainWindow()
        {
            InitializeComponent();
            ProgressBar1.AutoSize = false;
            ProgressBar1.Width = statusStrip1.Width - 20;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            check_config_file();
        }

        private void check_config_file()
        {
            try
            {
                using (StreamReader sr = new StreamReader("BLAST_path.ini"))
                {
                    String line = sr.ReadToEnd();
                    blast_dir = line;
                    blast_path.Text=line+"\\blastp.exe";
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                //nie ma potrzeby nic tu robić
            }
            
        }   //sprawdzenie obecności pliku konfiguracyjnego 

        private void statusStrip1_Resize(object sender, EventArgs e) //zmiana rozmiaru progressbar
        {
            ProgressBar1.AutoSize = false;
            ProgressBar1.Width = statusStrip1.Width - 20;
        }

        private void all_set_check() //sprawdzenie czy wszystkie wymagane dane są wprowadzone
        {
            if (blast_path.Text.Contains("blastp.exe") && pdb_path.Text != "" && genes_list.Items.Count > 0 && result_path_blast.Text != "")
            {
                button_start.Enabled = true;
            }
            else
            {
                button_start.Enabled = false;
            }
        }

        private void button_start_Click(object sender, EventArgs e) //start przeszukiwania
        {
            button_browse_blast.Enabled = false;
            button_browse_genes.Enabled = false;
            button_browse_output_path.Enabled = false;
            button_browse_pdb.Enabled = false;
            button_cancel.Enabled = true;
            button_start.Enabled = false;
            genes_list.Enabled = false;
            genes_clear.Enabled = false;

            ProgressBar1.Style = ProgressBarStyle.Marquee;
            ProgressBar1.MarqueeAnimationSpeed = 30;
            //wywolanie bgworker
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e) //anulowanie przeszukiwania
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void button_browse_genes_Click(object sender, EventArgs e) //wczytanie sekwencji genowych
        {
            genes_openFileDialog.Filter = "Pliki tekstowe (.txt)|*.txt|Pliki FASTA (.faa)|*.faa|Wszystkie pliki (*.*)|*.*";
            genes_openFileDialog.FilterIndex = 2;
            if (genes_openFileDialog.ShowDialog() == DialogResult.OK)
            {                
                foreach (String name in genes_openFileDialog.FileNames)
                {
                   genes.Add(name);
                   genes_dir = Path.GetDirectoryName(name);
                }
                foreach (String name in genes_openFileDialog.SafeFileNames)
                {
                   genes_list.Items.Add(name);
                }
                genes_list.SetSelected(0, true);
            }
            
            all_set_check();
        }

        private void button_browse_output_path_Click(object sender, EventArgs e) //wskazanie pliku do zapisu wyników
        {
            blast_saveFileDialog1.Filter = "Pliki tekstowe (.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            if (blast_saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                result_path_blast.Text = blast_saveFileDialog1.FileName;
                blast_result_path_value = blast_saveFileDialog1.FileName;
            }

            all_set_check();
        }

        private void button_browse_blast_Click(object sender, EventArgs e) //wskazanie ścieżki programu BLAST
        {
            blast_openFileDialog.Filter = "Pliki programów (.exe)|*.exe|Wszystkie pliki (*.*)|*.*";
            if (blast_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                blast_path.Text = blast_openFileDialog.FileName;
                blast_path_value =blast_openFileDialog.FileName;
                blast_dir = Path.GetDirectoryName(blast_path_value);
            }
            using (StreamWriter outfile = new StreamWriter("BLAST_path.ini"))
            {
                outfile.Write(blast_dir);
            }
            all_set_check();
        }

        private void button_browse_pdb_Click(object sender, EventArgs e) //wskazanie pliku bazy białek
        {
            pdb_openFileDialog.Filter = "Pliki tekstowe (.txt)|*.txt|Pliki FASTA (.faa)|*.faa|Wszystkie pliki (*.*)|*.*";
            pdb_openFileDialog.FilterIndex = 2;
            if (pdb_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pdb_path.Text = pdb_openFileDialog.FileName;
                pdb_path_value = pdb_openFileDialog.FileName;
                db_name = Path.GetDirectoryName(pdb_path_value)+"\\"+Path.GetFileNameWithoutExtension(pdb_path_value);
            }
            if(pdb_path.Text.Contains(' '))
            {
                pdb_path.Clear();
                pdb_path_value = "";
                db_name = "";
                MessageBox.Show("Ścieżka dostępu do bazy danych nie może zawierać spacji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            all_set_check();
        } 
        
        private void genes_clear_Click(object sender, EventArgs e) //czyszczenie listy sekwencji genowych
        {
            genes_list.Items.Clear();
            all_set_check();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) //wykonanie przeszukiwania
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            richTextBox1.Clear();
            richTextBox1.Text += "Rozpoczęto generowanie bazy.\n";

            System.Diagnostics.Process p = new System.Diagnostics.Process();

            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            //Generowanie bazy BLAST

            //makeblastdb -in human.protein.faa -out pdb1 -dbtype prot -hash_index
            String db_arguments = "-in " + pdb_path_value + " -out " +  db_name + " -dbtype prot -hash_index";
            System.Diagnostics.ProcessStartInfo dbcreate_process_info =
                new System.Diagnostics.ProcessStartInfo(blast_dir+"\\makeblastdb.exe", db_arguments);
            dbcreate_process_info.RedirectStandardOutput = true;
            dbcreate_process_info.RedirectStandardError = true;
            dbcreate_process_info.UseShellExecute = false;
            dbcreate_process_info.CreateNoWindow = true;

            p.StartInfo = dbcreate_process_info;
            p.Start();
            p.WaitForExit();
            string db_create_results = p.StandardOutput.ReadToEnd();
            string db_create_errors = p.StandardError.ReadToEnd();
            if (db_create_errors != "")
            {
                richTextBox1.Text += "Błąd, baza nie została wygenerowana.\n" + db_create_errors;
                return;
            }
            richTextBox1.Text += "Baza została wygenerowana pomyślnie.\n";
            //koniec generowania bazy

            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }

            //Wyszukiwanie pasujacych bialek
            richTextBox1.Text += "Rozpoczęto przeszukiwanie bazy.\n";
            Object selected_item=genes_list.SelectedItem;
            String selected_item_string=selected_item as String;
            String query_file = genes_dir + "\\" + selected_item_string;//"c:\\bio\\query_faa.txt";

            String blast_arguments = "-query " + "\"" + query_file + "\"" + " " + "-db " + db_name + 
                                    " -out " + "\"" + blast_result_path_value + "\"";
            //MessageBox.Show(blast_arguments);
            System.Diagnostics.ProcessStartInfo search_process_info =
                new System.Diagnostics.ProcessStartInfo(blast_dir+"\\blastp.exe", blast_arguments);
            search_process_info.RedirectStandardOutput = true;
            search_process_info.RedirectStandardError = true;

            search_process_info.UseShellExecute = false;
            search_process_info.CreateNoWindow = true;
            
            p.StartInfo = search_process_info;
            p.Start();
            p.WaitForExit();

            string search_process_output = p.StandardOutput.ReadToEnd();
            string search_process_errors = p.StandardError.ReadToEnd();
            if (search_process_errors != "")
            {
                richTextBox1.Text += "Błąd. Wyszukiwanie nie zostało wykonane. \n" + search_process_errors;
                return;
            }
            richTextBox1.Clear();
            richTextBox1.Text += "Przeszukiwanie zakończone.\n Wyniki zapisano do pliku: \n "+
                                    blast_result_path_value+"\n";
            //koniec wyszukiwania
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) //progressbar
        {
            ProgressBar1.Value += 20;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //wykonane po zakończeniu przeszukiwania
        {
            if ((e.Cancelled == true))
            {
                ProgressBar1.Style = ProgressBarStyle.Continuous;
                ProgressBar1.MarqueeAnimationSpeed = 0;
                richTextBox1.Text += "\n\nPrzerwano na życzenie użytkownika.";
                MessageBox.Show("Przerwano na życzenie użytkownika", "Anulowanie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!(e.Error == null))
            {
                ProgressBar1.Style = ProgressBarStyle.Continuous;
                ProgressBar1.MarqueeAnimationSpeed = 0;
                richTextBox1.Text += "\n\nPrzerwano z powodu błędu.";
                MessageBox.Show("Przerwano z powodu błędu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ProgressBar1.Style = ProgressBarStyle.Continuous;
                ProgressBar1.MarqueeAnimationSpeed = 0;
                richTextBox1.Text += "\nWyniki przeszukiwania:\n";
                display_results();
            }
            
                button_browse_blast.Enabled = true;
                button_browse_genes.Enabled = true;
                button_browse_output_path.Enabled = true;
                button_browse_pdb.Enabled = true;
                button_cancel.Enabled = false;
                button_start.Enabled = true;
                genes_list.Enabled = true;
                genes_clear.Enabled = true;
        }

        private void display_results() //wyświetlenie wyników przeszukiwania
        {
            List<string> lines = new List<string>();
            //otwarcie pliku
            try
            {
                using (StreamReader sr = new StreamReader(blast_result_path_value))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nie znaleziono pliku z wynikami\n." + blast_result_path_value, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //wyswietlenie wynikow
            int count = 0;
            int g = 0;
            int l = 0;
            int s = 0;
            int i = 0;
            int line_number=0;
            Boolean display = false;

            foreach (string line in lines)
            {
                
                if (count >= 15 && line.Trim().StartsWith("> gi"))
                {
                    break;
                }
                //opcja 1 (z literami)

                if (line.Trim().StartsWith("> gi"))
                {
                    display = true;
                    richTextBox1.Text += "\n------------------------------------------------------------------------------\n";
                    count++;
                    //MessageBox.Show(lines[line_number + 5].Contains("Identities").ToString());
                    //MessageBox.Show((find_score(lines[line_number + 5])>95).ToString());
                    if (lines[line_number + 5].Contains("Identities") == true)
                    {
                        if ((find_score(lines[line_number + 5]) < 80) == true)
                        {
                            display = false;
                            return;
                        }
                    }
                    if (lines[line_number + 4].Contains("Identities") == true)
                    {
                        if ((find_score(lines[line_number + 4]) < 80) == true)
                        {
                            display = false;
                            return;
                        }
                    }
                }
                if (display == true)
                {
                    richTextBox1.Text += line + "\n";
                }
                //koniec opcji 1

                ////opcja 2 (same wyniki)
                //if (line.Trim().StartsWith("> gi"))
                //{
                //    display = true;
                //    richTextBox1.Text += "\n------------------------------------------------------------------------------\n";
                //    count++;
                //    //MessageBox.Show(lines[line_number + 5].Contains("Identities").ToString());
                //    //MessageBox.Show((find_score(lines[line_number + 5])>95).ToString());
                //    if (lines[line_number + 5].Contains("Identities") == true)
                //    {
                //        if ((find_score(lines[line_number + 5]) < 80) == true)
                //        {
                //            display = false;
                //            return;
                //        }
                //    }
                //    if (lines[line_number + 4].Contains("Identities") == true)
                //    {
                //        if ((find_score(lines[line_number + 4]) < 80) == true)
                //        {
                //            display = false;
                //            return;
                //        }
                //    }
                //}
                //if (display == true && (line.Trim().StartsWith("> gi") || line.Trim().StartsWith("Length") || line.Trim().StartsWith("Score") || line.Trim().StartsWith("Identities")))
                //{
                //    richTextBox1.Text += line + "\n";
                //}
                ////koniec opcji 2
                line_number++;
            }
        }

        private int find_score(String line) //znalezienie stopnia dopasowania w wyniku
        {
            int score = 0;
            int start = line.IndexOf('(');
            int stop = line.IndexOf('%');
            int length = stop-start-1;
            string score_txt=line.Substring(start+1, length);
            score = Convert.ToInt32(score_txt);
            //MessageBox.Show(score_txt);
            //znajdz dopasowanie w linii
            return score;
        }


    }
}
