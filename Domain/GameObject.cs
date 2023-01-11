using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    public abstract class GameObject
    {
        public PictureBox image;

        public Point Location
        {
            get => image.Location;
            set
            {
                image.Location = value;
            }
        }

        public GameObject() { }
    }
}
