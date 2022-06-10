using SnakeGame.src;
using SnakeGame.src.Commons;
using System;
using System.Drawing;
using System.Windows.Documents;
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
            StartButton.Enabled = false;
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
            gameTimer.Start();
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
                            RestartGame();
                        }
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

        private void RestartGame()
        {
            gameTimer.Stop();
            applyNameButton.Visible = true;
            SetInitialSettings();
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

            food = new CircleItem 
            { 
                X = rand.Next(2, settings.MaxWidth),
                Y = rand.Next(2, settings.MaxHeight) 
            };
        }

        private void SetInitialSettings()
        {
            settings.MaxWidth = Map.Width / settings.Width - 1;
            settings.MaxHeight = Map.Height / settings.Height - 1;

            StartButton.Enabled = false;

            player.Score = 0;
        }

        private void NameButton(object sender, EventArgs e)
        {
            if(fieldNickname.Text != string.Empty)
            {
                fieldNickname.BorderStyle = BorderStyle.None;
                fieldNickname.ReadOnly = true;
                fieldNickname.BackColor = Color.White;
                applyNameButton.Visible = false;
                StartButton.Enabled = true;
            }
        }
    }
}
