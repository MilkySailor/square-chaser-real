using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace square_chaser_real
{
    public partial class squareChaser : Form
    {
        Random TeleporterXRan = new Random();
        Random pointYRan = new Random();
        Random pointXRan = new Random();
        Random speedBoostXRan = new Random();
        Random speedBoostYRan = new Random();

        Rectangle player1 = new Rectangle(120, 210, 20, 20);
        Rectangle player2 = new Rectangle(240, 120, 20, 20);
        Rectangle point = new Rectangle(295, 195, 10, 10);
        Rectangle speedBoost = new Rectangle(130, 170, 10, 10);
        Rectangle border = new Rectangle(4, 5,575,552);
        Rectangle teleporter = new Rectangle(380, 280, 15, 15);
        
        int player1Score = 0;
        int player2Score = 0;
        int P1timerticks = 0;
        int P2timerticks = 0;   

        int player1Speed = 6;
        int player2Speed = 6;
        int speedBoostTime = 0;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush redBrush = new SolidBrush(Color.DarkRed);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.ForestGreen);
        Pen Pen = new Pen(Color.CornflowerBlue, 10);
        Pen tele = new Pen(Color.Purple, 3);
        public squareChaser()
        {
            InitializeComponent();
        }

        private void squareChaser_KeyDown(object sender, KeyEventArgs e)
        {
            //movement
            switch (e.KeyCode)
            {
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void squareChaser_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void squareChaser_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawRectangle(Pen, border);
            e.Graphics.FillEllipse(blueBrush, player1);
            e.Graphics.FillEllipse(redBrush, player2);
            e.Graphics.FillRectangle(greenBrush, point);
            e.Graphics.FillEllipse(yellowBrush, speedBoost);
            e.Graphics.DrawRectangle(tele, teleporter);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //p1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }
            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }
            //p2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }
            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }
            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }


            //check if either player has interacted with anything
            if (player1.IntersectsWith(point))
            {
                player1Score++;
                pointXRan.Next(1, 580);
                pointYRan.Next(1, 580);
                point.X = pointXRan.Next(1, 530);
                point.Y = pointXRan.Next(1, 530);

            }
            if (player2.IntersectsWith(point))
            {
                player2Score++;
                point.X = pointXRan.Next(1, 530);
                point.Y = pointXRan.Next(1, 530);
            }
            if(player1.IntersectsWith(speedBoost))
            {
                speedBoost.Y = speedBoostYRan.Next(1, 580);
                speedBoost.X = speedBoostXRan.Next(1, 580);
                player1Speed = 12;

                P1speedBoostTimer.Enabled = true;
            }
            if (player2.IntersectsWith(speedBoost))
            {
                speedBoost.Y = speedBoostYRan.Next(1, 580);
                speedBoost.X = speedBoostXRan.Next(1, 580);
                player2Speed = 12;
                
                P2speedBoostTimer.Enabled =true;
            }
            if(player1.IntersectsWith(teleporter))
            {
                teleporter.X = TeleporterXRan.Next(30, 530);
                teleporter.Y = TeleporterXRan.Next(30, 530);
                
                player1.Y = TeleporterXRan.Next(30, 530);
                player1.X = TeleporterXRan.Next(30, 530);
            }
            if (player2.IntersectsWith(teleporter))
            {
                teleporter.X = TeleporterXRan.Next(30, 530);
                teleporter.Y = TeleporterXRan.Next(30, 530);
                
                player2.Y = TeleporterXRan.Next(30, 530);
                player2.X = TeleporterXRan.Next(30, 530);
            }

            //score
            p1ScoreLabel.Text = $"{player1Score}";
            p2ScoreLabel.Text = $"{player2Score}";
            if(player1Score == 7)
            {
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!!";
                gameTimer.Enabled = false;
            }
            if (player2Score == 7)
            {
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!!";
                gameTimer.Enabled = false;
            }

            // wall teleports player 1
            if (player1.X < 9)
            {
                player1.X = this.Width - 30;
            }
            if(player1.X > this.Width - 30)
            {
                player1.X = 9;
            }
            if(player1.Y < 9)
            {
                player1.Y = this.Height - 30;
            }
            if (player1.Y > this.Height - 30)
            {
                player1.Y = 9;
            }

            //wall teleports player 2
            if (player2.X < 9)
            {
                player2.X = this.Width - 30;
            }
            if (player2.X > this.Width - 30)
            {
                player2.X = 9;
            }
            if (player2.Y < 9)
            {
                player2.Y = this.Height - 30;
            }
            if (player2.Y > this.Height - 30)
            {
                player2.Y = 9;
            }

            Refresh();
        }

        private void P1speedBoostTimer_Tick(object sender, EventArgs e)
        {
            P1timerticks++;

            if(P1timerticks > 5)
            {
                player1Speed = 6;
                P1timerticks = 0;
                P1speedBoostTimer.Enabled = false;
            }
        }

        private void P2speedBoostTimer_Tick(object sender, EventArgs e)
        {
            P2timerticks++;

            if(P2timerticks > 5)
            {
                player2Speed = 6;
                P2timerticks = 0;
                P2speedBoostTimer.Enabled = false;
            }
        }
    }
}
