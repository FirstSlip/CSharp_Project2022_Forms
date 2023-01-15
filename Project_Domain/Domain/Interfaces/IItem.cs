using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public interface IItem : IGameObject
    {
        void GetBuff(ref Player player);
    }
}
