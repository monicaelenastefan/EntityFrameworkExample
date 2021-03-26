using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantBranchesController : ControllerBase
    {
        private IRestaurantBranchService _restaurantService;

        public RestaurantBranchesController(IRestaurantBranchService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public ActionResult<List<RestaurantBranchViewModel>> Get()
        {
            try
            {
                return _restaurantService.GetAll();
            }
            catch (ArgumentNullException)
            {
                return NoContent();
            }
            
        }
    }
}
