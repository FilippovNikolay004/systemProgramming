using System;
using System.Threading.Tasks;
using System.Windows;

using System.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public SynchronizationContext uiContext;
        public MainWindow()
        {
            InitializeComponent();
            // Получим контекст синхронизации для текущего потока 
            uiContext = SynchronizationContext.Current;
        }

        private Task ThreadFunk()
        {
            return Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => progressBar1.Minimum = 0, null);
                    uiContext.Send(d => progressBar1.Maximum = 230, null);
                    uiContext.Send(d => progressBar1.Value = 0, null);
                    uiContext.Send(d => button1.IsEnabled = false, null);

                    for (int i = 0; i < 230; i++)
                    {
                        Thread.Sleep(50);
                        // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                        // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 
                        uiContext.Send(d => progressBar1.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                            i /* Объект, переданный делегату */); // добавляем в список имя клиента
                        // progressBar1.Value = i;
                    }
                    uiContext.Send(d => button1.IsEnabled = true, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            await ThreadFunk();
        }
    }
}
