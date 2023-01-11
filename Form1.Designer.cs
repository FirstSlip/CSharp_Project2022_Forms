
namespace CSharpProject
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPlayer = new System.Windows.Forms.PictureBox();
            this.timerMoveUp = new System.Windows.Forms.Timer(this.components);
            this.timerMoveDown = new System.Windows.Forms.Timer(this.components);
            this.timerMoveLeft = new System.Windows.Forms.Timer(this.components);
            this.timerMoveRight = new System.Windows.Forms.Timer(this.components);
            this.EnemySpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.HpBarBorder = new System.Windows.Forms.Panel();
            this.HpBar = new System.Windows.Forms.Panel();
            this.EnemyAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.ProjectileMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.labelBuff = new System.Windows.Forms.Label();
            this.timerBuff = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).BeginInit();
            this.HpBarBorder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPlayer
            // 
            this.mainPlayer.BackColor = System.Drawing.Color.Transparent;
            this.mainPlayer.Image = global::CSharpProject.Properties.Resources.player_front;
            this.mainPlayer.Location = new System.Drawing.Point(765, 488);
            this.mainPlayer.Name = "mainPlayer";
            this.mainPlayer.Size = new System.Drawing.Size(25, 71);
            this.mainPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPlayer.TabIndex = 0;
            this.mainPlayer.TabStop = false;
            // 
            // timerMoveUp
            // 
            this.timerMoveUp.Interval = 20;
            this.timerMoveUp.Tick += new System.EventHandler(this.timerMoveUp_Tick);
            // 
            // timerMoveDown
            // 
            this.timerMoveDown.Interval = 20;
            this.timerMoveDown.Tick += new System.EventHandler(this.timerMoveDown_Tick);
            // 
            // timerMoveLeft
            // 
            this.timerMoveLeft.Interval = 20;
            this.timerMoveLeft.Tick += new System.EventHandler(this.timerMoveLeft_Tick);
            // 
            // timerMoveRight
            // 
            this.timerMoveRight.Interval = 20;
            this.timerMoveRight.Tick += new System.EventHandler(this.timerMoveRight_Tick);
            // 
            // EnemySpawnTimer
            // 
            this.EnemySpawnTimer.Interval = 3000;
            this.EnemySpawnTimer.Tick += new System.EventHandler(this.EnemySpawnTimer_Tick);
            // 
            // EnemyMoveTimer
            // 
            this.EnemyMoveTimer.Interval = 20;
            this.EnemyMoveTimer.Tick += new System.EventHandler(this.EnemyMoveTimer_Tick);
            // 
            // HpBarBorder
            // 
            this.HpBarBorder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.HpBarBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HpBarBorder.Controls.Add(this.HpBar);
            this.HpBarBorder.Location = new System.Drawing.Point(13, 14);
            this.HpBarBorder.Name = "HpBarBorder";
            this.HpBarBorder.Size = new System.Drawing.Size(204, 44);
            this.HpBarBorder.TabIndex = 1;
            // 
            // HpBar
            // 
            this.HpBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.HpBar.Location = new System.Drawing.Point(0, 0);
            this.HpBar.Name = "HpBar";
            this.HpBar.Size = new System.Drawing.Size(200, 40);
            this.HpBar.TabIndex = 2;
            // 
            // EnemyAttackTimer
            // 
            this.EnemyAttackTimer.Interval = 500;
            this.EnemyAttackTimer.Tick += new System.EventHandler(this.EnemyAttackTimer_Tick);
            // 
            // PlayerAttackTimer
            // 
            this.PlayerAttackTimer.Interval = 1500;
            this.PlayerAttackTimer.Tick += new System.EventHandler(this.PlayerAttackTimer_Tick);
            // 
            // ProjectileMoveTimer
            // 
            this.ProjectileMoveTimer.Interval = 20;
            this.ProjectileMoveTimer.Tick += new System.EventHandler(this.ProjectileMoveTimer_Tick);
            // 
            // labelBuff
            // 
            this.labelBuff.BackColor = System.Drawing.Color.Transparent;
            this.labelBuff.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBuff.ForeColor = System.Drawing.Color.Black;
            this.labelBuff.Location = new System.Drawing.Point(14, 61);
            this.labelBuff.Name = "labelBuff";
            this.labelBuff.Size = new System.Drawing.Size(307, 118);
            this.labelBuff.TabIndex = 2;
            // 
            // timerBuff
            // 
            this.timerBuff.Interval = 4000;
            this.timerBuff.Tick += new System.EventHandler(this.timerBuff_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.HpBarBorder);
            this.panel1.Controls.Add(this.labelBuff);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 186);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CSharpProject.Properties.Resources.floor;
            this.ClientSize = new System.Drawing.Size(1584, 961);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPlayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).EndInit();
            this.HpBarBorder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPlayer;
        private System.Windows.Forms.Timer timerMoveUp;
        private System.Windows.Forms.Timer timerMoveDown;
        private System.Windows.Forms.Timer timerMoveLeft;
        private System.Windows.Forms.Timer timerMoveRight;
        private System.Windows.Forms.Timer EnemySpawnTimer;
        private System.Windows.Forms.Timer EnemyMoveTimer;
        private System.Windows.Forms.Panel HpBarBorder;
        private System.Windows.Forms.Panel HpBar;
        private System.Windows.Forms.Timer EnemyAttackTimer;
        private System.Windows.Forms.Timer PlayerAttackTimer;
        private System.Windows.Forms.Timer ProjectileMoveTimer;
        private System.Windows.Forms.Label labelBuff;
        private System.Windows.Forms.Timer timerBuff;
        private System.Windows.Forms.Panel panel1;
    }
}

