using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
namespace GUID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
              мьютекс - примитив синхронизации, который также может использоваться в межпроцессорной синхронизации. 
             public Mutex(
             bool initiallyOwned, - Значение true для предоставления вызывающему потоку начального владения мьютексом; в противном случае — false.
             string name - Имя объекта Mutex. Если значение равно null, то у объекта Mutex нет имени.
             out bool createdNew - При возврате из данного метода содержит логическое значение, равное true, 
                      если был создан новый мьютекс; false, если была получена ссылка на существующий мютекс. 
                      Этот параметр передается неинициализированным. 
               )
                
              public virtual bool WaitOne(); - ожидает переход мьютекса в сигнальное состояние. 
              public void ReleaseMutex(); - переводит мьютекс из несигнального в сигнальное состояние.
              public static Mutex OpenExisting(string name); - возвращает ссылку на существующий мьютекс. 
              Если его нет, то появляется WaitHandleCannotBeOpenedException
             * public virtual void Close(); - закрывает дескриптор открытых мьютексов.
            */
            //запуск только одной копии приложения
            string GUID = "{6F9619FF-8B86-D011-B42D-00CF4FC964FF}";
            bool CreatedNew;
            Mutex mutex = new Mutex(false, GUID, out CreatedNew);
            if (!CreatedNew)//мьютекс уже был создан
            {
                MessageBox.Show("Must be only one copy");
            }
            else //мьютекс создаётся данным экземпляром приложения
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}

