using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using todo_api.Data;
using todo_api.Model;

namespace todo_api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {

        private ApplicationDbContext _context;
        public TodoController(ApplicationDbContext context){
            this._context = context;
        }

        [HttpGet]
        public ActionResult<List<Task>> Get () {
            return Ok(this._context.Tasks.ToList());
        }

        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        [HttpPost]
        public void Post ([FromBody] Task task) {
            this._context.Add(task);
            this._context.SaveChanges();
         }

        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { 
            var task = this._context.Tasks.FirstOrDefault(t => t.Id == id);
            if(task == null)
                return;

            task.Name = value;
            this._context.SaveChanges();
        }

        [HttpDelete ("{id}")]
        public void Delete (int id) {
            var task = this._context.Tasks.FirstOrDefault();
            if(task != null){
                this._context.Tasks.Remove(task);
                this._context.SaveChanges();
            }

         }
    }
}