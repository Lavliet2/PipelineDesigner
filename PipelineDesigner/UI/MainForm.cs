using PipelineDesigner.Data;
using PipelineDesigner.Models;
using PipelineDesigner.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace PipelineDesigner
{
    public partial class MainForm : Form
    {
        private PipelineRepository _repo;
        private string connStr;
        private List<Node> _nodes;

        public MainForm()
        {
            InitializeComponent();

            string dbFolder = Path.Combine(Application.StartupPath, "Database");
            if (!Directory.Exists(dbFolder))
                Directory.CreateDirectory(dbFolder);

            connStr = $"Data Source={Path.Combine(dbFolder, "pipeline.db")};Version=3;";
            _repo = new PipelineRepository(connStr);
            _nodes = new List<Node>();

            if (!File.Exists(Path.Combine(dbFolder, "pipeline.db")))
            {
                DatabaseInitializer.Initialize(connStr);
            }

            SetupChart();
            LoadNodes();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void LoadNodes()
        {
            _nodes = _repo.GetNodes();

            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("№", typeof(int));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            foreach (var node in _nodes)
            {
                table.Rows.Add(node.Id, node.PipelineId, node.X, node.Y);
            }

            dataGridView1.DataSource = table;
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;

            DrawChart(_nodes);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawChart(_nodes);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var collisions = CollisionChecker.FindSegmentCollisions(_nodes);
            var collisionSet = collisions.Select(n => (n.X, n.Y)).ToHashSet();
            //var collisionCoords = CollisionChecker.FindCollisionCoordinates(_nodes);
            //var collisionSet = new HashSet<(double, double)>(collisionCoords);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double x = Convert.ToDouble(row.Cells["X"].Value);
                double y = Convert.ToDouble(row.Cells["Y"].Value);
                row.DefaultCellStyle.BackColor = collisionSet.Contains((x, y)) ? Color.Gold : Color.White;
            }

            DrawChart(_nodes, collisionSet);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var node = new Node { PipelineId = 1, X = 1, Y = 2 };
            _repo.AddNode(node);
            LoadNodes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                _repo.DeleteNode(id);
                LoadNodes();
            }
        }

        private void DrawChart(List<Node> nodes, HashSet<(double X, double Y)> highlight = null)
        {
            chart1.Series.Clear();

            var palette = new[] { Color.Blue, Color.Orange, Color.Gray };

            var grouped = nodes.GroupBy(n => n.PipelineId).ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                var group = grouped[i].OrderBy(n => n.Id).ToList();
                var series = new Series($"Pipeline {group[0].PipelineId}")
                {
                    ChartType = SeriesChartType.Line,
                    Color = palette[i % palette.Length],
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6
                };

                foreach (var node in group)
                {
                    var point = series.Points.AddXY(node.X, node.Y);
                    if (highlight != null && highlight.Contains((node.X, node.Y)))
                    {
                        series.Points[point].MarkerColor = Color.Red;
                    }
                }

                chart1.Series.Add(series);
            }
        }
    }
}