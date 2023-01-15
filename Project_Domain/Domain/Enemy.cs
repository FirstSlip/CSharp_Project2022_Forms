using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    public class Enemy : GameObject, IEnemy
    {
        public bool IsDead { get => hp <= 0; }
        private int maxHp;
        public int MaxHp { get => maxHp; }
        private int hp;
        public int HP { get => hp; }
        private double distance;
        public double Distance { get => distance; }
        private Point directionToPoint;
        public Point DirectionToPlayer { get => directionToPoint; }
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
            this.maxHp = maxHp;
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

        public void MoveTo(Point destinationPoint)
        {
            directionToPoint = new Point(destinationPoint.X - Location.X,
                                                    destinationPoint.Y - Location.Y);
            distance = Math.Sqrt(Math.Pow(directionToPoint.X, 2) + Math.Pow(directionToPoint.Y, 2));
            if (distance == 0)
                return;
            Location = new Point(Location.X + (int)(directionToPoint.X / distance * Speed),
                                        Location.Y + (int)(directionToPoint.Y / distance * Speed));
            if (directionToPoint.X <= 0)
                image.Image = imageFileLeft;
            else
                image.Image = imageFileRight;
        }

        public void MoveToHero(Point player)
        {
            directionToPoint = new Point(player.X - Location.X,
                                                    player.Y - Location.Y);
            distance = Math.Sqrt(Math.Pow(directionToPoint.X, 2) + Math.Pow(directionToPoint.Y, 2));
            if (distance == 0)
                return;
            MoveTo(new Point(Location.X + (int)(directionToPoint.X / distance * Speed),
                                        Location.Y + (int)(directionToPoint.Y / distance * Speed)));
            if (directionToPoint.X <= 0)
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

        public void OnRemove(Form form, out Item item)
        {
            item = DropItem();
            form.Controls.Remove(image);
            //return DropItem;
        }

        public void AddHP(int AdditionalHP)
        {
            maxHp += AdditionalHP;
            hp += AdditionalHP;
        }

        public void AddSpeed(int additionalSpeed)
        {
            speed += additionalSpeed;
        }
    }
}
