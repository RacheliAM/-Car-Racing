using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game
{
    public partial class Game : Form
    {
        Random r = new Random();
        int x;
        int gameSpead = 0;
        int collectCoins = 0;
        public Game()
        {
            InitializeComponent();
            GameOver.Visible = false;
            exitGame.Visible = false;
            newGame.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveLine(gameSpead);
            Enemy(gameSpead);
            gameOver();
            Coins(gameSpead);
            CoinsCollection();

        }
        private void MoveLine(int speed)
        {
            if (pictureBox1.Top >= 500)
            { pictureBox1.Top = 0; }
            else { pictureBox1.Top += speed; }

            if (pictureBox2.Top >= 500)
            { pictureBox2.Top = 0; }
            else { pictureBox2.Top += speed; }

            if (pictureBox3.Top >= 500)
            { pictureBox3.Top = 0; }
            else { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 500)
            { pictureBox4.Top = 0; }
            else { pictureBox4.Top += speed; }
        }
        private void Enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(0, 200);
                enemy1.Location = new Point(x, 0);
            }
            else
            {
                enemy1.Top += speed;
            }

            if (enemy2.Top >= 500)
            {
                x = r.Next(0, 300);
                enemy2.Location = new Point(x, 0);
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 500)
            {
                x = r.Next(0, 300);
                enemy3.Location = new Point(x, 0);
            }
            else
            {
                enemy3.Top += speed;
            }

        }
        private void Coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(0, 200);
                coin1.Location = new Point(x, 0);
            }
            else
            {
                coin1.Top += speed;
            }

            if (coin2.Top >= 500)
            {
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }
            else
            {
                coin2.Top += speed;
            }

            if (coin3.Top >= 500)
            {
                x = r.Next(0, 200);
                coin3.Location = new Point(x, 0);
            }
            else
            {
                coin3.Top += speed;
            }

            if (coin4.Top >= 500)
            {
                x = r.Next(0, 200);
                coin4.Location = new Point(x, 0);
            }
            else
            {
                coin4.Top += speed;
            }
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            //Moving the vehicle, controlling the vehicle
            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 0)
                    car.Left += -8;

            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Right < 250)
                    car.Left += 8;
            }

            if (e.KeyCode == Keys.Up) //Vehicle speed control, fast
            {
                if (gameSpead < 21)
                {
                    gameSpead++;
                }
            }
            if (e.KeyCode == Keys.Down) //Control the vehicle speed, lower
            {
                if (gameSpead > 0)
                {
                    gameSpead--;
                }
            }


        }
        private void gameOver()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                exitGame.Visible = true;
                newGame.Visible = true;
            }

            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                exitGame.Visible = true;
                newGame.Visible = true;

            }

            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                exitGame.Visible = true;
                newGame.Visible = true;

            }
        }
        private void CoinsCollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectCoins++;
                Coinslabel.Text = "Coins = " + collectCoins.ToString();
                x = r.Next(0, 200);
                coin1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectCoins++;
                Coinslabel.Text = "Coins = " + collectCoins.ToString();
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectCoins++;
                Coinslabel.Text = "Coins = " + collectCoins.ToString();
                x = r.Next(0, 200);
                coin3.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectCoins++;
                Coinslabel.Text = "Coins = " + collectCoins.ToString();
                x = r.Next(0, 200);
                coin4.Location = new Point(x, 0);
            }
        }
        private void ExitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NewGame_Click(object sender, EventArgs e)
        {
            gameSpead = 0;
            collectCoins = 0;
            this.Controls.Clear();
            InitializeComponent();
            GameOver.Visible = false;
            exitGame.Visible = false;
            newGame.Visible = false;
        }

   
    }
}