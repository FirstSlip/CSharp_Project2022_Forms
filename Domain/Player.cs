using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    class Player : GameObject , IAlive, IPlayer
    {
        private int exp;
        public int Exp { get => exp; }
        private int maxHp;
        public int MaxHp { get => maxHp; }
        private int hp;
        public int HP { get => hp; }
        private int speed;
        public int Speed { get => speed; }
        private int damageBuff;
        public int DamageBuff { get => damageBuff; set => damageBuff = value; }



        public Player(PictureBox image, int maxHp = 100)
        {
            this.speed = 6;
            this.image = image;
            this.maxHp = maxHp;
            hp = maxHp;
            damageBuff = 0;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
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
