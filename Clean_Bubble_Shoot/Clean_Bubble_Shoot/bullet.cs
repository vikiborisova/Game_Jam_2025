using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Clean_Bubble_Shoot
{
    internal class bullet
    {

        public string direction;
        public int speed = 20;
        PictureBox Bullet = new PictureBox();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public int bulletLeft;
        public int bulletTop;

        public void mkBullet(Form form)
        {
            Bullet.BackColor = System.Drawing.Color.White;
            Bullet.Size = new Size(5, 5);
            Bullet.Tag = "bullet";
            Bullet.Left = bulletLeft;
            Bullet.Top = bulletTop;
            Bullet.BringToFront();
            form.Controls.Add(Bullet);

            timer.Interval = speed;
            timer.Tick += new EventHandler(tm_Tick);
            timer.Start();
        }
        public void tm_Tick(object sender, EventArgs e)
        {

            if (direction == "left")
            {
                Bullet.Left -= speed;
            }

            if (direction == "right")
            {
                Bullet.Left += speed;
            }

            if (direction == "up")
            {
                Bullet.Top -= speed;
            }

            if (direction == "down")
            {
                Bullet.Top += speed;
            }
            if (Bullet.Left < 16 || Bullet.Left > 860 || Bullet.Top < 10 || Bullet.Top > 616)
            {
                timer.Stop();
                timer.Dispose();
                Bullet.Dispose();
                timer = null;
                Bullet = null;
            }
        }
    }
}
