using static BattleshipGame.Controllers.BattleshipController;

namespace DigitTest_BattleshipGame.Models
{
    public class Coordinates
    {
        public char Letter { get; set; }
        public int Number { get; set; }

        public Coordinates(string coordinateString)
        {
            if (string.IsNullOrEmpty(coordinateString) || coordinateString.Length < 2)
                throw new ArgumentException("Invalid coordinate format.");

            // Extract the letter and number parts from the coordinate string
            Letter = char.ToUpper(coordinateString[0]);
            if (!char.IsLetter(Letter))
                throw new ArgumentException("Invalid coordinate format.");

            if (!int.TryParse(coordinateString.Substring(1), out int number))
                throw new ArgumentException("Invalid coordinate format.");

            Number = number;
        }
    }



}
