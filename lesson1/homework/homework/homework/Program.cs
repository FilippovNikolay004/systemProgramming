class Program {
    // TASK #1
    /*
        Создайте поток, который "принимает" в себя коллекцию элементов, 
        и вызывает из каждого элемента коллекции метод ToString() и 
        выводит результат работы метода на экран.
    */
    static void ProcessCollection(object? collection) {
        if (collection == null) { return; }

        List<string> items = (List<string>)collection;

        foreach (var item in items) {
            Console.WriteLine(item.ToString());
        }
    }

    static void Main() {
        // TASK #1
        List<string> items = new List<string> { 
            "message 1", "message 2", "message 3", "message 4" 
        };

        // Запуск первого потока.
        Thread thread1 = new Thread(new ParameterizedThreadStart(ProcessCollection));
        thread1.Start(items);
    }
}








