using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Infrastructure.Entities;
using Models;
using Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IOrderTableService _ordertableservice ;

        public ReservationController(IOrderTableService restaurantService)
        {
            _ordertableservice = restaurantService;
        }
        [HttpGet("{id}")]
        public ActionResult<OrderTableViewModel> GetById(int id)
        {
           
            try
            {

               return  _ordertableservice.GetById(id);
            }
            catch (ArgumentNullException)
            {
                return NoContent();
            }
        }

        [HttpPost]
        public  ActionResult Create(OrderTable orderTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _ordertableservice.GetContext().Add(orderTable);
                _ordertableservice.GetContext().SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
               var checkIfDelete =  _ordertableservice.Delete(id);
               if (checkIfDelete == false)
               {
                   return BadRequest();
               }

               return Ok();
     
        }

        [HttpPut]
        public ActionResult<OrderTableViewModel> Edit(OrderTable orderTable)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var entity = _ordertableservice.GetContext().OrderTable.Find(orderTable.Id);
                if (entity == null)
                {
                    return NoContent();
                }

                _ordertableservice.GetContext().Entry(entity).CurrentValues.SetValues(orderTable);
                _ordertableservice.GetContext().SaveChanges();
                var x = _ordertableservice.GetById(orderTable.Id);


                 return Ok(x);
            }
            catch (ArgumentNullException)
            {
                return NoContent();
            }
        }
    }
}
