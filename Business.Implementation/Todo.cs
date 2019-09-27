using Business.Abstraction;
using Business.Entity;
using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public class ToDo : IToDo
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDo(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public List<ToDoItem> GetToDoItems()
        {
            return _toDoRepository.GetItems();
        }

        public ToDoItem GetItem(int id)
        {
            return _toDoRepository.GetItem(id);
        }

        public void Add(ToDoItem toDoItem)
        {
            _toDoRepository.Add(toDoItem);
        }

        public void Delete(int id)
        {
            _toDoRepository.Delete(id);
        }

        public void Update(ToDoItem toDoItem)
        {
            _toDoRepository.Update(toDoItem);
        }
    }
}
