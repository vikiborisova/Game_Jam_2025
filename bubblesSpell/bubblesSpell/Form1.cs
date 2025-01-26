using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bubblesSpell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         1. Дъвка
         2. Балон
         3. Сапун
         4. Текст
         5. Мехур
         6. Пукам
         7. Сфера
         */

        List<string> words = new List<string> { "ДЪВКА", "БАЛОН", "САПУН", "МЕХУР", "ПУКАМ", "СФЕРА" };

        List<string> letters = new List<string> { "А", "Б", "В", "Г", "Д", //+ 0
                                                  "Е", "Ж", "З", "И", "Й", //+ 5
                                                  "К", "Л", "М", "Н", "О", //+ 10
                                                  "П", "Р", "С", "Т", "У", //+ 15
                                                  "Ф", "Х", "Ц", "Ч", "Ш", //+ 20
                                                  "Щ", "Ъ", "Ь", "Ю", "Я"};//+ 25
                                                /* 0    1    2    3    4*/

        List<Control> controls;
        int[,] wordsToIndex = { { 4, 26, 2, 10, 0 }, //Дъвка 0
                                { 1, 0, 11, 14, 13}, //Балон 1
                                { 17, 0, 15, 19, 13}, //Сапун 2
                                { 12, 5, 21, 19, 16}, //Мехур 3
                                { 15, 19, 10, 0, 11}, //Пукам 4
                                { 17, 20, 5, 16, 0}}; //Сфера 5

        List<Control> ltrShow;
        List<bool> tries = new List<bool>() { false, false, false, false, false, false}; //head, armL, armR, body, legL, legR
        

        int wordNum;
        private void Form1_Load(object sender, EventArgs e)
        {
            controls = new List<Control> { button1, button2, button3,
                                                     button4, button5, button6,
                                                     button7, button8, button9,
                                                     button10, button11, button12,
                                                     button13, button14, button15,
                                                     button16, button17, button18,
                                                     button19, button20, button21,
                                                     button22, button23, button24,
                                                     button25, button26, button27,
                                                     button28, button29, button30
            };

            ltrShow = new List<Control> { ltr1, ltr2, ltr3, ltr4, ltr5 };

            Random randomWord = new Random();
            wordNum = randomWord.Next(0, 6);
            MessageBox.Show(words[wordNum]);
            loadLetters();
        }

        private void loadLetters()
        {
            List<int> filled = new List<int>();
            foreach (Control control in controls)
            {
                control.Visible = true;
                control.Text = null;
                Random randomLtr = new Random();
                int ltrNum = randomLtr.Next(0, 30);
                while (filled.Contains(ltrNum))
                {
                    ltrNum = randomLtr.Next(0, 30);
                }
                filled.Add(ltrNum);
                control.Text = letters[ltrNum];
            }
            timeLtrs.Start();
        }

        int countFilled = 0;
        private void getLetter(Control control)
        {
            int index = -1;
            for (int i = 0; i < letters.Count; i++)
            {
                if (control.Text == letters[i])
                {
                    index = i;
                    break;
                }
            }

            bool contained = false;
            for (int i = 0; i < 5; i++)
            {
                if (wordsToIndex[wordNum, i] == index)
                {
                    ltrShow[i].Text = control.Text;
                    countFilled++;
                    contained = true;
                    if (countFilled == 5)
                    {
                        MessageBox.Show("You win!");
                    }
                    break;
                }
            }

            if (!contained)
            {
                if (tries.Contains(false))
                {
                    for (int i = 0; i < tries.Count; i++)
                    {
                        if (tries[i] == false)
                        {
                            tries[i] = true;
                            switch (i)
                            {
                                case 0: head2.Visible = true; break;
                                case 1: armL2.Visible = true; break;
                                case 2: armR2.Visible = true; break;
                                case 3: body2.Visible = true; break;
                                case 4: legL2.Visible = true; break;
                                case 5: legR2.Visible = true; break;
                                default: break;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    head3.Visible = true;
                    armL3.Visible = true;
                    armR3.Visible = true;
                    body3.Visible = true;
                    legL3.Visible = true;
                    legR3.Visible = true;

                    head2.Visible = false;
                    armL2.Visible = false;
                    armR2.Visible = false;
                    body2.Visible = false;
                    legL2.Visible = false;
                    legR2.Visible = false;

                    MessageBox.Show("You lost!");
                }

                
            }
        }
        private void timeLtrs_Tick(object sender, EventArgs e)
        {
            loadLetters();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getLetter(button1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            getLetter(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getLetter(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getLetter(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getLetter(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getLetter(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getLetter(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getLetter(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            getLetter(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            getLetter(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            getLetter(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            getLetter(button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            getLetter(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            getLetter(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            getLetter(button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            getLetter(button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            getLetter(button17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            getLetter(button18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            getLetter(button19);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            getLetter(button20);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            getLetter(button21);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            getLetter(button22);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            getLetter(button23);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            getLetter(button24);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            getLetter(button25);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            getLetter(button26);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            getLetter(button27);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            getLetter(button28);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            getLetter(button29);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            getLetter(button30);
        }
    }
}
