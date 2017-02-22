using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DGPattern
{
    public partial class Form1 : Form
    {
        double[] ratio;
        double[] phase;
        double[] spacing;
        double[] orientation;
        double[] heightA;
        double[] heightB;
        double[] heightC;
        double[] heightD;
        double elevation;
        int numTowers;
        int tower;
        double[] directionalmagnitude;
        


        public Form1()
        {
            InitializeComponent();
            ratio = new double[100];
            phase = new double[100];
            spacing = new double[100];
            orientation = new double[100];
            heightA = new double[100];
            heightB = new double[100];
            heightC = new double[100];
            heightD = new double[100];
            elevation = 0;
            numTowers = 1;
            tower = 1;
            ratio[1] = 1;
            heightA[1] = 90;
            directionalmagnitude = new double[3600];
            CalculatePattern();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void RatioScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtRatio.Text = ((double)(RatioScrollBar.Value)/100).ToString();
        }

        private void PhaseScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtPhase.Text = ((double)(PhaseScrollBar.Value) / 10).ToString();
        }

        private void SpacingScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtSpacing.Text = ((double)(SpacingScrollBar.Value) / 10).ToString();
        }
        private void OrientationScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtOrientation.Text = ((double)(OrientationScrollBar.Value) / 10).ToString();
        }

        private void HeightScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtHeight.Text = ((double)(HeightScrollBar.Value) / 10).ToString();
        }

        private void txtRatio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtRatio.Text) *100;
                RatioScrollBar.Value = (int)scrollValue;
                ratio[tower] = double.Parse(txtRatio.Text);
                CalculatePattern();
            }
            catch
            {

            }
                        
        }

        private void txtPhase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtPhase.Text) * 10;
                PhaseScrollBar.Value = (int)scrollValue;
                phase[tower] = double.Parse(txtPhase.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtSpacing_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtSpacing.Text) * 10;
                SpacingScrollBar.Value = (int)scrollValue;
                spacing[tower] = double.Parse(txtSpacing.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtOrientation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtOrientation.Text) * 10;
                OrientationScrollBar.Value = (int)scrollValue;
                orientation[tower] = double.Parse(txtOrientation.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtHeight.Text) * 10;
                HeightScrollBar.Value = (int)scrollValue;
                heightA[tower] = double.Parse(txtHeight.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtTowers_ValueChanged(object sender, EventArgs e)
        {
            numTowers = (int)txtTowers.Value;
            if (heightA[numTowers] < 1)
            {
                heightA[numTowers] = heightA[1];
            }
            TowerScrollBar.Maximum = (int)txtTowers.Value;
            
            if (tower > numTowers)
            {
                txtTower.Text = numTowers.ToString();
            }
            CalculatePattern();
        }

        private void TowerScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtTower.Text = TowerScrollBar.Value.ToString();
            tower = TowerScrollBar.Value;
            txtRatio.Text = ratio[tower].ToString();
            txtPhase.Text = phase[tower].ToString();
            txtSpacing.Text = spacing[tower].ToString();
            txtOrientation.Text = orientation[tower].ToString();
            txtHeight.Text = heightA[tower].ToString();
            
        }

        private void txtTower_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtTower.Text);
                TowerScrollBar.Value = (int)scrollValue;
                tower = TowerScrollBar.Value;
                txtRatio.Text = ratio[tower].ToString();
                txtPhase.Text = phase[tower].ToString();
                txtSpacing.Text = spacing[tower].ToString();
                txtOrientation.Text = orientation[tower].ToString();
                txtHeight.Text = heightA[tower].ToString();

            }
            catch
            {

            }
        }

        private void ThetaScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtTheta.Text = (90-((double)(ThetaScrollBar.Value)/10)).ToString();
            CalculatePattern();
        }

        private void txtTheta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = 900 - (double.Parse(txtTheta.Text) * 10);
                ThetaScrollBar.Value = (int) scrollValue;
                elevation = double.Parse(txtTheta.Text);
            }
            catch
            {

            }
        }

        private double FunctionOfTheta(double angle, double height)
        {
            double G = DegreeToRadian(height);
            double theta = DegreeToRadian(angle);
            return (Math.Cos(G * Math.Sin(theta)) - Math.Cos(G)) / ((1 - Math.Cos(G)) * Math.Cos(theta));
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double DirectionalResult (double azimuth, double elevation)
        {
            double phi = DegreeToRadian(azimuth);
            double theta = DegreeToRadian(elevation);
            
            Complex resultant = new Complex(0,0);
            
            for (int i = 1; i <= numTowers; i++)
            {
                double magnitude = ratio[i] * FunctionOfTheta(elevation, heightA[i]);
                double towerPhaseShift = DegreeToRadian(phase[i]);
                double totalphase = (DegreeToRadian(spacing[i]) * Math.Cos(DegreeToRadian(orientation[i]) - phi))+towerPhaseShift;
                Complex contribution = Complex.FromPolarCoordinates(magnitude, totalphase);
                resultant = Complex.Add(resultant, contribution);
            }
            return resultant.Magnitude;    
        }
        private void CalculatePattern(bool highPrecision)
        {
            double maxy = 0;
            Series pattern = new Series("Pattern");
            Series zoomandenhance = new Series("Zoom and Enhance");
            pattern.ChartType = SeriesChartType.Polar;
            zoomandenhance.ChartType = SeriesChartType.Polar;
            
            if (highPrecision)
            {
                for (int i = 0; i < 3600; i++)
                {
                    double azimuth = ((double)i)/10;
                    directionalmagnitude[i] = DirectionalResult(azimuth, elevation);
                    if (directionalmagnitude[i] > maxy)
                    {
                        maxy = directionalmagnitude[i];
                    }
                    DataPoint point = new DataPoint(azimuth, directionalmagnitude[i]);
                    pattern.Points.Add(point);
                    DataPoint zoompoint = new DataPoint(azimuth, directionalmagnitude[i] * 10);
                    zoomandenhance.Points.Add(zoompoint);
                    System.Diagnostics.Debug.WriteLine(directionalmagnitude[i].ToString());

                }
            }
            else
            {
                for (int i = 0; i < 360; i++)
                {
                    double azimuth = i;
                    directionalmagnitude[i] = DirectionalResult(azimuth, elevation);
                    if (directionalmagnitude[i] > maxy)
                    {
                        maxy = directionalmagnitude[i];
                    }
                    DataPoint point = new DataPoint(azimuth, directionalmagnitude[i]);
                    pattern.Points.Add(point);
                    DataPoint zoompoint = new DataPoint(azimuth, directionalmagnitude[i] * 10);
                    zoomandenhance.Points.Add(zoompoint);
                    System.Diagnostics.Debug.WriteLine(directionalmagnitude[i].ToString());

                }
            }
            
            
            PolarChart.Series.Clear();
            PolarChart.Series.Add(pattern);
            PolarChart.Series.Add(zoomandenhance);
            PolarChart.ChartAreas[0].AxisY.Maximum = maxy;
        }
        private void CalculatePattern()
        {
            CalculatePattern(false);
        }

        private void btnHighPrecison_Click(object sender, EventArgs e)
        {
            CalculatePattern(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            numTowers = 1;
            txtTowers.Value = 1;
            tower = 1;
            for (int i = 1; i<100; i++)
            {
                ratio[i] = 0;
                phase[i] = 0;
                spacing[i] = 0;
                orientation[i] = 0;
                heightA[i] = 0;
                heightB[i] = 0;
                heightC[i] = 0;
                heightD[i] = 0;
            }
            ratio[1] = 1;
            heightA[1] = 90;
            txtTower.Text = "1";
            txtRatio.Text = "1";
            txtPhase.Text = "0";
            txtSpacing.Text = "0";
            txtOrientation.Text = "0";
            txtHeight.Text = "90";
        }
    }
}
