using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Resources;

namespace Project_Domain
{
    public class GameManager : IGameManager
    {
        public List<Enemy> enemies = new List<Enemy>();
        public List<Projectile> projectiles = new List<Projectile>();
        public List<Item> items = new List<Item>();
        public Player player;

        Timer timerMoveLeft;
        Timer timerMoveRight;
        Timer timerMoveUp;
        Timer timerMoveDown;

        private bool isGameEnded;
        public bool IsGameEnded { get => isGameEnded; }
        List<Timer> regularTimers = new List<Timer>();
        private Control.ControlCollection Controls;
        public GameManager(PictureBox playerImage, 
                                            Timer EnemySpawnTimer,
                                            Timer EnemyMoveTimer,
                                            Timer EnemyAttackTimer,
                                            Timer PlayerAttackTimer,
                                            Timer ProjectileMoveTimer,
                                            Timer timerMoveLeft,
                                            Timer timerMoveRight,
                                            Timer timerMoveUp,
                                            Timer timerMoveDown,
                                            Control.ControlCollection Controls)
        {
            player = new Player(playerImage);

            regularTimers.Add(EnemySpawnTimer);
            regularTimers.Add(EnemyMoveTimer);
            regularTimers.Add(EnemyAttackTimer);
            regularTimers.Add(PlayerAttackTimer);
            regularTimers.Add(ProjectileMoveTimer);

            this.timerMoveLeft = timerMoveLeft;
            this.timerMoveRight = timerMoveRight;
            this.timerMoveUp = timerMoveUp;
            this.timerMoveDown = timerMoveDown;

            this.Controls = Controls;
            isGameEnded = false;
        }

        public void StartGame()
        {
            foreach (var timer in regularTimers)
            {
                timer.Start();
            }
            isGameEnded = true;
        }

        public void EndGame()
        {
            foreach (var timer in regularTimers)
            {
                timer.Stop();
            }
            timerMoveLeft.Stop();
            timerMoveRight.Stop();
            timerMoveUp.Stop();
            timerMoveDown.Stop();

            isGameEnded = true;

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

        public void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    StartDirectionalMoveTimer(Direction.up);
                    break;
                case Keys.A:
                    StartDirectionalMoveTimer(Direction.left);
                    break;
                case Keys.S:
                    StartDirectionalMoveTimer(Direction.down);
                    break;
                case Keys.D:
                    StartDirectionalMoveTimer(Direction.right);
                    break;
            }
        }

        private enum Direction
        { 
            left = 0, 
            right = 1, 
            up = 2, 
            down = 3 
        }

        private void StartDirectionalMoveTimer(Direction direction)
        {
            Timer[] moveTimers = new Timer[] { timerMoveLeft,
                                                timerMoveRight,
                                                timerMoveUp,
                                                timerMoveDown
                                             };
            Bitmap[] playerDirectionSprites = new Bitmap[] { Resources.player_left,
                                                Resources.player_right,
                                                Resources.player_back,
                                                Resources.player_front
                                             };
            for (int i = 0; i < moveTimers.Length; i++)
            {
                if (i != ((int)direction))
                    moveTimers[i].Stop();
                else
                {
                    moveTimers[i].Start();
                }
            }
            player.image.Image = playerDirectionSprites[((int)direction)];
        }

        public void OnKeyUp(KeyEventArgs e)
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

        public void MoveEnemy()
        {
            foreach (var enemy in enemies)
            {
                enemy.MoveTo(player.Location);
            }
        }

        public PictureBox CreateProjectile()
        {
            if (enemies.Count != 0)
            {
                Point direction = new Point(enemies[0].Location.X - player.Location.X,
                                                    enemies[0].Location.Y - player.Location.Y);
                double minEnemyDistance = Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
                foreach (var enemy in enemies)
                {
                    Point minDirection = new Point(enemy.Location.X - player.Location.X,
                                                    enemy.Location.Y - player.Location.Y);
                    double minDistance = Math.Sqrt(Math.Pow(minDirection.X, 2) + Math.Pow(minDirection.Y, 2));
                    if (minDistance < minEnemyDistance)
                    {
                        direction = new Point(enemy.Location.X - player.Location.X,
                                                    enemy.Location.Y - player.Location.Y);
                        minEnemyDistance = Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
                    }
                }
                projectiles.Add(new Projectile(new PictureBox(), Resources.Spark, player.Location, direction, minEnemyDistance));
                return projectiles.Last().image;
            }
            return null;
        }

        public void IntersectEnemy_Player()
        {
            List<Enemy> enemiesCopy = enemies;
            foreach (var enemy in enemiesCopy)
            {
                if (enemy.image.Bounds.IntersectsWith(player.image.Bounds))
                {
                    player.TakeDamage(enemy.baseDamage);
                    //HpBar.Size = new Size((int)(200 * (float)player.HP / player.MaxHp), HpBar.Size.Height);
                }

            }
            enemies = enemiesCopy;
            if (player.HP <= 0)
                EndGame();
        }

        public void IntersectEnemy_Projectile()
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
                if (enemy.IsDead)
                {
                    enemiesToRemove.Add(enemy);
                }
            }
            foreach (var obj in projectilesToRemove)
            {
                projectilesCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            //RemoveGameObjects(projectilesToRemove, projectilesCopy);
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

        public string IntersectItem_Player()
        {
            string labelBuffText = "";
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
                labelBuffText = obj.description;
                obj.GetBuff(ref player);
                itemsCopy.Remove(obj);
                Controls.Remove(obj.image);
            }
            items = itemsCopy;
            return labelBuffText;
        }

        public void MoveAllProjectiles()
        {
            List<Projectile> projectilesCopy = projectiles;
            List<Projectile> projectilesToRemove = new List<Projectile>();
            foreach (var projectile in projectilesCopy)
            {
                projectile.MoveTo();
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

        public void AddEnemy()
        {
            if (enemies.Count <= 10)
            {
                enemies.Add(new Enemy(new PictureBox(), Resources.enemy_wizard_left,
                                Resources.enemy_wizard_right,
                                SpawnArea.RandomizeSpawnPosition(), Resources.scroll));
                Controls.Add(enemies.Last().image);
            }
            //if (EnemySpawnTimer.Interval >= 2500)
            //    EnemySpawnTimer.Interval -= 50;
        }
    }
}
