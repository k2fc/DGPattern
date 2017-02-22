namespace DGPattern
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.PolarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RatioScrollBar = new System.Windows.Forms.HScrollBar();
            this.PhaseScrollBar = new System.Windows.Forms.HScrollBar();
            this.SpacingScrollBar = new System.Windows.Forms.HScrollBar();
            this.OrientationScrollBar = new System.Windows.Forms.HScrollBar();
            this.ThetaScrollBar = new System.Windows.Forms.VScrollBar();
            this.HeightScrollBar = new System.Windows.Forms.HScrollBar();
            this.txtRatio = new System.Windows.Forms.TextBox();
            this.txtPhase = new System.Windows.Forms.TextBox();
            this.txtSpacing = new System.Windows.Forms.TextBox();
            this.txtOrientation = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TowerScrollBar = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTower = new System.Windows.Forms.TextBox();
            this.txtTowers = new System.Windows.Forms.NumericUpDown();
            this.txtTheta = new System.Windows.Forms.TextBox();
            this.btnHighPrecison = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtAzimuth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AzimuthScrollBar = new System.Windows.Forms.HScrollBar();
            this.chkElevation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PolarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowers)).BeginInit();
            this.SuspendLayout();
            // 
            // PolarChart
            // 
            this.PolarChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.Name = "ChartArea1";
            this.PolarChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.PolarChart.Legends.Add(legend2);
            this.PolarChart.Location = new System.Drawing.Point(12, 12);
            this.PolarChart.Name = "PolarChart";
            this.PolarChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueMember = "0,1,2,3";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueMembers = "1,1,.5,1";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.PolarChart.Series.Add(series2);
            this.PolarChart.Size = new System.Drawing.Size(729, 747);
            this.PolarChart.SuppressExceptions = true;
            this.PolarChart.TabIndex = 0;
            this.PolarChart.Text = "chart1";
            title2.Name = "Title1";
            this.PolarChart.Titles.Add(title2);
            this.PolarChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // RatioScrollBar
            // 
            this.RatioScrollBar.Location = new System.Drawing.Point(841, 135);
            this.RatioScrollBar.Maximum = 1000;
            this.RatioScrollBar.Name = "RatioScrollBar";
            this.RatioScrollBar.Size = new System.Drawing.Size(223, 17);
            this.RatioScrollBar.TabIndex = 1;
            this.RatioScrollBar.Value = 100;
            this.RatioScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RatioScrollBar_Scroll);
            // 
            // PhaseScrollBar
            // 
            this.PhaseScrollBar.Location = new System.Drawing.Point(841, 161);
            this.PhaseScrollBar.Maximum = 1800;
            this.PhaseScrollBar.Minimum = -1800;
            this.PhaseScrollBar.Name = "PhaseScrollBar";
            this.PhaseScrollBar.Size = new System.Drawing.Size(223, 17);
            this.PhaseScrollBar.TabIndex = 2;
            this.PhaseScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PhaseScrollBar_Scroll);
            // 
            // SpacingScrollBar
            // 
            this.SpacingScrollBar.Location = new System.Drawing.Point(841, 222);
            this.SpacingScrollBar.Maximum = 18000;
            this.SpacingScrollBar.Name = "SpacingScrollBar";
            this.SpacingScrollBar.Size = new System.Drawing.Size(223, 17);
            this.SpacingScrollBar.TabIndex = 3;
            this.SpacingScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SpacingScrollBar_Scroll);
            // 
            // OrientationScrollBar
            // 
            this.OrientationScrollBar.Location = new System.Drawing.Point(842, 249);
            this.OrientationScrollBar.Maximum = 3600;
            this.OrientationScrollBar.Name = "OrientationScrollBar";
            this.OrientationScrollBar.Size = new System.Drawing.Size(223, 17);
            this.OrientationScrollBar.TabIndex = 4;
            this.OrientationScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OrientationScrollBar_Scroll);
            // 
            // ThetaScrollBar
            // 
            this.ThetaScrollBar.LargeChange = 1;
            this.ThetaScrollBar.Location = new System.Drawing.Point(747, 600);
            this.ThetaScrollBar.Maximum = 900;
            this.ThetaScrollBar.Name = "ThetaScrollBar";
            this.ThetaScrollBar.Size = new System.Drawing.Size(17, 80);
            this.ThetaScrollBar.TabIndex = 5;
            this.ThetaScrollBar.Value = 900;
            this.ThetaScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ThetaScrollBar_Scroll);
            // 
            // HeightScrollBar
            // 
            this.HeightScrollBar.Location = new System.Drawing.Point(842, 279);
            this.HeightScrollBar.Maximum = 3600;
            this.HeightScrollBar.Name = "HeightScrollBar";
            this.HeightScrollBar.Size = new System.Drawing.Size(223, 17);
            this.HeightScrollBar.TabIndex = 6;
            this.HeightScrollBar.Value = 900;
            this.HeightScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HeightScrollBar_Scroll);
            // 
            // txtRatio
            // 
            this.txtRatio.Location = new System.Drawing.Point(1068, 135);
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(100, 20);
            this.txtRatio.TabIndex = 7;
            this.txtRatio.Text = "1";
            this.txtRatio.TextChanged += new System.EventHandler(this.txtRatio_TextChanged);
            // 
            // txtPhase
            // 
            this.txtPhase.Location = new System.Drawing.Point(1068, 161);
            this.txtPhase.Name = "txtPhase";
            this.txtPhase.Size = new System.Drawing.Size(100, 20);
            this.txtPhase.TabIndex = 8;
            this.txtPhase.Text = "0";
            this.txtPhase.TextChanged += new System.EventHandler(this.txtPhase_TextChanged);
            // 
            // txtSpacing
            // 
            this.txtSpacing.Location = new System.Drawing.Point(1068, 222);
            this.txtSpacing.Name = "txtSpacing";
            this.txtSpacing.Size = new System.Drawing.Size(100, 20);
            this.txtSpacing.TabIndex = 9;
            this.txtSpacing.Text = "0";
            this.txtSpacing.TextChanged += new System.EventHandler(this.txtSpacing_TextChanged);
            // 
            // txtOrientation
            // 
            this.txtOrientation.Location = new System.Drawing.Point(1068, 249);
            this.txtOrientation.Name = "txtOrientation";
            this.txtOrientation.Size = new System.Drawing.Size(100, 20);
            this.txtOrientation.TabIndex = 10;
            this.txtOrientation.Text = "0";
            this.txtOrientation.TextChanged += new System.EventHandler(this.txtOrientation_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(1068, 276);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 11;
            this.txtHeight.Text = "90";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ratio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(803, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phase";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(794, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Spacing";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(782, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Orientation";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(802, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Height";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(770, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Num. Towers";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TowerScrollBar
            // 
            this.TowerScrollBar.LargeChange = 1;
            this.TowerScrollBar.Location = new System.Drawing.Point(842, 79);
            this.TowerScrollBar.Maximum = 1;
            this.TowerScrollBar.Minimum = 1;
            this.TowerScrollBar.Name = "TowerScrollBar";
            this.TowerScrollBar.Size = new System.Drawing.Size(223, 17);
            this.TowerScrollBar.TabIndex = 19;
            this.TowerScrollBar.Value = 1;
            this.TowerScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TowerScrollBar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(802, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tower";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTower
            // 
            this.txtTower.Location = new System.Drawing.Point(1068, 76);
            this.txtTower.Name = "txtTower";
            this.txtTower.Size = new System.Drawing.Size(100, 20);
            this.txtTower.TabIndex = 21;
            this.txtTower.Text = "1";
            this.txtTower.TextChanged += new System.EventHandler(this.txtTower_TextChanged);
            // 
            // txtTowers
            // 
            this.txtTowers.Location = new System.Drawing.Point(846, 10);
            this.txtTowers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTowers.Name = "txtTowers";
            this.txtTowers.Size = new System.Drawing.Size(65, 20);
            this.txtTowers.TabIndex = 23;
            this.txtTowers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTowers.ValueChanged += new System.EventHandler(this.txtTowers_ValueChanged);
            // 
            // txtTheta
            // 
            this.txtTheta.Location = new System.Drawing.Point(747, 683);
            this.txtTheta.Name = "txtTheta";
            this.txtTheta.Size = new System.Drawing.Size(40, 20);
            this.txtTheta.TabIndex = 24;
            this.txtTheta.Text = "0";
            this.txtTheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTheta.TextChanged += new System.EventHandler(this.txtTheta_TextChanged);
            // 
            // btnHighPrecison
            // 
            this.btnHighPrecison.Location = new System.Drawing.Point(1068, 302);
            this.btnHighPrecison.Name = "btnHighPrecison";
            this.btnHighPrecison.Size = new System.Drawing.Size(100, 23);
            this.btnHighPrecison.TabIndex = 25;
            this.btnHighPrecison.Text = "High Precision";
            this.btnHighPrecison.UseVisualStyleBackColor = true;
            this.btnHighPrecison.Click += new System.EventHandler(this.btnHighPrecison_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1068, 332);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 26;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtAzimuth
            // 
            this.txtAzimuth.Location = new System.Drawing.Point(747, 709);
            this.txtAzimuth.Name = "txtAzimuth";
            this.txtAzimuth.Size = new System.Drawing.Size(40, 20);
            this.txtAzimuth.TabIndex = 27;
            this.txtAzimuth.Text = "0";
            this.txtAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAzimuth.TextChanged += new System.EventHandler(this.txtAzimuth_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(793, 686);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Elevation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(794, 712);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Azimuth";
            // 
            // AzimuthScrollBar
            // 
            this.AzimuthScrollBar.Location = new System.Drawing.Point(747, 735);
            this.AzimuthScrollBar.Maximum = 1800;
            this.AzimuthScrollBar.Minimum = -1800;
            this.AzimuthScrollBar.Name = "AzimuthScrollBar";
            this.AzimuthScrollBar.Size = new System.Drawing.Size(227, 20);
            this.AzimuthScrollBar.TabIndex = 30;
            this.AzimuthScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AzimuthScrollBar_Scroll);
            // 
            // chkElevation
            // 
            this.chkElevation.AutoSize = true;
            this.chkElevation.Location = new System.Drawing.Point(853, 711);
            this.chkElevation.Name = "chkElevation";
            this.chkElevation.Size = new System.Drawing.Size(121, 17);
            this.chkElevation.TabIndex = 31;
            this.chkElevation.Text = "Show Elevation Plot";
            this.chkElevation.UseVisualStyleBackColor = true;
            this.chkElevation.CheckedChanged += new System.EventHandler(this.chkElevation_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 764);
            this.Controls.Add(this.chkElevation);
            this.Controls.Add(this.AzimuthScrollBar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAzimuth);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnHighPrecison);
            this.Controls.Add(this.txtTheta);
            this.Controls.Add(this.txtTowers);
            this.Controls.Add(this.txtTower);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TowerScrollBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtOrientation);
            this.Controls.Add(this.txtSpacing);
            this.Controls.Add(this.txtPhase);
            this.Controls.Add(this.txtRatio);
            this.Controls.Add(this.HeightScrollBar);
            this.Controls.Add(this.ThetaScrollBar);
            this.Controls.Add(this.OrientationScrollBar);
            this.Controls.Add(this.SpacingScrollBar);
            this.Controls.Add(this.PhaseScrollBar);
            this.Controls.Add(this.RatioScrollBar);
            this.Controls.Add(this.PolarChart);
            this.Name = "Form1";
            this.Text = "DGPattern";
            ((System.ComponentModel.ISupportInitialize)(this.PolarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PolarChart;
        private System.Windows.Forms.HScrollBar RatioScrollBar;
        private System.Windows.Forms.HScrollBar PhaseScrollBar;
        private System.Windows.Forms.HScrollBar SpacingScrollBar;
        private System.Windows.Forms.HScrollBar OrientationScrollBar;
        private System.Windows.Forms.VScrollBar ThetaScrollBar;
        private System.Windows.Forms.HScrollBar HeightScrollBar;
        private System.Windows.Forms.TextBox txtRatio;
        private System.Windows.Forms.TextBox txtPhase;
        private System.Windows.Forms.TextBox txtSpacing;
        private System.Windows.Forms.TextBox txtOrientation;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar TowerScrollBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTower;
        private System.Windows.Forms.NumericUpDown txtTowers;
        private System.Windows.Forms.TextBox txtTheta;
        private System.Windows.Forms.Button btnHighPrecison;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtAzimuth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.HScrollBar AzimuthScrollBar;
        private System.Windows.Forms.CheckBox chkElevation;
    }
}

