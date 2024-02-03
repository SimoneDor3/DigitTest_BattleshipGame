using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace BattleshipGame.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        
        private readonly IGameService _gameService;
        private ShipPositions _shipPositions;

        public BattleshipController(IGameService gameService, ShipPositions shipPositions)
        {
            _gameService = gameService;

            _shipPositions = shipPositions;
        }

        [HttpGet("init")]
        public IActionResult InitializeGameBoard()
        {
            try
            {
                return Ok(new { message = "Game board initialized successfully", _shipPositions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while initializing the game board", message = ex.Message });
            }
        }

        [HttpGet("initcheck")]
        public IActionResult CheckInitializeGameBoard()
        {
            try
            {

                return Ok(new { message = "Game board initialized successfully", _shipPositions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while initializing the game board", message = ex.Message });
            }
        }

        [HttpPost("fire")]
        public IActionResult FireMissile([FromBody] Missile missile)
        {
            try
            {
                int x = missile.X;
                int y = missile.Y;

                // Call method to fire missile and get result
                var result = _gameService.FireMissile(x, y);

                // Return result as JSON object
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing the request", message = ex.Message });
            }
        }

       
        

        
    }
}
