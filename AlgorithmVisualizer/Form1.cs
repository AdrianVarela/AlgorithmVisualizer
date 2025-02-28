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

//using System.Data.Entity;

// A program that visualises different algorithms and their patterns, 
// using the Windows Forms App (.NET Framework)
namespace AlgorithmVisualizer
{
    public partial class Form1 : Form
    {

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

            // Used this line for testing; Should not use this. Should create thread-safe code
            CheckForIllegalCrossThreadCalls = false;


            // Create Starting Chart
            Refresh_Click(null, null);

            //chartMain.ChartAreas.Clear();
            //chartMain.ChartAreas.Add(seriesToAdd);
        }

        private async void buttonOK_Click(object sender, EventArgs e)
        {
            //chartMain.Series[0].Points.Add(new DataPoint(goingUp, goingUp++));
            disableButtons();
            DataPointCollection col = chartMain.Series[0].Points;

            await Task.Run(() =>
            {
                for (int left = 0; left < col.Count() - 1; left++)
                {
                    col[left].Color = Color.Purple;
                    for (int right = left + 1; right < col.Count(); right++)
                    {
                        col[right].Color = Color.Pink;
                        if (col[left].YValues[0] > col[right].YValues[0])
                        {
                            var prev = col[left].YValues;
                            col[left].YValues = col[right].YValues;
                            col[right].YValues = prev;
                        }
                        Refresh();
                        col[right].Color = Color.CornflowerBlue;
                    }
                    col[left].Color = Color.CornflowerBlue;
                }
                Refresh();
            });

            enableButtons();
        }

        private void chartMain_Click(object sender, EventArgs e)
        {
        }

        private async void quickSort_Click(object sender, EventArgs e)
        {
            disableButtons();
            DataPointCollection easyType = chartMain.Series[0].Points;

            await Task.Run( () => quickSortHelper(ref easyType, 0, easyType.Count));

            enableButtons();
        }

        // A recursive helper method for quicksort
        private Task quickSortHelper(ref DataPointCollection arr, int min, int max)
        {
            //chartMain.BeginInvoke( new Action <DataPointCollection, int, int> ((arr, min, max) =>
            //{
                // Keep Recursing
                if (max - min > 1)
                {
                    //int half = ((max - min) / 2) + min;

                    // Setting our pivot point, both Value and Position
                    //  Pivot is going to be set at the middle of the array
                    int pivotPos = max - 1;

                    var pivotVal = arr[pivotPos].YValues;

                    arr[pivotPos].Color = Color.Red;
                    for (int i = min; i < pivotPos; i++)
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

                            arr[i + 1].Color = Color.CornflowerBlue;
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
            //}), new Object[] { arr1, min1, max1 });
            return Task.CompletedTask;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            chartMain.Series[0].Points.Clear();
            var rand = new Random();
            List<int> startList = new List<int>();

            for (int i = 1; i < 100; i++)
            {
                startList.Add(i);
            }

            for (int i = 1; i < 100; i++)
            {
                int nextData = rand.Next(startList.Count);
                chartMain.Series[0].Points.Add(new DataPoint(i, startList[nextData]));
                startList.Remove(startList[nextData]);
            }
        }

        private void disableButtons()
        {
            foreach(Control button in this.Controls)
            {
                if (button.GetType() == buttonOK.GetType())
                {
                    button.Enabled = false;
                }
            }
        }
        private void enableButtons()
        {
            foreach (Control button in this.Controls)
            {
                if (button.GetType() == buttonOK.GetType())
                {
                    button.Enabled = true;
                }
            }
        }
    }
}
