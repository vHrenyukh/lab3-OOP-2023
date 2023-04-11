using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3new
{
    public partial class TriangleFigure : Form
    {
        public TriangleFigure()
        {
            InitializeComponent();
        }
        public class Triangle
        {
            public Point A { get; set; }
            public Point B { get; set; }
            public Point C { get; set; }

            public double SideAB => Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            public double SideAC => Math.Sqrt(Math.Pow(C.X - A.X, 2) + Math.Pow(C.Y - A.Y, 2));
            public double SideBC => Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));

            public double Perimeter => SideAB + SideAC + SideBC;
            public double Area => Math.Sqrt(Perimeter * (Perimeter - SideAB) * (Perimeter - SideBC) * (Perimeter - SideAC));
            public Point MedianCrossPoint => new Point((A.X + B.X + C.X) / 3, (A.Y + B.Y + C.Y) / 3);

            public Triangle(double xA, double yA, double xB, double yB, double xC, double yC)
            {
                A = new Point(xA, yA);
                B = new Point(xB, yB);
                C = new Point(xC, yC);
            }
            public class Point
            {
                public double X { get; set; }
                public double Y { get; set; }

                public Point(double x, double y)
                {
                    X = x;
                    Y = y;
                }
            }
            public static string IsExist(double xA, double yA, double xB, double yB, double xC, double yC)
            {
                double sideAB = Math.Sqrt(Math.Pow(xB - xA, 2) + Math.Pow(yB - yA, 2));
                double sideAC = Math.Sqrt(Math.Pow(xC - xA, 2) + Math.Pow(yC - yA, 2));
                double sideBC = Math.Sqrt(Math.Pow(xC - xB, 2) + Math.Pow(yC - yB, 2));
                if (sideAB + sideAC <= sideBC || sideAC + sideBC <= sideAB || sideAB + sideBC <= sideAC)
                {
                    throw new ArgumentException("Трикутника не існує!");
                }

                return "Трикутник існує!";
            }
        }

      

        private void Triangle_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(aX.Text, out double xA) &&
               double.TryParse(aY.Text, out double yA) &&
               double.TryParse(bX.Text, out double xB) &&
               double.TryParse(bY.Text, out double yB) &&
               double.TryParse(cX.Text, out double xC) &&
               double.TryParse(cY.Text, out double yC))
            {
                Triangle triangle = new Triangle(xA, yA, xB, yB, xC, yC);
                try
                {
                    ABCalculation.Text = triangle.SideAB.ToString("N1");
                    ACCalculation.Text = triangle.SideAC.ToString("N1");
                    BCCalculation.Text = triangle.SideBC.ToString("N1");
                    PerimeterCalculation.Text = triangle.Perimeter.ToString("N1");
                    AreaCalculation.Text = triangle.Area.ToString("N1");
                    MedianPointCalculation.Text = $"{triangle.MedianCrossPoint.X:N1}, {triangle.MedianCrossPoint.Y:N1}";
                    Exclusion.Text = Triangle.IsExist(xA, yA, xB, yB, xC, yC).ToString();
                }
                catch (ArgumentException ex)
                {
                    Exclusion.Text = ex.Message;
                }
            }
            else
            {
                MessageBox.Show("Введіть правильні значення (лише цифри)!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

