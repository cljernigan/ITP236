﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using InventoryOopProjectGrader;

namespace InventoryOopGrader
{
    public partial class Form1 : Form
    {
        Assembly p4Assembly;
        Grader grader;
        XDocument projectData;
        Setup setup;

        const int Value = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["ProjectPath"];
            string assemblyName = ConfigurationManager.AppSettings["AssemblyName"];
            try
            {
                projectData = XDocument.Load("XML/VsProjectGrader.xml");
                string directory = Directory.GetCurrentDirectory();
                string assemblyFile = string.Format("{0}\\{1}.DLL", directory,  assemblyName);

                p4Assembly = Assembly.LoadFile(assemblyFile); 

                setup = new Setup(p4Assembly, projectData);
                grader = new Grader(setup.Name());
                List<string> topicNames = setup.TopicNames();
                foreach (string topicName in topicNames)
                    grader.Topics.Add(setup.SetupTopic(topicName));
                ProjectName.Text = grader.Name;

                PopulateData data = new PopulateData();
                setup.GradeTheProject(grader, data);
                ResultsView.DataSource = grader.Topics;

                StudentName.Text = grader.Programmer;
                GradeSummary.Text = String.Format("Grade {0} / {1}", grader.TotalGrade, grader.TotalValue);
                Percentage.Text = String.Format("{0:0.0%}", grader.GradePercentage);
                ProgressIndicator.Maximum = grader.TotalValue;
                ProgressIndicator.Value = grader.TotalGrade;
                Color color = GetProgressColor(grader.GradePercentage);
                ProgressIndicator.BackColor = color;
                ProgressIndicator.ForeColor = color;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(String.Format("Could not load {0} from {1}. Check the properties in your App.Config file. {2}", assemblyName, path, ex.Message), "Could not find file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetProgressColor(decimal gradePercentage)
        {
            Color color ;
            if (gradePercentage < .42M)
                color = Color.Red;
            else if (gradePercentage < .62M)
                color = Color.RosyBrown;
            else if (gradePercentage < .72M)
                color = Color.OrangeRed;
            else if (gradePercentage < .82M)
                color = Color.Yellow;
            else if (gradePercentage < .92M)
                color = Color.GreenYellow;
            else
                color = Color.Green;
            return color;
        }

        private void ResultsView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn column = e.Column;
            switch (column.HeaderText)
            {
                case "TotalValue":
                    column.HeaderText = "Value";
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
                    break;
                case "TotalGrade":
                    column.HeaderText = "Grade";
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
                    break;
                case "GradePercentage":
                    column.HeaderText = "Percentage";
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
                    column.DefaultCellStyle = new DataGridViewCellStyle() { 
                        Format = "##0.0%", 
                        Alignment = DataGridViewContentAlignment.TopRight 
                    };
                    break;
            }
        }

        private void ResultsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ResultsView.Rows[e.RowIndex];
            var item = row.DataBoundItem;
            Type type = item.GetType();
            Topic topic = (Topic)item;
            TestView.Visible = true;
            TestView.DataSource = topic.Tests;
        }

        private void TestView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn column = e.Column;
            switch (column.HeaderText)
            {
                case "Message":
                    column.Width = 245;
                    break;
                case "Name":
                    column.Width = 155;
                    break;
                case "Method":
                case "Generic":
                case "ReadWrite":
                case "DataType":
                case "Parameters":
                    column.Visible = false;
                    break;
            }
        }
        private enum TestCols
        {
            Name = 1,
            Grade = 6
        }
        private void TestView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in TestView.Rows)
            {
                DataGridViewCell name = row.Cells[(int)TestCols.Name],
                    grade = row.Cells[(int)TestCols.Grade];
                name.Style.BackColor = Color.White;
                grade.Style.BackColor = Color.White;

                string gradeValue = grade.Value.ToString();
                if (gradeValue.Equals("0"))
                {
                    name.Style.BackColor = Color.Red;
                    grade.Style.BackColor = Color.Red;
                }
            }
        }
    }
}