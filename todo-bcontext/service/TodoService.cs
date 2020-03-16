using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crosscutting.validation;
using todo_bcontext.infrastructure;
using todo_bocontext.model;

namespace todo_bcontext.service
{
    public class TodoService : ITodoService
    {
        private readonly IRepository _repository;
        public TodoService(IRepository repository)
        {
            _repository = repository;
        }

        public (ValidationResult, TodoModel) Create(TodoModel todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Id))
            {
                todo.Id = Guid.NewGuid().ToString("N");
            }

            var (valid, error) = todo.ValidTodo();

            if (!valid)
            {
                return (new ValidationResult { }.AddError(error), todo);
            }

            var result = _repository.Add(todo);

            return (null, result);
        }

        public ValidationResult Delete(string todo)
        {
            throw new NotImplementedException();
        }

        public IList<TodoModel> GetByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}