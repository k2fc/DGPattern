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
        int[] toploadSw;
        bool[] towerRefSw;
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
            toploadSw = new int[100];
            towerRefSw = new bool[100];
            viewElevation = 0;
            viewAzimuth = 0;
            numTowers = 1;
            tower = 1;
            ratio[1] = 1;
            heightA[1] = 90;
            toploadSw[1] = 0;
            towerRefSw[1] = false;
            chkRefSw.Enabled = false;
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

        private void HeightBScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtHeightB.Text = ((double)(HeightBScrollBar.Value) / 10).ToString();
        }
        private void HeightCScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtHeightC.Text = ((double)(HeightCScrollBar.Value) / 10).ToString();
        }
        private void HeightDScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtHeightD.Text = ((double)(HeightDScrollBar.Value) / 10).ToString();
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

        private void txtHeightB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtHeightB.Text) * 10;
                HeightBScrollBar.Value = (int)scrollValue;
                heightB[tower] = double.Parse(txtHeightB.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtHeightC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtHeightC.Text) * 10;
                HeightCScrollBar.Value = (int)scrollValue;
                heightC[tower] = double.Parse(txtHeightC.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtHeightD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtHeightD.Text) * 10;
                HeightDScrollBar.Value = (int)scrollValue;
                heightD[tower] = double.Parse(txtHeightD.Text);
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
                txtHeightB.Text = heightB[tower].ToString();
                txtHeightC.Text = heightC[tower].ToString();
                txtHeightD.Text = heightD[tower].ToString();
                radioButton0.Checked = (toploadSw[tower] == 0);
                radioButton1.Checked = (toploadSw[tower] == 1);
                radioButton2.Checked = (toploadSw[tower] == 2);
                chkRefSw.Checked = towerRefSw[tower];
                if (tower == 1)
                {
                    chkRefSw.Enabled = false;
                }
                else
                {
                    chkRefSw.Enabled = true;
                }
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

        private double FunctionOfTheta(double angle, double heightA, double heightB)
        {
            double A = DegreeToRadian(heightA);
            double B = DegreeToRadian(heightB);
            double theta = DegreeToRadian(angle);
            return (
                (
                    (Math.Cos(B) * Math.Cos(A * Math.Sin(theta))) - (Math.Sin(theta) * Math.Sin(B) * Math.Sin(A * Math.Sin(theta))) - (Math.Cos(A + B))
                ) / (
                    Math.Cos(theta) * (Math.Cos(B) - Math.Cos(A + B))
                ));
        }

        private double FunctionOfTheta(double angle, double heightA, double heightB, double heightC, double heightD)
        {
            double A = DegreeToRadian(heightA);
            double B = DegreeToRadian(heightB);
            double C = DegreeToRadian(heightC);
            double D = DegreeToRadian(heightD);
            double G = A + B;
            double H = C + D;
            double delta = H - A;
            double theta = DegreeToRadian(angle);
            

            return ((
                    (Math.Sin(delta)*((Math.Cos(B) * Math.Cos(A * Math.Sin(theta))) - Math.Cos(G)) + (Math.Sin(B) * ((Math.Cos(D) * Math.Cos (C * Math.Sin(theta))) - (Math.Sin(theta) * Math.Sin(D) * Math.Sin(C * Math.Sin(theta))) - (Math.Cos(delta)* Math.Cos(A * Math.Sin(theta))))))
                )/(
                    Math.Cos(theta) * ((Math.Sin(delta) * (Math.Cos(B) - Math.Cos(G)))+(Math.Sin(B) * (Math.Cos(D) - Math.Cos(delta))))
                ));

        }

        private double FunctionOfTheta (int toploadsw, double angle, double heightA, double heightB, double heightC, double heightD)
        {
            if (toploadsw == 0)
            {
                return FunctionOfTheta(angle, heightA);
            }
            else if (toploadsw == 1)
            {
                return FunctionOfTheta(angle, heightA, heightB);
            }
            else if (toploadsw == 2)
            {
                return FunctionOfTheta(angle, heightA, heightB, heightC, heightD);
            }
            else
            {
                return 0;
            }
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double RadianToDegree (double angle)
        {
            return angle * (180 / Math.PI);
        }

        private double DirectionalResult (double azimuth, double elevation)
        {
            double phi = DegreeToRadian(azimuth);
            double theta = DegreeToRadian(elevation);

                       
            Complex resultant = new Complex(0,0);
            
            for (int i = 1; i <= numTowers; i++)
            {
                double absolutespacing;
                double absoluteorientation;

                if (towerRefSw[i])
                {
                    Complex absolutelocation = Complex.Add(Complex.FromPolarCoordinates(spacing[i - 1], DegreeToRadian(orientation[i - 1])), 
                        Complex.FromPolarCoordinates(spacing[i], DegreeToRadian(orientation[i])));
                    absolutespacing = absolutelocation.Magnitude;
                    absoluteorientation = absolutelocation.Phase;
                }
                else
                {
                    absolutespacing = spacing[i];
                    absoluteorientation = DegreeToRadian(orientation[i]);
                }

                double magnitude = ratio[i] * FunctionOfTheta(toploadSw[i], elevation, heightA[i], heightB[i], heightC[i], heightD[i]);
                double towerPhaseShift = DegreeToRadian(phase[i]);
                double totalphase = (DegreeToRadian(absolutespacing) * Math.Cos(absoluteorientation - phi))+towerPhaseShift;
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
                toploadSw[i] = 0;
                towerRefSw[i] = false;
            }
            ratio[1] = 1;
            heightA[1] = 90;
            txtTower.Text = "1";
            txtRatio.Text = "1";
            txtPhase.Text = "0";
            txtSpacing.Text = "0";
            txtOrientation.Text = "0";
            txtHeight.Text = "90";
            txtHeightB.Text = "0";
            txtHeightC.Text = "0";
            txtHeightD.Text = "0";
            radioButton0.Checked = true;
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

        private void radioButton0_CheckedChanged(object sender, EventArgs e)
        {
            toploadSwChange();
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            toploadSwChange();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            toploadSwChange();
        }

        private void toploadSwChange()
        {
            if (radioButton2.Checked)
            {
                toploadSw[tower] = 2;

                lblHeightA.Text = "A";
                
                lblHeightB.Visible = true;
                HeightBScrollBar.Visible = true;
                txtHeightB.Visible = true;

                lblHeightC.Visible = true;
                HeightCScrollBar.Visible = true;
                txtHeightC.Visible = true;

                lblHeightD.Visible = true;
                HeightDScrollBar.Visible = true;
                txtHeightD.Visible = true;
            }
            else if (radioButton1.Checked)
            {
                toploadSw[tower] = 1;

                lblHeightA.Text = "A";

                lblHeightB.Visible = true;
                HeightBScrollBar.Visible = true;
                txtHeightB.Visible = true;

                lblHeightC.Visible = false;
                HeightCScrollBar.Visible = false;
                txtHeightC.Visible = false;

                lblHeightD.Visible = false;
                HeightDScrollBar.Visible = false;
                txtHeightD.Visible = false;
            }
            else if (radioButton0.Checked)
            {
                toploadSw[tower] = 0;

                lblHeightA.Text = "Height";

                lblHeightB.Visible = false;
                HeightBScrollBar.Visible = false;
                txtHeightB.Visible = false;

                lblHeightC.Visible = false;
                HeightCScrollBar.Visible = false;
                txtHeightC.Visible = false;

                lblHeightD.Visible = false;
                HeightDScrollBar.Visible = false;
                txtHeightD.Visible = false;
            }
            CalculatePattern();
        }

        private void chkRefSw_CheckedChanged(object sender, EventArgs e)
        {
            towerRefSw[tower] = chkRefSw.Checked;
            CalculatePattern();
        }
    }
}
