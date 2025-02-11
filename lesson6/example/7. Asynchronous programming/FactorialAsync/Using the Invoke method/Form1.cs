using System;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Using_the_Invoke_method
{
    public partial class Form1 : Form
    {
        private delegate void InWork(int a);
        public Form1()
        {
            InitializeComponent();
        }

        private Task ThreadFunk()
        {
            return Task.Run(() =>
            {
                try
                {
                    // Создание анонимных делегатов
                    Action Act1 = delegate
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 230;
                        progressBar1.Value = 0;
                        button1.Enabled = false;
                    };

                    Action Act2 = delegate
                    {
                        button1.Enabled = true;
                    };

                    InWork IW = delegate (int a)
                    {
                        progressBar1.Value = a;
                    };

                    // Выполняет указанный делегат в том потоке, которому принадлежит базовый дескриптор окна элемента управления.
                    this.Invoke(Act1);

                    for (int i = 0; i < 230; i++)
                    {
                        Thread.Sleep(50);
                        // Выполняет указанный делегат в том потоке, которому принадлежит базовый дескриптор окна элемента управления.
                        this.Invoke(IW, i);
                    }
                    this.Invoke(Act2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
        async private void button1_Click(object sender, EventArgs e)
        {
            await ThreadFunk();
        }
    }
}
