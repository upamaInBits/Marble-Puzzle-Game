using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assignment_2_marble
{
    internal class PBXPictureBox : PictureBox
    {
        private bool LeftWall;
        private bool RightWall;
        private bool TopWall;
        private bool BottomWall;
        private int row;
        private int column;
        private int ballOrHole;
        private int Ball;
        private int Hole;



        public bool leftwall
        {
            set
            {
                LeftWall = value;
            }

            get
            {
                return LeftWall;
            }

        }

        public bool rightwall
        {
            set
            {
                RightWall = value;
            }

            get
            {
                return RightWall;
            }

        }

        public bool topwall
        {
            set
            {
                TopWall = value;
            }

            get
            {
                return TopWall;
            }

        }

        public bool bottomwall
        {
            set
            {
                BottomWall = value;
            }

            get
            {
                return BottomWall;
            }

        }
        public int BallOrHole
        {
            get
            {
                return ballOrHole;
            }
            set
            {
                ballOrHole = value;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }


        public int ball
        {
            set
            {
                Ball = value;
            }

            get
            {
                return Ball;
            }
        }

        public int hole
        {
            set
            {
                Hole = value;
            }

            get
            {
                return Hole;
            }

        }



    }
}
