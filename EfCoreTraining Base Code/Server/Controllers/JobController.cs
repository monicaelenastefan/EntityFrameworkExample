using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<JobApplication> GetById(int id)
        {
            var apply = RestaurantContext.JobApplications.FirstOrDefault(p => p.Id == id);
            if (apply == null)
            {
                return NotFound();
            }

            return apply;
        }

        [HttpPost]
        public ActionResult<JobApplication> Post(JobApplication jobApplication)
        {
            RestaurantContext.JobApplications.Add(jobApplication);

            var a =new HttpClient();
            return CreatedAtAction(nameof(GetById), new {id = jobApplication.Id}, jobApplication);
        }
    }
}