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

        private async Task CopyFileAsync(string sourcePath, string destinationPath) {
            const int bufferSize = 4096;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
            using (FileStream destinationStream = new FileStream(destinationPath + Path.GetFileName(sourcePath), FileMode.Create, FileAccess.Write)) {
                byte[] buffer = new byte[bufferSize];
                int bytesCopied = 0;
                int bytesRead;

                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                    await destinationStream.WriteAsync(buffer, 0, bytesRead);

                    bytesCopied += bytesRead;
                    Invoke(UpdateProgress, (bytesCopied * 100) / (int)sourceStream.Length);
                }
            }

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
                Task.Run(() => CopyFileAsync(sourcePath, destinationPath));
            } else {
                MessageBox.Show("Убедитесь, что исходный файл существует и путь назначения корректен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCopyComplete() {
            // Включаем кнопку копирования после завершения
            button3.Enabled = true; 
            MessageBox.Show("Копирование завершено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}