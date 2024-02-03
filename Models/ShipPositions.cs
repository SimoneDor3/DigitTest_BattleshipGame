using System.Text.Json;
using static BattleshipGame.Controllers.BattleshipController;

namespace DigitTest_BattleshipGame.Models
{
    public class ShipPositions
    {
        public Ship[] Ships { get; set; }
        public HashSet<(int x, int y)> HitCoordinates = new HashSet<(int x, int y)>();


        public static ShipPositions loadShipsPositionFromFile() { 
            string shipsJsonPath = "ships.json";
            string jsonString = System.IO.File.ReadAllText(shipsJsonPath);
            var shipPositions = JsonSerializer.Deserialize<ShipPositions>(jsonString);
            return shipPositions;
        }
    }
    
    
}
