using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace squareChaser
{
    //Abbey Catcher
    //May 3rd, 2022
    //Square chaser (Summative)

    public partial class Form1 : Form
    {
        Random randGen =  new Random();

        Rectangle player1 = new Rectangle(20, 200, 20, 20);
        Rectangle player2 = new Rectangle(560, 200, 20, 20);
        Rectangle pointSquare = new Rectangle(295, 160, 15, 15);
        Rectangle speedPoint = new Rectangle(295, 180, 15, 15);


        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush violetBrush = new SolidBrush(Color.Violet);
        Pen boarderPen = new Pen(Color.YellowGreen, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    sDown = false;
                    aDown = false;
                    dDown = false;
                    break;
                case Keys.S:
                    sDown = true;
                    wDown = false;
                    aDown = false;
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = true;
                    wDown = false;
                    sDown = false;
                    dDown = false;
                    break;
                case Keys.D:
                    dDown = true;
                    wDown = false;
                    sDown = false;
                    aDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    downArrowDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    upArrowDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    upArrowDown = false;
                    downArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    upArrowDown = false;
                    downArrowDown = false;
                    leftArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            //move player 1
            if (wDown == true && player1.Y >= 48)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < (this.Height - 20) - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X >= 19)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < (this.Width - 19) - player1.Width)
            {
                player1.X += playerSpeed;
            }
            
            //move player 2 
            if (upArrowDown == true && player2.Y >= 48)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < (this.Height - 20) - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && player2.X >= 19)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && player2.X < (this.Width - 19) - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //if statement if player gets white square, add point, change location
            if (player1.IntersectsWith(pointSquare))
            {
                int pointSquarex = randGen.Next(16, 580);
                int pointSquarey = randGen.Next(41, 350);
                pointSquare.Location = new Point(pointSquarex, pointSquarey);
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources._353497__matteshaus__metall_tischbein);
                pointPlayer.Play();
            }
            else if (player2.IntersectsWith(pointSquare))
            {
                int pointSquarex = randGen.Next(16, 580);
                int pointSquarey = randGen.Next(41, 350);
                pointSquare.Location = new Point(pointSquarex, pointSquarey);
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                SoundPlayer pointPlayer2 = new SoundPlayer(Properties.Resources._353497__matteshaus__metall_tischbein);
                pointPlayer2.Play();
            }

            //Move speed point, up speed of player when hit
            if (player1.IntersectsWith(speedPoint))
            {
                int speedPointx = randGen.Next(16, this.Width - 20);
                int speedPointy = randGen.Next(41, this.Height - 50);
                speedPoint.Location = new Point(speedPointx, speedPointy);
                if (playerSpeed < 7)
                {
                    playerSpeed++;
                }
                SoundPlayer speedPlayer = new SoundPlayer(Properties.Resources._341227__jeremysykes__powerup);
                speedPlayer.Play();
            }
            else if (player2.IntersectsWith(speedPoint))
            {
                int speedPointx = randGen.Next(16, this.Width - 20);
                int speedPointy = randGen.Next(41, this.Height - 50);
                speedPoint.Location = new Point(speedPointx, speedPointy);
                if (playerSpeed < 7)
                {
                    playerSpeed++;
                }
                SoundPlayer speedPlayer2 = new SoundPlayer(Properties.Resources._341227__jeremysykes__powerup);
                speedPlayer2.Play();
            }

            //player reaches 10 points, win
            if (player1Score == 10)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                SoundPlayer winPlayer = new SoundPlayer(Properties.Resources._270319__littlerobotsoundfactory__jingle_win_01__1_);
                winPlayer.Play();
            }
            else if (player2Score == 10)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                SoundPlayer winPlayer2 = new SoundPlayer(Properties.Resources._270319__littlerobotsoundfactory__jingle_win_01__1_);
                winPlayer2.Play();
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draws boarder
            e.Graphics.DrawRectangle(boarderPen, 10, 40, this.Width - 20, this.Height - 50);

            //Draws players and points (Score and speed)
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, pointSquare);
            e.Graphics.FillEllipse(violetBrush, speedPoint);
        }
    }
}
