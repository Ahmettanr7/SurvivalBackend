using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class GamesController : ControllerBase
    {

        IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [Authorize]
        [HttpPost("add")]
        public ActionResult Add(Game game)
        {

            var result = _gameService.Add(game);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost("war")]
        public ActionResult War(int gameId, int enemyId)
        {

            var result = _gameService.War(gameId,enemyId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [Authorize]
        [HttpPost("escape")]
        public ActionResult Escape(int gameId, int enemyId)
        {

            var result = _gameService.Escape(gameId, enemyId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost("shopping")]
        public ActionResult Shopping(int gameId, int itemId)
        {

            var result = _gameService.Shopping(gameId, itemId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public ActionResult GetAll()
        {

            var result = _gameService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {

            var result = _gameService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
