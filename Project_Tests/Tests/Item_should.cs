using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;
using Project_Domain;

namespace Project_Tests
{
    class Item_should
    {
        [Test]
        public void ItemRandomizeNotNull()
        {
            var item = Item.RandomItem(null, new Point(0, 0));
            Assert.IsTrue(item != null);
        }

        [Test]
        public void ItemRandomizeCorrectLocation()
        {
            var item = Item.RandomItem(null, new Point(0, 0));
            Assert.AreEqual(item.Location, new Point(0, 0));
        }

        [Test]
        public void ItemCorrectAddingDamageBuff()
        {
            var player = new Player(new PictureBox());
            var item = new Item(null, new Point(0, 0), Item.possibleBuffs[0], 5, "Increase damage by 5");
            var startDamage = player.DamageBuff;
            item.GetBuff(ref player);
            Assert.AreEqual(startDamage + 5, player.DamageBuff);
        }


        [Test]
        public void ItemCorrectAddingHPBuff()
        {
            var player = new Player(new PictureBox());
            var item = new Item(null, new Point(0, 0), Item.possibleBuffs[1], 10, "Increase Hp by 10");
            var startHP = player.HP;
            var startMaxHP = player.MaxHp;
            item.GetBuff(ref player);
            Assert.AreEqual(startHP + 10, player.HP);
            Assert.AreEqual(startMaxHP + 10, player.MaxHp);
        }

        [Test]
        public void ItemCorrectAddingSpeedBuff()
        {
            var player = new Player(new PictureBox());
            var item = new Item(null, new Point(0, 0), Item.possibleBuffs[2], 5, "Increase speed by 5");
            var startSpeed = player.Speed;
            item.GetBuff(ref player);
            Assert.AreEqual(startSpeed + 5, player.Speed);
        }
    }
}
