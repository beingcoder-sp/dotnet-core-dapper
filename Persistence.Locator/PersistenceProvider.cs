using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence.Locator
{
    public class PersistenceProvider : IPersistenceManager
    {
        private readonly IToDoRepository _toDoRepository;

        public PersistenceProvider(IServiceProvider serviceProvider)
        {
            _toDoRepository = serviceProvider.GetService<IToDoRepository>();
        }

        public IToDoRepository GetToDoRepository()
        {
            return _toDoRepository;
        }
    }
}
