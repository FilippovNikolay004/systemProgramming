using System.IO;
using System.Threading.Tasks;

namespace homework
{
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Фамилия", 100);
            listView1.Columns.Add("Имя", 100);
            listView1.Columns.Add("Возраст", 100);
            listView1.Columns.Add("Группа", 100);

            ReadFromFile("../../data.txt");
        }

        private void button1_Click(object sender, EventArgs e) {
            string lastName = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string age = textBox3.Text.Trim();
            string group = textBox4.Text.Trim();

            if (!int.TryParse(age, out int parsedAge)) {
                MessageBox.Show("Ошибка: Введите число.");
                return;
            }

            if (lastName.Length == 0 || name.Length == 0 || age.Length == 0 || group.Length == 0) {
                MessageBox.Show("Заполните поля!");
                return;
            }

            // Создание первой задачи
            Task tsk = new Task(WriteToFileTask, "../../data.txt");

            // Создание продолжение задачи
            Task nextTsk = tsk.ContinueWith(ReadFromFileTask);

            Task search = nextTsk.ContinueWith(FindYoungStudentTask);

            try {
                // Запуск первой задачи на выполнение
                tsk.Start();

                // Ожидание выполнения второй задачи
                nextTsk.Wait();

                search.Wait();

                MessageBox.Show("Задачи выполнены!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteToFileTask(object? path) {
            if (path == null) { return; }

            WriteToFile(path as string??"");
        }
        private void WriteToFile(string path) {
            string lastName = textBox1.Text.Trim();
            string firstName = textBox2.Text.Trim();
            string age = textBox3.Text.Trim();
            string group = textBox4.Text.Trim();

            try {
                FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                
                writer.Write($"LastName: {lastName}; FirstName: {firstName}; Age: {age}; Group: {group}\n");
                
                writer.Close();
                file.Close();

                MessageBox.Show("Данные в файл записаны!");
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                throw;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void ReadFromFileTask(Task t) {
            ReadFromFile("../../data.txt");
        }
        private void ReadFromFile(string path) {
            try {
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);

                // Запись в ViewBox
                listView1.Items.Clear();
                while (!reader.EndOfStream) {

                    string[] parts = reader.ReadLine().Split("; ", StringSplitOptions.RemoveEmptyEntries);

                    List<string> list = new List<string>();
                    foreach (string part in parts) {
                        string[] keyValue = part.Split(':');

                        if (keyValue.Length == 2) {
                            list.Add(keyValue[1].Trim());
                        }
                    }

                    listView1.Items.Add(new ListViewItem(list.ToArray()));
                }
                reader.Close();
                file.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void FindYoungStudentTask(Task t) {
            FindYoungStudent();
        }

        private void FindYoungStudent() {
            // Создаем списки для хранения данных
            List<string> students = new List<string>();
            List<int> ages = new List<int>();

            // Перебираем все элементы в ListView
            foreach (ListViewItem item in listView1.Items) {
                // Добавляем данные в списки: строку и возраст
                students.Add(item.SubItems[0].Text + " " + item.SubItems[1].Text);
                int age;
                if (int.TryParse(item.SubItems[2].Text, out age))
                    ages.Add(age);
            }

            int minAgeIndex = ages.IndexOf(ages.Min());

            // Выводим данные самого молодого студента
            MessageBox.Show($"Самый молодой студент: {students[minAgeIndex]}\nВозраст: {ages[minAgeIndex]}\nГруппа: {listView1.Items[minAgeIndex].SubItems[3].Text}");

        }
    }
}