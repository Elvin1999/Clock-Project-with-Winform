﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ClockProjectAsDigital
{
    public partial class Form1 : Form
    {
        public DateTime london_time { get; set; }
        public DateTime baku_time { get; set; }
        public Label MyClockLabel { get; set; }
        public string time { get; set; }
        public bool IsClickedToLondonButton { get; set; }
        public bool IsClickedToBakuButton { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private Button GetButton(string text,int x,int y)
        {
            Button button = new Button();
            button.Size = new Size(85, 30);
            button.Location = new Point(x, y);
            button.BackColor = Color.LightBlue;
            button.Text = text;
            button.Font = new Font("Italic", 14);
            return button;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IsClickedToBakuButton = true;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;
            Label clocklabel = new Label();
            clocklabel.Location = new Point(170, 30);
            clocklabel.BackColor = Color.Blue;
            clocklabel.Size = new Size(500, 350);
            clocklabel.Text = DateTime.Now.ToLongTimeString();
            clocklabel.Font = new Font("Imprint MT Shadow", 50);
            //clocklabel.Image = Image.FromFile("baku.png");
            clocklabel.Image = Properties.Resources.baku;
            
            Button baku_clock_button = GetButton("Baku",250,150);
            Button london_clock_button = GetButton("London",450,150);         
            baku_clock_button.Click += Baku_clock_Click;
            london_clock_button.Click += London_clock_Click;
            Controls.Add(baku_clock_button);
            Controls.Add(london_clock_button);
            MyClockLabel = clocklabel;
            Controls.Add(clocklabel);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            baku_time = DateTime.Now;
            baku_time.AddSeconds(1);
            london_time = baku_time.AddHours(-4);
            london_time.AddSeconds(1);
            time = london_time.ToLongTimeString();//for london
            if (IsClickedToLondonButton)
            {
                MyClockLabel.Text = time;
            }
            else if (IsClickedToBakuButton)
            {
                MyClockLabel.Text = baku_time.ToLongTimeString();
            }
        }
        private void London_clock_Click(object sender, EventArgs e)
        {
            MyClockLabel.Text = time;
            //MyClockLabel.Image = Image.FromFile("london.png");
            MyClockLabel.Image = Properties.Resources.london;
            IsClickedToLondonButton = true;
            IsClickedToBakuButton = false;
        }
        private void Baku_clock_Click(object sender, EventArgs e)
        {
            MyClockLabel.Text = baku_time.ToLongTimeString();
            //MyClockLabel.Image = Image.FromFile("baku.png");
            MyClockLabel.Image = Properties.Resources.baku;
            IsClickedToBakuButton = true;
            IsClickedToLondonButton = false;
        }
    }
}