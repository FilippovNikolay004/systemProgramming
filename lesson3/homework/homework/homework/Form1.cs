using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework {
    public partial class Form1 :Form {
        private bool _stopSearch = false;

        public Form1() {
            InitializeComponent();

            listView1.Columns.Add("Имя", 150);
            listView1.Columns.Add("Папка", 250);
            listView1.Columns.Add("Размер", 100);
            listView1.Columns.Add("Дата модификации", 150);

            button2_stop.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e) {
            // Путь
            string directory = @"C:\";

            // Маска поиска (*, ?)
            string searchPattern = textBox1.Text;

            button1_start.Enabled = false;
            button2_stop.Enabled = true;
            listView1.Items.Clear();

            await SearchFilesAndDirectoriesAsync(directory, searchPattern);

            button1_start.Enabled = true;
            button2_stop.Enabled = false;

            MessageBox.Show("Поиск завершён");
        }

        private async Task SearchFilesAndDirectoriesAsync(string directory, string searchPattern) {
            await Task.Run(() => {
                try {
                    // Поиск файлов
                    var files = Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories);
                    foreach (var file in files) {
                        // Проверяем флаг остановки
                        if (_stopSearch) return;

                        FileInfo fileInfo = new FileInfo(file);
                        AddItemViewList(fileInfo.Name, fileInfo.DirectoryName, fileInfo.Length.ToString(), fileInfo.LastWriteTime.ToString());
                    }

                    // Поиск папок
                    var directories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
                    foreach (var dir in directories) { 
                        // Проверяем флаг остановки
                        if (_stopSearch) return; 

                        DirectoryInfo dirInfo = new DirectoryInfo(dir);
                        AddItemViewList(dirInfo.Name, dirInfo.Parent?.FullName ?? dirInfo.FullName, "—", dirInfo.LastWriteTime.ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void AddItemViewList(string name, string folder, string size, string lastWriteTime) {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(name);
            item.SubItems.Add(folder);
            item.SubItems.Add(size);
            item.SubItems.Add(lastWriteTime);

            listView1.Items.Add(item);
        }

        private void button2_stop_Click(object sender, EventArgs e) {
            _stopSearch = true;
        }
    }
}
