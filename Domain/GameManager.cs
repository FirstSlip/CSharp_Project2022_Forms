using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Domain
{
    class GameManager
    {
        private bool isGameEnded;
        public bool IsGameEnded { get => isGameEnded; }
        List<Timer> allTimers = new List<Timer>();

        public GameManager(ref Player player, PictureBox playerImage, 
                                            Timer EnemySpawnTimer,
                                            Timer EnemyMoveTimer,
                                            Timer EnemyAttackTimer,
                                            Timer PlayerAttackTimer,
                                            Timer ProjectileMoveTimer,
                                            Timer timerMoveLeft,
                                            Timer timerMoveRight,
                                            Timer timerMoveUp,
                                            Timer timerMoveDown)
        {
            player = new Player(playerImage);
            allTimers.Add(EnemySpawnTimer);
            allTimers.Add(EnemyMoveTimer);
            allTimers.Add(EnemyAttackTimer);
            allTimers.Add(PlayerAttackTimer);
            allTimers.Add(ProjectileMoveTimer);
            allTimers.Add(timerMoveLeft);
            allTimers.Add(timerMoveRight);
            allTimers.Add(timerMoveUp);
            allTimers.Add(timerMoveDown);
            EnemySpawnTimer.Start();
            EnemyMoveTimer.Start();
            EnemyAttackTimer.Start();
            PlayerAttackTimer.Start();
            ProjectileMoveTimer.Start();
            isGameEnded = false;
        }

        public void EndGame()
        {
            foreach (var timer in allTimers)
            {
                timer.Stop();
            }
            isGameEnded = true;
        }
    }
}
