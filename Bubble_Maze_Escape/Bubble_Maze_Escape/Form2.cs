using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Bubble_Maze_Escape
{
    public partial class Bubble_Maze_Escape_Medium : Form
    {

        private const int MoveStep = 5;
        private int timeLeft = 60;
        private System.Timers.Timer gameTimer;
        public Bubble_Maze_Escape_Medium()
        {
            InitializeComponent();

            gameTimer = new System.Timers.Timer(1000);
            gameTimer.Elapsed += OnTimerTick;
            gameTimer.Start();

            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private bool IsCollidingWithWalls(Point newLocation)
        {
            Rectangle newBounds = new Rectangle(newLocation, ballon.Size);

            foreach (Control wall in wallsPanel.Controls)
            {
                if (wall is Panel && newBounds.IntersectsWith(wall.Bounds))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInsideMazePanel(Point newLocation)
        {
            Rectangle balloonBounds = new Rectangle(newLocation, ballon.Size);

            return wallsPanel.ClientRectangle.Contains(balloonBounds);
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            if (!gameTimer.Enabled || !this.IsHandleCreated)
            {
                return;
            }

            timeLeft--;
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                Invoke(new Action(() => GameOver("Time's up! You lost.")));
            }
            else
            {
                Invoke(new Action(() => timerLabel.Text = $"Time Left: {timeLeft}"));
            }
        }


        private void GameOver(string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "Game Over");
            this.Close();
            //Program.SwitchMainForm(new Bubble_Maze_Escape_Hard());
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Point newLocation = ballon.Location;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    newLocation.Y -= MoveStep;
                    break;
                case Keys.Down:
                    newLocation.Y += MoveStep;
                    break;
                case Keys.Left:
                    newLocation.X -= MoveStep;
                    break;
                case Keys.Right:
                    newLocation.X += MoveStep;
                    break;
            }

            if (IsCollidingWithWalls(newLocation))
            {
                GameOver("You touched a wall! Game Over.");
            }
            else if (!IsInsideMazePanel(newLocation))
            {
                GameOver("You moved outside the maze! Game Over.");
            }
            else
            {
                ballon.Location = newLocation;
            }

            if (ballon.Bounds.IntersectsWith(goal.Bounds))
            {
                GameOver("You Win! Congratulations");
            }
        }
    }
}
