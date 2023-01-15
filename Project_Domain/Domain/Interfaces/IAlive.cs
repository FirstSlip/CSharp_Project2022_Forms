using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public interface IAlive : IMovable
    {
        bool IsDead { get; }
        int HP { get; }
        int MaxHp { get; }
        int Speed { get; }
        void TakeDamage(int damage);

        void AddHP(int AdditionalHP);

        void AddSpeed(int additionalSpeed);
    }
}
