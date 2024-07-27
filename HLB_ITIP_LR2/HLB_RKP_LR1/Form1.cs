using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HLB_RKP_LR1
{
    public partial class Form1 : Form
    {
        static int X_COUNT = 11;
        static int Y_COUNT = 15;
        static Button[,] btns = new Button[Y_COUNT, X_COUNT];
        static List<Button> max_btns_list;
        static List<Button> current_btns_list = new List<Button>();

        public void CreateButtons()
        {
            int SIZE = 30;
            int GAP = 5;
            int START_POSITION = 50;
            for (int y = 0; y < Y_COUNT; y++)
            {
                for (int x = 0; x < X_COUNT; x++)
                {
                    Button btn = new Button
                    {
                        Location = new Point(START_POSITION + GAP * x + SIZE * x, START_POSITION + GAP * y + SIZE * y),
                        Size = new Size(SIZE, SIZE),
                        BackColor = Color.Black,
                        ForeColor = Color.White
                    };
                    btns[y, x] = btn;
                }
            }
        }

        public void DrawButtons()
        {
            foreach (Button btn in btns)
            {
                Controls.Add(btn);
            }
            for (int i = 1; i <= max_btns_list.Count; i++)
            {
                max_btns_list[i - 1].Text = i.ToString();
            }
        }

        public void ClearButtons()
        {
            foreach (Button btn in btns)
            {
                Controls.Remove(btn);
            }
        }

        public void RandomMazeButtons()
        {
            Random r = new Random();
            foreach (Button btn in btns)
            {
                int res = r.Next(2);
                if (res == 0)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
                else
                {
                    btn.Text = "";
                }
            }
        }

        public int FindWaysToFinish()
        {
            max_btns_list = new List<Button>();
            foreach (Button btn in btns)
            {
                if (btn.BackColor == Color.Black)
                {
                    max_btns_list.Add(btn);
                }
            }
            int startY = Y_COUNT - 1;
            int startX = 0;

            int endY = 0;
            int endX = X_COUNT - 1;

            if (btns[startY, startX].BackColor == Color.White || btns[startY, startX].BackColor == Color.White)
            {
                return 0;
            }

            return RecursiveWayFinder(startX, startY, endX, endY);
        }

        public int RecursiveWayFinder(int x, int y, int endX, int endY)
        {
            current_btns_list.Add(btns[y, x]);
            if (x == endX && y == endY)
            {
                Console.WriteLine(current_btns_list.Count);
                if (current_btns_list.Count < max_btns_list.Count)
                {
                    max_btns_list = new List<Button>(current_btns_list);
                }
                current_btns_list.Remove(btns[y, x]);
                return 1;
            }
            btns[y, x].Text = "1";
            int waysAvailable = 0;
            if (x > 0 && btns[y, x - 1].BackColor == Color.Black && btns[y, x - 1].Text == "")
            {
                waysAvailable += RecursiveWayFinder(x - 1, y, endX, endY);
            }
            if (x < X_COUNT - 1 && btns[y, x + 1].BackColor == Color.Black && btns[y, x + 1].Text == "")
            {
                waysAvailable += RecursiveWayFinder(x + 1, y, endX, endY);
            }
            if (y > 0 && btns[y - 1, x].BackColor == Color.Black && btns[y - 1, x].Text == "")
            {
                waysAvailable += RecursiveWayFinder(x, y - 1, endX, endY);
            }
            if (y < Y_COUNT - 1 && btns[y + 1, x].BackColor == Color.Black && btns[y + 1, x].Text == "")
            {
                waysAvailable += RecursiveWayFinder(x, y + 1, endX, endY);
            }
            btns[y, x].Text = "";
            current_btns_list.Remove(btns[y, x]);
            return waysAvailable;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int ways = 0;
            while (ways == 0)
            {
                ClearButtons();
                CreateButtons();
                RandomMazeButtons();
                ways = FindWaysToFinish();
            }
            label1.Text = $"Количество путей до финиша: {ways}";
            DrawButtons();
        }
    }
}
