using Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstraction
{
    public interface IToDoRepository
    {
        List<ToDoItem> GetItems();
        ToDoItem GetItem(int id);
        void Add(ToDoItem toDoItem);
        void Delete(int id);
        void Update(ToDoItem toDoItem);
    }
}
