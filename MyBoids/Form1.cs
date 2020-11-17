using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyBoids
{
    public partial class Form1 : Form
    {
        public static int AreaWidth;
        public static int AreaHeight;
        public static bool MouseOverRenderArea;
        public static bool Recording = false;
        Bitmap image { get; set; }
        StreamWriter file;

        private readonly Stopwatch stopwatch = new Stopwatch();

        enum Flavors {CPUseq, CPUpar}
        
        Flavors flavor = Flavors.CPUseq;


        public Form1()
        {
            InitializeComponent();
            
            AreaWidth = RenderArea.Width;
            AreaHeight = RenderArea.Height;

            image = new Bitmap(AreaWidth, AreaHeight, PixelFormat.Format32bppRgb);
            RenderArea.Image = image;

            BoidCalculations.Reset(AreaWidth / 2, AreaHeight / 2);
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.Renderer.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        switch (radio.Name)
                        {
                            case "CpuSeqRadBut":
                                flavor = Flavors.CPUseq;
                                break;
                            case "CPUParRadBut":
                                flavor = Flavors.CPUpar;
                                break;
                            default:
                                flavor = Flavors.CPUseq;
                                break;
                        }
                    }
                }
            }
        }

        private void VisionTrackBar_Scroll(object sender, EventArgs e)
        {
            BoidCalculations.VisionDistance = 2 * VisionTrackBar.Value;
        }

        private void AttractTrackBar_Scroll(object sender, EventArgs e)
        {
            BoidCalculations.CohesionWeight = (double)AttractTrackBar.Value / 10000;
        }

        private void AvoidTrackBar_Scroll(object sender, EventArgs e)
        {
            BoidCalculations.SeparateWeight = (float)AvoidTrackBar.Value / 1000;
        }

        private void AlignTrackBar_Scroll(object sender, EventArgs e)
        {
            BoidCalculations.AlignmentWeight = (float)AlignTrackBar.Value / 100;
        }

        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            BoidCalculations.SpeedMultiplier = (float)SpeedTrackBar.Value / 4;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            BoidCalculations.Reset(AreaWidth / 2, AreaHeight / 2);

            for (int x = 1; x < RenderArea.Width; x++)
            {
                for (int y = 1; y < RenderArea.Height; y++)
                {
                    image.SetPixel(x, y, Color.Black);
                }

            }
        }

        private void RenderArea_Click(object sender, EventArgs e)
        {
            MouseEventArgs mevent = e as MouseEventArgs;

            if (mevent.Button == MouseButtons.Left)
            {
                image.SetPixel(mevent.X, mevent.Y, Color.White);
            }

            RenderArea.Refresh();
        }

        private void RenderArea_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mevent = e as MouseEventArgs;

            if(RenderArea.ClientRectangle.Contains(mevent.Location)) // check if mouse inside render area ( prevents crashing)
            {
                if (mevent.Button == MouseButtons.Left)
                {
                    BoidCalculations.GenerateBoids(mevent.X, mevent.Y);
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            stopwatch.Restart();


            switch (flavor)
            {
                case Flavors.CPUpar:
                    BoidCalculations.CalcBoidsCPUPAR(); // this is the CPU parallel version
                    break;
                case Flavors.CPUseq:
                default:
                    BoidCalculations.CalcBoidsCPUSEQ(); // this is the CPU sequential version // comment this out if you want to validate parallel calculations
                    // BoidCalculations.ValidateParCPU(); // uncomment this if you want to validate parallel calculations
                    break;
            }

            foreach (BoidObject Boid in BoidCalculations.BoidArray)
            {
                image.SetPixel(Boid.OldIntPosX, Boid.OldIntPosY, Color.Black); 
                image.SetPixel(Boid.IntPosX, Boid.IntPosY, Color.White);

            }

            RenderArea.Refresh();
            double fps = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;
            FPSLabel.Text = $"FPS: {1 / fps:0.00} ";
            
            BoidCountLabel.Text = $"Boids on screen: {BoidCalculations.BoidArray.Length:0}";

            if (Recording)
            {
                file.WriteLine($"{flavor}, {fps}, {1/fps}, {BoidCalculations.BoidArray.Length}"); // Flavour, Time since last tick, Framerate, Boids on screen
            }
            
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            
            string WorkingDirectory = Environment.CurrentDirectory;
            string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;

            string FileName= string.Concat(ProjectDirectory, "/RecordBoids.csv");

            file = new StreamWriter(FileName, true);
             
            file.WriteLine("Flavour, Time since last tick, Framerate, Boids on screen");

            RecordButton.Visible = false;
            SaveButton.Visible = true;
            Recording = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Recording = false;
            file.Close();

            RecordButton.Visible = true;
            SaveButton.Visible = false;
        }

    }
}
