using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;


namespace Kalman_Filter
{
    public partial class Form1 : Form
    {
        #region Variables
        float px, py, cx, cy, ix = 100, iy;
        #endregion

        #region Plot Variables
        double[] data_array_X = new double[100];
        double[] data_array_Y = new double[100];
        double[] Kalman_array_Y = new double[100];
        double[] Kalman_array_X = new double[100];
        Random rand = new Random();
        int sine_pos = 0;
        #endregion

        #region Kalman Filter and Poins Lists
        PointF[] oup = new PointF[2];
        private Kalman kal;
        private SyntheticData syntheticData;
        private List<PointF> mousePoints;
        private List<PointF> kalmanPoints;
        #endregion

        #region Timers
        Timer SineWave_Timer = new Timer();
        Timer RandomWave_Timer = new Timer();
        #endregion

        public Form1()
        {
            InitializeComponent();
            //InitialiseTimers();
            InitialiseTimers(100);

            //set up x data for initial condition and scrolling
            data_array_X[0] = 100;
            for (int i = 1; i < data_array_X.Length; i++)
            {
                data_array_X[i] = i;
                Kalman_array_X[i] = i;
                //data_array_Y[i] = rand.Next(100);
            }
            SetupChart();
        }
        //private void InitialiseTimers(int Timer_Interval = 100)
        private void InitialiseTimers(int Timer_Interval)
        {
            SineWave_Timer.Interval = Timer_Interval;
            SineWave_Timer.Tick += new EventHandler(SineWave_Timer_Tick);
            RandomWave_Timer.Interval = Timer_Interval;
            RandomWave_Timer.Tick += new EventHandler(RandomWave_Timer_Tick);
        }
        public void SetupChart()
        {
            //Data 
            //Type and colour

            chart1.Series[0].Label = "The Data";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[0].Color = Color.Blue;

            //Axis
            chart1.ChartAreas[0].AxisX.Title = "X axis";
            chart1.ChartAreas[0].AxisY.Title = "Y axis";

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisX.Maximum = data_array_X.Length - 1;

            //Kalman
            //Type and colour
            chart1.Series[1].Label = "Kalman Data";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[1].Color = Color.Red;

            Update();
        }
        
       
        //Setup Kalman Filter and predict methods
        public void KalmanFilter()
            {
                mousePoints = new List<PointF>();
                kalmanPoints = new List<PointF>();
                kal = new Kalman(4, 2, 0);
                syntheticData = new SyntheticData();
                Matrix<float> state = new Matrix<float>(new float[]
                {
                    0.0f, 0.0f, 0.0f, 0.0f
                });
                kal.CorrectedState = state;
                kal.TransitionMatrix = syntheticData.transitionMatrix;
                kal.MeasurementNoiseCovariance = syntheticData.measurementNoise;
                kal.ProcessNoiseCovariance = syntheticData.processNoise;
                kal.ErrorCovariancePost = syntheticData.errorCovariancePost;
                kal.MeasurementMatrix = syntheticData.measurementMatrix;
            }
        public PointF[] filterPoints(PointF pt)
        {
            syntheticData.state[0, 0] = pt.X;
            syntheticData.state[1, 0] = pt.Y;
            Matrix<float> prediction = kal.Predict();
            PointF predictPoint = new PointF(prediction[0, 0], prediction[1, 0]);
            PointF measurePoint = new PointF(syntheticData.GetMeasurement()[0, 0],
                syntheticData.GetMeasurement()[1, 0]);
            Matrix<float> estimated = kal.Correct(syntheticData.GetMeasurement());
            PointF estimatedPoint = new PointF(estimated[0, 0], estimated[1, 0]);
            syntheticData.GoToNextState();
            PointF[] results = new PointF[2];
            results[0] = predictPoint;
            results[1] = estimatedPoint;
            px = predictPoint.X;
            py = predictPoint.Y;
            cx = estimatedPoint.X;
            cy = estimatedPoint.Y;
            return results;
        }

        //Initialse Wave Function
        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (Start_BTN.Text == "Start Sine Wave")
            {
                KalmanFilter(); //initialize kalman filter
                SineWave_Timer.Start();
                Start_BTN.Text = "Stop Sine Wave";
            }
            else
            {
                SineWave_Timer.Stop();
                Start_BTN.Text = "Start Sine Wave";
            }
        }
        private void Start_BTN2_Click(object sender, EventArgs e)
        {
            if (Start_BTN2.Text == "Start Random")
            {
                KalmanFilter(); //initialize kalman filter
                RandomWave_Timer.Start();
                Start_BTN2.Text = "Stop Random";
                timmer_UPDN.Enabled = false;
            }
            else
            {
                RandomWave_Timer.Stop();
                Start_BTN2.Text = "Start Random";
                timmer_UPDN.Enabled = true;
            }
        }

        public void SineWave_Timer_Tick(object sender, EventArgs e)
        {
            ix++;
            iy = nextSineWavePosition(ix++);

            //set data
            Array.Copy(data_array_Y, 1, data_array_Y, 0, 99);
            data_array_Y[data_array_Y.Length - 1] = iy;
            Array.Copy(data_array_X, 1, data_array_X, 0, 99);
            data_array_X[data_array_X.Length - 1] = ix;

            //display data
            CalculatedData_LBL.Text = "Calculated Data- X:" + ix.ToString() + " Y:" + iy.ToString();

            //updatae kalman and predict
            PointF inp = new PointF(ix, iy);
            oup = new PointF[2];
            oup = filterPoints(inp);

            PointF[] pts = oup;

            KalmanCorrection_LBL.Text = "Kalman Correction- X:" + ((int)cx).ToString() + " Y:" + ((int)cy).ToString();
            CalculatedPrediction_LBL.Text = "Calculated Prediction- X:" + ((int)px).ToString() + " Y:" + ((int)py).ToString();

            //Set kalman Data
            Array.Copy(Kalman_array_Y, 1, Kalman_array_Y, 0, 99);
            Kalman_array_Y[Kalman_array_Y.Length - 1] = cy;
            Array.Copy(Kalman_array_X, 1, Kalman_array_X, 0, 99);
            Kalman_array_X[Kalman_array_X.Length - 1] = cx;

            Update();
            this.Refresh();
        }
        public void RandomWave_Timer_Tick(object sender, EventArgs e)
        {
            ix++;
            iy = rand.Next(100);

            //set data
            Array.Copy(data_array_Y, 1, data_array_Y, 0, 99);
            data_array_Y[data_array_Y.Length - 1] = iy;
            Array.Copy(data_array_X, 1, data_array_X, 0, 99);
            data_array_X[data_array_X.Length - 1] = ix;

            //display data
            CalculatedData_LBL.Text = "Calculated Data- X:" + ix.ToString() + " Y:" + iy.ToString();

            //updatae kalman and predict
            PointF inp = new PointF(ix, iy);
            oup = new PointF[2];
            oup = filterPoints(inp);

            PointF[] pts = oup;

            KalmanCorrection_LBL.Text = "Kalman Correction- X:" + ((int)cx).ToString() + " Y:" + ((int)cy).ToString();
            CalculatedPrediction_LBL.Text = "Calculated Prediction- X:" + ((int)px).ToString() + " Y:" + ((int)py).ToString();

            //Set kalman Data
            Array.Copy(Kalman_array_Y, 1, Kalman_array_Y, 0, 99);
            Kalman_array_Y[Kalman_array_Y.Length - 1] = cy;
            Array.Copy(Kalman_array_X, 1, Kalman_array_X, 0, 99);
            Kalman_array_X[Kalman_array_X.Length - 1] = cx;

            Update();
            this.Refresh();
        }

        double amplitude = 100;
        double frequency = 500;

        public float nextSineWavePosition(float i)
        {
            return (float)(amplitude * Math.Sin(2 * Math.PI * frequency * i * 0.00004));
        }
        public void Update()
        {
            chart1.ChartAreas[0].AxisX.Minimum = data_array_X[0];
            chart1.Series[0].Points.DataBindXY(data_array_X, data_array_Y);
            chart1.Series[1].Points.DataBindXY(Kalman_array_X, Kalman_array_Y);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            InitialiseTimers((int)timmer_UPDN.Value);
        }


    }
}
