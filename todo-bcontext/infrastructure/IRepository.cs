using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_bocontext.model;

namespace todo_bcontext.infrastructure
{
    public interface IRepository
    {
        TodoModel Add(TodoModel entity);
        void Remove(TodoModel entity);
        IEnumerable<TodoModel> ListByUser(string userId);
        TodoModel GetById(long id);
        TodoModel Update(TodoModel entity);
    }
}