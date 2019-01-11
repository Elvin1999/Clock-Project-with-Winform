using System;
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
        DateTime london_time = DateTime.Now.AddHours(-4);
        DateTime baku_time = DateTime.Now;
        public Label MyClockLabel { get; set; }
        public string imagepath { get; set; }
        public string LabelImage { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            Label clocklabel = new Label();
            clocklabel.Location = new Point(170, 30);
            clocklabel.BackColor = Color.Blue;
            clocklabel.Size = new Size(500, 350);
            clocklabel.Text = baku_time.ToLongTimeString();
            clocklabel.Font = new Font("Italic", 50);
            clocklabel.Image = Image.FromFile("baku.png");
            Button baku_clock = new Button();
            Button london_clock = new Button();
            baku_clock.Size = new Size(85, 30);
            london_clock.Size = new Size(85, 30);
            baku_clock.Location = new Point(250, 150);
            london_clock.Location = new Point(400, 150);
            baku_clock.BackColor = Color.LightBlue;
            london_clock.BackColor = Color.LightBlue;
            baku_clock.Text = "Baku";
            london_clock.Text = "London";
            baku_clock.Font = new Font("Italic", 14);
            london_clock.Font = new Font("Italic", 14);
            baku_clock.Click += Baku_clock_Click;
            london_clock.Click += London_clock_Click;
            Controls.Add(baku_clock);
            Controls.Add(london_clock);
            MyClockLabel = clocklabel;
            Controls.Add(clocklabel);
            
        }       
        private void London_clock_Click(object sender, EventArgs e)
        {
            MyClockLabel.Text = london_time.ToLongTimeString();

            MyClockLabel.Image = Image.FromFile("london.png");
        }

        private void Baku_clock_Click(object sender, EventArgs e)
        {         
            MyClockLabel.Text = baku_time.ToLongTimeString();
            MyClockLabel.Image = Image.FromFile("baku.png");
        }
    }
}
