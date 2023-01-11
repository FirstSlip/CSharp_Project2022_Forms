using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Windows.Forms;

namespace Project_Domain
{
    class Player_should
    {
        [Test]
        public void PlayerGetLethalDamageWith1Hit()
        {
            var player = new Player(new PictureBox());
            player.TakeDamage(player.MaxHp);
            Assert.IsTrue(player.IsDead);
        }

        [Test]
        public void PlayerGetDamageWith4Hits()
        {
            var player = new Player(new PictureBox());
            player.TakeDamage(player.MaxHp / 4 + 1);
            player.TakeDamage(25);
            player.TakeDamage(25);
            player.TakeDamage(25);
            Assert.IsTrue(player.IsDead);
        }

        [Test]
        public void PlayerLethalGetNonLethalHit()
        {
            var player = new Player(new PictureBox());
            player.TakeDamage(player.MaxHp / 5);
            Assert.IsFalse(player.IsDead);
        }

        [Test]
        public void PlayerGet2NonLethalHits()
        {
            var player = new Player(new PictureBox());
            player.TakeDamage(player.MaxHp / 4);
            player.TakeDamage(player.MaxHp / 4);
            Assert.IsFalse(player.IsDead);
        }

        [Test]
        public void PlayerIncreaseSpeed()
        {
            var player = new Player(new PictureBox());
            int startSpeed = player.Speed;
            player.AddSpeed(5);
            Assert.AreEqual(startSpeed + 5, player.Speed);
        }

        [Test]
        public void PlayerIncreaseHp()
        {
            var player = new Player(new PictureBox());
            int startMaxHP = player.MaxHp;
            int startHP = player.HP;
            player.AddHP(10);
            Assert.AreEqual(startMaxHP + 10, player.MaxHp);
            Assert.AreEqual(startHP + 10, player.HP);
        }
    }
}
