namespace Bubble_Pop_Challenge
{
    public partial class Bubble_Pop_Challenge : Form
    {

        private Random random = new Random();
        private int score = 0;
        public Bubble_Pop_Challenge()
        {
            InitializeComponent();
        }

        private void Bubble_Pop_Challenge_Load(object sender, EventArgs e)
        {
            lblScore.Location = new Point(10, 10);
            pictureBox1.SendToBack();
            pictureBox2.SendToBack();
            pictureBox3.SendToBack();
            pictureBox4.SendToBack();
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (random.Next(0, 20) == 0)
            {
                CreateBubble();
            }
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Tag != null && pictureBox.Tag.ToString() == "bubble")
                {
                    pictureBox.Top -= 7;
                    if (pictureBox.Top < 0)
                    {
                        gameTimer.Stop();
                        MessageBox.Show("Game Over! Final Score: " + score);
                        Application.Exit();
                    }
                }
            }
        }

        private void CreateBubble()
        {
            PictureBox bubble = new PictureBox
            {
                Width = 100,
                Height = 100,
                BackColor = Color.Transparent,
                Image = Properties.Resources.ballon,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Left = random.Next(0, this.ClientSize.Width - 50),
                Top = this.ClientSize.Height,
                Tag = "bubble"
            };
            bubble.Click += Bubble_Click;
            this.Controls.Add(bubble);
            bubble.BringToFront();
        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            PictureBox bubble = sender as PictureBox;
            if (bubble != null)
            {
                this.Controls.Remove(bubble);
                score++;
                
                lblScore.Text = "Score: " + score;
            }
        }

    }
}