using System;
using System.IO;
using System.Text;
using System.Threading;

class Demo
{
    FileStream f;
    byte[] buf;
    event AsyncCallback callback;

    public void UserInput()
    {
        string s;
        do
        {
            Console.WriteLine("Введите строку: ");
            s = Console.ReadLine();
        } while (s.Length != 0);
    }

    public void OnCompletedRead(IAsyncResult ar) // содержит сведения о завершении операции
    {
        int bytes = f.EndRead(ar);
        Thread.Sleep(3000);
        Console.WriteLine("Чтение в потоке {0} закончено", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Считано " + bytes);
        Console.WriteLine(Encoding.UTF8.GetString(buf).Remove(0, 1));
        f.Close();
    }

    public void AsyncRead()
    {

        FileInfo fi;
        try
        {
            fi = new FileInfo("../../program.cs");
            long length = fi.Length;
            buf = new byte[length];
            // Инициализирует новый экземпляр класса FileStream с заданными путем, режимом создания, 
            // разрешениями на чтение и запись и совместное использование, размером буфера и 
            // синхронным или асинхронным состоянием.
            f = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, buf.Length, true); // файл открывается в асинхронном режиме
            callback = new AsyncCallback(OnCompletedRead); // экземпляр стандартного делегата
            f.BeginRead(buf, 0, buf.Length, callback, null);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}

class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Основной поток ID = {0}", Thread.CurrentThread.ManagedThreadId);
        Demo d = new Demo();
        d.AsyncRead();
        d.UserInput();
    }
}

