using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    interface IPlayer : IAlive
    {
        int Exp { get; }
        int DamageBuff { get; set; }
    }
}
