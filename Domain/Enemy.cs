using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    class Enemy : GameObject, IAlive
    {
        public readonly int MaxHp;
        private int hp;
        private double distance;
        public double Distance { get => distance; }
        private Point directionToPlayer;
        public Point DirectionToPlayer { get => directionToPlayer; }
        public int HP { get => hp; }
        private int speed;
        public int Speed { get => speed; }
        public int baseDamage;
        private int itemDropChance = 15;
        private Bitmap itemImageFile;
        private Bitmap imageFileLeft;
        private Bitmap imageFileRight;

        public Enemy(PictureBox image, Bitmap imageFileLeft, Bitmap imageFileRight, Point startLocation, Bitmap itemImageFile, int baseDamage = 10, int maxHp = 100, int speed = 5)
        {
            this.speed = speed;
            this.image = image;
            this.MaxHp = maxHp;
            this.baseDamage = baseDamage;
            this.imageFileLeft = imageFileLeft;
            this.imageFileRight = imageFileRight;
            hp = maxHp;
            this.itemImageFile = itemImageFile;
            SetPictureBoxSettings(imageFileLeft, startLocation);
        }

        private void SetPictureBoxSettings(Bitmap imageFile, Point location)
        {
            image.BackColor = System.Drawing.Color.Transparent;
            image.Image = imageFile;
            image.Location = location;
            image.Name = "enemy";
            image.Size = new System.Drawing.Size(30, 56);
            image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            image.TabIndex = 0;
            image.TabStop = false;
        }
        public void MoveToHero(PictureBox mainPlayer)
        {
            directionToPlayer = new Point(mainPlayer.Location.X - Location.X,
                                                    mainPlayer.Location.Y - Location.Y);
            distance = Math.Sqrt(Math.Pow(directionToPlayer.X, 2) + Math.Pow(directionToPlayer.Y, 2));
            Location = new Point(Location.X + (int)(directionToPlayer.X / distance * Speed),
                                        Location.Y + (int)(directionToPlayer.Y / distance * Speed));
            if (directionToPlayer.X <= 0)
                image.Image = imageFileLeft;
            else
                image.Image = imageFileRight;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
        }

        public Item DropItem()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 101) <= itemDropChance)
            {
                return Item.RandomItem(itemImageFile, Location);
            }
            return null;
        }
    }
}
