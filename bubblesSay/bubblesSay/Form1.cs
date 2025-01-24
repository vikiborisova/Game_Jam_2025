using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bubblesSay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
        1 - червено
        2 - жълто
        3 - зелено
        4 - аква
        5 - синьо
        6 - лилаво
         */

        List<int> bubbleSort = new List<int>();
        int level = -1;
        int clickCount = -1;
        List<Control> controlList;
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Играта започва!");
            controlList = new List<Control> { basic1, basic2, basic3, basic4, basic5, basic6 };
            startLevel();
        }

        private async void startLevel()
        {
            level++;
            if(level == 10)
            {
                MessageBox.Show("Спечелихте играта!");
                return;
            }
            lvlLbl.Text = "Ниво: " + (level+1).ToString();
            clickCount = -1;

            await Task.Delay(1000);
            Random randomBbl = new Random();
            int bubbleNum = randomBbl.Next(1, 7);
            bubbleSort.Add(bubbleNum);

            foreach (int i in bubbleSort)
            {
                controlList[i - 1].Visible = false;
                controlList[i-1].Visible = false;
                await Task.Delay(1000);

                controlList[i-1].Visible = true;
                await Task.Delay(500);
            }
        }

        private void newGame()
        {
            level = -1;
            clickCount = -1;
            bubbleSort.Clear();
            foreach(Control control in controlList)
            {
                control.Visible = true;
            }
            startLevel();

        }

        private async void basic1_Click(object sender, EventArgs e)
        {
            controlList[0].Visible = false;
            await Task.Delay(1000);

            controlList[0].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 1)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }

        private async void basic2_Click(object sender, EventArgs e)
        {
            controlList[1].Visible = false;
            await Task.Delay(1000);

            controlList[1].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 2)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }

        private async void basic3_Click(object sender, EventArgs e)
        {
            controlList[2].Visible = false;
            await Task.Delay(1000);

            controlList[2].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 3)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }

        private async void basic4_Click(object sender, EventArgs e)
        {
            controlList[3].Visible = false;
            await Task.Delay(1000);

            controlList[3].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 4)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }

        private async void basic5_Click(object sender, EventArgs e)
        {
            controlList[4].Visible = false;
            await Task.Delay(1000);

            controlList[4].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 5)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }

        private async void basic6_Click(object sender, EventArgs e)
        {
            controlList[5].Visible = false;
            await Task.Delay(1000);

            controlList[5].Visible = true;

            clickCount++;
            if (bubbleSort[clickCount] != 6)
            {
                MessageBox.Show("Загубихте!");
                newGame();
                return;
            }

            if ((clickCount + 1) == bubbleSort.Count)
            {
                startLevel();
            }
        }
    }
}
