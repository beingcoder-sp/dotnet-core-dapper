using Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstraction
{
    public interface IToDo
    {
        List<ToDoItem> GetToDoItems();
        void Add(ToDoItem toDoItem);
        ToDoItem GetItem(int id);
        void Delete(int id);
        void Update(ToDoItem toDoItem);
    }
}
