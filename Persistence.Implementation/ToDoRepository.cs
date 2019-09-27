using Business.Entity;
using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace Persistence
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IConfiguration _config;

        private readonly string _connectionString;

        public ToDoRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("MyConnectionString");
        }


        public List<ToDoItem> GetItems()
        {
            List<ToDoItem> result = null;
            using (var con = new SqlConnection(_connectionString))
            {
                string sQuery = "SELECT Id, Name, IsComplete FROM ToDo";
                con.Open();
                result = con.Query<ToDoItem>(sQuery).AsList();
            }
            return result;

        }

        public ToDoItem GetItem(int id)
        {
            ToDoItem toDoItem = null;
            using (var con = new SqlConnection(_connectionString))
            {
                string sQuery = "SELECT Id, Name, IsComplete FROM ToDo WHERE Id = @Id";
                con.Open();
                toDoItem = con.QuerySingle<ToDoItem>(sQuery, new { Id = id });
            }
            return toDoItem;

        }

        public void Add(ToDoItem toDoItem)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string sQuery = "INSERT INTO ToDo VALUES(@Id, @Name, @IsComplete)";
                con.Open();
                con.Execute(sQuery, new { Id = toDoItem.Id, Name = toDoItem.Name, IsComplete = toDoItem.IsComplete });
            }
        }

        public void Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string sQuery = "DELETE FROM ToDo WHERE Id = @Id";
                con.Open();
                con.Execute(sQuery, new { Id = id});
            }
        }

        public void Update(ToDoItem toDoItem)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string sQuery = "UPDATE ToDo SET Name = @Name, IsComplete = @IsComplete WHERE Id = @Id";
                con.Open();
                con.Execute(sQuery, new { Id = toDoItem.Id, Name = toDoItem.Name, IsComplete = toDoItem.IsComplete });
            }
        }
    }
}
