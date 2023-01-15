using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public static class SpawnArea
    {
        private static Random rnd = new Random();
        private static Dictionary<int, (Point, Point)> areas = new Dictionary<int, (Point, Point)>()
        {
            {1, (new Point(-150, -150), new Point(-50, 1150)) },
            {2, (new Point(-150, -150), new Point(1750, -60)) },
            {3, (new Point(1610, -150), new Point(1750, 1150)) },
            {4, (new Point(-150, 1010), new Point(1750, 1150)) }
        };
        public static Point RandomizeSpawnPosition()
        {
            var k = areas[rnd.Next(1, 5)];
            return new Point(rnd.Next(k.Item1.X, k.Item2.X), rnd.Next(k.Item1.Y, k.Item2.Y));
        }
    }
}
