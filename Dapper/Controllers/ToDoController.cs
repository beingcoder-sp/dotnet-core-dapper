using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper.Models;
using Business.Abstraction;
using AutoMapper;


namespace Dapper.Controllers
{
    [Route("api/v0.1/todo")]
    public class ToDoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToDo _toDo;

        public ToDoController(IMapper mapper, IToDo toDo)
        {
            _mapper = mapper;
            _toDo = toDo;
        }
        
        [HttpGet("")]
        public async Task<List<ToDoItem>> GetAll()
        {
            var myToDoItems = new List<ToDoItem>();
            try
            {
                List<Business.Entity.ToDoItem> toDoItems = _toDo.GetToDoItems();

                myToDoItems = _mapper.Map<List<ToDoItem>>(toDoItems);
            }
            catch(Exception exception)
            {

            }
            return myToDoItems;
        }

        [HttpGet("{id}")]
        public async Task<ToDoItem> Get(int id)
        {
            var myToDoItem = new ToDoItem();
            try
            {
                Business.Entity.ToDoItem toDoItem = _toDo.GetItem(id);

                myToDoItem = _mapper.Map<ToDoItem>(toDoItem);
            }
            catch (Exception exception)
            {

            }
            return myToDoItem;
        }

        [HttpPost("")]
        public async Task<List<ToDoItem>> Add([FromBody] ToDoItem toDoItem)
        {
            var myToDoItems = new List<ToDoItem>();
            try
            {
                var todo = _mapper.Map<Business.Entity.ToDoItem>(toDoItem);

                _toDo.Add(todo);

                List<Business.Entity.ToDoItem> toDoItems = _toDo.GetToDoItems();
                myToDoItems = _mapper.Map<List<ToDoItem>>(toDoItems);
            }
            catch (Exception exception)
            {

            }
            return myToDoItems;
        }

        [HttpPost("update")]
        public async Task<List<ToDoItem>> Update([FromBody] ToDoItem toDoItem)
        {
            var myToDoItems = new List<ToDoItem>();
            try
            {
                var todo = _mapper.Map<Business.Entity.ToDoItem>(toDoItem);

                _toDo.Update(todo);

                List<Business.Entity.ToDoItem> toDoItems = _toDo.GetToDoItems();
                myToDoItems = _mapper.Map<List<ToDoItem>>(toDoItems);
            }
            catch (Exception exception)
            {

            }
            return myToDoItems;
        }

        [HttpDelete("{id}")]
        public async Task<List<ToDoItem>> Delete(int id)
        {
            var myToDoItems = new List<ToDoItem>();
            try
            {
                _toDo.Delete(id);

                List<Business.Entity.ToDoItem> toDoItems = _toDo.GetToDoItems();
                myToDoItems = _mapper.Map<List<ToDoItem>>(toDoItems);
            }
            catch (Exception exception)
            {

            }
            return myToDoItems;
        }
    }
}