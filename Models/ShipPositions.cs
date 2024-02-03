using static BattleshipGame.Controllers.BattleshipController;

namespace DigitTest_BattleshipGame.Models
{
    public class ShipPositions
    {
        public Ship[] Ships { get; set; }
        public HashSet<(int x, int y)> HitCoordinates = new HashSet<(int x, int y)>();
    }
    
    
}
