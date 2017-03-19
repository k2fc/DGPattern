using System.Numerics;
using System;

namespace DGPattern
{
    class DirectionalArray
    {
        public int numTowers;
        public double[] ratio;
        public double[] phase;
        public double[] spacing;
        public double[] orientation;
        public bool[] towerRefSw;
        public int[] toploadSw;
        public double[] heightA;
        public double[] heightB;
        public double[] heightC;
        public double[] heightD;

        public double[] absolutespacing;
        public double[] absoluteorientation;

        public DirectionalArray(int numTowers, double[] ratio, double[] phase, double[] spacing, double[] orientation, bool[] towerRefSw, int[] toploadSw, double[] heightA,
            double[] heightB, double[] heightC, double[] heightD)
        {
            this.numTowers = numTowers;
            this.ratio = ratio;
            this.phase = phase;
            this.spacing = spacing;
            this.orientation = orientation;
            this.towerRefSw = towerRefSw;
            this.toploadSw = toploadSw;
            this.heightA = heightA;
            this.heightB = heightB;
            this.heightC = heightC;
            this.heightD = heightD;
            absolutespacing = new double[spacing.Length];
            absoluteorientation = new double[orientation.Length];

            CalculateAbsoluteLocations();
        }

        public DirectionalArray()
        {
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
            numTowers = 1;
            ratio[1] = 1;
            heightA[1] = 90;
            toploadSw[1] = 0;
            towerRefSw[1] = false;
            absolutespacing = new double[spacing.Length];
            absoluteorientation = new double[orientation.Length];
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
                    (Math.Sin(delta) * ((Math.Cos(B) * Math.Cos(A * Math.Sin(theta))) - Math.Cos(G)) + (Math.Sin(B) * ((Math.Cos(D) * Math.Cos(C * Math.Sin(theta))) - (Math.Sin(theta) * Math.Sin(D) * Math.Sin(C * Math.Sin(theta))) - (Math.Cos(delta) * Math.Cos(A * Math.Sin(theta))))))
                ) / (
                    Math.Cos(theta) * ((Math.Sin(delta) * (Math.Cos(B) - Math.Cos(G))) + (Math.Sin(B) * (Math.Cos(D) - Math.Cos(delta))))
                ));

        }

        public double FunctionOfTheta(int toploadsw, double angle, double heightA, double heightB, double heightC, double heightD)
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

        private double RadianToDegree(double angle)
        {
            return angle * (180 / Math.PI);
        }

        public double DirectionalResult(double azimuth, double elevation)
        {
            CalculateAbsoluteLocations();
            double phi = DegreeToRadian(azimuth);
            double theta = DegreeToRadian(elevation);


            Complex resultant = new Complex(0, 0);

            for (int i = 1; i <= numTowers; i++)
            {

                double magnitude = ratio[i] * FunctionOfTheta(toploadSw[i], elevation, heightA[i], heightB[i], heightC[i], heightD[i]);
                double towerPhaseShift = DegreeToRadian(phase[i]);
                double totalphase = (DegreeToRadian(absolutespacing[i]) * Math.Cos(absoluteorientation[i] - phi)) + towerPhaseShift;
                Complex contribution = Complex.FromPolarCoordinates(magnitude, totalphase);
                resultant = Complex.Add(resultant, contribution);
            }
            return resultant.Magnitude;
        }

        private void CalculateAbsoluteLocations()
        {
            for (int i = 1; i <= numTowers; i++)
            {
                if (towerRefSw[i])
                {
                    Complex absolutelocation = Complex.Add(Complex.FromPolarCoordinates(absolutespacing[i - 1], absoluteorientation[i - 1]),
                        Complex.FromPolarCoordinates(spacing[i], DegreeToRadian(orientation[i])));
                    absolutespacing[i] = absolutelocation.Magnitude;
                    absoluteorientation[i] = absolutelocation.Phase;
                }
                else
                {
                    absolutespacing[i] = spacing[i];
                    absoluteorientation[i] = DegreeToRadian(orientation[i]);
                }
            }

        }

        private void setSpacing (int tower, double spacing)
        {
            this.spacing[tower] = spacing;
            CalculateAbsoluteLocations();
        }
        private void setOrientation(int tower, double orientation)
        {
            this.orientation[tower] = orientation;
            CalculateAbsoluteLocations();
        }

        public string absoluteLocation(int tower)
        {
            CalculateAbsoluteLocations();
            if (RadianToDegree(absoluteorientation[tower]) < 0)
            {
                return (absolutespacing[tower].ToString("N1") + "° @ " + (RadianToDegree(absoluteorientation[tower])+360).ToString("N1") + "°");
            }
            else
            {
                return (absolutespacing[tower].ToString("N1") + "° @ " + RadianToDegree(absoluteorientation[tower]).ToString("N1") + "°");
            }
            
        }
        
    }
}
