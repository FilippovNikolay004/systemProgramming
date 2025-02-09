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

            listView1.Columns.Add("���", 150);
            listView1.Columns.Add("�����", 250);
            listView1.Columns.Add("������", 100);
            listView1.Columns.Add("���� �����������", 150);

            button2_stop.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e) {
            // ����
            string directory = @"C:\";

            // ����� ������ (*, ?)
            string searchPattern = textBox1.Text;

            button1_start.Enabled = false;
            button2_stop.Enabled = true;
            listView1.Items.Clear();

            await SearchFilesAndDirectoriesAsync(directory, searchPattern);

            button1_start.Enabled = true;
            button2_stop.Enabled = false;

            MessageBox.Show("����� ��������");
        }

        private async Task SearchFilesAndDirectoriesAsync(string directory, string searchPattern) {
            await Task.Run(() => {
                try {
                    // ����� ������
                    var files = Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories);
                    foreach (var file in files) {
                        // ��������� ���� ���������
                        if (_stopSearch) return;

                        FileInfo fileInfo = new FileInfo(file);
                        AddItemViewList(fileInfo.Name, fileInfo.DirectoryName, fileInfo.Length.ToString(), fileInfo.LastWriteTime.ToString());
                    }

                    // ����� �����
                    var directories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
                    foreach (var dir in directories) { 
                        // ��������� ���� ���������
                        if (_stopSearch) return; 

                        DirectoryInfo dirInfo = new DirectoryInfo(dir);
                        AddItemViewList(dirInfo.Name, dirInfo.Parent?.FullName ?? dirInfo.FullName, "�", dirInfo.LastWriteTime.ToString());
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
