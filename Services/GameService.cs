using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
using System.Net.Http;
using static BattleshipGame.Controllers.BattleshipController;

namespace BattleshipGame.Services
{
    public class GameService : IGameService
    {
        private readonly ShipPositions _shipPositions;
        public GameService(ShipPositions shipPositions)
        {
            _shipPositions = shipPositions;
        }

        public string FireMissile(char letter, int number)
        {
            //Check in the coordinates are valid
            if (!IsValidCoordinate(letter, number))
            {
                return "Invalid coordinates!";
            }

            int x = letter - 'A' + 1;
            int y = number;
            //Loop through each ship object
            foreach (var ship in _shipPositions.Ships)
            {
                //Check if already hit
                if (_shipPositions.HitCoordinates.Contains((x, y)))
                {
                    return "Already hit this point";
                }
                //Check if hit
                if (IsHit(ship, x, y))
                {
                    //Update hit counter and hitCoordinates to handle history
                    ship.HitCount++;
                    _shipPositions.HitCoordinates.Add((x, y));
                    //Check if sunk
                    if (IsSunk(ship))
                    {
                        return $"Sank {ship.Name}!";
                    }
                    else
                    {
                        
                        return $"Hit! {ship.Name}";
                    }
                }
            }

            return "Missed!";
        }
        private bool IsValidCoordinate(char letter, int number)
        {
            
            return char.IsLetter(letter) && letter >= 'A' && letter <= 'J' && number > 0 && number <= 10;
        }
        private bool IsHit(Ship ship, int x, int y)
        {
            if (ship.Orientation == "Horizontal")
            {
                return ship.Row == x && y >= ship.Column && y < ship.Column + ship.Size;
            }
            else // Vertical
            {
                return ship.Column == y && x >= ship.Row && x < ship.Row + ship.Size;
            }
        }

        private bool IsSunk(Ship ship)
        {
            return ship.HitCount == ship.Size;
        }

    }
}
