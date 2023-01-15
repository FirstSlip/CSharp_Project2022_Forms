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
    class Enemy_should
    {
        [Test]
        public void EnemyGetLethalDamageWith1Hit()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            enemy.TakeDamage(enemy.MaxHp);
            Assert.IsTrue(enemy.IsDead);
        }

        [Test]
        public void EnemyGetLethalDamageWith4Hits()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            enemy.TakeDamage(enemy.MaxHp / 4 + 1);
            enemy.TakeDamage(enemy.MaxHp / 4 + 1);
            enemy.TakeDamage(enemy.MaxHp / 4 + 1);
            enemy.TakeDamage(enemy.MaxHp / 4 + 1);
            Assert.IsTrue(enemy.IsDead);
        }

        [Test]
        public void EnemyGetNonLethalHit()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            enemy.TakeDamage(enemy.MaxHp / 5);
            Assert.IsFalse(enemy.IsDead);
        }

        [Test]
        public void EnemyGet2NonLethalHits()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            enemy.TakeDamage(enemy.MaxHp / 5);
            enemy.TakeDamage(enemy.MaxHp / 5);
            Assert.IsFalse(enemy.IsDead);
        }

        [Test]
        public void EnemyMoveToPlayerCorrect_Point_0_0()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            var picture = new PictureBox();
            picture.Location = new Point(0, 0);
            enemy.MoveToHero(picture);
            Assert.AreEqual(new Point(0, 0), enemy.Location);
        }

        [Test]
        public void EnemyMoveToPlayerCorrect_Point_5_0()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            var picture = new PictureBox();
            picture.Location = new Point(5, 0);
            enemy.MoveToHero(picture);
            Assert.AreEqual(new Point(5, 0), enemy.Location);
        }

        [Test]
        public void EnemyMoveToPlayerCorrect_Point_0_5()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            var picture = new PictureBox();
            picture.Location = new Point(0, 5);
            enemy.MoveToHero(picture);
            Assert.AreEqual(new Point(0, 5), enemy.Location);
        }

        [Test]
        public void EnemyMoveToPlayerCorrect_Point_0_15()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            var picture = new PictureBox();
            picture.Location = new Point(0, 15);
            enemy.MoveToHero(picture);
            Assert.AreEqual(new Point(0, 5), enemy.Location);
        }

        [Test]
        public void EnemyMoveToPlayerCorrect_Point_15_0()
        {
            var enemy = new Enemy(new PictureBox(), null, null, new Point(0, 0), null);
            var picture = new PictureBox();
            picture.Location = new Point(15, 0);
            enemy.MoveToHero(picture);
            Assert.AreEqual(new Point(5, 0), enemy.Location);
        }
    }
}
