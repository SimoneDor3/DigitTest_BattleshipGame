using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
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

        public string FireMissile(int x, int y)
        {
            foreach (var ship in _shipPositions.Ships)
            {
                if (_shipPositions.HitCoordinates.Contains((x, y)))
                {
                    return "Already hit this point";
                }
                if (IsHit(ship, x, y))
                {
                    ship.HitCount++;
                    _shipPositions.HitCoordinates.Add((x, y));
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
