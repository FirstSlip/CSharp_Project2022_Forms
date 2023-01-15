using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    public class Projectile : GameObject, IMovable
    {
        private Point direction;
        private double distance;
        private int speed;
        public int damage = 30;
        public int Speed { get => speed; }
        public Projectile(PictureBox image, Bitmap imageFile, Point startLocation, Point direction, double distance, int speed = 20)
        {
            this.speed = speed;
            this.image = image;
            this.direction = direction;
            this.distance = distance;
            SetPictureBoxSettings(imageFile, startLocation);
        }

        private void SetPictureBoxSettings(Bitmap imageFile, Point location)
        {
            image.BackColor = System.Drawing.Color.Transparent;
            image.Image = imageFile;
            image.Location = location;
            image.Name = "projectile";
            image.Size = new System.Drawing.Size(50, 50);
            image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            image.TabIndex = 0;
            image.TabStop = false;
        }

        public void MoveTo()
        {
            Location = new Point(Location.X + (int)(direction.X / distance * Speed), Location.Y + (int)(direction.Y / distance * Speed));
        }
    }
}
