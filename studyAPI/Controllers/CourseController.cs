using Microsoft.AspNetCore.Mvc;
using studyAPI.Models;

namespace studyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly KtdatabaseContext db;

        public CourseController(KtdatabaseContext dbA)
        {
            this.db = dbA;
        }

        [HttpGet(Name = "GetCourseDetails")]

        public IActionResult GetCourses()
        {
            return Ok(db.CourseDetails.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            return Ok(db.CourseDetails.FirstOrDefault(x => x.CourseId == id));


        }
        [HttpPost]
        public IActionResult PushCourse([FromBody] CourseDetail crd)
        {
            db.CourseDetails.Add(crd);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseDetail crd)
        {
            db.Entry(crd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok(db.CourseDetails.FirstOrDefault(x => x.CourseId == id));
        }

        [HttpDelete("{id}")]
        public IActionResult DelCourse(int id)
        {
            var course = db.CourseDetails.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            db.CourseDetails.Remove(course);
            db.SaveChanges();

            return Ok();
        }

    }
}
