
namespace Assignment_2_marble
{
    partial class Form2
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
            this.clock1 = new FormDLL.Clock();
            this.label1 = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.btn_StartRaffle = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.btn_PickWinner = new System.Windows.Forms.Button();
            this.lblWinner = new System.Windows.Forms.Label();
            this.lbl_TimeRemaining = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // clock1
            // 
            this.clock1.Location = new System.Drawing.Point(30, 315);
            this.clock1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(361, 367);
            this.clock1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(742, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the duration of the raffle in minutes:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(117, 132);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(150, 31);
            this.numDuration.TabIndex = 2;
            this.numDuration.ValueChanged += new System.EventHandler(this.numDuration_ValueChanged);
            // 
            // btn_StartRaffle
            // 
            this.btn_StartRaffle.Location = new System.Drawing.Point(311, 132);
            this.btn_StartRaffle.Name = "btn_StartRaffle";
            this.btn_StartRaffle.Size = new System.Drawing.Size(107, 64);
            this.btn_StartRaffle.TabIndex = 3;
            this.btn_StartRaffle.Text = "Start Raffle";
            this.btn_StartRaffle.UseVisualStyleBackColor = true;
            this.btn_StartRaffle.Click += new System.EventHandler(this.btn_StartRaffle_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToResizeColumns = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(464, 315);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.RowHeadersWidth = 82;
            this.dgvPeople.RowTemplate.Height = 33;
            this.dgvPeople.Size = new System.Drawing.Size(569, 358);
            this.dgvPeople.TabIndex = 4;
            // 
            // btn_PickWinner
            // 
            this.btn_PickWinner.Location = new System.Drawing.Point(311, 202);
            this.btn_PickWinner.Name = "btn_PickWinner";
            this.btn_PickWinner.Size = new System.Drawing.Size(107, 73);
            this.btn_PickWinner.TabIndex = 6;
            this.btn_PickWinner.Text = "Pick Winner";
            this.btn_PickWinner.UseVisualStyleBackColor = true;
            this.btn_PickWinner.Click += new System.EventHandler(this.btn_PickWinner_Click_1);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.Location = new System.Drawing.Point(548, 141);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(304, 55);
            this.lblWinner.TabIndex = 7;
            this.lblWinner.Text = "                    ";
            // 
            // lbl_TimeRemaining
            // 
            this.lbl_TimeRemaining.AutoSize = true;
            this.lbl_TimeRemaining.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_TimeRemaining.Location = new System.Drawing.Point(112, 212);
            this.lbl_TimeRemaining.Name = "lbl_TimeRemaining";
            this.lbl_TimeRemaining.Size = new System.Drawing.Size(174, 25);
            this.lbl_TimeRemaining.TabIndex = 8;
            this.lbl_TimeRemaining.Text = "                           ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 78);
            this.button1.TabIndex = 9;
            this.button1.Text = "View a message for Winner";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1086, 697);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_TimeRemaining);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.btn_PickWinner);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.btn_StartRaffle);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clock1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormDLL.Clock clock1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btn_StartRaffle;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btn_PickWinner;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label lbl_TimeRemaining;
        private System.Windows.Forms.Button button1;
    }
}