using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace BattleshipGame.Controllers
{
    [EnableCors("AllowOrigin")] // Enable CORS 
    [Route("v1/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        
        private readonly IGameService _gameService;
        private ShipPositions _shipPositions;

        // Constructor to inject dependencies
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
                _shipPositions.HitCoordinates.Clear(); //Clear HitCoordinates every time I inizialize the board
                return Ok(new { message = "Game board initialized successfully", _shipPositions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while initializing the game board", message = ex.Message });
            }
        }

        [HttpPost("fire")]
        public IActionResult FireMissile([FromBody] String coordinatesString)
        {
            try
            {
                //Convert in object coordinates and extract letter and number
                Coordinates coordinates = new Coordinates(coordinatesString);
                char x = coordinates.Letter;
                int y = coordinates.Number;

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
