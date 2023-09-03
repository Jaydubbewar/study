using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studyAPI.Models;

namespace studyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinedDataController : ControllerBase
    {
        private readonly KtdatabaseContext db;

        public CombinedDataController(KtdatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet(Name = "GetCombinedData")]

        public IActionResult GetAllData()
        {
            var data = db.Students.FromSqlRaw("EXEC ALDATA").ToList();
            return Ok(data);
        }
        //[HttpGet]
        //public IActionResult GetRequiredData()
        //{
        //    var data = db.Students.FromSqlRaw("EXEC RECDATA").ToList();
        //    return Ok(data);
        //}
    }
}
