using System.Drawing;
using System.Windows.Forms;

namespace Clean_Bubble_Shoot
{

    public partial class Clean_Bubble_Shoot : Form
    {

        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        string facing = "up";
        double playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int dishSpeed = 2;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();
        public Clean_Bubble_Shoot()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                facing = "up";
                goup = true;
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                facing = "down";
                godown = true;
                player.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                shoot(facing);
                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                progressBar1.Value = Convert.ToInt32(playerHealth);
            }
            else
            {
                player.Image = Properties.Resources.dead;
                timer.Stop();
                gameOver = true;
                MessageBox.Show("You are dead!");
                this.Close();
            }

            lblAmmo.Text = "   Ammo:  " + ammo;
            lblKills.Text = "Kills: " + score;
            if (playerHealth < 20)
            {
                progressBar1.ForeColor = System.Drawing.Color.Red;
            }

            if (goleft && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goright && player.Left + player.Width < 1366)
            {
                player.Left += speed;
            }
            if (goup && player.Top > 60)
            {
                player.Top -= speed;
            }

            if (godown && player.Top + player.Height < 768)
            {
                player.Top += speed;
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && x.Tag == "ammo")
                {

                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x));

                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if (x is PictureBox && x.Tag == "bullet")
                {
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 1366 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 768)
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                if (x is PictureBox && x.Tag == "dish")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= dishSpeed;
                        ((PictureBox)x).Image = Properties.Resources._21;
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= dishSpeed;
                        ((PictureBox)x).Image = Properties.Resources._21;
                        if (((PictureBox)x).Left < player.Left)
                        {
                            ((PictureBox)x).Left += dishSpeed;
                            ((PictureBox)x).Image = Properties.Resources._21;
                        }
                        if (((PictureBox)x).Top < player.Top)
                        {
                            ((PictureBox)x).Top += dishSpeed;
                            ((PictureBox)x).Image = Properties.Resources._21;
                        }
                    }
                    foreach (Control j in this.Controls)
                    {

                        if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "dish"))
                        {

                            if (x.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(j);
                                j.Dispose();
                                this.Controls.Remove(x);
                                x.Dispose();
                                makeEnemy();
                            }
                        }
                    }
                }
            }
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }

        private void shoot(string direct)
        {
            bullet shoot = new bullet();
            shoot.direction = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            shoot.mkBullet(this);
        }

        private int dishIndex = 0;
        private void makeEnemy()
        {
            Image[] dishImages =
            {
                Properties.Resources._21,
                Properties.Resources._31,
                Properties.Resources._41
            };

            Image selectedImage = dishImages[dishIndex];
            dishIndex = (dishIndex + 1) % dishImages.Length;

            PictureBox dish = new PictureBox();
            dish.Tag = "dish";
            dish.Image = selectedImage; 
            dish.Left = rnd.Next(0, 900); 
            dish.Top = rnd.Next(0, 800); 
            dish.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(dish);
            player.BringToFront();
        }
    }
}