using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


// A program that visualises different algorithms and their patterns, 
// using the Windows Forms App (.NET Framework)
namespace AlgorithmVisualizer
{
    public partial class Form1 : Form
    {

        int goingUp = 11;
        public Form1()
        {
            InitializeComponent();

            Series seriesToAdd = new Series("Data");
            ChartArea chartAreaMain = new ChartArea("ChartAreaMain");
            Legend legendMain = new Legend("LegendMain");

            //
            chartMain.ChartAreas.Add(chartAreaMain);
            chartMain.Legends.Add(legendMain);

            seriesToAdd.ChartArea = "ChartAreaMain";
            seriesToAdd.Legend = "LegendMain";

            chartMain.Series.Add(seriesToAdd);

            chartMain.ChartAreas[0].AxisY.Minimum = 0;
            chartMain.ChartAreas[0].AxisY.Maximum = 100;
            chartMain.ChartAreas[0].AxisX.Minimum = 0;
            chartMain.ChartAreas[0].AxisX.Maximum = 100;

            // Create Starting Chart
            Refresh_Click(null, null);

            //chartMain.ChartAreas.Clear();
            //chartMain.ChartAreas.Add(seriesToAdd);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //chartMain.Series[0].Points.Add(new DataPoint(goingUp, goingUp++));

            for (int i = 0;i < chartMain.Series[0].Points.Count() - 1; i++)
            {
                chartMain.Series[0].Points[i].Color = Color.Purple;
                for(int j = i+1; j < chartMain.Series[0].Points.Count(); j++)
                {
                    chartMain.Series[0].Points[j].Color = Color.Pink;
                    if (chartMain.Series[0].Points[i].YValues[0] > chartMain.Series[0].Points[j].YValues[0])
                    {
                        var prev = chartMain.Series[0].Points[i].YValues;
                        chartMain.Series[0].Points[i].YValues = chartMain.Series[0].Points[j].YValues;
                        chartMain.Series[0].Points[j].YValues = prev;
                    }
                    Refresh();
                    chartMain.Series[0].Points[j].Color = Color.CornflowerBlue;
                }
                chartMain.Series[0].Points[i].Color = Color.CornflowerBlue;
            }
            Refresh();
        }

        private void chartMain_Click(object sender, EventArgs e)
        {
        }

        private void quickSort_Click(object sender, EventArgs e)
        {
            DataPointCollection easyType = chartMain.Series[0].Points;
            quickSortHelper(ref easyType, 0, easyType.Count);
        }

        // A recursive helper method for quicksort
        private void quickSortHelper(ref DataPointCollection arr, int min, int max)
        {
            // Keep Recursing
            if(max - min > 1)
            {
                //int half = ((max - min) / 2) + min;

                // Setting our pivot point, both Value and Position
                //  Pivot is going to be set at the middle of the array
                int pivotPos = max - 1;
                var pivotVal = arr[pivotPos].YValues;

                arr[pivotPos].Color = Color.Red;
                for(int i = min; i < pivotPos; i++)
                {
                    arr[i].Color = Color.Pink;
                    if (arr[i].YValues[0] > pivotVal[0])
                    {
                        // i pos, Yvalue
                        var other = arr[i].YValues;
                        // 1 pos before Pivot, Yvalue
                        var beforePivot = arr[pivotPos - 1].YValues;

                        arr[pivotPos].YValues = other;
                        arr[i].YValues = beforePivot;
                        arr[pivotPos - 1].YValues = pivotVal;
                        pivotPos--;
                        i--;

                        arr[i+1].Color = Color.CornflowerBlue;
                        arr[pivotPos + 1].Color = Color.CornflowerBlue;
                        arr[pivotPos].Color = Color.Red;
                        Refresh();
                    }
                    else
                    {
                        Refresh();
                        arr[i].Color = Color.CornflowerBlue;
                    }
                    arr[pivotPos].Color = Color.CornflowerBlue;
                }

                Refresh();
                quickSortHelper(ref arr, min, pivotPos);
                quickSortHelper(ref arr, pivotPos + 1, max);
            }
            // Done Recursing
            else
            {

            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            chartMain.Series[0].Points.Clear();
            var rand = new Random();
            List<int> startList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                startList.Add(i);
            }

            for (int i = 0; i < 100; i++)
            {
                int nextData = rand.Next(startList.Count);
                chartMain.Series[0].Points.Add(new DataPoint(i, startList[nextData]));
                startList.Remove(startList[nextData]);
            }
        }
    }
}
