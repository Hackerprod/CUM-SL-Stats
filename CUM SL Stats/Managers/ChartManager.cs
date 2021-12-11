using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Panel = System.Windows.Controls.Panel;
using System.Windows.Media;
using Separator = LiveCharts.Wpf.Separator;
using LiveCharts.Defaults;
using SKYNET.Models;

namespace SKYNET
{
    public class ChartManager
    {
        public static void LoadCartesianChart(LiveCharts.WinForms.CartesianChart cartesianChart, List<CourceStats> stats)
        {
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();

            var barSeries = new ColumnSeries
            {
                Values = new ChartValues<int>(),
                Title = "Estudiantes Activos",
            };
            var lineSeries = new LineSeries
            {
                Values = new ChartValues<int>(),
                Fill = Brushes.Transparent,
                StrokeThickness = 4,
                PointGeometry = null,
                Title = "Estudiantes matriculados",
            };
            var lineSeries2 = new LineSeries
            {
                Values = new ChartValues<int>(),
                Fill = Brushes.Transparent,
                StrokeThickness = 4,
                PointGeometry = null,
                Title = "Estudiantes graduados",
            };
            var lineSeries_4 = new LineSeries
            {
                Values = new ChartValues<int>(),
                Fill = Brushes.Transparent,
                StrokeThickness = 4,
                PointGeometry = null,
                Title = "Estudiantes calificados con 4 puntos",
            };
            var lineSeries_3 = new LineSeries
            {
                Values = new ChartValues<int>(),
                Fill = Brushes.Transparent,
                StrokeThickness = 4,
                PointGeometry = null,
                Title = "Estudiantes calificados con 3 puntos",
            };
            Axis axis = new Axis
            {
                Labels = new List<string>(),
                Separator = new Separator 
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
            };
            bool isGraduated = false;
            foreach (var item in stats)
            {
                barSeries.Values.Add(item.Active);
                lineSeries.Values.Add(item.Enrolled);
                lineSeries2.Values.Add(item.Graduates);
                axis.Labels.Add(item.Cource.Name);

                isGraduated = item.Graduates > 0 ? true : false;
                //lineSeries_4.Values.Add(item.PointsStudents_4);
                //lineSeries_3.Values.Add(item.PointsStudents_3);
            }

            cartesianChart.Series.Add(barSeries);
            cartesianChart.Series.Add(lineSeries);

            if (isGraduated)
            {
                cartesianChart.Series.Add(lineSeries2);
            }

            //cartesianChart.Series.Add(lineSeries_4);
            //cartesianChart.Series.Add(lineSeries_3);
            cartesianChart.AxisX.Add(axis);

            Panel.SetZIndex(barSeries, 0);
            Panel.SetZIndex(lineSeries, 1);

        }

        public static void LoadPieChart(LiveCharts.WinForms.PieChart pieChart1)
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Estudiantes con 5",
                    Values = new ChartValues<double> {3},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Estudiantes con 4",
                    Values = new ChartValues<double> {4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Estudiantes con 3",
                    Values = new ChartValues<double> {6},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Estudiantes suspensos",
                    Values = new ChartValues<double> {2},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };
        }
        public class CourceStats
        {
            /// <summary>
            /// Curso escolar
            /// </summary>
            public SchoolCource Cource;

            /// <summary>
            /// Activos
            /// </summary>
            public int Active;

            /// <summary>
            /// Matriculados
            /// </summary>
            public int Enrolled;

            /// <summary>
            /// Graduados
            /// </summary>
            public int Graduates;

            public int PointsStudents_3;
            public int PointsStudents_4;
            public int PointsStudents_5;

        }
    }
}
