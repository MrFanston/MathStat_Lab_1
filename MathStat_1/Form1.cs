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

/*!
    \brief Оценка вероятности выпадения орла

    Моделирование процесса подбрасывания монеты и оценка вероятностей
*/
namespace MathStat_1
{

    /*!
	    \brief Родительский класс, форма приложения

	    Данный класс содержит все событийные и обрабатывающие классы
    */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*!
	        \brief Событие нажатия на кнопку расчета

	        Производит эксперементальные расчеты подбрасывания монетки:
            1) Проведение эксперемента;
            2) Расчет средней относительной частоты;
            3) Расчет доверительного интервала;
            4) Расчет приближенного значения вероятности;
            5) Расчет теоретической ошибки частоты подбрасывания;
            6) Построение всех графиков и их вывод.
            
        */
        public void button_calculation_Click(object sender, EventArgs e)
        {
            // Очистка графика
            chart_depending_frequencies.Series.Clear();
            chart_error.Series.Clear();

            // Параметры для расчета
            int numThrows = ((int)numericUpDown_num_throws.Value);
            int numExperiments = ((int)numericUpDown_num_experiments.Value);
            float confidenceLevel = ((int)numericUpDown_confidence_level.Value) / 100.0f;

            // Матрица с частотами
            List<List<float>> frequencyMatrix = PerformExperiments(numThrows, numExperiments, chart_depending_frequencies);

            // Матрица с средними значениями
            List<float> averageFrequencies = CalculateMeanFrequencies(numThrows, numExperiments, frequencyMatrix, chart_depending_frequencies);

            // Строим график доверительного интервала
            List<List<float>> confidenceIntervals = CalculateConfidenceIntervals(numThrows, confidenceLevel, frequencyMatrix, chart_depending_frequencies);

            // Приближенное значение вероятности
            float approximatedProbability = CalculateApproximatedProbability(numThrows, frequencyMatrix, confidenceIntervals, label5);

            // Вычисляем теоретическую ошибку частоты от количества подбрасывания монеты
            List<float> theoreticalError = CalculateTheoreticalError(numThrows, confidenceLevel, chart_error);

            // Вычисляем эксперементальную ошибку частоты от количества подбрасывания монеты
            List<float> experimentalError = CalculateExperimentalError(numThrows, confidenceIntervals, chart_error);

            // Настройка графика
            chart_depending_frequencies.ChartAreas[0].AxisX.Maximum = numThrows;
            chart_depending_frequencies.ChartAreas[0].AxisX.Minimum = 1;
            chart_depending_frequencies.ChartAreas[0].AxisY.Maximum = 1;
            chart_depending_frequencies.ChartAreas[0].AxisY.Minimum = 0;

            // Установка логарифмической шкалы на оси X
            chart_depending_frequencies.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart_error.ChartAreas[0].AxisX.IsLogarithmic = true;

            // Установка базы логарифма
            chart_depending_frequencies.ChartAreas[0].AxisX.LogarithmBase = 10;
            chart_error.ChartAreas[0].AxisX.LogarithmBase = 10;

        }

        public List<List<float>> PerformExperiments(int numThrows, int numExperiments, Chart chart)
        {
            Function function = new Function();
            List<List<float>> frequencyMatrix = new List<List<float>>();

            // Проводим серию экспериментов
            frequencyMatrix = function.PerformExperiments(numThrows, numExperiments, frequencyMatrix);

            // Вывод графика частот
            for (int i = 0; i < numExperiments; i++)
            {
                chart.Series.Add(Name + i);
                chart.Series[i].ChartType = SeriesChartType.Line;
                chart.Series[i].Color = Color.Black;
                for (int j = 1; j <= numThrows; j++)
                {
                    chart.Series[i].Points.AddXY(j, frequencyMatrix[i][j - 1]);
                }
            }

            return frequencyMatrix;
        }

        public List<float> CalculateMeanFrequencies(int numThrows, int numExperiments, List<List<float>> frequencyMatrix, Chart chart)
        {
            Function function = new Function();

            // Рассчитываем значения средней относительной частоты
            List<float> averageFrequencies = function.CalculateMeanFrequencies(frequencyMatrix);

            // Строим график средней относительной частоты
            chart.Series.Add("average_frequency");
            chart.Series["average_frequency"].ChartType = SeriesChartType.Line;
            chart.Series["average_frequency"].Color = Color.Red;

            for (int i = 0; i < numThrows; i++)
            {
                chart.Series["average_frequency"].Points.AddXY(i, averageFrequencies[i] / (float)numExperiments);
            }

            return averageFrequencies;
        }

        public List<List<float>> CalculateConfidenceIntervals(int numThrows, float confidenceLevel, List<List<float>> frequencyMatrix, Chart chart)
        {
            Function function = new Function();

            // Строим график доверительного интервала
            List<List<float>> confidenceIntervals = function.CalculateConfidenceIntervals(confidenceLevel, frequencyMatrix);

            chart.Series.Add("upper_bound");
            chart.Series["upper_bound"].ChartType = SeriesChartType.Line;
            chart.Series["upper_bound"].Color = Color.Blue;

            chart.Series.Add("lower_bound");
            chart.Series["lower_bound"].ChartType = SeriesChartType.Line;
            chart.Series["lower_bound"].Color = Color.Blue;

            for (int i = 0; i < numThrows; i++)
            {
                chart.Series["upper_bound"].Points.AddXY(i, confidenceIntervals[1][i]);
                chart.Series["lower_bound"].Points.AddXY(i, confidenceIntervals[0][i]);
            }

            return confidenceIntervals;
        }

        public float CalculateApproximatedProbability(int numThrows, List<List<float>> frequencyMatrix, List<List<float>> confidenceIntervals, System.Windows.Forms.Label label)
        {
            Function function = new Function();
            float approximatedProbability = function.CalculateApproximatedProbability(frequencyMatrix);

            float lowerBound = confidenceIntervals[0][numThrows - 1];
            float upperBound = confidenceIntervals[1][numThrows - 1];

            label.Text = approximatedProbability.ToString() + " +- " + ((upperBound - lowerBound) / 2).ToString();

            return approximatedProbability;
        }

        public List<float> CalculateTheoreticalError(int numThrows, float confidenceLevel, Chart chart)
        {
            Function function = new Function();
            float quantile = function.GetNormalQuantile((1 + confidenceLevel) / 2);

            List<float> theoreticalError = new List<float>();

            for (int i = 1; i < numThrows + 1; i++)
            {
                // Здесь 0.5 и 0.5 вероятности выпадения сторон
                float temp = (float)(quantile * Math.Sqrt((0.5 * 0.5) / i));
                theoreticalError.Add(temp);
            }

            // Рисуем графики ошибки
            chart.Series.Add("theoretical_error");
            chart.Series["theoretical_error"].ChartType = SeriesChartType.Line;
            chart.Series["theoretical_error"].Color = Color.Blue;

            for (int i = 1; i < numThrows; i++)
            {
                chart.Series["theoretical_error"].Points.AddXY(i, theoreticalError[i]);
            }

            return theoreticalError;
        }

        public List<float> CalculateExperimentalError(int numThrows, List<List<float>> confidenceIntervals, Chart chart)
        {
            List<float> experimentalError = new List<float>();
            for (int i = 1; i < numThrows + 1; i++)
            {
                experimentalError.Add((confidenceIntervals[0][i - 1] - confidenceIntervals[1][i - 1]) / 2);
            }

            chart.Series.Add("experimental_error");
            chart.Series["experimental_error"].ChartType = SeriesChartType.Line;
            chart.Series["experimental_error"].Color = Color.Red;

            for (int i = 1; i < numThrows; i++)
            {
                chart.Series["experimental_error"].Points.AddXY(i, experimentalError[i]);
            }

            return experimentalError;
        }
    }

    //! Класс с методами расчета
    public class Function
    {
        /*!
            \brief Метод проведения эксперемента подкидывания монетки
        
            \param[in] numThrows Количество подбрасываний монеты
            \param[in] numExperiments Количество проводимых экспериментов
            \param[out] frequencyMatrix Двумерный лист с экспериментами и частотами выпадения орла в каждом из них
        
            Проводит серию экспериментов, в каждом из которых проводит серию бросков монеты, 
            записывая каждый раз относительные частоты выпадения орла
        */
        public List<List<float>> PerformExperiments(int numThrows, int numExperiments, List<List<float>> frequencyMatrix)
        {
            var rand = new Random();

            // Повторение экспериментов
            for (int i = 0; i < numExperiments; i++)
            {
                float relativeFrequency;
                int headsCount = 0;
                List<float> experimentResults = new List<float>();

                // Повторение бросков
                for (int j = 0; j < numThrows; j++)
                {
                    int coinFlip = rand.Next(0, 2);

                    if (coinFlip >= 1) ++headsCount;

                    relativeFrequency = (float)headsCount / (float)(j + 1);

                    experimentResults.Add(relativeFrequency);
                }

                frequencyMatrix.Add(experimentResults);
            }

            return frequencyMatrix;
        }

        /*!
            \brief Метод вычисления средней частоты по столбцам
        
            \param[in] frequencyMatrix Двумерный лист с экспериментами и частотами выпадения орла в каждом из них
            \param[out] averageFrequencies Лист со средними частотами каждого эксперимента
        */
        public List<float> CalculateMeanFrequencies(List<List<float>> frequencyMatrix)
        {
            List<float> averageFrequencies = new List<float>();
            int numThrows = frequencyMatrix[0].Count;
            int numExperiments = frequencyMatrix.Count;
            float sum = 0;

            for (int i = 0; i < numThrows; i++)
            {
                for (int j = 0; j < numExperiments; j++)
                {
                    sum += frequencyMatrix[j][i];
                }

                averageFrequencies.Add(sum);
                sum = 0;
            }

            return averageFrequencies;
        }

        /*!
            \brief Метод вычисления доверительного интервала
        
            \param[in] confidenceLevel Уровень доверия
            \param[in] frequencyMatrix Двумерный лист с экспериментами и частотами выпадения орла в каждом из них
            \param[out] confidenceIntervals Двумерный лист с верхними и нижними границами частот доверительного интервала

            Сортирует исходный лист с частотами и записывает границы с откинутыми значениями
            сверху и снизу
        */
        public List<List<float>> CalculateConfidenceIntervals(float confidenceLevel, List<List<float>> frequencyMatrix)
        {
            int numThrows = frequencyMatrix[0].Count;
            int numExperiments = frequencyMatrix.Count;

            float lowerBoundIndex = (1 - confidenceLevel) / 2 * numExperiments;
            float upperBoundIndex = numExperiments - lowerBoundIndex - 1;

            List<List<float>> confidenceIntervals = new List<List<float>>();
            List<float> lowerBounds = new List<float>();
            List<float> upperBounds = new List<float>();

            confidenceIntervals.Add(lowerBounds);
            confidenceIntervals.Add(upperBounds);

            // Сортируем вероятности в каждом эксперименте при определенном броске
            for (int i = 0; i < numThrows; i++)
            {
                for (int j = 0; j < numExperiments - 1; j++)
                {
                    for (int c = j + 1; c < numExperiments; c++)
                    {
                        if (frequencyMatrix[c][i] > frequencyMatrix[j][i])
                        {
                            var temp = frequencyMatrix[j][i];
                            frequencyMatrix[j][i] = frequencyMatrix[c][i];
                            frequencyMatrix[c][i] = temp;
                        }
                    }
                }

                confidenceIntervals[0].Add(frequencyMatrix[(int)lowerBoundIndex][i]);
                confidenceIntervals[1].Add(frequencyMatrix[(int)upperBoundIndex][i]);
            }
            return confidenceIntervals;
        }

        /*!
            \brief Метод вычисления приближенного значения вероятности
        
            \param[in] frequencyMatrix Двумерный лист с экспериментами и частотами выпадения орла в каждом из них
            \param[out] approximatedProbability Приближенное значение вероятности

            Выводит среднее значение вероятностей среди последних вероятностей экспериментов
        */
        public float CalculateApproximatedProbability(List<List<float>> frequencyMatrix)
        {
            float sum = 0;
            int numThrows = frequencyMatrix[0].Count;
            int numExperiments = frequencyMatrix.Count;

            for (int i = 0; i < numExperiments; i++)
            {
                sum += frequencyMatrix[i][numThrows - 1];
            }

            return sum / (float)numExperiments;
        }

        /*!
            \brief Метод вычисления квантиля стандартного нормального распределения

            \param[in] p ((1 + ALPHA) / 2)
            \param[out] quantile Значение квантиля распределения
        */
        public float GetNormalQuantile(float p)
        {
            double probability = Math.Pow(p, 0.14);
            double oneMinusProbability = Math.Pow((1 - p), 0.14);

            return (float)(4.91 * (probability - oneMinusProbability));
        }
    }
}