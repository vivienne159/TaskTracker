using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_trecker
{
    enum Type { todo, progress, done }
    internal class Task
    {
        private int id;
        private string description;
        private Type status;
        private DateTime createdAt;
        private DateTime updateAt;

        public int Id
        {
            get { return id; }
        }
        public Type Status
        {
            get
            {
                return status;
            }
        }
        public DateTime CreatedAt
        {
            get { return createdAt; }
        }
        public DateTime UpdateAt
        {
            get { return updateAt; }
        }
        public Task(int id, string description, Type status, DateTime createdAt, DateTime updateAt)
        {
            this.id = id;
            Description = description;
            this.status = status;
            this.createdAt = createdAt;
            this.updateAt = updateAt;
            this.status = status;
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 200)
                {
                    throw new ArgumentException("описание не может быть пустым/" +
                        "длина описания не может быть больше 200 символов");
                }
                else
                {
                    description = value;
                }
                
            }
        }
       
        public void PrintTask()
        {
            Console.WriteLine($"id: {id} | description: {description} | status: {status} | createdAt: {createdAt} | updateAt: " +
                $"{updateAt}");
        }
        public void UpdateTask()
        {
            
            Console.WriteLine("выберите статус задачи\n" +
                "1. - todo\n" +
                "2. - progress\n" +
                "3. - done");
            bool is_choice = int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    if (status != Type.todo)
                    {
                        status = Type.todo;
                        updateAt = DateTime.Now;
                    }
                    else
                        Console.WriteLine("текущий статус задачи уже является таким");
                    break;
                case 2:
                    if (status != Type.progress)
                    {
                        status = Type.progress;
                        updateAt = DateTime.Now;
                    }
                    else
                        Console.WriteLine("текущий статус задачи уже является таким");
                    break;
                case 3:
                    if (status != Type.done)
                    {
                        status = Type.done;
                        updateAt = DateTime.Now;
                    }
                    else
                        Console.WriteLine("текущий статус задачи уже является таким");
                    break;
                default:
                    Console.WriteLine("такого выбора несуществует.");
                    break;

            }
        }
        public void PrintDoneTask()
        {
            if (status == Type.done)
            {
                PrintTask();
            }
            
                
        }
        public void PrintNoDoneTask()
        {
            if (status != Type.done)
            {
                PrintTask();
            }
            

        }

    }
}
