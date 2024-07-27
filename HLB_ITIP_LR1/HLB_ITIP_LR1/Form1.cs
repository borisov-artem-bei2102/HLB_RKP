using System;
using System.Windows.Forms;

namespace HLB_ITIP_LR1
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBox[,] pictureBoxes = new PictureBox[,] {
                {pb11, pb12, pb13, pb14, pb15, pb16, pb17, pb18},
                {pb21, pb22, pb23, pb24, pb25, pb26, pb27, pb28},
                { pb31, pb32, pb33, pb34, pb35, pb36, pb37, pb38},
                { pb41, pb42, pb43, pb44, pb45, pb46, pb47, pb48},
                { pb51, pb52, pb53, pb54, pb55, pb56, pb57, pb58},
                { pb61, pb62, pb63, pb64, pb65, pb66, pb67, pb68},
                { pb71, pb72, pb73, pb74, pb75, pb76, pb77, pb78},
                { pb81, pb82, pb83, pb84, pb85, pb86, pb87, pb88},
            };
            Board.init(pictureBoxes);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PictureBox[,] pictureBoxes = new PictureBox[,] {
                {pb11, pb12, pb13, pb14, pb15, pb16, pb17, pb18},
                {pb21, pb22, pb23, pb24, pb25, pb26, pb27, pb28},
                { pb31, pb32, pb33, pb34, pb35, pb36, pb37, pb38},
                { pb41, pb42, pb43, pb44, pb45, pb46, pb47, pb48},
                { pb51, pb52, pb53, pb54, pb55, pb56, pb57, pb58},
                { pb61, pb62, pb63, pb64, pb65, pb66, pb67, pb68},
                { pb71, pb72, pb73, pb74, pb75, pb76, pb77, pb78},
                { pb81, pb82, pb83, pb84, pb85, pb86, pb87, pb88},
            };
            Board.init(pictureBoxes);
            updateTurn();
        }

        private void updateTurn()
        {
            if (Board.turn == 0)
            {
                lblTurn.Text = "Ход белых";
            }
            else if (Board.turn == 1)
            {
                lblTurn.Text = "Ход черных";
            }
            else if (Board.turn == -1)
            {
                lblTurn.Text = "Игра завершена";
            }
        }

        private void pb88_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb87_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb86_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb85_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb84_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb83_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb82_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb81_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 7;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }


        private void pb78_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb77_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb76_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb75_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb74_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb73_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb72_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb71_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 6;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb68_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb67_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb66_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb65_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb64_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb63_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb62_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb61_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 5;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb58_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb57_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb56_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb55_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb54_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb53_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb52_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();

        }

        private void pb51_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 4;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb48_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb47_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb46_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb45_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb44_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb43_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb42_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb41_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 3;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb38_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb37_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb36_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb35_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb34_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb33_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb32_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb31_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 2;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb28_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb27_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb26_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb25_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb24_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb23_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb22_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb21_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 1;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb18_Click(object sender, EventArgs e)
        {
            int coordinateX = 7;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb17_Click(object sender, EventArgs e)
        {
            int coordinateX = 6;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb16_Click(object sender, EventArgs e)
        {
            int coordinateX = 5;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb15_Click(object sender, EventArgs e)
        {
            int coordinateX = 4;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb14_Click(object sender, EventArgs e)
        {
            int coordinateX = 3;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb13_Click(object sender, EventArgs e)
        {
            int coordinateX = 2;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb12_Click(object sender, EventArgs e)
        {
            int coordinateX = 1;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }

        private void pb11_Click(object sender, EventArgs e)
        {
            int coordinateX = 0;
            int coordinateY = 0;
            Board.Fields[coordinateY, coordinateX].onClick();
            updateTurn();
        }
    }
}
