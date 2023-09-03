using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using studyAPI.Models;

namespace studyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudController : ControllerBase
    {
        private readonly KtdatabaseContext db;

        public StudController(KtdatabaseContext db)
        {
            this.db = db;
        }
        [HttpGet(Name = "GetStudentDetails")]

        public IActionResult GetAll()
        {
            /*var data = db.Students.ToList();*/
            var data = db.Students.FromSqlRaw("EXEC FIRSTY").ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetStud(int id)
        {
            /*return Ok(db.Students.FirstOrDefault(x => x.Id == id));*/
            var student = db.Students.FromSqlRaw("EXEC GetStudentsByID @ID", new SqlParameter("@ID", id)).ToList();
            return Ok(student);
        }

        //[EnableCors("MyAllowSpecificOrigins")]
        //[DisableCors]

        [HttpPost]

        public IActionResult PushStud([FromBody] Student std)
        {
            db.Students.Add(std);
            //var idParm = new SqlParameter("@ID", std.Id);
            //var nameParm = new SqlParameter("@NAME", std.Name);
            //var ageParm = new SqlParameter("@AGE", std.Age);
            //var phoneParm = new SqlParameter("@PHONE_NUMBER", std.PhoneNumber);
            //var courseParm = new SqlParameter("@COURSE_ID", std.Course);
            //var stud = db.Students.FromSqlRaw("EXEC CreateStudent @ID, @NAME, @AGE, @PHONE_NUMBER, @COURSE_ID",
            //    idParm,nameParm,ageParm,phoneParm,courseParm);
            
            db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStud(int id, [FromBody] Student std)
        {
            db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok(db.Students.FirstOrDefault(x => x.Id == id));
        }

        [HttpDelete("{id}")]
        //[EnableCors("AllowOrigin")]
        public IActionResult DelStud(int id)
        {
            var student = db.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            db.SaveChanges();

            return Ok();
        }


    }
}
