namespace Match_Bubble_Types
{
    public partial class Match_Bubble_Types : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        string firstChoice;
        string secondChoice;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 60;
        int countDownTime;
        bool gameOver = false;
        public Match_Bubble_Types()
        {
            InitializeComponent();
            LoadPictures();
        }

        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = "Time Left: " + countDownTime;
            if (countDownTime < 1)
            {
                GameOver("Times Up, You Lose");
                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                    }
                }
            }
        }

        private void LoadPictures()
        {
            int leftPos = 40;
            int topPos = 40;
            int rows = 0;
            for (int i = 0; i < 12; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 100;
                newPic.Width = 100;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);
                if (rows < 3)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 120;
                }
                if (rows == 3)
                {
                    leftPos = 40;
                    topPos += 120;
                    rows = 0;
                }
            }
            RestartGame();
        }

        private void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            PictureBox clickedPic = sender as PictureBox;

            if (clickedPic.Tag == null || clickedPic.Image != null) return;

            clickedPic.Image = Image.FromFile("pics/" + (string)clickedPic.Tag + ".png");

            if (firstChoice == null)
            {
                picA = clickedPic;
                firstChoice = (string)picA.Tag;
            }
            else if (secondChoice == null)
            {
                picB = clickedPic;
                secondChoice = (string)picB.Tag;

                Task.Delay(500).ContinueWith(t =>
                {
                    this.Invoke(new Action(() => CheckPictures(picA, picB)));
                });
            }
        }



        private void RestartGame()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }

            lblTimeLeft.Text = "Time Left: " + totalTime;
            firstChoice = null;
            secondChoice = null;
            gameOver = false;
            GameTimer.Start();
            countDownTime = totalTime;

        }


        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                A.Image = null;
                B.Image = null;
            }

            firstChoice = null;
            secondChoice = null;

            if (pictures.All(p => p.Tag == null))
            {
                GameOver("Great Work, You Win!!!!");
            }

        }
        private void GameOver(string msg)
        {
            GameTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Click Restart to Play Again.");
        }
    }
}