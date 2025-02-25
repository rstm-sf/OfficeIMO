﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using OfficeIMO.Word;
using SixLabors.ImageSharp;

namespace OfficeIMO.Examples.Word {
    internal static class Charts {
        public static void Example_AddingMultipleCharts(string folderPath, bool openWord) {
            Console.WriteLine("[*] Creating standard document with charts");
            string filePath = System.IO.Path.Combine(folderPath, "Charts Document.docx");

            using (WordDocument document = WordDocument.Create(filePath)) {
                List<string> categories = new List<string>() {
                    "Food", "Housing", "Mix", "Data"
                };

                document.AddParagraph("This is a bar chart");
                var barChart1 = document.AddBarChart();
                barChart1.AddCategories(categories);
                barChart1.AddChartBar("Brazil", new List<int>() { 10, 35, 18, 23 }, SixLabors.ImageSharp.Color.Brown);
                barChart1.AddChartBar("Poland", new List<int>() { 13, 20, 230, 150 }, SixLabors.ImageSharp.Color.Green);
                barChart1.AddChartBar("USA", new[] { 10, 35, 18, 23 }, SixLabors.ImageSharp.Color.AliceBlue);
                barChart1.BarGrouping = BarGroupingValues.Clustered;
                barChart1.BarDirection = BarDirectionValues.Column;

                document.AddParagraph("This is a bar chart");
                var barChart2 = document.AddBarChart();
                barChart2.AddCategories(categories);
                barChart2.AddChartBar("USA", 15, Color.Aqua);
                barChart2.RoundedCorners = true;

                document.AddParagraph("This is a pie chart");
                var pieChart = document.AddPieChart();
                pieChart.AddCategories(categories);
                pieChart.AddChartPie("Poland", new List<int> { 15, 20, 30 });

                document.AddParagraph("Adding a line chart as required 1");

                var lineChart = document.AddLineChart();
                lineChart.AddChartAxisX(categories);
                lineChart.AddChartLine("USA", new List<int>() { 10, 35, 18, 23 }, SixLabors.ImageSharp.Color.AliceBlue);
                lineChart.AddChartLine("Brazil", new List<int>() { 10, 35, 300, 18 }, SixLabors.ImageSharp.Color.Brown);
                lineChart.AddChartLine("Poland", new List<int>() { 13, 20, 230, 150 }, SixLabors.ImageSharp.Color.Green);

                document.AddParagraph("Adding a line chart as required 2");

                var lineChart2 = document.AddLineChart();
                lineChart2.AddChartAxisX(categories);
                lineChart2.AddChartLine("USA", new List<int>() { 10, 35, 18, 23 }, SixLabors.ImageSharp.Color.AliceBlue);
                lineChart2.AddChartLine("Brazil", new List<int>() { 10, 35, 300, 18 }, SixLabors.ImageSharp.Color.Brown);
                lineChart2.AddChartLine("Poland", new List<int>() { 13, 20, 230, 150 }, SixLabors.ImageSharp.Color.Green);

                document.Save(openWord);
            }
        }
    }
}
