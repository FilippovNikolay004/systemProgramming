using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace homework {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();

            updateListProcess();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e) {
            string nameProcess = textBox1.Text.Trim();

            try {
                Process newProcess = Process.Start(nameProcess);

                Thread.Sleep(100 * 10);
                updateListProcess();

                textBox1.Text = "";
            }
            catch {
                MessageBox.Show("Ошибка при запуске процесса: " + nameProcess);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (listBox1.SelectedItem != null) {
                string selectedItem = listBox1.SelectedItem.ToString()??"";
                int pidToKill = int.Parse(Regex.Match(selectedItem, @"\d+").Value);

                Process processToKill = Process.GetProcessById(pidToKill);
                processToKill.Kill();
                processToKill.WaitForExit();

                updateListProcess();
            }
        }

        private void updateListProcess() {
            listBox1.Items.Clear();

            Process[] processes = Process.GetProcesses();

            //для каждого процесса выводим имя и PID
            foreach (Process p in processes) {
                string tempText = $"{p.ProcessName}\t{p.Id}";
                listBox1.Items.Add(tempText);
            }
        }
        private void listBox1_SelectedIndexChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
        }
    }
}