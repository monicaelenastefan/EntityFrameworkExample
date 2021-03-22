using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantWantedAdController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EmployeeRequirements>> Get()
        {
            var requirements = from r in RestaurantContext.EmployeesRequirements
                orderby r.JobTitle
                select r;
            return requirements.ToList();
        }
    }
}