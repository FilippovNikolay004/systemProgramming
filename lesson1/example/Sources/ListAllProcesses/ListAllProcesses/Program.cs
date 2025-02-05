using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ListAllProcesses
{
    class Program
    {
        static void Main(string[] args)
        {
            //устанавливаем заголовок консоли
            Console.Title = "Список процессов";
            //изменяем размер буфера консоли и окна на необходимый нам
            Console.WindowWidth = 40;
            Console.BufferWidth = 40;
            //получаем список процессов
            Process[] processes = Process.GetProcesses();
            //выводим заголовок
            Console.WriteLine("Имя процесса:","PID:");
            //для каждого процесса выводим имя и PID
            foreach (Process p in processes)
                Console.WriteLine(p.ProcessName + " " + p.Id);


            Console.WriteLine("Введите PID процесса для завершения:");
            string pidToKill = Console.ReadLine();

            Process[] processesToKill = Process.GetProcessesByName(pidToKill);

            // Завершаем процесс
            foreach (Process process in processesToKill) {
                process.Kill();
                Console.WriteLine($"Процесс {process.ProcessName} с PID {process.Id} был завершен.");
            }
        }
    }
}
