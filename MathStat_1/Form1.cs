using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace MathStat_1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Очистка графика
            chart1.Series.Clear();
            chart2.Series.Clear();

            Function function = new Function();

            int N = ((int)numericUpDown1.Value);
            int K = ((int)numericUpDown2.Value);
            float a = ((int)numericUpDown3.Value);
            a = a / (float)100;
            
            //Матрица с частотами
            List<List<float>> Vo_sum = new List<List<float>>();

            //Проводим серию эксперементов
            Vo_sum = function.experiment(N, K, Vo_sum);

            //Вывод графика частот
            for (int i = 0; i < K; i++)
            {
                chart1.Series.Add(Name + i);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[i].Color = Color.Black;
                for (int j = 1; j <= N; j++)
                {
                    chart1.Series[i].Points.AddXY(j, Vo_sum[i][j-1]);
                }
            }

            //Матрица с средними значениями
            List<float> Vo_mean;

            //Рассчитываем значения средней относительной частоты
            Vo_mean = function.mean(Vo_sum);

            //Строим график средней относительной частоты
            chart1.Series.Add("average_frequency");
            chart1.Series["average_frequency"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["average_frequency"].Color = Color.Red;
            for (int i = 0; i < N; i++)
            {
                chart1.Series["average_frequency"].Points.AddXY(i, Vo_mean[i] / (float)K);
            }

            //Строим график доверительного интервала
            List < List<float> > Vo_interval = new List<List<float>>();
            Vo_interval = function.conf_Interval(a, Vo_sum);
            float down = (1 - a) / 2 * K;
            float up = K - down - 1;
            chart1.Series.Add("up");
            chart1.Series["up"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["up"].Color = Color.Blue;
            chart1.Series.Add("down");
            chart1.Series["down"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["down"].Color = Color.Blue;
            for (int i = 0; i < N; i++)
            {
                chart1.Series["up"].Points.AddXY(i, Vo_interval[1][i]);
                chart1.Series["down"].Points.AddXY(i, Vo_interval[0][i]);
            } 

            //Приближенное значение вероятности
            float sum = function.approximate_Value(a, Vo_sum);
            label5.Text = sum.ToString() + " +- " + ((Vo_interval[0][N-1] - Vo_interval[1][N-1]) / 2).ToString();

            //Вычисляем теоретическую ошибку частоты от количества подбрасывания монеты
            List<float> exp_error = new List<float>();
            for (int i = 1; i < N + 1; i++)
            {
                exp_error.Add((Vo_interval[0][i-1] - Vo_interval[1][i-1]) / 2);
            }
           

            float coef = function.normal_Quantile((1 + a) / 2);
            List<float> theory_error = new List<float>();
            
            for(int i = 1; i < N + 1; i++)
            {
                float temp = (float)(coef * Math.Sqrt(((1.0/3.0) * (2.0/3.0) )/ i));
                theory_error.Add(temp);
            }

            //Рисуем графики ошибки
            chart2.Series.Add("theory");
            chart2.Series["theory"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["theory"].Color = Color.Blue;
            chart2.Series.Add("exp");
            chart2.Series["exp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["exp"].Color = Color.Red;

            for (int i = 1; i < N; i++)
            {
                chart2.Series["theory"].Points.AddXY(i, theory_error[i]);
                chart2.Series["exp"].Points.AddXY(i, exp_error[i]);
            }

            //Настройка графика
            chart1.ChartAreas[0].AxisX.Maximum = N;
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            //Установка логарифмической шкалы на оси X
            chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart2.ChartAreas[0].AxisX.IsLogarithmic = true;
            //Установка базы логарифма
            chart1.ChartAreas[0].AxisX.LogarithmBase = 10;
            chart2.ChartAreas[0].AxisX.LogarithmBase = 10;

        }
    }
    public class Function
    {
        public List<List<float>> experiment(int N, int K, List<List<float>> Vo_sum)
        {
            var rand = new Random();
            //Повторение эксперементов
            for (int i = 0; i < K; i++)
            {
                float V = 0;
                int count = 0;
                List<float> Vo = new List<float>();
                //Повторение бросков
                for (int j = 0; j < N; j++)
                {

                    int value = rand.Next(0, 3);
                    if (value >= 1)
                    {
                        V = (float)++count / (float)(j + 1);
                    }
                    else
                    {
                        V = (float)count / (float)(j + 1);
                    }
                    Vo.Add(V);
                }
                Vo_sum.Add(Vo);
            }
            return Vo_sum;
        }
        public List<float> mean(List<List<float>> Vo_sum)
        {
            List<float> Vo_mean = new List<float>();
            int N = Vo_sum[0].Count;
            int K = Vo_sum.Count;
            float sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    sum += Vo_sum[j][i];
                }
                Vo_mean.Add(sum);
                sum = 0;
            }
            return Vo_mean;
        }
        public List<List<float>> conf_Interval(float a, List<List<float>> Vo_sum)
        {
            int N = Vo_sum[0].Count;
            int K = Vo_sum.Count;
            float down = (1 - a) / 2 * K;
            float up = K - down - 1;
            List<List<float>> Vo_interval = new List<List<float>>();
            List<float> Vo_up = new List<float>();
            List<float> Vo_down = new List<float>();
            Vo_interval.Add(Vo_up);
            Vo_interval.Add(Vo_down);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < K - 1; j++)
                {
                    for (int c = j + 1; c < K; c++)
                    {
                        if (Vo_sum[c][i] > Vo_sum[j][i])
                        {
                            var temp = Vo_sum[j][i];
                            Vo_sum[j][i] = Vo_sum[c][i];
                            Vo_sum[c][i] = temp;
                        }
                    }
                }
                Vo_interval[0].Add(Vo_sum[(int)down][i]);
                Vo_interval[1].Add(Vo_sum[(int)up][i]);
            }
            return Vo_interval;
        }
        public float approximate_Value(float a, List<List<float>> Vo_sum)
        {
            float sum = 0;
            int N = Vo_sum[0].Count;
            int K = Vo_sum.Count;
            float down = (1 - a) / 2 * K;
            float up = K - down - 1;
            up = Vo_sum[(int)(up)][N - 1];
            down = Vo_sum[(int)(down)][N - 1];
            for (int i = 0; i < K; i++)
            {
                sum += Vo_sum[i][N - 1];
            }
            sum = sum / (float)K;
            return sum;
        }
        public float normal_Quantile(float p)
        {
            return (float)(4.91 * (Math.Pow(p,0.14) - Math.Pow((1 - p),0.14)));
        }
    }
}
