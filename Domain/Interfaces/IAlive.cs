using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public interface IAlive
    {
        int HP { get; }
        int Speed { get; }
        void TakeDamage(int damage);
    }
}
