using System.Threading;

namespace homework
{
    public partial class Form1 :Form {
        private const string GUID = "B4107BC4-5D34-48AD-B174-92E13373CCCD";
        private int threadCounter = 1;
        private Semaphore sem;
        private Dictionary<int, CancellationTokenSource> runningThreads = new();
        private Queue<int> waitingThreads = new();
        private SynchronizationContext uiContext;

        public Form1() {
            InitializeComponent();

            sem = new Semaphore(1, 1, GUID);
            uiContext = SynchronizationContext.Current;
        }

        private void button1_Click(object sender, EventArgs e) {
            int threadId = threadCounter++;
            listBox3.Items.Add(threadId);
        }

        private void listBox3_DoubleClick_1(object sender, EventArgs e) {
            if (listBox3.SelectedItem is int threadId) {
                listBox3.Items.Remove(threadId);
                listBox2.Items.Add(threadId);
                waitingThreads.Enqueue(threadId);
                TryStartWaitingThreads();
            }
        }

        private async void TryStartWaitingThreads() {
            while (waitingThreads.Count > 0) {
                if (!sem.WaitOne(0))
                    return;

                int threadId = waitingThreads.Dequeue();
                listBox2.Items.Remove(threadId);
                listBox1.Items.Add(threadId);

                var cts = new CancellationTokenSource();
                runningThreads[threadId] = cts;

                await Task.Run(() => RunThread(threadId, cts.Token));
            }
        }

        private void RunThread(int threadId, CancellationToken token) {
            int counter = 0;
            while (!token.IsCancellationRequested) {
                counter++;
                uiContext.Post(state => UpdateThreadDisplay(threadId, counter), null);
                Thread.Sleep(1000);
            }
            sem.Release();
        }

        private void UpdateThreadDisplay(int threadId, int counter) {
            if (listBox1.Items.Contains(threadId)) {
                int index = listBox1.Items.IndexOf(threadId);
                listBox1.Items[index] = $"{threadId} ({counter})";
            }
        }

        private void listBox1_DoubleClick_1(object sender, EventArgs e) {
            if (listBox1.SelectedItem is string selectedItem && int.TryParse(selectedItem.Split(' ')[0], out int threadId)) {
                if (runningThreads.TryGetValue(threadId, out var cts)) {
                    cts.Cancel();
                    runningThreads.Remove(threadId);
                    listBox1.Items.Remove(selectedItem);
                    TryStartWaitingThreads();
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            int newLimit = int.Parse(numericUpDown1.Value.ToString());
            sem = new Semaphore(newLimit, newLimit, GUID);
            TryStartWaitingThreads();
        }
    }
}
