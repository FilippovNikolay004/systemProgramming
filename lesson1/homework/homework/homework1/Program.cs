// TASK #2
/*
    Создайте класс Bank, в котором будут следующие свойства: 
    int money, string name, int percent. 
    Постройте класс так, чтобы при изменении одного из свойств, класса создавался новый поток, 
    который записывал данные о свойствах класса в текстовый файл на жестком диске. 
    Класс должен инкапсулировать в себе всю логику многопоточности.
*/

class Bank {
    private int money;
    private string name;
    private int percent;
    private Thread loggingThread;

    public int Money {
        get => money;
        set {
            money = value;
            StartLoggingThread();
        }
    }
    public string Name {
        get => name;
        set {
            name = value;
            StartLoggingThread();
        }
    }
    public int Percent {
        get => percent;
        set {
            percent = value;
            StartLoggingThread();
        }
    }

    public Bank(string name, int money, int percent) {
        Name = name;
        Money = money;
        Percent = percent;

        StartLoggingThread();
    }

    private void StartLoggingThread() {
        if (loggingThread == null) {
            loggingThread = new Thread(LogToFile);
            loggingThread.Start();
        } else if (loggingThread.ThreadState == ThreadState.Suspended) {
            loggingThread.Resume(); // Возобновление потока
        }
    }
    private void LogToFile() {
        string filePath = "bank_log.txt";
        
        string logEntry = $"{DateTime.Now}: Name={Name}, Money={Money}, Percent={Percent}";
        using (StreamWriter WFile = new StreamWriter(filePath, true)) {
            WFile.WriteLine(logEntry);
        }
        Thread.CurrentThread.Suspend(); // Приостановка потока
        //Thread.Sleep(1000);
    }
}

class Program {
    static void Main() {
        Bank bank = new Bank("PrivatBank", 1000, 5);

        bank.Money = 2000;
        bank.Name = "MONOBANK";
        bank.Percent = 7;

        Console.WriteLine("Данные записаны в файл.");
    }
}