using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_bocontext.model;
using crosscutting.extension;

namespace cicd_pipeline_test
{
    public static class TodoModelStub
    {
        public static TodoModel GetSimpleTodo()
        {
            return new TodoModel
            {
                Id = "",
                Name = "Todo Test",
                Description = "Todo Test",
                Expires = DateTime.Now.AddDays(1).GetBrazilianDateTime(),
                UserId = "user Test"
            };
        }
    }
}