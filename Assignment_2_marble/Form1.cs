using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IPControl3;
using System.IO.Compression;
using System.Collections;



namespace Assignment_2_marble
{

   
    public partial class Form1 : Form
    {

       

        String fileContent = String.Empty;
        String CurrentPath = String.Empty;

     //   private List<PersonItem> ExistingPersonList;

        int PuzzleSize;
        int BallsinPlay;
     

        Image imgTemp;

 
        private TableLayoutPanel puzzlePanel;
        private TableLayoutPanel puzzlePanel2;

        private int oldWidth;
        private int oldHeight;
        private int oldDimensions;
        public string selectedFilePath;
        public string filepath;

        public string fileimg;
        public string FullPath { get; set; }

        private Image LoadImage;


        public Form1()
        {
           InitializeComponent();
           clock1.pause();
          
           ExistingPersonList = new List<PersonItem>();
              
    }

        public Form1(string selectedFilePath)

        {
            InitializeComponent();
            loadfile(filepath);
            UpdatePictures(fileimg);


        }
        private PBXPictureBox[,] pbxGrid;
        private int WallNumber(bool LeftWall, bool RightWall, bool UpWall, bool DownWall)
        {
            // presence or absence of walls in 4 different directions 
            Dictionary<string, int> lookup = new Dictionary<string, int>
          {

        //false false false false
        {"0000", 0},
        // false false false true   
        {"0001", 4},
        {"0010", 3},
        {"0011", 7},
        {"0100", 2},
        {"0101", 9},
        {"0110", 8},
        {"0111", 12},
        {"1000", 1},
        {"1001", 5},
        {"1010", 11},
        {"1011", 15},
        {"1100", 10},
        {"1101", 13},
        {"1110", 14},
        {"1111", 6}
    };

            string key = Convert.ToInt32(LeftWall).ToString() + Convert.ToInt32(RightWall).ToString() + Convert.ToInt32(UpWall).ToString() + Convert.ToInt32(DownWall).ToString();

            return lookup[key];
        }

        public void UpdatePictures(string fileimg)
        {

            LoadImage = Image.FromFile(fileimg);

            for (int row = 0; row < PSize; row++)
            {
                for (int col = 0; col < PSize; col++)
                {
                    int wall = WallNumber(pbxGrid[row, col].leftwall, pbxGrid[row, col].rightwall, pbxGrid[row, col].topwall, pbxGrid[row, col].bottomwall);
                    int index = wall;

                    if (pbxGrid[row, col].ball > 0)
                    {
                        //index = 4;

                        index += 32;
                    }
                    else if (pbxGrid[row, col].hole > 0)
                    {
                        //index = 2;

                        index += 16;
                    }

                    int pbxWidth = LoadImage.Width / 7;
                    int pbxHeight = LoadImage.Height / 7;
                    int x = index % 7;
                    int y = index / 7;

                    Bitmap bm = new Bitmap(pbxGrid[row, col].Width, pbxGrid[row, col].Height);
                    Graphics g = Graphics.FromImage(bm);
                    Rectangle rec = new Rectangle(0, 0, pbxGrid[row, col].Width, pbxGrid[row, col].Height);
                    g.DrawImage(LoadImage, rec, pbxWidth * x, pbxHeight * y, pbxWidth, pbxHeight, GraphicsUnit.Pixel);


                    Font f = new Font("Arial", 20f);
                    Brush stringBrush = Brushes.WhiteSmoke;
                    string stringValue = "";

                    if (pbxGrid[row, col].BallOrHole > 0)
                    {
                        stringValue = pbxGrid[row, col].BallOrHole.ToString();
                    }


                    if (pbxGrid[row, col].ball > 0)
                    {
                        stringValue = pbxGrid[row, col].ball.ToString();
                    }
                    else if (pbxGrid[row, col].hole > 0)
                    {
                        stringValue = pbxGrid[row, col].hole.ToString();
                    }

                    SizeF stringSize = g.MeasureString(stringValue, f);
                    float xPosition = (pbxGrid[row, col].Width - stringSize.Width) / 2f;
                    float yPosition = (pbxGrid[row, col].Height - stringSize.Height) / 2f;
                    g.DrawString(stringValue, f, stringBrush, xPosition, yPosition);


                    pbxGrid[row, col].Image = bm;
                }
            }
        }
        public void loadfile(string filepath)
        {

            using (var fileStream = new StreamReader(filepath))
            {
                var pieces = fileStream.ReadLine().Split(' ');
                var size = int.Parse(pieces[0]);
                var ballCount = int.Parse(pieces[1]);
                var wallCount = int.Parse(pieces[2]);

                marbles = ballCount;
                PSize = size;

                var (pbWidth, pbHeight) = GetPictureBoxDimensions(size, imgTemp);

                pbxGrid = new PBXPictureBox[size, size];
                CreatePictureBoxes(size, pbWidth, pbHeight);

                AssignBallsAndHoles(fileStream, ballCount);
                AssignWalls(fileStream, wallCount);
            }
        }
        private (int, int) GetPictureBoxDimensions(int size, Image image)
        {
            var reservedSpace = 900;
            var ratio = (double)Math.Min(image.Width, image.Height) / reservedSpace;
            var pbWidth = (int)(reservedSpace / (double)size);
            var pbHeight = (int)(ratio * pbWidth);
            return (pbWidth, pbHeight);
        }
        private void CreatePictureBoxes(int size, int pbWidth, int pbHeight)
        {

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    pbxGrid[row, col] = new PBXPictureBox()
                    {
                        Size = new Size(pbWidth, pbHeight),
                        Location = new Point(pbWidth * col + 50, pbHeight * row + 15),
                        BackColor = Color.White,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,

                    };
                    Controls.Add(pbxGrid[row, col]);

                }
            }

        }

        private void AssignBallsAndHoles(StreamReader fileStream, int ballCount)
        {
            for (int n = 1; n <= ballCount * 2; n++)
            {
                var x = fileStream.ReadLine().Split(' ');
                var r = int.Parse(x[0]);
                var c = int.Parse(x[1]);
                var isBall = n <= ballCount;
                var number = isBall ? n : n - ballCount;
                var pbx = pbxGrid[r, c];
                if (isBall) pbx.ball = number;
                else pbx.hole = number;
            }
        }
        private void AssignWalls(StreamReader fileStream, int wallCount)
        {
            for (int n = 1; n <= wallCount; n++)
            {
                var x = fileStream.ReadLine().Split(' ');
                var r1 = int.Parse(x[0]);
                var c1 = int.Parse(x[1]);
                var r2 = int.Parse(x[2]);
                var c2 = int.Parse(x[3]);
                var pb1 = pbxGrid[r1, c1];
                var pb2 = pbxGrid[r2, c2];
                if (r1 == r2)
                {
                    if (c1 < c2)
                    {
                        pb1.rightwall = true;
                        pb2.leftwall = true;
                    }
                    else
                    {
                        pb1.leftwall = true;
                        pb2.rightwall = true;
                    }
                }
                else if (c1 == c2)
                {
                    if (r1 > r2)
                    {
                        pb1.topwall = true;
                    }
                }
            }
        }
        int PSize;
        int marbles;
        bool result = false;
        private void DisableArrowButtons()
        {
            Btn_Left.Enabled = false;
            Btn_Right.Enabled = false;
            Btn_Up.Enabled = false;
            Btn_Down.Enabled = false;
        }

        private void EnableArrowButtons()
        {
            Btn_Left.Enabled = true;
            Btn_Right.Enabled = true;
            Btn_Up.Enabled = true;
            Btn_Down.Enabled = true;
        }

        int moves = 0;
        //   ControlID.FirstName = txtBoxName.Text;


        private List<PersonItem> ExistingPersonList;

        //  private String fileContent = String.Empty;
        private String filePath = String.Empty;
        private String tempLocation = String.Empty;
        private void Btn_Left_Click_1(object sender, EventArgs e)
        {
            moves++;
            if (result == false)
            {
                for (int r = 0; r < PSize; r++)
                {
                    for (int c = 1; c < PSize; c++)
                    {

                        if (pbxGrid[r, c].ball > 0)
                        {
                            for (int tempcol = c; tempcol > 0; tempcol--)
                            {
                                if (!pbxGrid[r, tempcol].leftwall && pbxGrid[r, tempcol - 1].ball == 0)
                                {
                                    pbxGrid[r, tempcol - 1].ball = pbxGrid[r, tempcol].ball;
                                    pbxGrid[r, tempcol].ball = 0;

                                    if (pbxGrid[r, tempcol - 1].ball == pbxGrid[r, tempcol - 1].hole)
                                    {
                                        pbxGrid[r, tempcol - 1].ball = 0;
                                        pbxGrid[r, tempcol - 1].hole = 0;
                                        marbles--;

                                        if (marbles == 0)
                                        {
                                            result = true;
                                            clock1.Stop();
                                            MessageBox.Show("You Win!!");

                                            TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
                                            int gameMin = playingTime.Minutes;
                                            int gameSec = playingTime.Seconds;

                                            int secondsplayed = (gameMin * 60) + gameSec;

                                            PersonItem person = new PersonItem();
                                            person.Name = ControlID.PersonName;
                                            person.moves = moves;
                                            person.timeelapsed = secondsplayed;

                                            ExistingPersonList.Add(person);
                                            SortListViewByMoves();
                                            AddPerson(person);

                                            DisplayMessage();
                                            DisableArrowButtons();
                                            ResetGame();
                                            puzzlePanel2.Hide();
                                            moves = 0;
                                            return;


                                        }
                                    }
                                    else if (pbxGrid[r, tempcol - 1].ball != pbxGrid[r, tempcol - 1].hole && pbxGrid[r, tempcol - 1].hole > 0)
                                    {

                                        pbxGrid[r, tempcol - 1].ball = 0;
                                        pbxGrid[r, tempcol - 1].hole = 0;
                                        clock1.Stop();
                                        MessageBox.Show("Game Over");
                                        DisplayMessage();
                                        DisableArrowButtons();
                                        ResetGame();
                                        puzzlePanel2.Hide();
                                        btnPause.Hide();
                                        btnStart.Hide();
                                        btnReset.Hide();
                                        btnResume.Hide();
                                        moves = 0;
                                        return;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        UpdatePictures(fileimg);//update

                    }
                }
            }
        }
        private void Btn_Right_Click(object sender, EventArgs e)
        {
            moves++;
            if (result == false)
            {
                for (int c = PSize - 2; c >= 0; c--)
                {
                    for (int r = 0; r < PSize; r++)
                    {
                        if (pbxGrid[r, c].ball > 0)
                        {
                            for (int tempc = c; tempc < PSize - 1; tempc++)
                            {
                                if (pbxGrid[r, tempc].rightwall == false && pbxGrid[r, tempc + 1].ball == 0)
                                {
                                    pbxGrid[r, tempc + 1].ball = pbxGrid[r, tempc].ball;
                                    pbxGrid[r, tempc].ball = 0;

                                    if (pbxGrid[r, tempc + 1].ball == pbxGrid[r, tempc + 1].hole)
                                    {
                                        pbxGrid[r, tempc + 1].ball = 0;
                                        pbxGrid[r, tempc + 1].hole = 0;

                                        marbles--;

                                        if (marbles == 0)
                                        {
                                            result = true;
                                            clock1.Stop();
                                            MessageBox.Show("You Win!!");


                                            TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
                                            int gameMin = playingTime.Minutes;
                                            int gameSec = playingTime.Seconds;

                                            int secondsplayed = (gameMin * 60) + gameSec;

                                            PersonItem person = new PersonItem();
                                            person.Name = ControlID.PersonName;
                                            person.moves = moves;
                                            person.timeelapsed = secondsplayed;

                                            ExistingPersonList.Add(person);
                                            SortListViewByMoves();
                                            AddPerson(person);

                                            DisplayMessage();
                                            DisableArrowButtons();
                                            ResetGame();
                                            puzzlePanel2.Hide();
                                            moves = 0;
                                            return;
                                        }
                                    }
                                    else if (pbxGrid[r, tempc + 1].ball != pbxGrid[r, tempc + 1].hole && pbxGrid[r, tempc + 1].hole > 0)
                                    {

                                        pbxGrid[r, tempc + 1].ball = 0;
                                        pbxGrid[r, tempc + 1].hole = 0;
                                        clock1.Stop();
                                        MessageBox.Show("Game Over");
                                        DisplayMessage();

                                        DisableArrowButtons();
                                        ResetGame();
                                        puzzlePanel2.Hide();
                                        btnPause.Hide();
                                        btnStart.Hide();
                                        btnReset.Hide();
                                        btnResume.Hide();
                                        moves = 0;
                                        return;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        UpdatePictures(fileimg);

                    }
                }
            }
        }
        private void Btn_Up_Click_1(object sender, EventArgs e)
        {
            moves++;
            if (result == false)
            {
                for (int r = 1; r < PSize; r++)
                {
                    for (int c = 0; c < PSize; c++)
                    {
                        if (pbxGrid[r, c].ball > 0)
                        {
                            for (int tempc = r; tempc > 0; tempc--)
                            {
                                if (pbxGrid[tempc, c].topwall == false && pbxGrid[tempc - 1, c].ball == 0)
                                {
                                    pbxGrid[tempc - 1, c].ball = pbxGrid[tempc, c].ball;
                                    pbxGrid[tempc, c].ball = 0;

                                    if (pbxGrid[tempc - 1, c].ball == pbxGrid[tempc - 1, c].hole)
                                    {
                                        pbxGrid[tempc - 1, c].ball = 0;
                                        pbxGrid[tempc - 1, c].hole = 0;

                                        marbles--;

                                        if (marbles == 0)
                                        {
                                            result = true;
                                            clock1.Stop();
                                            MessageBox.Show("You Win!!");


                                            TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
                                            int gameMin = playingTime.Minutes;
                                            int gameSec = playingTime.Seconds;

                                            int secondsplayed = (gameMin * 60) + gameSec;

                                            PersonItem person = new PersonItem();
                                            person.Name = ControlID.PersonName;
                                            person.moves = moves;
                                            person.timeelapsed = secondsplayed;


                                            ExistingPersonList.Add(person);
                                            SortListViewByMoves();
                                            AddPerson(person);

                                            DisplayMessage();
                                            DisableArrowButtons();
                                            ResetGame();
                                            puzzlePanel2.Hide();
                                            moves = 0;
                                            return;

                                        }
                                    }
                                    else if (pbxGrid[tempc - 1, c].ball != pbxGrid[tempc - 1, c].hole && pbxGrid[tempc - 1, c].hole > 0)
                                    {

                                        pbxGrid[tempc - 1, c].ball = 0;
                                        pbxGrid[tempc - 1, c].hole = 0;
                                        clock1.Stop();
                                        MessageBox.Show("Game Over");
                                        DisplayMessage();
                                        DisableArrowButtons();
                                        ResetGame();
                                        puzzlePanel2.Hide();
                                        btnPause.Hide();
                                        btnStart.Hide();
                                        btnReset.Hide();
                                        btnResume.Hide();
                                        moves = 0;
                                        return;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    UpdatePictures(fileimg);

                }
            }
        }

    
        private void Btn_Down_Click_1(object sender, EventArgs e)
        {
            moves++;
            if (result == false)
            {
                for (int r = PSize - 2; r >= 0; r--)
                {
                    for (int c = 0; c < PSize; c++)
                    {
                        if (pbxGrid[r, c].ball > 0)
                        {
                            for (int tempr = r; tempr < PSize - 1; tempr++)
                            {
                                if (pbxGrid[tempr, c].bottomwall == false && pbxGrid[tempr + 1, c].ball == 0)
                                {
                                    pbxGrid[tempr + 1, c].ball = pbxGrid[tempr, c].ball;
                                    pbxGrid[tempr, c].ball = 0;

                                    if (pbxGrid[tempr + 1, c].ball == pbxGrid[tempr + 1, c].hole)
                                    {
                                        pbxGrid[tempr + 1, c].ball = 0;
                                        pbxGrid[tempr + 1, c].hole = 0;

                                        marbles--;

                                        if (marbles == 0)
                                        {
                                            result = true;
                                            clock1.Stop();
                                            MessageBox.Show("You Win!!");

                                            TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
                                            int gameMin = playingTime.Minutes;
                                            int gameSec = playingTime.Seconds;

                                            int secondsplayed =  (gameMin * 60) + gameSec;

                                            PersonItem person = new PersonItem();
                                            person.Name = ControlID.PersonName;
                                            person.moves = moves;
                                            person.timeelapsed = secondsplayed;

                                          
                                            ExistingPersonList.Add(person);
                                            SortListViewByMoves();
                                            AddPerson(person);

                                            DisplayMessage();
                                            DisableArrowButtons();
                                            ResetGame();
                                            puzzlePanel2.Hide();

                                            moves = 0;

                                           

                                            return;

                                          

                                        }
                                    }
                                    else if (pbxGrid[tempr + 1, c].ball != pbxGrid[tempr + 1, c].hole && pbxGrid[tempr + 1, c].hole > 0)
                                    {
                                        pbxGrid[tempr + 1, c].ball = 0;
                                        pbxGrid[tempr + 1, c].hole = 0;
                                        clock1.Stop();
                                        MessageBox.Show("Game Over");
                                        DisplayMessage();
                                        DisableArrowButtons();
                                       
                                        ResetGame();
                                        puzzlePanel2.Hide();
                                        btnPause.Hide();
                                        btnStart.Hide();
                                        btnReset.Hide();
                                        btnResume.Hide();
                                        moves = 0;
                                        return;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        UpdatePictures(fileimg);
                      
                    }
                }
            }
        }
  



        private void RemoveTempDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(tempLocation);
            FileInfo[] fileList = dirInfo.GetFiles();
            foreach (FileInfo file in fileList)
            {
                File.Delete(file.FullName);
            }
            Directory.Delete(tempLocation);
        }


        // private List<PersonItem> ExistingPersonList;

        //private void AddPerson(PersonItem person)
        //{
        //    ListViewItem lvi = new ListViewItem();

        //    //Whatever you want to be visible in the first column goes in the text property
        //    lvi.Text = person.Name;
        //    lvi.SubItems.Add(person.Age.ToString());
        //    lvi.SubItems.Add(person.PhoneNumber);
        //    lvi.ImageIndex = person.ImageIndex;

        //    lsvPeople.Items.Add(lvi);
        //}


        public void AddPerson(PersonItem person)
        {
            ListViewItem lvi = new ListViewItem();
            //Whatever you want to be visible in the first column goes in the text property
            lvi.Text = person.Name;
            lvi.SubItems.Add(person.moves.ToString());
            lvi.SubItems.Add(person.timeelapsed.ToString());
            listViewPeople.Items.Add(lvi);
        }

        //public void DisplayMessage()
        //{
        //    if (clock1 != null)
        //    {
        //        int min = clock1.minutes;
        //        int sec = clock1.seconds;

        //        MessageBox.Show("The time elapsed was " + min + " minutes and " + sec + " seconds.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Clock has not been properly initialized.");
        //    }
        //}

        //public void DisplayMessage()
        //{
        //    if (clock1 != null)
        //    {
        //        int min = clock1.minutes;
        //        int sec = clock1.seconds;

        //        // Subtract total paused time from total playing time to get time taken to play the game
        //        TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
        //        int gameMin = playingTime.Minutes;
        //        int gameSec = playingTime.Seconds;

        //        MessageBox.Show("The time elapsed was " + min + " minutes and " + sec + " seconds.\n" +
        //                        "The time taken to play the game was " + gameMin + " minutes and " + gameSec + " seconds.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Clock has not been properly initialized.");
        //    }
        //}

        public void DisplayMessage()
        {
            if (clock1 != null)
            {
                int min = clock1.minutes;
                int sec = clock1.seconds;

                // Subtract total paused time from total playing time to get time taken to play the game
                TimeSpan playingTime = clock1.PlayingTime - clock1.PauseTime;
                if (playingTime < TimeSpan.Zero)
                {
                    playingTime = TimeSpan.Zero;
                }
                int gameMin = playingTime.Minutes;
                int gameSec = playingTime.Seconds;

                MessageBox.Show("The time elapsed was " + min + " minutes and " + sec + " seconds.\n" +
                                "The time taken to play the game was " + gameMin + " minutes and " + gameSec + " seconds.");
            }
            else
            {
                MessageBox.Show("Clock has not been properly initialized.");
            }
        }




        public void btn_select_Click_1(object sender, EventArgs e)
        {

            clock1.PauseTime = TimeSpan.Zero;
            moves = 0;
            button1.Show();
            FormDLL.open_file NewGame = new FormDLL.open_file();
            NewGame.ShowDialog();
            fileContent = NewGame.gamepath;
           fileimg = fileContent + "/" + "puzzle.jpg";
          filepath = fileContent + "/" + "puzzle.txt";
            if (File.Exists(filepath))
            {
                clock1.Start();
                string[] lines = File.ReadAllLines(filepath);


                string[] pieces = lines[0].Split(' ');
                int size = Convert.ToInt32(pieces[0]);
                int ballCount = Convert.ToInt32(pieces[1]);
                int wallCount = Convert.ToInt32(pieces[2]);

                imgTemp = Image.FromFile(fileimg);

                BallsinPlay = ballCount;
                PuzzleSize = size;

                float ratio = 0;

                oldWidth = this.Width;
                oldHeight = this.Height;

                if (imgTemp.Height >= imgTemp.Width)
                {
                    ratio = (float)imgTemp.Width / (float)imgTemp.Height;
                }
                else
                {
                    ratio = (float)imgTemp.Height / (float)imgTemp.Width;
                }

                pbxGrid = new PBXPictureBox[size, size];

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        pbxGrid[row, col] = new PBXPictureBox();
                        pbxGrid[row, col].BackColor = System.Drawing.Color.Red;
                        pbxGrid[row, col].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        pbxGrid[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                        pbxGrid[row, col].Dock = DockStyle.Fill;
                        pbxGrid[row, col].Margin = new System.Windows.Forms.Padding(0);
                        Controls.Add(pbxGrid[row, col]);
                    }
                }

                for (int idx = 1; idx <= ballCount; idx++)
                {
                    string[] coords = lines[idx].Split(' ');
                    int r = Convert.ToInt32(coords[0]);
                    int c = Convert.ToInt32(coords[1]);
                    pbxGrid[r, c].ball = idx;
                }

                for (int idx = ballCount + 1; idx <= ballCount + ballCount; idx++)
                {
                    string[] coords = lines[idx].Split(' ');
                    int r = Convert.ToInt32(coords[0]);
                    int c = Convert.ToInt32(coords[1]);
                    pbxGrid[r, c].hole = idx - ballCount;
                }

                for (int idx = (2 * ballCount) + 1; idx <= ballCount + ballCount + wallCount; idx++)
                {
                    string[] coords = lines[idx].Split(' ');
                    int r1 = Convert.ToInt32(coords[0]);
                    int c1 = Convert.ToInt32(coords[1]);
                    int r2 = Convert.ToInt32(coords[2]);
                    int c2 = Convert.ToInt32(coords[3]);
                    if (r1 == r2)
                    {
                        if (c1 < c2)
                        {
                            pbxGrid[r1, c1].rightwall = true;
                            pbxGrid[r2, c2].leftwall = true;
                        }
                        else
                        {
                            pbxGrid[r1, c1].leftwall = true;
                            pbxGrid[r2, c2].rightwall = true;

                        }
                    }
                    else if (c1 == c2)
                    {
                        if (r1 > r2)
                        {
                            pbxGrid[r1, c1].topwall = true;
                            pbxGrid[r2, c2].bottomwall = true;
                        }
                        else
                        {
                            pbxGrid[r1, c1].bottomwall = true;
                            pbxGrid[r2, c2].topwall = true;
                        }
                    }
                }

                for (int X = 0; X < PuzzleSize; X++)
                {
                    pbxGrid[0, X].topwall = true;
                    pbxGrid[X, 0].leftwall = true;
                    pbxGrid[X, PuzzleSize - 1].rightwall = true;
                    pbxGrid[PuzzleSize - 1, X].bottomwall = true;
                }

                int Dimension = size;
                float PBSize = 100f / Dimension;

                ClearPuzzlePanel();


                puzzlePanel = new TableLayoutPanel();
                puzzlePanel.Dock = DockStyle.Fill;
                puzzlePanel.Margin = new System.Windows.Forms.Padding(0);
                oldDimensions = Dimension;
                if (imgTemp.Width >= imgTemp.Height)

                {
                    puzzlePanel.RowCount = 2;
                    puzzlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, ratio * 100));
                    puzzlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, Math.Abs((ratio * 100) - 100)));
                    tableLayoutPanel1.Controls.Add(puzzlePanel, 0, 0);
                }
                else

                {
                    puzzlePanel.ColumnCount = 2;
                    puzzlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, ratio * 100));
                    puzzlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, Math.Abs((ratio * 100) - 100)));
                    tableLayoutPanel1.Controls.Add(puzzlePanel, 0, 0);

                }

                puzzlePanel2 = new TableLayoutPanel();
                puzzlePanel2.Dock = DockStyle.Fill;
                puzzlePanel2.Margin = new System.Windows.Forms.Padding(0);
                puzzlePanel2.ColumnCount = Dimension;
                puzzlePanel2.RowCount = Dimension;
                puzzlePanel.Controls.Add(puzzlePanel2, 0, 0);
                oldDimensions = Dimension;

                loadfile(filepath);
                UpdatePictures(fileimg);


                for (int row = 0; row < Dimension; row++)
                {
                    puzzlePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, PBSize));
                    puzzlePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, PBSize));
                    for (int col = 0; col < Dimension; col++)
                    {

                        puzzlePanel2.Controls.Add(pbxGrid[row, col], col, row);
                       

                    }


                }


                EnableArrowButtons();
                btnPause.Show();
                btnStart.Show();
                btnReset.Show();
                btnResume.Show();

            }
            else
            {
                Console.WriteLine($"Error: file {filepath} not found");
            }

        }

        //private void Form1_ResizeEnd(object sender, EventArgs e)
        //{
        //    int DiffW = Math.Abs(Width - OldWidth); //Tells us how much W was changed
        //    int DiffH = Math.Abs(Height - OldHeight); //Tells us how much W was changed

        //    if (DiffH > DiffW)
        //    {
        //        Width = Height + 77;
        //    }
        //    else if (DiffW > DiffH)
        //    {
        //        Height = Width - 77;
        //    }
        //}


        private void ResetGame()
        {

            result = false;
            EnableArrowButtons();

            // Load the default image file
            LoadImage = Image.FromFile("puzzle.jpg");

            // Loop through each row and column of the puzzle grid
            for (int row = 0; row < PSize; row++)
            {
                for (int col = 0; col < PSize; col++)
                {
                    // Reset the ball, hole, and wall flags for the current cell
                    pbxGrid[row, col].ball = 0;
                    pbxGrid[row, col].hole = 0;
                    pbxGrid[row, col].leftwall = false;
                    pbxGrid[row, col].rightwall = false;
                    pbxGrid[row, col].topwall = false;
                    pbxGrid[row, col].bottomwall = false;
                }
            }

            // Load the default puzzle file
            loadfile(filepath);

            // Update the pictures in the puzzle grid
            UpdatePictures(fileimg);

            // Disable arrow buttons
            DisableArrowButtons();
        }


        private void ClearPuzzlePanel()
        {
            // Check if the puzzlepanel is not null
            if (puzzlePanel2 != null)
            {
                for (int row = 0; row < oldDimensions; row++)
                {
                    for (int col = 0; col < oldDimensions; col++)
                    {
                        // Remove the control at index 0 from the puzzlepanel
                        puzzlePanel2.Controls.RemoveAt(0);
                    }
                }

                // Remove the puzzlepanel from its parent control (tableLayoutPanel1)
                tableLayoutPanel1.Controls.Remove(puzzlePanel);
            }
        }

        
 
        

 
        private void btnPause_Click_1(object sender, EventArgs e)
        {
            
            if (puzzlePanel2 != null)
            {
                clock1.pause();
                puzzlePanel2.Hide();
                DisableArrowButtons();   

            }
                else
                {
                clock1.pause();
                DisableArrowButtons();
                }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (puzzlePanel2 != null)
            {
                clock1.Start();
                puzzlePanel2.Show();
                EnableArrowButtons();

            }
            else
            {
                clock1.Start();
                EnableArrowButtons();
            }
           
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            clock1.reset();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (puzzlePanel2 != null)
            {
                clock1.Start();
                puzzlePanel2.Show();
                EnableArrowButtons();

            }
            else
            {
                clock1.Start();
                EnableArrowButtons();
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    AddForm af = new AddForm();
        //   af.PersonName = "Type your name!";
        //    DialogResult dr = af.ShowDialog();

        //    if (dr == DialogResult.OK)
        //    {
        //        //Add person to our shadow list
        //        PersonItem tempPerson = new PersonItem();
        //        tempPerson.FirstName = af.PersonName;
        //        ExistingPersonList.Add(tempPerson);


        //        //Add person to the listview
        //        AddPerson(tempPerson);
        //    }
            
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            IFormatter formatter = new BinaryFormatter();

            string ArchiveFile = Path.Combine(Directory.GetCurrentDirectory(), "base.mrb");
            using (ZipArchive archive = ZipFile.Open(ArchiveFile, ZipArchiveMode.Update))
            {
                ZipArchiveEntry oldEntry = archive.GetEntry("puzzle.bin");
                if (oldEntry != null)
                {
                    oldEntry.Delete();
                }
                ZipArchiveEntry scoreEntry = archive.CreateEntry("puzzle.bin");


                using (Stream stream = scoreEntry.Open())
                {
                    formatter.Serialize(stream, ExistingPersonList);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Remember this info will come from your second (file browser) form.
            string archiveLocation = Path.Combine(Directory.GetCurrentDirectory(), "base.mrb");

            if (tempLocation != "")
            {
                RemoveTempDirectory();
            }

            tempLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            Directory.CreateDirectory(tempLocation);

            using (ZipArchive archive = ZipFile.OpenRead(archiveLocation))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(tempLocation, entry.FullName), true);
                }
            }


            IFormatter formatter = new BinaryFormatter();
            string PersonFile = Path.Combine(tempLocation, "puzzle.bin");
            try
            {
                using (FileStream stream = new FileStream(PersonFile, FileMode.Open, FileAccess.Read))
                {
                    ExistingPersonList = (List<PersonItem>)formatter.Deserialize(stream);

                    foreach (PersonItem p in ExistingPersonList)
                    {
                        AddPerson(p);
                    }
                }
            }
            catch (FileNotFoundException )
            {

            }
        }


        public class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 2; // default sort column is 2 (number of moves)
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;

                // Compare the number of moves
                int moves1 = int.Parse(item1.SubItems[1].Text);
                int moves2 = int.Parse(item2.SubItems[1].Text);
                if (moves1 != moves2)
                {
                    return moves1.CompareTo(moves2);
                }

                // If the number of moves are equal, compare the time taken
                double time1 = double.Parse(item1.SubItems[2].Text);
                double time2 = double.Parse(item2.SubItems[2].Text);
                return time1.CompareTo(time2);
            }
        }

        // Sort the items based on the number of moves
        private void SortListViewByMoves()
        {
            listViewPeople.ListViewItemSorter = new ListViewItemComparer(2); // sort by column 2 (number of moves)
            listViewPeople.Sort(); // sort the items
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewPeople.Items.Clear();
            //ExistingPersonList.Clear();


        }

       private void button1_Click_1(object sender, EventArgs e)
{

    if (puzzlePanel2 != null)
    {
                clock1.pause();
                DialogResult result = MessageBox.Show("The game is not saved. Do you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.OK)
        {
            clock1.pause();
            puzzlePanel2.Hide();
            btnPause.Hide();
            btnStart.Hide();
            btnReset.Hide();
            btnResume.Hide();
            DisableArrowButtons();
                    button1.Hide();
            Form2 form2 = new Form2(ExistingPersonList);
            DialogResult form2Result = form2.ShowDialog();

            if (form2Result == DialogResult.Cancel || form2Result == DialogResult.Abort)
            {
                clock1.Start();
                
            }
        }
        else
        {
            return;
        }
    }
    else
    {
        clock1.pause();
        btnPause.Hide();
        btnStart.Hide();
        btnReset.Hide();
        btnResume.Hide();
        DisableArrowButtons();
        Form2 form2 = new Form2(ExistingPersonList);
        DialogResult form2Result = form2.ShowDialog();
       
    }
}

    }
}
