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
            PositionControls();
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
            int pictureSize = 100;
            int spacing = 20; 
            int columns = 3; 
            int rows = 4;  

            int totalWidth = (pictureSize + spacing) * columns - spacing;
            int totalHeight = (pictureSize + spacing) * rows - spacing;

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight - 100) / 2;

            pictures.Clear();
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                this.Controls.Remove(control);
            }

            int leftPos = startX;
            int topPos = startY;

            for (int i = 0; i < 12; i++)
            {
                PictureBox newPic = new PictureBox
                {
                    Height = pictureSize,
                    Width = pictureSize,
                    BackColor = Color.LightGray,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Left = leftPos,
                    Top = topPos
                };
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);
                this.Controls.Add(newPic);

                leftPos += pictureSize + spacing;

                if ((i + 1) % columns == 0)
                {
                    leftPos = startX;
                    topPos += pictureSize + spacing;
                }
            }

            RestartGame();
        }

        private void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            PictureBox clickedPic = sender as PictureBox;

            if (clickedPic.Tag == null || clickedPic.Image != null) return;

            if (firstChoice == null || secondChoice == null)
            {
                clickedPic.Image = Image.FromFile("pics/" + (string)clickedPic.Tag + ".png");
            }

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

        private void PositionControls()
        {
            btnRestart.Left = ((this.ClientSize.Width - btnRestart.Width) / 2) - 90;
            btnRestart.Top = this.ClientSize.Height - 60;

            lblTimeLeft.Left = btnRestart.Left + btnRestart.Width;
            lblTimeLeft.Top = btnRestart.Top + (btnRestart.Height - lblTimeLeft.Height) / 2;
        }

        private void Match_Bubble_Types_Load(object sender, EventArgs e)
        {

        }

        private void lblTimeLeft_Click(object sender, EventArgs e)
        {

        }
    }
}