using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Business.Entity.ToDoItem, Models.ToDoItem>();
            CreateMap<Models.ToDoItem, Business.Entity.ToDoItem>();
        }
    }
}
