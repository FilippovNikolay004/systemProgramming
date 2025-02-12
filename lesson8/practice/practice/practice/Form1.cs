using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice {
    public partial class Form1 :Form {
        private ProgressBar[] progressBars;
        private Random r = new Random();
        private CancellationTokenSource cts;

        public Form1() {
            InitializeComponent();
            progressBars = [
                progressBar1, progressBar2, 
                progressBar3, progressBar4, progressBar5
            ];
        }

        private async void button1_Click(object sender, EventArgs e) {
            cts?.Cancel();
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            for (int i = 0; i < progressBars.Length; i++) {
                progressBars[i].Value = 0;
            }

            try {
                Task<(ProgressBar, TimeSpan)>[] tasks = progressBars
                    .Select(pb => ProgressFillAsync(pb, token)).ToArray();

                var results = await Task.WhenAll(tasks);

                // Формируем строку с результатами и выводим в MessageBox
                string message = string.Join("\n", results.Select(res => 
                    $"{res.Item1.Name}: {res.Item2.TotalSeconds:F2} сек"));

                MessageBox.Show(message, "Время выполнения");
            }
            catch {
            }
        }

        private async Task<(ProgressBar, TimeSpan)> ProgressFillAsync(ProgressBar progressBar, CancellationToken token) {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i <= 100; i++) {
                token.ThrowIfCancellationRequested();

                await Task.Delay(r.Next(50, 250), token);

                if (!token.IsCancellationRequested) {
                    Invoke(new Action(() => progressBar.Value = i)); 
                }
            }

            stopwatch.Stop();
            return (progressBar, stopwatch.Elapsed);
        }
    }
}