using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Task_trecker
{
    internal class Tasks
    {
        private List<Task> AllListTasks = new List<Task>();
       
        public List<Task> allListTasks
        {
            get { return AllListTasks; }
        }
        public void LoadDataFromFileJson()
        {
            string json = File.ReadAllText("tasks.json");
            AllListTasks = JsonSerializer.Deserialize<List<Task>>(json);
            
        }
        public void PrintListTasks()
        {
            foreach(Task task in AllListTasks)
            {
                Console.WriteLine($"id: {task.Id} | description: {task.Description} | status: {task.Status} |" +
                    $" createdAt: {task.CreatedAt} | updateAt: " +
                $"{task.UpdateAt}");
            }
        }
         public int FoundNewId()
        {
            int newid = 1;
            
            foreach (Task el in AllListTasks)
            {
                
                if (el.Id >= newid)
                {
                  newid = el.Id + 1;
                }
            }
            return newid;
            
        }
        public void AddInListTasks(Task task)
        {
            AllListTasks.Add(task);
            
        }
        public void RemoveInListTasks(int id)
        {
                int iddelete = id - 1;
                AllListTasks.RemoveAt(iddelete);
        }
        public void UpdateTaskInList(int id)
        {
            Task task1 = null;
            foreach (Task task in AllListTasks)
            {
                if (id == task.Id)
                {
                    task1 = task;
                    break;
                }
            }
            task1.UpdateTask();
            Console.WriteLine("статус задачи успешно обновлен");
        }
        public void PrintDoneTaskInList()
        {
            foreach(Task task in allListTasks)
            {
                task.PrintDoneTask();
            }
        }
        public void PrintNoDoneTaskInList()
        {
            foreach (Task task in allListTasks)
            {
                task.PrintNoDoneTask();
            }
        }
    }
}
