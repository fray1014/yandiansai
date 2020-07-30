namespace History
{
    partial class HistoryPlot
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chHB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chHB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chB)).BeginInit();
            this.SuspendLayout();
            // 
            // chHB
            // 
            chartArea1.Name = "ChartArea1";
            this.chHB.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chHB.Legends.Add(legend1);
            this.chHB.Location = new System.Drawing.Point(12, 40);
            this.chHB.Name = "chHB";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "心率";
            series1.Name = "Series1";
            this.chHB.Series.Add(series1);
            this.chHB.Size = new System.Drawing.Size(694, 300);
            this.chHB.TabIndex = 0;
            this.chHB.Text = "chart1";
            // 
            // chB
            // 
            chartArea2.Name = "ChartArea1";
            this.chB.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chB.Legends.Add(legend2);
            this.chB.Location = new System.Drawing.Point(12, 390);
            this.chB.Name = "chB";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.LegendText = "呼吸率";
            series2.Name = "Series1";
            this.chB.Series.Add(series2);
            this.chB.Size = new System.Drawing.Size(694, 300);
            this.chB.TabIndex = 1;
            this.chB.Text = "chart2";
            // 
            // HistoryPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 729);
            this.Controls.Add(this.chB);
            this.Controls.Add(this.chHB);
            this.Name = "HistoryPlot";
            this.Text = "历史数据";
            this.Load += new System.EventHandler(this.HistoryPlot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chHB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chHB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chB;
    }
}

