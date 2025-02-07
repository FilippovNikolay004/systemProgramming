using static System.Net.Mime.MediaTypeNames;

namespace homework {
    public partial class Form1 :Form {
        // Делегат для копирования файла
        private delegate void CopyFileDelegate(string sourcePath, string destinationPath);

        // Делегат для обновления прогресса
        private delegate void UpdateProgressDelegate(int progress);

        public Form1() {
            InitializeComponent();
        }

        // Обработчик для кнопки "Файл" (выбор исходного файла)
        private void button1_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        // Обработчик для кнопки "Файл" (выбор директории назначения)
        private void button2_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()) {
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    textBox2.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void CopyFile(string sourcePath, string destinationPath) {
            const int bufferSize = 4096;

            FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            FileStream destinationStream = new FileStream(destinationPath + Path.GetFileName(sourcePath), FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[bufferSize];
            int totalBytes = (int)sourceStream.Length;
            int bytesCopied = 0;
            int bytesRead = sourceStream.Read(buffer, 0, buffer.Length);

            while (bytesRead > 0) {
                destinationStream.Write(buffer, 0, bytesRead);
                bytesCopied += bytesRead;
                Invoke(UpdateProgress, 
                    (bytesCopied * 100) / totalBytes);
            }

            sourceStream.Close();
            destinationStream.Close();

            // Вызываем метод после завершения копирования
            Invoke(new Action(OnCopyComplete));
        }

        private void UpdateProgress(int progress) {
            progressBar1.Value = progress;
        }

        private void button3_Click(object sender, EventArgs e) {
            string sourcePath = textBox1.Text.Trim();
            string destinationPath = textBox2.Text.Trim();

            if (sourcePath.Length != 0 || destinationPath.Length != 0) {
                progressBar1.Value = 0;
                button3.Enabled = false;

                // Создаем новый поток для копирования
                Thread copyThread = new Thread(() => CopyFile(sourcePath, destinationPath));
                copyThread.Start();
            } else {
                MessageBox.Show("Убедитесь, что исходный файл существует и путь назначения корректен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCopyComplete() {
            button3.Enabled = true; // Включаем кнопку копирования после завершения
            MessageBox.Show("Копирование завершено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}