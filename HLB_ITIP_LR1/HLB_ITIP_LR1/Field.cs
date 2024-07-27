using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLB_ITIP_LR1
{
    internal class Field
    {
        public bool hasWhiteCheck;
        public bool hasWhiteQueen;
        public bool hasBlackCheck;
        public bool hasBlackQueen;

        public PictureBox pictureBox;
        public int coordinateX;
        public int coordinateY;

        public Field(bool hasWhiteCheck, bool hasBlackCheck, PictureBox pictureBox, int coordinateY, int coordinateX)
        {
            this.hasWhiteCheck = hasWhiteCheck;
            this.hasWhiteQueen = false;
            this.hasBlackCheck = hasBlackCheck;
            this.hasBlackQueen = false;
            this.pictureBox = pictureBox;
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public void removeCheck()
        {
            hasWhiteCheck = false;
            hasBlackCheck = false;
            hasWhiteQueen = false;
            hasBlackQueen = false;
            pictureBox.Image = null;
        }

        public void onClick()
        {
            if (Board.turn == -1)
            {
                return;
            }
            if (Board.activeField == this)
            {
                Board.ClearActiveField();
                return;
            }
            if (Board.activeField == null || hasBlackCheck || hasWhiteCheck || hasWhiteQueen || hasBlackQueen)
            {
                Board.SetActiveField(this);
                return;
            }
            if ((Math.Abs(coordinateX - Board.activeCoordinateX) == Math.Abs(coordinateY - Board.activeCoordinateY)) && ((Board.activeField.hasBlackQueen && (Board.turn == 1 || (Board.blackJustAte && Board.activeField == Board.justAteField))) || (Board.activeField.hasWhiteQueen && (Board.turn == 0 || (Board.whiteJustAte && Board.activeField == Board.justAteField)))))
            {
                bool res = Board.TryEatQueen(this);
                if (res)
                {
                    Board.MakeStepQueen(this);
                    Board.CheckIsEnded();
                    return;
                }
            }
            if (Math.Abs(coordinateX - Board.activeCoordinateX) == 1 && ((coordinateY - Board.activeCoordinateY == 1 && Board.activeField.hasWhiteCheck && Board.turn == 0) || (coordinateY - Board.activeCoordinateY == -1 && Board.activeField.hasBlackCheck && Board.turn == 1)))
            {
                Board.MakeStep(this);
                Board.blackJustAte = false;
                Board.whiteJustAte = false;
                Board.justAteField = null;
                return;
            }
            if (Math.Abs(coordinateX - Board.activeCoordinateX) == 2 && Math.Abs(coordinateY - Board.activeCoordinateY) == 2)
            {
                bool res = Board.TryEat(this);
                if (res)
                {
                    if (hasBlackCheck || hasBlackQueen)
                    {
                        Board.blackJustAte = true;
                        Board.whiteJustAte = false;
                    }
                    else if (hasWhiteCheck || hasWhiteQueen)
                    {
                        Board.blackJustAte = false;
                        Board.whiteJustAte = true;
                    }
                    Board.justAteField = this;
                    return;
                }
            }
            Board.SetActiveField(this);
        }

    }
}
