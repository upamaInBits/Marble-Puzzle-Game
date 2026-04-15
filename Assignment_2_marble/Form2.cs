using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static Assignment_2_marble.Form1;


namespace Assignment_2_marble
{
    public partial class Form2 : Form
    {
        private List<PersonItem> personList;

        
        private Timer timer1 = new Timer();
        private int raffleDuration;
        private Stopwatch stopwatch1 = new Stopwatch();
        public Form2(List<PersonItem> personList)
        {
            InitializeComponent();
            btn_PickWinner.Enabled = false;
            button1.Visible = false;
            this.personList = personList;

            // Add columns to the ListView control
            dgvPeople.Columns.Add("Name", "Name");
            dgvPeople.Columns.Add("Moves", "Moves");
            dgvPeople.Columns.Add("Time Elapsed", "Time Elapsed");

            // Populate the ListView control with the PersonItem objects
            foreach (PersonItem person in personList)
            {
                dgvPeople.Rows.Add(person.Name, person.moves.ToString(), person.timeelapsed.ToString());
            }
            dgvPeople.ReadOnly = true;
        }
        
        private void btn_StartRaffle_Click(object sender, EventArgs e)
        {
            if (numDuration.Value == 0)
            {
                MessageBox.Show("Please select a time duration for the raffle.");
                return;
            }

            // Get the duration of the raffle from the NumericUpDown control
            raffleDuration = (int)numDuration.Value * 60 * 1000; // Convert to milliseconds

            clock1.Start();
            // Start the stopwatch and timer
            stopwatch1.Start();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            // Disable the NumericUpDown and Start Raffle button
            numDuration.Enabled = false;
            btn_StartRaffle.Enabled = false;
            btn_PickWinner.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
            {
                // Calculate the time remaining for the raffle
                int timeRemaining = raffleDuration - (int)stopwatch1.ElapsedMilliseconds;

                // Update the label with the time remaining
                lbl_TimeRemaining.Text = string.Format("{0}:{1:00}", timeRemaining / 60000, (timeRemaining / 1000) % 60);
            //The remaining time is displayed in the format "mm:ss" where "mm" represents minutes and "ss" represents seconds.

            // If the raffle is over, stop the timer and pick a winner
            if (timeRemaining <= 0)
                {
                    timer1.Stop();
                    PickWinner();
                }
            }

            public void PickWinner()
            {
            timer1.Stop();
            // Select a random participant from the list
            Random rdm = new Random();
                int index = rdm.Next(personList.Count);
                string winnerName = personList[index].Name;

                // Display the name of the winner in the label
                lblWinner.Text = "Winner: " + winnerName;

                // Disable the Pick Winner button
                btn_PickWinner.Enabled = false;


            clock1.Stop();


            if (clock1 != null)
            {
                int min = clock1.minutes;
                int sec = clock1.seconds;

                MessageBox.Show("The time elapsed was " + min + " minutes and " + sec + " seconds.");

            }
            else
            {
                MessageBox.Show("Clock has not been properly initialized.");
            }

            button1.Visible = true;

        }

       

        private void numDuration_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_PickWinner_Click_1(object sender, EventArgs e)
        {
            // Call the PickWinner method
            PickWinner();
        
                //if (clock1 != null)
                //{
                //    int min = clock1.minutes;
                //    int sec = clock1.seconds;

                //MessageBox.Show("The time elapsed was " + min + " minutes and " + sec + " seconds.");
                                    
                //}
                //else
                //{
                //    MessageBox.Show("Clock has not been properly initialized.");
                //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string winnerName = lblWinner.Text.Replace("Winner: ", "");
            //rafflewinner.winner NewGame = new rafflewinner.winner();
            rafflewinner.winner winnerForm = new rafflewinner.winner(winnerName);
          //  winnerForm.Show();

        }
    }

}
