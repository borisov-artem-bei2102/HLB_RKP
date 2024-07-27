using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLB_ITIP_LR1
{
    internal class Board
    {
        private static Field[,] fields;
        private static string whiteUrl = "../../Resources/white.png";
        private static string whiteQueenUrl = "../../Resources/white-queen.png";
        private static string blackUrl = "../../Resources/black.png";
        private static string blackQueenUrl = "../../Resources/black-queen.png";

        public static Field activeField;
        public static int activeCoordinateX;
        public static int activeCoordinateY;
        public static int turn = 0;

        public static bool whiteJustAte = false;
        public static bool blackJustAte = false;
        public static Field justAteField = null;

        public static Field[,] Fields
        {
            get { return fields; }
        }

        public static void init(PictureBox[,] pictureBoxes)
        {
            fields = null;
            fields = new Field[8, 8]
            {
                { new Field(true, false, pictureBoxes[0, 0], 0, 0), new Field(false, false, pictureBoxes[0, 1], 0, 1), new Field(true, false, pictureBoxes[0, 2], 0, 2), new Field(false, false, pictureBoxes[0, 3], 0, 3), new Field(true, false, pictureBoxes[0, 4], 0, 4), new Field(false, false, pictureBoxes[0, 5], 0, 5), new Field(true, false, pictureBoxes[0, 6], 0, 6), new Field(false, false, pictureBoxes[0, 7], 0, 7) },
                { new Field(false, false, pictureBoxes[1, 0], 1, 0), new Field(true, false, pictureBoxes[1, 1], 1, 1), new Field(false, false, pictureBoxes[1, 2], 1, 2), new Field(true, false, pictureBoxes[1, 3], 1, 3), new Field(false, false, pictureBoxes[1, 4], 1, 4), new Field(true, false, pictureBoxes[1, 5], 1, 5), new Field(false, false, pictureBoxes[1, 6], 1, 6), new Field(true, false, pictureBoxes[1, 7], 1, 7) },
                { new Field(true, false, pictureBoxes[2, 0], 2, 0), new Field(false, false, pictureBoxes[2, 1], 2, 1), new Field(true, false, pictureBoxes[2, 2], 2, 2), new Field(false, false, pictureBoxes[2, 3], 2, 3), new Field(true, false, pictureBoxes[2, 4], 2, 4), new Field(false, false, pictureBoxes[2, 5], 2, 5), new Field(true, false, pictureBoxes[2, 6], 2, 6), new Field(false, false, pictureBoxes[2, 7], 2, 7) },
                { new Field(false, false, pictureBoxes[3, 0], 3, 0), new Field(false, false, pictureBoxes[3, 1], 3, 1), new Field(false, false, pictureBoxes[3, 2], 3, 2), new Field(false, false, pictureBoxes[3, 3], 3, 3), new Field(false, false, pictureBoxes[3, 4], 3, 4), new Field(false, false, pictureBoxes[3, 5], 3, 5), new Field(false, false, pictureBoxes[3, 6], 3, 6), new Field(false, false, pictureBoxes[3, 7], 3, 7) },
                { new Field(false, false, pictureBoxes[4, 0], 4, 0), new Field(false, false, pictureBoxes[4, 1], 4, 1), new Field(false, false, pictureBoxes[4, 2], 4, 2), new Field(false, false, pictureBoxes[4, 3], 4, 3), new Field(false, false, pictureBoxes[4, 4], 4, 4), new Field(false, false, pictureBoxes[4, 5], 4, 5), new Field(false, false, pictureBoxes[4, 6], 4, 6), new Field(false, false, pictureBoxes[4, 7], 4, 7) },
                { new Field(false, false, pictureBoxes[5, 0], 5, 0), new Field(false, true, pictureBoxes[5, 1], 5, 1), new Field(false, false, pictureBoxes[5, 2], 5, 2), new Field(false, true, pictureBoxes[5, 3], 5, 3), new Field(false, false, pictureBoxes[5, 4], 5, 4), new Field(false, true, pictureBoxes[5, 5], 5, 5), new Field(false, false, pictureBoxes[5, 6], 5, 6), new Field(false, true, pictureBoxes[5, 7], 5, 7) },
                { new Field(false, true, pictureBoxes[6, 0], 6, 0), new Field(false, false, pictureBoxes[6, 1], 6, 1), new Field(false, true, pictureBoxes[6, 2], 6, 2), new Field(false, false, pictureBoxes[6, 3], 6, 3), new Field(false, true, pictureBoxes[6, 4], 6, 4), new Field(false, false, pictureBoxes[6, 5], 6, 5), new Field(false, true, pictureBoxes[6, 6], 6, 6), new Field(false, false, pictureBoxes[6, 7], 6, 7) },
                { new Field(false, false, pictureBoxes[7, 0], 7, 0), new Field(false, true, pictureBoxes[7, 1], 7, 1), new Field(false, false, pictureBoxes[7, 2], 7, 2), new Field(false, true, pictureBoxes[7, 3], 7, 3), new Field(false, false, pictureBoxes[7, 4], 7, 4), new Field(false, true, pictureBoxes[7, 5], 7, 5), new Field(false, false, pictureBoxes[7, 6], 7, 6), new Field(false, true, pictureBoxes[7, 7], 7, 7) },
            };
            turn = 0;
            ClearActiveField();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Fields[i, j].hasBlackCheck)
                    {
                        Fields[i, j].pictureBox.ImageLocation = blackUrl;
                    }
                    else if (Fields[i, j].hasWhiteCheck)
                    {
                        Fields[i, j].pictureBox.ImageLocation = whiteUrl;
                    }
                    else
                    {
                        Fields[i, j].pictureBox.Image = null;
                    }
                }
            }
        }

        public static void CheckIsEnded()
        {
            int whiteChecksOnBoard = 0;
            int blackChecksOnBoard = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Fields[i, j].hasBlackCheck || Fields[i, j].hasBlackQueen)
                    {
                        blackChecksOnBoard++;
                    }
                    if (Fields[i, j].hasWhiteCheck || Fields[i, j].hasWhiteQueen)
                    {
                        whiteChecksOnBoard++;
                    }
                }
            }

            Console.WriteLine();

            if (whiteChecksOnBoard == 0 || blackChecksOnBoard == 0)
            {
                turn = -1;
            }
        }

        public static void ClearActiveField()
        {
            if (activeField != null)
            {
                activeField.pictureBox.BorderStyle = BorderStyle.FixedSingle;
                activeField = null;
            }
            activeCoordinateX = -10;
            activeCoordinateY = -10;
        }

        public static void SetActiveField(Field field)
        {
            if (activeField != null)
            {
                activeField.pictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            field.pictureBox.BorderStyle = BorderStyle.Fixed3D;
            activeField = field;
            activeCoordinateX = field.coordinateX;
            activeCoordinateY = field.coordinateY;
        }

        public static void MakeStep(Field field)
        {
            if (activeField.hasWhiteCheck)
            {
                if (field.coordinateY == 7)
                {
                    field.pictureBox.ImageLocation = whiteQueenUrl;
                    field.hasWhiteCheck = false;
                    field.hasWhiteQueen = true;
                }
                else
                {
                    field.pictureBox.ImageLocation = whiteUrl;
                    field.hasWhiteCheck = true;
                }
                turn = 1;
            }
            if (activeField.hasBlackCheck)
            {
                if (field.coordinateY == 0)
                {
                    field.pictureBox.ImageLocation = blackQueenUrl;
                    field.hasBlackCheck = false;
                    field.hasBlackQueen = true;
                }
                else
                {
                    field.pictureBox.ImageLocation = blackUrl;
                    field.hasBlackCheck = true;
                }
                turn = 0;
            }

            activeField.removeCheck();
            ClearActiveField();
        }

        public static void MakeStepQueen(Field field)
        {
            if (activeField.hasWhiteQueen)
            {
                field.pictureBox.ImageLocation = whiteQueenUrl;
                field.hasWhiteQueen = true;
                turn = 1;
            }
            if (activeField.hasBlackQueen)
            {
                field.pictureBox.ImageLocation = blackQueenUrl;
                field.hasBlackQueen = true;
                turn = 0;
            }

            activeField.removeCheck();
            ClearActiveField();
        }

        private static bool CanFieldBeEaten(Field field)
        {
            if (field == null) return false;
            if (((field.hasWhiteCheck || field.hasWhiteQueen) && activeField.hasBlackCheck && (turn == 1 || (blackJustAte && activeField == justAteField))) || ((field.hasBlackCheck || field.hasBlackQueen) && activeField.hasWhiteCheck && (turn == 0 || (whiteJustAte && activeField == justAteField))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Eat(Field fieldToStep, Field fieldToEat)
        {
            MakeStep(fieldToStep);
            fieldToEat.removeCheck();
            CheckIsEnded();
        }

        public static bool TryEat(Field field)
        {
            Field topLeftField = (field.coordinateX > 0 && field.coordinateY > 0) ? Fields[field.coordinateY - 1, field.coordinateX - 1] : null;
            Field topRightFIeld = (field.coordinateX < 7 && field.coordinateY > 0) ? Fields[field.coordinateY - 1, field.coordinateX + 1] : null;
            Field bottomLeftField = (field.coordinateX > 0 && field.coordinateY < 7) ? Fields[field.coordinateY + 1, field.coordinateX - 1] : null;
            Field bottomRightFIeld = (field.coordinateX < 7 && field.coordinateY < 7) ? Fields[field.coordinateY + 1, field.coordinateX + 1] : null;

            if (field.coordinateX - activeCoordinateX == 2)
            {
                if (field.coordinateY - activeCoordinateY == 2 && CanFieldBeEaten(topLeftField))
                {
                    Eat(field, topLeftField);
                    return true;
                }
                if (field.coordinateY - activeCoordinateY == -2 && CanFieldBeEaten(bottomLeftField))
                {
                    Eat(field, bottomLeftField);
                    return true;
                }
            }
            if (field.coordinateX - activeCoordinateX == -2)
            {
                if (field.coordinateY - activeCoordinateY == 2 && CanFieldBeEaten(topRightFIeld))
                {
                    Eat(field, topRightFIeld);
                    return true;
                }
                if (field.coordinateY - activeCoordinateY == -2 && CanFieldBeEaten(bottomRightFIeld))
                {
                    Eat(field, bottomRightFIeld);
                    return true;
                }
            }
            return false;
        }

        public static bool TryEatQueen(Field field)
        {
            int xStep = field.coordinateX > activeCoordinateX ? 1 : -1;
            int yStep = field.coordinateY > activeCoordinateY ? 1 : -1;
            int xTemp = activeCoordinateX;
            int yTemp = activeCoordinateY;

            int toBeEaten = 0;
            int toBeEatenX = -1;
            int toBeEatenY = -1;

            while (xTemp != field.coordinateX && yTemp != field.coordinateY)
            {

                if (activeField.hasWhiteQueen)
                {
                    if (Fields[yTemp, xTemp].hasBlackQueen || Fields[yTemp, xTemp].hasBlackCheck)
                    {
                        toBeEaten++;
                        toBeEatenX = xTemp;
                        toBeEatenY = yTemp;
                    }
                }
                if (activeField.hasBlackQueen)
                {
                    if (Fields[yTemp, xTemp].hasWhiteQueen || Fields[yTemp, xTemp].hasWhiteCheck)
                    {
                        toBeEaten++;
                        toBeEatenX = xTemp;
                        toBeEatenY = yTemp;
                    }
                }
                xTemp += xStep;
                yTemp += yStep;
            }

            if (toBeEaten > 1)
            {
                return false;
            }
            if (toBeEaten == 1)
            {
                blackJustAte = false;
                whiteJustAte = false;
                if (activeField.hasBlackQueen)
                {
                    blackJustAte = true;
                }
                if (activeField.hasWhiteQueen) { whiteJustAte = true; }
                Board.justAteField = field;
                Fields[toBeEatenY, toBeEatenX].removeCheck();
                return true;
            }
            if (toBeEaten == 0 && ((turn == 0 && activeField.hasWhiteQueen) || (turn == 1 && activeField.hasBlackQueen)))
            {
                justAteField = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
