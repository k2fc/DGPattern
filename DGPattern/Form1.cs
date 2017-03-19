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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DGPattern
{
    public partial class Form1 : Form
    {
        DirectionalArray array = new DirectionalArray();
        int tower;
        double viewAzimuth = 0;
        double viewElevation = 0;
        
        public Form1()
        {
            InitializeComponent();
            tower = 1;
            chkRefSw.Enabled = false;
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
                array.ratio[tower] = double.Parse(txtRatio.Text);
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
                array.phase[tower] = double.Parse(txtPhase.Text);
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
                array.spacing[tower]= double.Parse(txtSpacing.Text);
                lblAbsoluteLocation.Text = array.absoluteLocation(tower);
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
                array.orientation[tower] = double.Parse(txtOrientation.Text);
                lblAbsoluteLocation.Text = array.absoluteLocation(tower);
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
                array.heightA[tower] = double.Parse(txtHeight.Text);
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
                array.heightB[tower] = double.Parse(txtHeightB.Text);
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
                array.heightC[tower] = double.Parse(txtHeightC.Text);
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
                array.heightD[tower] = double.Parse(txtHeightD.Text);
                CalculatePattern();
            }
            catch
            {

            }
        }

        private void txtTowers_ValueChanged(object sender, EventArgs e)
        {
            array.numTowers = (int)txtTowers.Value;
            if (array.heightA[array.numTowers] < 1)
            {
                array.heightA[array.numTowers] = array.heightA[1];
            }
            TowerScrollBar.Maximum = (int)txtTowers.Value;
            
            if (tower > array.numTowers)
            {
                txtTower.Text = array.numTowers.ToString();
            }
            CalculatePattern();
        }

        private void TowerScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            txtTower.Text = TowerScrollBar.Value.ToString();
            tower = TowerScrollBar.Value;
            txtRatio.Text = array.ratio[tower].ToString();
            txtPhase.Text = array.phase[tower].ToString();
            txtSpacing.Text = array.spacing[tower].ToString();
            txtOrientation.Text = array.orientation[tower].ToString();
            txtHeight.Text = array.heightA[tower].ToString();
            
        }

        private void txtTower_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double scrollValue = double.Parse(txtTower.Text);
                TowerScrollBar.Value = (int)scrollValue;
                tower = TowerScrollBar.Value;
                txtRatio.Text = array.ratio[tower].ToString();
                txtPhase.Text = array.phase[tower].ToString();
                txtSpacing.Text = array.spacing[tower].ToString();
                txtOrientation.Text = array.orientation[tower].ToString();
                txtHeight.Text = array.heightA[tower].ToString();
                txtHeightB.Text = array.heightB[tower].ToString();
                txtHeightC.Text = array.heightC[tower].ToString();
                txtHeightD.Text = array.heightD[tower].ToString();
                radioButton0.Checked = (array.toploadSw[tower] == 0);
                radioButton1.Checked = (array.toploadSw[tower] == 1);
                radioButton2.Checked = (array.toploadSw[tower] == 2);
                chkRefSw.Checked = array.towerRefSw[tower];
                if (tower == 1)
                {
                    chkRefSw.Enabled = false;
                }
                else
                {
                    chkRefSw.Enabled = true;
                }
                lblAbsoluteLocation.Visible = (array.towerRefSw[tower]);
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

        
        private void CalculatePattern()
        {
            

            double maxy = 0;
            Series pattern = new Series("Pattern");
            Series zoomandenhance = new Series("Zoom and Enhance");
            Series verticalPattern = new Series("Vertical Pattern");
            pattern.ChartType = SeriesChartType.Polar;
            zoomandenhance.ChartType = SeriesChartType.Polar;
            verticalPattern.ChartType = SeriesChartType.Polar;
            
            double previousMagnitude = array.DirectionalResult(359.9, viewElevation);
            bool increasing = (array.DirectionalResult(0, viewElevation) > previousMagnitude);
            lstLobes.Items.Clear();
            lstNulls.Items.Clear();
            for (int i = 0; i < 3600; i++)
            {
                double azimuth = ((double)i) / 10;
                double directionalmagnitude = array.DirectionalResult(azimuth, viewElevation);
                if (directionalmagnitude > maxy)
                {
                    maxy = directionalmagnitude;
                }

                if (directionalmagnitude > previousMagnitude)
                {
                    if (!increasing)
                    {
                        lstNulls.Items.Add((azimuth - .1).ToString());
                    }
                    increasing = true;
                }
                else
                {
                    if (increasing)
                    {
                        lstLobes.Items.Add((azimuth - .1).ToString());
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
                    DataPoint verticalpoint = new DataPoint(azimuth, array.DirectionalResult(viewAzimuth, elevation));
                    verticalPattern.Points.Add(verticalpoint);
                }
                else if (azimuth >= 270 && chkElevation.Checked)
                {
                    double elevation = azimuth - 270;
                    DataPoint verticalpoint = new DataPoint(azimuth, array.DirectionalResult(viewAzimuth + 180, elevation));
                    verticalPattern.Points.Add(verticalpoint);
                }

            }
            
            PolarChart.Series.Clear();
            PolarChart.Series.Add(pattern);
            PolarChart.Series.Add(zoomandenhance);
            PolarChart.Series.Add(verticalPattern);
            PolarChart.ChartAreas[0].AxisY.Maximum = maxy;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            txtTowers.Value = 1;
            tower = 1;
            array = new DirectionalArray();
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
                array.toploadSw[tower] = 2;

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
                array.toploadSw[tower] = 1;

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
                array.toploadSw[tower] = 0;

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
            array.towerRefSw[tower] = chkRefSw.Checked;
            lblAbsoluteLocation.Visible = array.towerRefSw[tower];
            lblAbsoluteLocation.Text = array.absoluteLocation(tower);
            CalculatePattern();
        }
        
    }
}
