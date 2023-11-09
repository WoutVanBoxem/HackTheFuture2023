using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class VineCalculator
    {
        public (int x, int y) CalculateEndPosition(int amountOfVines, string start, string[] directions)
        {
            int fieldSize = (int)Math.Sqrt(amountOfVines);
            var currentPosition = ParsePosition(start);
            foreach (var direction in directions)
            {
                var newPosition = GetNewPosition(currentPosition, direction);
                if (IsValidPosition(newPosition, fieldSize))
                {
                    currentPosition = newPosition;
                }
            }
            return currentPosition;
        }

        private (int x, int y) ParsePosition(string position)
        {
            var parts = position.Split(',');
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        private (int x, int y) GetNewPosition((int x, int y) currentPosition, string direction)
        {
            var movement = direction switch
            {
                "U" => (0, 1),
                "D" => (0, -1),
                "L" => (-1, 0),
                "R" => (1, 0),
                "UL" => (-1, 1),
                "UR" => (1, 1),
                "DL" => (-1, -1),
                "DR" => (1, -1),
                _ => (0, 0)
            };
            return (currentPosition.x + movement.Item1, currentPosition.y + movement.Item2);
        }

        private bool IsValidPosition((int x, int y) position, int fieldSize)
        {
            return position.x >= 0 && position.x < fieldSize && position.y >= 0 && position.y < fieldSize;
        }

    }
}
