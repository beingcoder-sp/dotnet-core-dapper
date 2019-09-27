using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Locator
{
    public interface IPersistenceManager
    {
        IToDoRepository GetToDoRepository();
    }
}
