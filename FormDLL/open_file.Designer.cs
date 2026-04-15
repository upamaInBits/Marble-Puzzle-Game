using System.Drawing;
using System.Windows.Forms;


namespace FormDLL
{
    partial class open_file
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(open_file));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ListName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_size = new System.Windows.Forms.Label();
            this.lbl_ball = new System.Windows.Forms.Label();
            this.lbl_wall = new System.Windows.Forms.Label();
            this.picbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListName,
            this.size,
            this.DateModified});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(513, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(436, 364);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // ListName
            // 
            this.ListName.Text = "Name";
            this.ListName.Width = 128;
            // 
            // size
            // 
            this.size.Text = "size";
            this.size.Width = 78;
            // 
            // DateModified
            // 
            this.DateModified.Text = "Date Modified";
            this.DateModified.Width = 90;
            // 
            // imageList1
            // 



            this.imageList1.Images.Add(Image.FromFile("mrb.png"));
            this.imageList1.Images.Add(Image.FromFile("jpg.png"));
            this.imageList1.Images.Add(Image.FromFile("txt.png"));
            this.imageList1.Images.Add(Image.FromFile("folder.png"));
            this.imageList1.Images.Add(Image.FromFile("vs.png"));
            this.imageList1.Images.Add(Image.FromFile("zip.png"));
            this.imageList1.Images.Add(Image.FromFile("extra.png"));



            //  this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mrb.png");
            this.imageList1.Images.SetKeyName(1, "jpg.jpg");
            this.imageList1.Images.SetKeyName(2, "txt.png");
            this.imageList1.Images.SetKeyName(3, "vs.png");
            this.imageList1.Images.SetKeyName(4, "folder.png");
            this.imageList1.Images.SetKeyName(5, "zip.png");
            this.imageList1.Images.SetKeyName(6, "extra.png");

            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(800, 6);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(116, 40);
            this.btn_open.TabIndex = 6;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(644, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.WordWrap = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchKey);
            // 
            // btn_up
            // 
            this.btn_up.Location = new System.Drawing.Point(664, 6);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(128, 40);
            this.btn_up.TabIndex = 9;
            this.btn_up.Text = "One Level Up";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(836, 426);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(116, 40);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_size
            // 
            this.lbl_size.AutoSize = true;
            this.lbl_size.Location = new System.Drawing.Point(18, 426);
            this.lbl_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(48, 20);
            this.lbl_size.TabIndex = 10;
            this.lbl_size.Text = "size: ";
            // 
            // lbl_ball
            // 
            this.lbl_ball.AutoSize = true;
            this.lbl_ball.Location = new System.Drawing.Point(174, 426);
            this.lbl_ball.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ball.Name = "lbl_ball";
            this.lbl_ball.Size = new System.Drawing.Size(51, 20);
            this.lbl_ball.TabIndex = 11;
            this.lbl_ball.Text = "Balls: ";
            // 
            // lbl_wall
            // 
            this.lbl_wall.AutoSize = true;
            this.lbl_wall.Location = new System.Drawing.Point(328, 426);
            this.lbl_wall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_wall.Name = "lbl_wall";
            this.lbl_wall.Size = new System.Drawing.Size(51, 20);
            this.lbl_wall.TabIndex = 12;
            this.lbl_wall.Text = "Walls:";
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(22, 49);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(360, 369);
            this.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox.TabIndex = 13;
            this.picbox.TabStop = false;
            // 
            // Read_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 483);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.lbl_wall);
            this.Controls.Add(this.lbl_ball);
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_open);
            this.Name = "Read_File";
            this.Text = "Read_File";
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ListName;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader DateModified;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_up;

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Label lbl_ball;
        private System.Windows.Forms.Label lbl_wall;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.ImageList imageList1;
    }
}