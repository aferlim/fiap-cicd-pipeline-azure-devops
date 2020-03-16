using System.Collections.Generic;
using crosscutting.validation;
using todo_bocontext.model;

namespace todo_bcontext.service
{
    public interface ITodoService
    {
        (ValidationResult, TodoModel) Create(TodoModel todo);

        IList<TodoModel> GetByUser(string userId);

        ValidationResult Delete(string todo);
    }
}