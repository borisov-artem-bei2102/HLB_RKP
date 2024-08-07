using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;

namespace HLP_RKP_LR2.Models
{
    internal class Charts
    {
        public static void FormatLinesChart(CartesianChart chart)
        {
            chart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 4, 1, 8, 5, 12 },
                }
            };
            chart.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = new string[] { "11", "22", "33", "44", "50" }
                }
            };
            chart.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
        }

        public static void FormatHistChart(CartesianChart chart)
        {
            chart.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = new double[] { 4, 1, 8, 5, 12 },
                }
            };
            chart.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = new string[] { "11", "22", "33", "44", "50" }
                }
            };
            chart.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
        }

        public static void FormatPieChart(PieChart chart)
        {
            chart.Series = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { 2 } },
                new PieSeries<double> { Values = new double[] { 4 } },
                new PieSeries<double> { Values = new double[] { 1 } },
                new PieSeries<double> { Values = new double[] { 4 } },
                new PieSeries<double> { Values = new double[] { 3 } }
            };
        }
    }
}
