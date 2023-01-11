using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    class Item : GameObject
    {
        public static List<Action<Player, int>> possibleBuffs = new List<Action<Player, int>>
        {
            { (a, b) => a.DamageBuff += b },
            { (a, b) => a.AddHP(b) },
            { (a, b) => a.AddSpeed(b)},
        };
        private protected Action<Player, int> buff;
        private protected int buffValue;
        public string description;

        public Item(Bitmap imageFile, Point location, Action<Player, int> buff, int buffValue, string description)
        {
            this.buff = buff;
            this.buffValue = buffValue;
            this.description = description;
            image = new PictureBox();
            SetPictureBoxSettings(imageFile, location);
        }
        private void SetPictureBoxSettings(Bitmap imageFile, Point location)
        {
            image.BackColor = System.Drawing.Color.Transparent;
            image.Image = imageFile;
            image.Location = location;
            image.Name = "enemy";
            image.Size = new System.Drawing.Size(30, 30);
            image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            image.TabIndex = 0;
            image.TabStop = false;
        }

        public static Item RandomItem(Bitmap imageFile, Point location)
        {
            Random rnd = new Random();
            int randInt = rnd.Next(0, possibleBuffs.Count);
            if (randInt == 0)
                return new Item(imageFile, location, possibleBuffs[0], 5, "Взято улучшение урона\nВаш урон увеличен на 5.");
            if (randInt == 1)
                return new Item(imageFile, location, possibleBuffs[1], 10, "Взято улучшение здоровья.\nВаше текущее и максимальное здоровье увеличено на 10.");
            return new Item(imageFile, location, possibleBuffs[2], 1, "Взято улучшение скорости.\nВаша скорость передвижения увеличена на 1.");
        }

        public void GetBuff(ref Player player)
        {
            buff(player, buffValue);
        }
    }
}
