using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public abstract class Entity
    {
        public int id;

        public Entity(int id)
        {
            this.id = id;
        }
    }
}
