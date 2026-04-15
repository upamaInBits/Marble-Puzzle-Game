using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FormDLL
{
    public partial class Clock : UserControl
    {
        private BufferedGraphicsContext CurrentContext;
        private float radius;
        private float radius1; //second
        private Point center;
        private Point center1;   //second

        public Clock()
        {

            InitializeComponent();

            if (Height > Width)
            {
                radius = Width / 2;
                radius1 = Width / 5; //sec
            }
            else
            {
                radius = Height / 2;
                radius1 = Height / 5; // sec
            }
            center = new Point(Width / 2, Height / 2);
            center1 = new Point(Width / 2, (Height / 4));

        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);
            DrawMinuteLines(bg.Graphics);

            bg.Render();
        }

        private void DrawLines(Graphics g)
        {
            Pen myPen1 = new Pen(Color.Red, radius * 0.07f);
            Pen myPen2 = new Pen(Color.Black, radius * 0.05f);
            Pen myPen3 = new Pen(Color.Black, radius * 0.02f);


            Pen SPen1 = new Pen(Color.Red, radius1 * 0.03f);
            Pen SPen2 = new Pen(Color.Black, radius1 * 0.005f);
            Pen SPen3 = new Pen(Color.Black, radius1 * 0.002f);

            for (int i = 0; i < 4; i++)
            {
                float x = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .7f + center.X;
                float y = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .7f + center.Y;

                float x2 = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .8f + center.X;
                float y2 = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .8f + center.Y;

                g.DrawLine(myPen1, x, y, x2, y2);

                //do same for the second too

                //float a = (float)Math.Cos(i * 90 * Math.PI / 180) * radius1 * .7f + center1.X;
                //float b = (float)Math.Sin(i * 90 * Math.PI / 180) * radius1 * .7f + center1.Y;

                //float a2 = (float)Math.Cos(i * 90 * Math.PI / 180) * radius1 * .8f + center1.X;
                //float b2 = (float)Math.Sin(i * 90 * Math.PI / 180) * radius1 * .8f + center1.Y;

                //g.DrawLine(SPen1, a, b, a2, b2);
            }

            for (int i = 0; i < 12; i++)
            {

                if (i % 3 != 0)
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen2, x, y, x2, y2);


                    //do same for the second too

                    //float a = (float)Math.Cos(i * 30 * Math.PI / 180) * radius1 * .7f + center1.X;
                    //float b = (float)Math.Sin(i * 30 * Math.PI / 180) * radius1 * .7f + center1.Y;

                    //float a2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius1 * .8f + center1.X;
                    //float b2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius1 * .8f + center1.Y;

                    //g.DrawLine(SPen2, a, b, a2, b2);
                }
            }

            for (int i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    float x = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen3, x, y, x2, y2);

                    //do same for the second too

                    //float a = (float)Math.Cos(i * 6 * Math.PI / 180) * radius1 * .7f + center1.X;
                    //float b = (float)Math.Sin(i * 6 * Math.PI / 180) * radius1 * .7f + center1.Y;

                    //float a2 = (float)Math.Cos(i * 6 * Math.PI / 180) * radius1 * .8f + center1.X;
                    //float b2 = (float)Math.Sin(i * 6 * Math.PI / 180) * radius1 * .8f + center1.Y;

                    //g.DrawLine(SPen3, a, b, a2, b2);
                }
            }
        }


        private void DrawMinuteLines(Graphics g)
        {
            Pen myPen = new Pen(Color.Black, radius1 * 0.05f);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < 12; i++)
            {
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * radius1 * .4f + center1.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * radius1 * .4f + center1.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius1 * .5f + center1.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius1 * .5f + center1.Y;

                    g.DrawLine(myPen, x, y, x2, y2);
                }
            }
        }
        private void DrawNumbers(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font numfont = new Font("Tahoma", radius * 0.09f, FontStyle.Bold);
            Brush numberBrush = new SolidBrush(Color.Black);

            for (int i = 1; i <= 60; i++)
            {

                if (i % 5 == 0)
                {
                    float x = (float)Math.Cos(((i / 5) * 30 - 90) * Math.PI / 180) * radius * .9f + center.X;
                    float y = (float)Math.Sin(((i / 5) * 30 - 90) * Math.PI / 180) * radius * .9f + center.Y;
                    g.DrawString(i.ToString(), numfont, numberBrush, x, y, sf);

                }
            }

        }

        private void DrawHands(Graphics g)
        {
            // Pen hourPen = new Pen(Color.Red, radius * 0.05f);
            Pen minutePen = new Pen(Color.Black, radius * 0.03f);
            Pen secondPen = new Pen(Color.Red, radius1 * 0.01f);

            DateTime now = DateTime.Now;

            //Make use of this in your stopwatch!!
            //TimeSpan x = now - DateTime.Now;


            //   int hours = now.Hour;
            int seconds = now.Minute;
            int minutes = now.Second;

            //float hx = (float)Math.Cos((hours * 30 - 90) * Math.PI / 180) * radius * .5f + center.X;
            //float hy = (float)Math.Sin((hours * 30 - 90) * Math.PI / 180) * radius * .5f + center.Y;



            float mx = (float)Math.Cos((minutes * 6 - 90) * Math.PI / 180) * radius * .7f + center.X;
            float my = (float)Math.Sin((minutes * 6 - 90) * Math.PI / 180) * radius * .7f + center.Y;


            float sx = (float)Math.Cos((seconds * 6 - 90) * Math.PI / 180) * radius1 * .75f + center1.X;
            float sy = (float)Math.Sin((seconds * 6 - 90) * Math.PI / 180) * radius1 * .75f + center1.Y;


            //  g.DrawLine(hourPen, center.X, center.Y, hx, hy);
            g.DrawLine(minutePen, center.X, center.Y, mx, my);
            g.DrawLine(secondPen, center1.X, center1.Y, sx, sy);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);
            DrawMinuteLines(bg.Graphics);

            bg.Render();
        }

        private void Clock_Resize(object sender, EventArgs e)
        {
            if (Height > Width)
            {
                radius = Width / 2;
                radius1 = Width / 5;
            }
            else
            {
                radius = Height / 2;
                radius = Height / 5;
            }
            center = new Point(Width / 2, Height / 2);
            center1 = new Point(Width / 2, (Height / 2) * 1 / 2);

            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);
            DrawMinuteLines(bg.Graphics);

            bg.Render();
        }

        DateTime StartTime;
        DateTime EndTime;
        DateTime Pause1;
        TimeSpan TotalTime;
        public TimeSpan PauseTime;
     
        TimeSpan PreviousRunTime;
        public TimeSpan PlayingTime;
        bool playing = false;
        bool paused = false;
        

        public int seconds
        {

            get
            {
                return PlayingTime.Seconds;
            }
        }

        public int minutes
        {

            get
            {
                return PlayingTime.Minutes;
            }
        }




        public void Start()
        {
            

            if (playing == false)
            {
                playing = true;
                StartTime = DateTime.Now;
                timer1.Enabled = true;
            }
            else if (paused == true)
            {
                PauseTime += DateTime.Now - Pause1;
                timer1.Enabled = true;
                paused = false;
            }
        }

        //public void Start()
        //{
        //    if (playing == false)
        //    {
        //        playing = true;

        //        if (!paused)
        //        {
        //            // If clock is not paused, start from scratch
        //            StartTime = DateTime.Now;
        //            PreviousRunTime = TimeSpan.Zero;
        //            PauseTime = TimeSpan.Zero;
        //        }
        //        else
        //        {
        //            // If clock was paused, resume from the last pause point
        //            PauseTime += DateTime.Now - Pause1;
        //            paused = false;
        //        }

        //        timer1.Enabled = true;
        //    }
        //}



        public void Stop()
        {
            if (playing == true)
            {
          
                timer1.Enabled = false;
                EndTime = DateTime.Now;
                TotalTime = EndTime - StartTime;

                if (paused == true)
                {
                    PlayingTime = TotalTime - PauseTime;
                    paused = false;
                }
                else
                {
                    PlayingTime = TotalTime;
                }

                playing = false;
            }
            
        }



        public void pause()
        {
                PreviousRunTime = DateTime.Now - StartTime;
                Pause1 = DateTime.Now;
                timer1.Enabled = false;
                paused = true;
        }

        public void reset()
        {
            timer1.Enabled = false;
            playing = false;
            PauseTime = TimeSpan.Zero;
            PreviousRunTime = TimeSpan.Zero;
            paused = false;

        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (playing)
                {
                    if (paused)
                    {
                        return PreviousRunTime;
                    }
                    else
                    {
                        return DateTime.Now - StartTime - PauseTime;
                    }
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }


        private void Clock_Load(object sender, EventArgs e)
        {

        }

     
   
        

    }
}
