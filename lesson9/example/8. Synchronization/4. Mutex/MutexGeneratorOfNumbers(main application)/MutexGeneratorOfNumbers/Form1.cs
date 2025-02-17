using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace MutexGeneratorOfNumbers
{
    public partial class Form1 : Form
    {
        SynchronizationContext uiContext;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }
        void GeneratorOfNumbers()
        {
            try
            {
                uiContext.Send(d => label1.Text = "Начинаем генерировать числа!", null);
                FileStream file = new FileStream(@"c:/Temp/array.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                int range = rnd.Next(1000);
                for (int i = 0; i < 100000000; i++)
                {
                    int n = rnd.Next(range);
                    writer.Write(n);
                }
                writer.Close();
                file.Close();
                uiContext.Send(d => label1.Text = "Файл с числовыми данными создан!", null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void ThreadFunction()
        {
            try
            {
                bool CreatedNew;
                // Создаём мьютекс
                Mutex mutex = new Mutex(false, "F55491EF-4DDF-4126-BD5F-E8DD6C8AA00F", out CreatedNew);
                mutex.WaitOne();
                GeneratorOfNumbers();
                mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(ThreadFunction);
        }
    }
}