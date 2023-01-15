using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public interface IMovable : IGameObject
    {
        void MoveTo(Point destinationPoint);
    }
}
