//    DG Pattern. A tool to visualize AM Directional Arrays
//    Copyright(C)2017 Dennis Graiani <dennis.graiani@gmail.com>

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, version 3.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with this program.If not, see<http://www.gnu.org/licenses/>.

using System;
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
        double viewElevation;
        double viewAzimuth;
        int numTowers;
        int tower;
        //double[] directionalmagnitude;
        


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
            viewElevation = 0;
            viewAzimuth = 0;
            numTowers = 1;
            tower = 1;
            ratio[1] = 1;
            heightA[1] = 90;
            //directionalmagnitude = new double[3600];
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
                viewElevation = double.Parse(txtTheta.Text);
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
            Series verticalPattern = new Series("Vertical Pattern");
            pattern.ChartType = SeriesChartType.Polar;
            zoomandenhance.ChartType = SeriesChartType.Polar;
            verticalPattern.ChartType = SeriesChartType.Polar;
            
            if (highPrecision)
            {
                double previousMagnitude = DirectionalResult(359.9, viewElevation);
                bool increasing = (DirectionalResult(0, viewElevation) > previousMagnitude);
                lstLobes.Items.Clear();
                lstNulls.Items.Clear();
                for (int i = 0; i < 3600; i++)
                {
                    double azimuth = ((double)i)/10;
                    double directionalmagnitude = DirectionalResult(azimuth, viewElevation);
                    if (directionalmagnitude > maxy)
                    {
                        maxy = directionalmagnitude;
                    }

                    if (directionalmagnitude > previousMagnitude)
                    {
                        if (!increasing)
                        {
                            lstNulls.Items.Add((azimuth -.1) .ToString());
                        }
                        increasing = true;
                    }
                    else
                    {
                        if (increasing)
                        {
                            lstLobes.Items.Add((azimuth -.1).ToString());
                        }
                        increasing = false;
                    }
                    previousMagnitude = directionalmagnitude;
                    DataPoint point = new DataPoint(azimuth, directionalmagnitude);
                    pattern.Points.Add(point);
                    DataPoint zoompoint = new DataPoint(azimuth, directionalmagnitude * 10);
                    zoomandenhance.Points.Add(zoompoint);
                    if (azimuth <= 90 && chkElevation.Checked)
                    {
                        double elevation = 90 - azimuth;
                        DataPoint verticalpoint = new DataPoint(azimuth, DirectionalResult(viewAzimuth, elevation));
                        verticalPattern.Points.Add(verticalpoint);
                    }
                    else if (azimuth >= 270 && chkElevation.Checked)
                    {
                        double elevation = azimuth - 270;
                        DataPoint verticalpoint = new DataPoint(azimuth, DirectionalResult(viewAzimuth + 180, elevation));
                        verticalPattern.Points.Add(verticalpoint);
                    }
                    System.Diagnostics.Debug.WriteLine(directionalmagnitude.ToString());

                }
            }
            else
            {
                double previousMagnitude = DirectionalResult(359, viewElevation);
                bool increasing = (DirectionalResult(0, viewElevation) > previousMagnitude);
                lstLobes.Items.Clear();
                lstNulls.Items.Clear();
                for (int i = 0; i < 360; i++)
                {

                    double azimuth = i;
                    double directionalmagnitude = DirectionalResult(azimuth, viewElevation);
                    if (directionalmagnitude > maxy)
                    {
                        maxy = directionalmagnitude;
                        //txtAzimuth.Text = azimuth.ToString();
                    }

                    if (directionalmagnitude > previousMagnitude)
                    {
                        if (!increasing)
                        {
                            lstNulls.Items.Add((azimuth - 1).ToString());
                        }
                        increasing = true;
                    }
                    else
                    {
                        if (increasing)
                        {
                            lstLobes.Items.Add((azimuth - 1).ToString());
                        }
                        increasing = false;
                    }
                    previousMagnitude = directionalmagnitude;
                    DataPoint point = new DataPoint(azimuth, directionalmagnitude);
                    pattern.Points.Add(point);
                    DataPoint zoompoint = new DataPoint(azimuth, directionalmagnitude * 10);
                    zoomandenhance.Points.Add(zoompoint);
                    System.Diagnostics.Debug.WriteLine(directionalmagnitude.ToString());
                    if (azimuth <= 90 && chkElevation.Checked) 
                    {
                        double elevation = 90 - azimuth;
                        DataPoint verticalpoint = new DataPoint(azimuth, DirectionalResult(viewAzimuth, elevation));
                        verticalPattern.Points.Add(verticalpoint);
                    }
                    else if (azimuth >= 270 && chkElevation.Checked)
                    {
                        double elevation = azimuth - 270;
                        DataPoint verticalpoint = new DataPoint(azimuth, DirectionalResult(viewAzimuth + 180, elevation));
                        verticalPattern.Points.Add(verticalpoint);
                    }
                }
            }
            
            
            PolarChart.Series.Clear();
            PolarChart.Series.Add(pattern);
            PolarChart.Series.Add(zoomandenhance);
            PolarChart.Series.Add(verticalPattern);
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

        private void txtAzimuth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtAzimuth.Text) * 10;
                AzimuthScrollBar.Value = (int)scrollValue;
                viewAzimuth = double.Parse(txtAzimuth.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void AzimuthScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtAzimuth.Text = ((double)(AzimuthScrollBar.Value) / 10).ToString();
            CalculatePattern();
        }

        private void chkElevation_CheckedChanged(object sender, EventArgs e)
        {
            AzimuthScrollBar.Enabled = chkElevation.Checked;
            txtAzimuth.Enabled = chkElevation.Checked;
            lblAzimuth.Enabled = chkElevation.Checked;
            CalculatePattern();
        }
    }
}
