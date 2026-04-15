namespace Assignment_2_marble
{
    partial class Form1
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.Btn_Right = new System.Windows.Forms.Button();
            this.Btn_Down = new System.Windows.Forms.Button();
            this.Btn_Left = new System.Windows.Forms.Button();
            this.Btn_Up = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.clock1 = new FormDLL.Clock();
            this.listViewPeople = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMoves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReset = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 844F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1117F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2608, 1117);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.Btn_Right);
            this.panel1.Controls.Add(this.Btn_Down);
            this.panel1.Controls.Add(this.Btn_Left);
            this.panel1.Controls.Add(this.Btn_Up);
            this.panel1.Controls.Add(this.btn_select);
            this.panel1.Controls.Add(this.clock1);
            this.panel1.Controls.Add(this.listViewPeople);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnResume);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Location = new System.Drawing.Point(1767, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 939);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 100);
            this.button1.TabIndex = 51;
            this.button1.Text = "Open Raffle!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(531, 842);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(115, 72);
            this.btn_clear.TabIndex = 50;
            this.btn_clear.Text = "CLEAR BOARD";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Right
            // 
            this.Btn_Right.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Right.Image")));
            this.Btn_Right.Location = new System.Drawing.Point(415, 326);
            this.Btn_Right.Name = "Btn_Right";
            this.Btn_Right.Size = new System.Drawing.Size(193, 183);
            this.Btn_Right.TabIndex = 49;
            this.Btn_Right.UseVisualStyleBackColor = true;
            this.Btn_Right.Click += new System.EventHandler(this.Btn_Right_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Down.Image")));
            this.Btn_Down.Location = new System.Drawing.Point(219, 515);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(200, 171);
            this.Btn_Down.TabIndex = 48;
            this.Btn_Down.UseVisualStyleBackColor = true;
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click_1);
            // 
            // Btn_Left
            // 
            this.Btn_Left.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Left.Image")));
            this.Btn_Left.Location = new System.Drawing.Point(24, 316);
            this.Btn_Left.Name = "Btn_Left";
            this.Btn_Left.Size = new System.Drawing.Size(189, 191);
            this.Btn_Left.TabIndex = 47;
            this.Btn_Left.UseVisualStyleBackColor = true;
            this.Btn_Left.Click += new System.EventHandler(this.Btn_Left_Click_1);
            // 
            // Btn_Up
            // 
            this.Btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Up.Image")));
            this.Btn_Up.Location = new System.Drawing.Point(219, 143);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(198, 171);
            this.Btn_Up.TabIndex = 46;
            this.Btn_Up.UseVisualStyleBackColor = true;
            this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click_1);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(204, 26);
            this.btn_select.Margin = new System.Windows.Forms.Padding(4);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(213, 75);
            this.btn_select.TabIndex = 45;
            this.btn_select.Text = "SELECT FILE";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click_1);
            // 
            // clock1
            // 
            this.clock1.Location = new System.Drawing.Point(38, 730);
            this.clock1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(191, 194);
            this.clock1.TabIndex = 44;
            // 
            // listViewPeople
            // 
            this.listViewPeople.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colMoves,
            this.colTime});
            this.listViewPeople.HideSelection = false;
            this.listViewPeople.Location = new System.Drawing.Point(238, 730);
            this.listViewPeople.Name = "listViewPeople";
            this.listViewPeople.Size = new System.Drawing.Size(287, 184);
            this.listViewPeople.TabIndex = 43;
            this.listViewPeople.UseCompatibleStateImageBehavior = false;
            this.listViewPeople.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 78;
            // 
            // colMoves
            // 
            this.colMoves.Text = "moves";
            this.colMoves.Width = 77;
            // 
            // colTime
            // 
            this.colTime.Text = "timeelapsed";
            this.colTime.Width = 132;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(466, 631);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(133, 55);
            this.btnReset.TabIndex = 42;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(466, 545);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(133, 55);
            this.btnResume.TabIndex = 41;
            this.btnResume.Text = "RESUME";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(38, 557);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 55);
            this.btnStart.TabIndex = 40;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(38, 645);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(125, 55);
            this.btnPause.TabIndex = 39;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2608, 1117);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPause;
       // private IPControl3.Clock clock1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView listViewPeople;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colMoves;
        private System.Windows.Forms.ColumnHeader colTime;
        private FormDLL.Clock clock1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button Btn_Right;
        private System.Windows.Forms.Button Btn_Down;
        private System.Windows.Forms.Button Btn_Left;
        private System.Windows.Forms.Button Btn_Up;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button button1;
    }
}


