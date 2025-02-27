using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace examProject
{
    public partial class Form1 :Form {
        // Заменить
        private const string SourceFolderPath = @"D:\Step\3 course\systemProgramming\ExamProject\examProject\documents"; 
        private const string DestinationFolderPath = @"D:\Step\3 course\systemProgramming\ExamProject\examProject\filesWithProhibitedWords";
        private CancellationTokenSource cts;

        public Form1() {
            InitializeComponent();

            Directory.CreateDirectory(DestinationFolderPath);
        }

        private async void Start_Click(object sender, EventArgs e) {
            Start.Enabled = false;

            cts = new CancellationTokenSource();
            listBoxResults.Items.Clear();
            progressBar1.Value = 0;

            List<string> forbiddenWords = GetForbiddenWords();
            if (forbiddenWords.Count == 0) {
                MessageBox.Show("Введите запрещённые слова или загрузите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] files = Directory.GetFiles(SourceFolderPath, "*.txt");
            progressBar1.Maximum = files.Length;

            int totalReplacements = 0;
            Dictionary<string, int> fileReport = new();

            await Task.Run(async () => {
                foreach (var file in files) {
                    if (cts.Token.IsCancellationRequested)
                        break;

                    try {
                        string content = File.ReadAllText(file);
                        int replacements = 0;

                        foreach (string word in forbiddenWords) {
                            int count = (content.Length - content.Replace(word, "").Length) / word.Length;
                            if (count > 0) {
                                replacements += count;
                                content = content.Replace(word, "*******");
                            }
                        }

                        if (replacements > 0) {
                            string destFile = Path.Combine(DestinationFolderPath, Path.GetFileName(file));
                            File.WriteAllText(destFile, content);
                            fileReport[file] = replacements;
                            Interlocked.Add(ref totalReplacements, replacements);
                        }
                    }
                    catch (Exception ex) {
                        Invoke(new Action(() => listBoxResults.Items.Add($"Ошибка в файле {file}: {ex.Message}")));
                    }

                    Invoke(new Action(() => progressBar1.Value++));

                    // Задержка для возможности отмены
                    await Task.Delay(1000); 
                }
            }, cts.Token);

            listBoxResults.Items.Add($"Всего заменено: {totalReplacements}");
            foreach (var entry in fileReport) {
                listBoxResults.Items.Add($"Файл: {Path.GetFileName(entry.Key)}, Заменено слов: {entry.Value}");
            }

            // Сохранение log файла
            if (textBoxChosenPath.Text.Length != 0) {
                string logFile = Path.Combine(textBoxChosenPath.Text, Path.GetFileName("logFile.txt"));
                string results = "";
                foreach (string line in listBoxResults.Items) {
                    results += $"{line}\n";
                }
                File.WriteAllText(logFile, results);
            }

            Start.Enabled = true;
        }

        private void Stop_Click(object sender, EventArgs e) {
            Start.Enabled = true;
            cts?.Cancel();
        }


        // Обработчик для кнопки "Путь" (выбор директории назначения)
        private void pathSelection_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()) {
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    textBoxChosenPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        // Обработчик для кнопки "Файл" (выбор файла)
        private void fileSelection_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    textBoxNameFile.Text = Path.GetFileName(openFileDialog.FileName);
                    textBoxForbiddenWords.Text += " " + File.ReadAllText(openFileDialog.FileName);
                }
            }
        }
        private List<string> GetForbiddenWords() {
            List<string> words = new List<string>();

            if (textBoxForbiddenWords.Text.Trim().Length != 0) {
                string[] splitWords = textBoxForbiddenWords.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                words.AddRange(splitWords.Distinct());
            }

            return words;
        }
    }
}
