using Business;
using Business.Abstraction;
using DryIoc;
using Persistence;
using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public class MyCompositionRoot
    {
        public MyCompositionRoot(IRegistrator registrator)
        {
            registrator.Register<IToDoRepository, ToDoRepository>();
            registrator.Register<IToDo, ToDo>();
        }
    }
}
