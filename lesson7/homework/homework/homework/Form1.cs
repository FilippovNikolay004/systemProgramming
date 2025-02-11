using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace homework {
    public partial class Form1 :Form {
        // Делегат для копирования файла
        private delegate void CopyFileDelegate(string sourcePath, string destinationPath);

        // Делегат для обновления прогресса
        private delegate void UpdateProgressDelegate(int progress);

        private CancellationTokenSource cancellationTokenSource;
        private int totalBytesCopied = 0;

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


        private async Task CopyFileAsync(string sourcePath, string destinationPath, CancellationToken cancellationToken) {
            const int bufferSize = 4096;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
            using (FileStream destinationStream = new FileStream(destinationPath + Path.GetFileName(sourcePath), FileMode.Create, FileAccess.Write)) {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                    // Проверяем, не была ли отменена операция
                    cancellationToken.ThrowIfCancellationRequested();

                    await destinationStream.WriteAsync(buffer, 0, bytesRead);

                    totalBytesCopied += bytesRead;
                    Invoke(UpdateProgress, (totalBytesCopied * 100) / (int)sourceStream.Length);

                    Thread.Sleep(500);
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

            if (sourcePath.Length == 0 || destinationPath.Length == 0) {
                MessageBox.Show("Убедитесь, что исходный файл существует и путь назначения корректен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar1.Value = 0;

            button3.Enabled = false;
            button4.Enabled = true;

            // Создаем новый токен отмены
            cancellationTokenSource = new CancellationTokenSource();

            // Создаем новый поток для копирования
            Task.Factory.StartNew(() => CopyFileAsync(sourcePath, destinationPath, cancellationTokenSource.Token));
        }

        private void OnCopyComplete() {
            // Включаем кнопку копирования после завершения
            button3.Enabled = true;
            button4.Enabled = false;

            MessageBox.Show("Копирование завершено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e) {
            button3.Enabled = true;
            button4.Enabled = false;

            // Отменяем операцию копирования
            cancellationTokenSource?.Cancel();

            // Ожидаем завершения копирования, если оно было отменено
            MessageBox.Show($"Количество записанных байтов: {totalBytesCopied}", "Стоп", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}