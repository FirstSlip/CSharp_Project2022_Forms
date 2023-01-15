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
using Project_Resources;

namespace CSharpProject
{
    public partial class Form1 : Form
    {

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
            gameManager = new GameManager(mainPlayer,
                                                EnemySpawnTimer,
                                            EnemyMoveTimer,
                                            EnemyAttackTimer,
                                            PlayerAttackTimer,
                                            ProjectileMoveTimer,
                                            timerMoveLeft,
                                            timerMoveRight,
                                            timerMoveUp,
                                            timerMoveDown,
                                            Controls);
            gameManager.StartGame();
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
                mainPlayer.Top += gameManager.player.Speed;
        }
        private void timerMoveUp_Tick(object sender, EventArgs e)
        {

            if (mainPlayer.Top > 2)
                mainPlayer.Top -= gameManager.player.Speed;
        }
        private void timerMoveRight_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Right < 1600)
                mainPlayer.Left += gameManager.player.Speed;
        }
        private void timerMoveLeft_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left > 2)
                mainPlayer.Left -= gameManager.player.Speed;
        }

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            gameManager.AddEnemy();
        }
        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            gameManager.MoveEnemy();
            string labelText = gameManager.IntersectItem_Player();
            if (labelText != "")
            {
                labelBuff.Text = labelText;
                timerBuff.Stop();
                timerBuff.Start();
            }
        }

        private void EnemyAttackTimer_Tick(object sender, EventArgs e)
        {
            gameManager.IntersectEnemy_Player();
        }

        private void PlayerAttackTimer_Tick(object sender, EventArgs e)
        {
            
            Controls.Add(gameManager?.CreateProjectile());
        }

        private void ProjectileMoveTimer_Tick(object sender, EventArgs e)
        {
            gameManager.MoveAllProjectiles();
            gameManager.IntersectEnemy_Projectile();
        }

        private void timerBuff_Tick(object sender, EventArgs e)
        {
            labelBuff.Text = "";
            this.timerBuff.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameManager.OnKeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gameManager.OnKeyUp(e);
        }


        /*private void RemoveGameObjects<T>(List<T> objectsToRemove, List<T> objectListToChange)
            where T : IGameObject
        {
            foreach (var obj in objectsToRemove)
            {
                //
                //Controls.Remove(obj.image);
                //Item i = obj.OnRemove();
                //items.Add(i);
                objectListToChange.Remove(obj);
            }
        }*/



        /*private void MoveAllProjectiles()
        {
            List<Projectile> projectilesCopy = gameManager.projectiles;
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
            gameManager.projectiles = projectilesCopy;
        }*/
    }
}
