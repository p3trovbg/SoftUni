using SnakeGame.src;
using SnakeGame.src.Commons;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameForm : Form
    {
        private Settings settings;
        private ISnake snake;
        private IPlayer player;
        private CircleItem food;
        private Random rand;
        public GameForm()
        {
            InitializeComponent();
            KeyPreview = true;
            snake = new Snake();
            settings = new Settings();
            player = new Player();
            rand = new Random();
            food = new CircleItem();
        }

        private void StartGame(object sender, EventArgs e)
        {
            SetInitialSettings();
            SetPlayerName();
            gameTimer.Start();
        }


        private void StopGame(object sender, EventArgs e)
        {

        }


        private void UpdatePictureBox(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for (int i = 0; i < snake.SnakeItems.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.DarkOrange;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    snake.SnakeItems[i].X * settings.Width,
                    snake.SnakeItems[i].Y * settings.Height,
                    settings.Width, settings.Height
                    ));
            }


            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * settings.Width,
            food.Y * settings.Height,
            settings.Width, settings.Height
            ));
        }

        private void KeysDown(object sender, KeyEventArgs e)
        {
            snake.Move(e);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            for (int i = snake.SnakeItems.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {

                    switch (snake.Direction)
                    {
                        case Directions.Left:
                            snake.SnakeItems[i].X--;
                            break;
                        case Directions.Right:
                            snake.SnakeItems[i].X++;
                            break;
                        case Directions.Down:
                            snake.SnakeItems[i].Y++;
                            break;
                        case Directions.Up:
                            snake.SnakeItems[i].Y--;
                            break;
                    }

                    if (snake.SnakeItems[i].X < 0)
                    {
                        snake.SnakeItems[i].X = settings.MaxWidth;
                    }
                    if (snake.SnakeItems[i].X > settings.MaxWidth)
                    {
                        snake.SnakeItems[i].X = 0;
                    }
                    if (snake.SnakeItems[i].Y < 0)
                    {
                        snake.SnakeItems[i].Y = settings.MaxHeight;
                    }
                    if (snake.SnakeItems[i].Y > settings.MaxHeight)
                    {
                        snake.SnakeItems[i].Y = 0;
                    }


                    if (snake.SnakeItems[i].X == food.X &&
                        snake.SnakeItems[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < snake.SnakeItems.Count; j++)
                    {

                        if (snake.SnakeItems[i].X == snake.SnakeItems[j].X &&
                            snake.SnakeItems[i].Y == snake.SnakeItems[j].Y)
                        {
                            gameTimer.Stop();
                            SetInitialSettings();                       }
                    }
                }
                else
                {
                    snake.SnakeItems[i].X = snake.SnakeItems[i - 1].X;
                    snake.SnakeItems[i].Y = snake.SnakeItems[i - 1].Y;
                }
            }
            Map.Invalidate();
        }

        private void EatFood()
        {
            player.Score += 10;

            txtScore.Text = "Score: " + player.Score;

            var body = new CircleItem
            {
                X = snake.SnakeItems[snake.SnakeItems.Count - 1].X,
                Y = snake.SnakeItems[snake.SnakeItems.Count - 1].Y
            };

            snake.SnakeItems.Add(body);

            food = new CircleItem { X = rand.Next(2, settings.MaxWidth), Y = rand.Next(2, settings.MaxHeight) };
        }

        private void InputName(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(inputName.Text))
            {
                player.Name = inputName.Text;
                inputName.Enabled = true;
            }
        }

        private void SetPlayerName()
        {
            if (string.IsNullOrEmpty(inputName.Text))
            {
                txtInputName.Text = "You should add your nickname.";
                StartButton.Enabled = true;
                return;
            }
            else
            {
                txtPlayerName.Text = player.Name;
                txtPlayerName.Visible = true;
                txtInputName.Visible = false;
                inputName.Visible = false;
            }
        }

        private void SetInitialSettings()
        {
            settings.MaxWidth = Map.Width / settings.Width - 1;
            settings.MaxHeight = Map.Height / settings.Height - 1;

            StartButton.Enabled = false;

            player.Score = 0;
        }
    }
}
