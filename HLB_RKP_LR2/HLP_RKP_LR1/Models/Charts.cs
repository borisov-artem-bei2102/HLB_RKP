using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using HLP_RKP_LR1.Models;
using System.Linq;

namespace HLP_RKP_LR2.Models
{
    internal class Charts
    {
        public static void FormatLinesChart(CartesianChart chart)
        {
            SortedDictionary<string, int> patients = new SortedDictionary<string, int>();
            Patient.items.ForEach(patient =>
            {
                if (DateTime.TryParse(patient.Birth, out DateTime date))
                {
                    string year = date.Year.ToString();
                    patients.TryGetValue(year, out int patientsByYear);
                    patients[year] = patientsByYear + 1;
                }
            });
            int[] values = patients.Values.ToArray();
            string[] keys = patients.Keys.ToArray();
            chart.Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = values,
                }
            };
            chart.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labels = keys,
                }
            };
            chart.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
        }

        public static void FormatHistChart(CartesianChart chart)
        {
            SortedDictionary<DateTime, int> appointments = new SortedDictionary<DateTime, int>();
            Appointment.items.ForEach(appointment =>
            {
                if (DateTime.TryParse(appointment.Date, out DateTime date))
                {
                    appointments.TryGetValue(date, out int currentAppointments);
                    appointments[date] = currentAppointments + 1;
                }
            });
            int[] values = appointments.Values.ToArray();
            string[] keys = appointments.Keys.ToArray().Select(key => key.ToShortDateString()).ToArray();
            chart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = values,
                }
            };
            chart.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labels = keys
                }
            };
            chart.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
        }

        public static void FormatPieChart(PieChart chart)
        {
            int male = 0;
            int female = 0;
            Patient.items.ForEach(patient =>
            {
                if (patient.Sex == "Мужской")
                {
                    male++;
                }
                else if (patient.Sex == "Женский")
                {
                    female++;
                }
            });
            chart.Series = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { male }, Name = "Мужской" },
                new PieSeries<double> { Values = new double[] { female }, Name = "Женский" },
            };
        }
    }
}
