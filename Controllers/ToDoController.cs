using System.Linq;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private ApplicationDbContext _db;
        
        public ToDoController()
        {
            _db = ApplicationDbContext.Create();
        }

        [HttpGet]
        public JsonResult Get()
        {
            var toDoList = _db.ToDos.AsNoTracking().ToList();
            return Json(toDoList, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public bool Create(Models.ToDo toDo)
        {
            _db.ToDos.Add(toDo);
            return _db.SaveChanges() > 0;
        }

        [HttpPost]
        public bool Edit(Models.ToDo updatedToDo)
        {
            var toDo = _db.ToDos.Find(updatedToDo.Number);
            if (toDo != null)
            {
                _db.Entry(toDo).CurrentValues.SetValues(updatedToDo);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        [HttpPost]
        public bool Delete(Models.ToDo deletedToDo)
        {
            var toDo = _db.ToDos.Find(deletedToDo.Number);
            if (toDo != null)
            {
                _db.ToDos.Remove(toDo);
                return _db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
