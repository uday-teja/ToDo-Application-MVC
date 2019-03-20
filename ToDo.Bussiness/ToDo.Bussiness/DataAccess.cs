using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Model;

namespace ToDo.Bussiness
{
    public class DataAccess
    {
        ToDoApplicationEntities toDoApplication = new ToDoApplicationEntities();
        TasksList tasksList = new TasksList();
        Tasks tasks = new Tasks();

        public List<TasksList> TaskList()
        {
            return toDoApplication.TasksLists.ToList();
        }

        public Tasks Tasks()
        {
            tasks.task = tasksList;
            tasks.taskList = toDoApplication.TasksLists.ToList();
            return tasks;
        }

        public void AddToDo(TasksList taskList)
        {
            if(taskList.TaskCategory is null)
            {
                taskList.TaskCategory = "ToDo";
            }
            toDoApplication.TasksLists.Add(taskList);
            toDoApplication.SaveChanges();
        }

        public void AddCategory(TasksList task)
        {
            toDoApplication.TasksLists.Add(task);
            toDoApplication.SaveChanges();
        }

        public void UpdateToDo(TasksList taskList)
        {
                var updateToDo = toDoApplication.TasksLists.FirstOrDefault(c => c.id == taskList.id);
                updateToDo.TaskCreationDate = taskList.TaskCreationDate;
                updateToDo.TaskNotes = updateToDo.TaskNotes;
                toDoApplication.SaveChanges();
        }

        public void DeleteToDo(string id)
        {
            var toDo = toDoApplication.TasksLists.First(c => c.TaskNotes == id);
            toDoApplication.TasksLists.Remove(toDo);
            toDoApplication.SaveChanges();
        }
    }
}