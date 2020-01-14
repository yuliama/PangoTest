using PangoCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PangoCalculator.Controllers
{
    public class HomeController : ApiController
    {
        // POST: api/Home
        [HttpPost]
        public IHttpActionResult CalculateResult([FromBody] MathExercise exercise)
        {
            try
            {
                Result resSolution = new Result();
                var res = resSolution.Calculate(exercise);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //get all operators
        [HttpGet]
        public IHttpActionResult GetOperators()
        {
            try
            {
                Result resSolution = new Result();
                var res = resSolution.GetOperators();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
