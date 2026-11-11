using System.Text.Json;
using System.IO;

namespace Task_trecker
{
    internal class Program
    {
        
        static Tasks ListTasks = new Tasks();
        static string json = JsonSerializer.Serialize(ListTasks.allListTasks);
        static string filepath = "tasks.json";
        
        static int id = ListTasks.FoundNewId();
        static void Main(string[] args)
        {
            
            if (!File.Exists("tasks.json"))
            {
                File.WriteAllText(filepath, json);
            }
            else
            {
                ListTasks.LoadDataFromFileJson();
            }
                bool menu = true;
            while (menu)
            {
                Console.WriteLine("task tracker");
                Console.WriteLine("1. - добавить задачу\n" +
                    "2. - удалить задачу\n" +
                    "3. - обновить задачу\n" +
                    "4. - список всех задач\n" +
                    "5. - все выполненые задачи\n" +
                    "6. - все невыполненные задачи\n" +
                    "7. - выйти");
                bool is_choice = int.TryParse(Console.ReadLine(), out int choice);
                if(!is_choice)
                {
                    Console.WriteLine("необходимо ввести число");
                }
                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        
                        RemoveTask();
                        break;
                    case 3:
                        UpdateTask();
                        break;
                    case 4:
                        ListTasks.PrintListTasks();
                        break;
                    case 5:
                        ListTasks.PrintDoneTaskInList();
                        break;
                    case 6:
                        ListTasks.PrintNoDoneTaskInList();
                        break;
                    case 7:
                        menu = false;
                        Console.WriteLine("все задачи сохранены, ждем вас снова!");
                        break;
                    default:
                        Console.WriteLine("такого выбора несуществует");
                        break;

                }
            }
        }
        static void AddJsonFile()
        {
            
            File.WriteAllText(filepath, json);
        }
        static void AddTask()
        {
            
            while (true)
            {
                try
                {
                    Console.WriteLine("введите описание задачи");
                    string EnterDescription = Console.ReadLine();
                    
                    Task task = new Task(id, EnterDescription, Type.todo, DateTime.Now, DateTime.Now);
                    id++;
                    Console.WriteLine("ваша задача:");
                    task.PrintTask();
                    ListTasks.AddInListTasks(task);
                    AddJsonFile();

                    break;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("повторите попытку");
                }
            }

        }
        static void RemoveTask()
        {
            ListTasks.PrintListTasks();
            int Id = CheckId();
            ListTasks.RemoveInListTasks(Id);
            ListTasks.PrintListTasks();
            AddJsonFile();
        }
        static void UpdateTask()
        {
            ListTasks.PrintListTasks();
            int Id = CheckId();
            ListTasks.UpdateTaskInList(Id);
            ListTasks.PrintListTasks();
            AddJsonFile();
        }
        static public int CheckId()
        {

            while (true)
            {

                Console.WriteLine("введите id");
                bool is_IdForChange = int.TryParse(Console.ReadLine(), out int IdForChange);
                bool isFound = false;
                foreach(Task task in ListTasks.allListTasks)
                {
                    if(task.Id == IdForChange)
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound || !is_IdForChange)
                {
                    Console.WriteLine("неверно введен id");
                    
                }
                else
                {
                    return IdForChange;
                    
                }
            }
                
        }
        
    }
}
