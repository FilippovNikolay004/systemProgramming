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

namespace MutexMaxOfNumbers
{
    public partial class Form1 : Form
    {
        SynchronizationContext uiContext;
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }

        void MaxOfNumbers()
        {
            try
            {
                FileStream file = new FileStream(@"c:/Temp/array.dat", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                int max = 0, i = 0;
                int[] ar = new int[file.Length / 4];
                try
                {
                    while (true)
                    {
                        ar[i] = reader.ReadInt32();
                        if (ar[i] > ar[max])
                            max = i;
                        i++;
                    }
                }
                catch (EndOfStreamException)
                {
                    //Достигнут конец файла
                }
                uiContext.Send(d => label1.Text = "Максимальный элемент массива чисел: " + ar[max].ToString() 
                    + " имеет индекс " + max.ToString(), null);
                reader.Close();
                file.Close();
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
                // Проверяем не создавался ли он раньше
                if (CreatedNew == true)
                    throw new Exception("Не запускался поток, генерирующий данные!");
                // Ожидаем переход мьютекса в сигнальное состояние
                uiContext.Send(d => label1.Text = "Ожидаем переход мьютекса в сигнальное состояние.", null);
                mutex.WaitOne();
                uiContext.Send(d => label1.Text = "Мьютекс свободен!", null);
                MaxOfNumbers();
                //Переводим мьютекс в сигнальное состояние
                mutex.ReleaseMutex();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(ThreadFunction);
        }
    }
}