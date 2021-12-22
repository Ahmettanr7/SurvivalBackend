using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemiesController : ControllerBase
    {
        IEnemyService _enemyService;

        public EnemiesController(IEnemyService enemyService)
        {
            _enemyService = enemyService;
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {

            var result = _enemyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {

            var result = _enemyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
