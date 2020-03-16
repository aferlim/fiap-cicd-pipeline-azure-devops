using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crosscutting.extension;

namespace todo_bocontext.model
{
    public class TodoModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Expires { get; set; }

        public string UserId { get; set; }

        public (bool, string) ValidTodo()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                return (false, "Invalid Id");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                return (false, "Invalid Name");
            }

            if (Expires <= DateTime.Now.GetBrazilianDateTime())
            {
                return (false, "Invalid Expiration, need be grater than now and timezone: America/Sao_Paulo");
            }

            return (true, "");
        }
    }
}