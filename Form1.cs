using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Domain;

namespace CSharpProject
{
    public partial class Form1 : Form
    {
        private List<Enemy> enemies = new List<Enemy>();
        private List<Projectile> projectiles = new List<Projectile>();
        private List<Item> items = new List<Item>();
        private Player player;
        GameManager gameManager;
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // WS_EX_COMPOSITED
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            gameManager = new GameManager(ref player, mainPlayer,
                                                EnemySpawnTimer,
                                            EnemyMoveTimer,
                                            EnemyAttackTimer,
                                            PlayerAttackTimer,
                                            ProjectileMoveTimer,
                                            timerMoveLeft,
                                            timerMoveRight,
                                            timerMoveUp,
                                            timerMoveDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerMoveDown_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Bottom < 950)
                mainPlayer.Top += player.Speed;
        }
        private void timerMoveUp_Tick(object sender, EventArgs e)
        {

            if (mainPlayer.Top > 2)
                mainPlayer.Top -= player.Speed;
        }
        private void timerMoveRight_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Right < 1600)
                mainPlayer.Left += player.Speed;
        }
        private void timerMoveLeft_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left > 2)
                mainPlayer.Left -= player.Speed;
        }
        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            if (enemies.Count <= 10)
            {
                enemies.Add(new Enemy(new PictureBox(), Properties.Resources.enemy_wizard_left, 
                                Properties.Resources.enemy_wizard_right,
                                SpawnArea.RandomizeSpawnPosition(), Properties.Resources.scroll));
                Controls.Add(enemies.Last().image);
            }
            //if (EnemySpawnTimer.Interval >= 2500)
            //    EnemySpawnTimer.Interval -= 50;
        }
        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemy();
            IntersectItem_Player();
        }

        private void MoveEnemy()
        {
            foreach (var enemy in enemies)
            {
                enemy.MoveToHero(mainPlayer);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            //mainPlayer.BackgroundImage = Properties.Resources.player_walk_back;
            switch (e.KeyCode)
            {
                case Keys.W:
                    mainPlayer.Image = Properties.Resources.player_back;
                    timerMoveUp.Start();
                    break;
                case Keys.A:
                    mainPlayer.Image = Properties.Resources.player_left;
                    timerMoveLeft.Start();
                    break;
                case Keys.S:
                    mainPlayer.Image = Properties.Resources.player_front;
                    timerMoveDown.Start();
                    break;
                case Keys.D:
                    mainPlayer.Image = Properties.Resources.player_right;
                    timerMoveRight.Start();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                timerMoveLeft.Stop();
            }

            if (e.KeyCode == Keys.D)
            {
                timerMoveRight.Stop();
            }

            if (e.KeyCode == Keys.W)
            {
                timerMoveUp.Stop();
            }

            if (e.KeyCode == Keys.S)
            {
                timerMoveDown.Stop();
            }
        }

        private void EnemyAttackTimer_Tick(object sender, EventArgs e)
        {
            IntersectEnemy_Player();
        }

        private void PlayerAttackTimer_Tick(object sender, EventArgs e)
        {
            CreateProjectile();
        }

        private void ProjectileMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveAllProjectiles();
            IntersectEnemy_Projectile();
        }

        private void IntersectEnemy_Player()
        {
            List<Enemy> enemiesCopy = enemies;
            foreach (var enemy in enemiesCopy)
            {
                if (enemy.image.Bounds.IntersectsWith(player.image.Bounds))
                {
                    player.TakeDamage(enemy.baseDamage);
                    HpBar.Size = new Size((int)(200 * (float)player.HP / player.MaxHp), HpBar.Size.Height);
                }
                
            }
            enemies = enemiesCopy;
            if (player.HP <= 0)
                DoGameEnd();
        }

        private void IntersectItem_Player()
        {
            List<Item> itemsCopy = items;
            List<Item> itemsToRemove = new List<Item>();
            foreach (var item in itemsCopy)
            {
                if (item.image.Bounds.IntersectsWith(player.image.Bounds))
                {
                    itemsToRemove.Add(item);
                }

            }
            foreach (var obj in itemsToRemove)
            {
                labelBuff.Text = obj.description;
                timerBuff.Stop();
                timerBuff.Start();
                obj.GetBuff(ref player);
                itemsCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            items = itemsCopy;
        }

        private void IntersectEnemy_Projectile()
        {
            List<Projectile> projectilesCopy = projectiles;
            List<Enemy> enemiesCopy = enemies;
            List<Projectile> projectilesToRemove = new List<Projectile>();
            List<Enemy> enemiesToRemove = new List<Enemy>();
            foreach (var enemy in enemiesCopy)
            {
                foreach (var projectile in projectilesCopy)
                {
                    if (enemy.image.Bounds.IntersectsWith(projectile.image.Bounds))
                    {
                        enemy.TakeDamage(projectile.damage + player.DamageBuff);
                        projectilesToRemove.Add(projectile);
                    }
                }
                if (enemy.HP <= 0)
                {
                    enemiesToRemove.Add(enemy);
                }
            }
            foreach (var obj in projectilesToRemove)
            {
                projectilesCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            foreach (var obj in enemiesToRemove)
            {
                Item item = obj.DropItem();
                if (item != null)
                {
                    items.Add(item);
                    Controls.Add(items.Last().image);
                }
                enemiesCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            projectiles = projectilesCopy;
            enemies = enemiesCopy;
        }

        private void CreateProjectile()
        {
            if (enemies.Count != 0)
            {
                Point direction = new Point(enemies[0].Location.X - mainPlayer.Location.X,
                                                    enemies[0].Location.Y - mainPlayer.Location.Y);
                double minEnemyDistance = Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
                foreach (var enemy in enemies)
                {
                    Point minDirection = new Point(enemy.Location.X - mainPlayer.Location.X,
                                                    enemy.Location.Y - mainPlayer.Location.Y);
                    double minDistance = Math.Sqrt(Math.Pow(minDirection.X, 2) + Math.Pow(minDirection.Y, 2));
                    if (minDistance < minEnemyDistance)
                    {
                        direction = new Point(enemy.Location.X - mainPlayer.Location.X,
                                                    enemy.Location.Y - mainPlayer.Location.Y);
                        minEnemyDistance = Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
                    }
                }
                projectiles.Add(new Projectile(new PictureBox(), Properties.Resources.spark, mainPlayer.Location, direction, minEnemyDistance));
                Controls.Add(projectiles.Last().image);
            }
        }

        private void MoveAllProjectiles()
        {
            List<Projectile> projectilesCopy = projectiles;
            List<Projectile> projectilesToRemove = new List<Projectile>();
            foreach (var projectile in projectilesCopy)
            {
                projectile.Move();
                if (projectile.Location.X < 0 || projectile.Location.X > 1600 || projectile.Location.Y < 0 || projectile.Location.Y > 1000)
                {
                    projectilesToRemove.Add(projectile);
                }
            }
            foreach (var obj in projectilesToRemove)
            {
                projectilesCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            projectiles = projectilesCopy;
        }

        private void DoGameEnd()
        {
            gameManager.EndGame();
            var result = MessageBox.Show("Игра окончена. Вы проиграли.", "Игра окончена", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Application.Restart();
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void timerBuff_Tick(object sender, EventArgs e)
        {
            labelBuff.Text = "";
            this.timerBuff.Stop();
        }
    }
}
