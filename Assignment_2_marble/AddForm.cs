using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//{
//    public partial class AddForm : Form

//    { 
//        open_file dlg = new open_file();

//        private string strPlaceholder;

//        public AddForm()
//        {
//            InitializeComponent();
//        }

//        public string PersonName
//        {
//            set
//            {
//                txtBoxName.Text = value;
//                strPlaceholder = value;
//            }
//            get
//            {
//                return txtBoxName.Text;
//            }
//        }
//        private void btnAdd_Click(object sender, EventArgs e)
//        {

//            if (txtBoxName.Text == "")
//            {
//                MessageBox.Show("Enter Your Name!!!");
//            }

//            this.Close();
//        }

//    }
//}
namespace Assignment_2_marble
{

    public static class ControlID
    {
        
        public static string gamepath { get; set; }
        public static int gamesize { get; set; }

        public static string PersonName { get; set; }
        


    }
    public partial class AddForm : Form
    {
        private string strPlaceholder;

        Form1 dlg = new Form1();

        public AddForm()
        {
           
            InitializeComponent();
           
        }

        public string PersonName
        {
            set
            {
                txtBoxName.Text = value;
                strPlaceholder = value;
            }
            get
            {
                return txtBoxName.Text;
            }
        }
   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "")
            {
                MessageBox.Show("Enter Your Name!!!");
            }

            else
            {
                ControlID.PersonName = txtBoxName.Text;
                dlg.ShowDialog();
                this.Close();
            }
           
        }
    }
}

