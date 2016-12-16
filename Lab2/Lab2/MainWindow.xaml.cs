using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab2.ViewModel;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            chart.ChartAreas.Add(new ChartArea("ChartArea1"));


            chart.Series.Add(new Series("Series1"));
            chart.Series["Series1"].ChartArea = "ChartArea1";
            chart.Series["Series1"].ChartType = SeriesChartType.Column;
            chart.Series["Series1"].XAxisType = AxisType.Primary;
            MainViewModel.OnCalculate += doubles =>
            {
                chart.Series["Series1"].Points.Clear();

                const int intervalsCount = 40;
                List<double> numbers = doubles.ToList();
                numbers.Sort();
                double width = numbers.Last() - numbers.First();

                double widthOfInterval = width / intervalsCount;

                double[] heights = new double[intervalsCount];
                double[] xValues = new double[intervalsCount];

                xValues[0] = Math.Round(0.0245 * width + numbers.First(), 3);
                for (int i = 1; i < intervalsCount; i++)
                {
                    xValues[i] = Math.Round(xValues[i - 1] + widthOfInterval, 3);
                }

                double xLeft = numbers.First();
                double xRight = xLeft + widthOfInterval;
                int j = 0;
                for (int i = 0; i < intervalsCount; i++)
                {
                    while (j < numbers.Count && xLeft <= numbers[j] && xRight > numbers[j])
                    {
                        heights[i]++;
                        j++;
                    }
                    heights[i] /= numbers.Count;
                    xLeft = xRight;
                    xRight += widthOfInterval;
                }

                chart.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart.Series["Series1"].Points.DataBindXY(xValues, heights);

                AllItems.ItemsSource = doubles;


            };
        }
    }
}
