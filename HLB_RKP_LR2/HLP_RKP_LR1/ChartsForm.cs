using System.Windows.Forms;
using HLP_RKP_LR2.Models;

namespace HLP_RKP_LR2
{
    public partial class ChartsForm : Form
    {
        public ChartsForm()
        {
            InitializeComponent();
            Charts.FormatLinesChart(cartesianChart1);
            Charts.FormatHistChart(cartesianChart2);
            Charts.FormatPieChart(pieChart1);
        }
    }
}
