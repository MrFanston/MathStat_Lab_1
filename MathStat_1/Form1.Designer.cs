namespace MathStat_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.numericUpDown_num_throws = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_num_experiments = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_confidence_level = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_depending_frequencies = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_calculation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart_error = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_throws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_experiments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_confidence_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_depending_frequencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_error)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_num_throws
            // 
            this.numericUpDown_num_throws.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_num_throws.Location = new System.Drawing.Point(24, 52);
            this.numericUpDown_num_throws.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_num_throws.Name = "numericUpDown_num_throws";
            this.numericUpDown_num_throws.Size = new System.Drawing.Size(85, 23);
            this.numericUpDown_num_throws.TabIndex = 0;
            this.numericUpDown_num_throws.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericUpDown_num_experiments
            // 
            this.numericUpDown_num_experiments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_num_experiments.Location = new System.Drawing.Point(24, 110);
            this.numericUpDown_num_experiments.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_num_experiments.Name = "numericUpDown_num_experiments";
            this.numericUpDown_num_experiments.Size = new System.Drawing.Size(84, 23);
            this.numericUpDown_num_experiments.TabIndex = 1;
            this.numericUpDown_num_experiments.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown_confidence_level
            // 
            this.numericUpDown_confidence_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_confidence_level.Location = new System.Drawing.Point(24, 167);
            this.numericUpDown_confidence_level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_confidence_level.Name = "numericUpDown_confidence_level";
            this.numericUpDown_confidence_level.Size = new System.Drawing.Size(83, 23);
            this.numericUpDown_confidence_level.TabIndex = 2;
            this.numericUpDown_confidence_level.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество подбрасываний монеты N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество серий экспериментов K";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Доверительный интервал α";
            // 
            // chart_depending_frequencies
            // 
            this.chart_depending_frequencies.BorderlineWidth = 0;
            chartArea3.Name = "ChartArea1";
            this.chart_depending_frequencies.ChartAreas.Add(chartArea3);
            this.chart_depending_frequencies.Location = new System.Drawing.Point(316, 26);
            this.chart_depending_frequencies.Name = "chart_depending_frequencies";
            this.chart_depending_frequencies.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart_depending_frequencies.Size = new System.Drawing.Size(446, 404);
            this.chart_depending_frequencies.TabIndex = 6;
            this.chart_depending_frequencies.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title2.Name = "Title1";
            this.chart_depending_frequencies.Titles.Add(title2);
            // 
            // button_calculation
            // 
            this.button_calculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_calculation.Location = new System.Drawing.Point(23, 208);
            this.button_calculation.Name = "button_calculation";
            this.button_calculation.Size = new System.Drawing.Size(75, 30);
            this.button_calculation.TabIndex = 7;
            this.button_calculation.Text = "Расчет";
            this.button_calculation.UseVisualStyleBackColor = true;
            this.button_calculation.Click += new System.EventHandler(this.button_calculation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Приближенное значение вероятности:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 9;
            // 
            // chart_error
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_error.ChartAreas.Add(chartArea4);
            this.chart_error.Location = new System.Drawing.Point(784, 26);
            this.chart_error.Name = "chart_error";
            this.chart_error.Size = new System.Drawing.Size(431, 404);
            this.chart_error.TabIndex = 10;
            this.chart_error.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1227, 442);
            this.Controls.Add(this.chart_error);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_calculation);
            this.Controls.Add(this.chart_depending_frequencies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_confidence_level);
            this.Controls.Add(this.numericUpDown_num_experiments);
            this.Controls.Add(this.numericUpDown_num_throws);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Лабораторная 1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_throws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_num_experiments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_confidence_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_depending_frequencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_num_throws;
        private System.Windows.Forms.NumericUpDown numericUpDown_num_experiments;
        private System.Windows.Forms.NumericUpDown numericUpDown_confidence_level;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_depending_frequencies;
        private System.Windows.Forms.Button button_calculation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_error;
    }
}

