using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace squareChaser
{
    public partial class Form1 : Form
    {
        Random randGen =  new Random();

        Rectangle player1 = new Rectangle(20, 200, 20, 20);
        Rectangle player2 = new Rectangle(560, 200, 20, 20);
        Rectangle pointSquare = new Rectangle(295, 160, 15, 15);
        

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;
        int ballXSpeed = 6;
        int ballYSpeed = -6;

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
        Pen boarderPen = new Pen(Color.Blue, 10);

        public Form1()
        {
            InitializeComponent();
            Rectangle boarder = new Rectangle(10, 40, this.Width - 20, this.Height - 50);
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
            if (wDown == true && player1.Y >= 17)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X >= 17)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }
            
            //move player 2 
            if (upArrowDown == true && player2.Y >= 17)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && player2.X >= 17)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //if statement if player gets white square, add point. change location
            if (player1.IntersectsWith(pointSquare))
            {
                int x = randGen.Next(16, 580);
                int y = randGen.Next(41, 350);
                pointSquare.Location = new Point(x, y);
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
            }
            else if (player2.IntersectsWith(pointSquare))
            {
                int x = randGen.Next(16, 580);
                int y = randGen.Next(41, 350);
                pointSquare.Location = new Point(x, y);
                player2Score++;
                p2ScoreLabel.Text = $"{player1Score}";
            }

            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }

            //Move speed point, up speed of player when hit

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(boarderPen, boarder.X, boarder.Y, boarder.Width, boarder.Height);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, pointSquare);
            e.Graphics.FillEllipse(violetBrush, 290, 180, 15, 15);

            //if statement for drawing pointSquare when player starts moving
        }
    }
}
