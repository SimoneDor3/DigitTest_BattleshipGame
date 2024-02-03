using static BattleshipGame.Controllers.BattleshipController;

namespace DigitTest_BattleshipGame.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string Orientation { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HitCount { get; internal set; }
    }


}
