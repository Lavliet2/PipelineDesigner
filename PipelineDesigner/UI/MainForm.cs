
using PipelineDesigner.Data;
using PipelineDesigner.Models;
using PipelineDesigner.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PipelineDesigner
{
    public partial class MainForm : Form
    {
        private PipelineRepository _repo;
        private string connStr;
        private List<Pipeline> _pipelines;
        private List<Node> _nodes;
        private Pipeline _selectedPipeline;

        public MainForm()
        {
            InitializeComponent();

            string dbFolder = Path.Combine(Application.StartupPath, "Database");
            if (!Directory.Exists(dbFolder))
                Directory.CreateDirectory(dbFolder);

            connStr = $"Data Source={Path.Combine(dbFolder, "pipeline.db")};Version=3;";
            _repo = new PipelineRepository(connStr);

            if (!File.Exists(Path.Combine(dbFolder, "pipeline.db")))
            {
                DatabaseInitializer.Initialize(connStr);
            }

            SetupChart();
            LoadPipelines();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Arial", 9),
            });
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void LoadPipelines()
        {
            _pipelines = _repo.GetPipelines();
            comboPipelines.DataSource = null;
            comboPipelines.DataSource = _pipelines;
            comboPipelines.DisplayMember = "Name";
            comboPipelines.ValueMember = "Id";

            if (_pipelines.Any())
            {
                _selectedPipeline = (Pipeline)comboPipelines.SelectedItem;
                LoadNodes();
            }
        }

        private void comboPipelines_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPipeline = (Pipeline)comboPipelines.SelectedItem;
            LoadNodes();
        }

        private void LoadNodes()
        {
            if (_selectedPipeline == null) return;

            _nodes = _repo.GetNodes()
                          .Where(n => n.PipelineId == _selectedPipeline.Id)
                          .ToList();

            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            foreach (var node in _nodes)
            {
                table.Rows.Add(node.Id, node.X, node.Y);
            }

            dataGridView1.DataSource = table;
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;

            DrawChart(_repo.GetNodes());
        }

        private void btnAddPipeline_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Введите имя новой трубы", "Добавить трубопровод", "Труба X");
            if (!string.IsNullOrWhiteSpace(name))
            {
                _repo.AddPipeline(name);
                LoadPipelines();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_selectedPipeline == null) return;

            if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y))
            {
                var node = new Node { X = x, Y = y, PipelineId = _selectedPipeline.Id };
                _repo.AddNode(node);
                LoadNodes();
            }
            else
            {
                MessageBox.Show("Введите корректные X и Y");
            }
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

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawChart(_repo.GetNodes());
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var allNodes = _repo.GetNodes();
            var collisions = CollisionChecker.FindSegmentCollisions(allNodes);
            var highlight = collisions.Select(n => (n.X, n.Y)).ToHashSet();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double x = Convert.ToDouble(row.Cells["X"].Value);
                double y = Convert.ToDouble(row.Cells["Y"].Value);
                row.DefaultCellStyle.BackColor = highlight.Contains((x, y)) ? Color.Red : Color.White;
            }

            DrawChart(allNodes, highlight);
        }

        private void DrawChart(List<Node> nodes, HashSet<(double X, double Y)> highlight = null)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Arial", 9)
            });

            var palette = new[] { Color.Blue, Color.Orange, Color.Green, Color.Purple };

            var grouped = nodes.GroupBy(n => n.PipelineId).ToList();
            for (int i = 0; i < grouped.Count; i++)
            {
                var group = grouped[i].OrderBy(n => n.Id).ToList();
                var pipeId = group[0].PipelineId;
                var pipeName = _pipelines.FirstOrDefault(p => p.Id == pipeId)?.Name ?? $"Труба {pipeId}";

                var series = new Series(pipeName)
                {
                    ChartType = SeriesChartType.Line,
                    Color = palette[i % palette.Length],
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    Legend = "Legend",
                    LegendText = pipeName
                };

                foreach (var node in group)
                {
                    int pointIndex = series.Points.AddXY(node.X, node.Y);
                    if (highlight != null && highlight.Contains((node.X, node.Y)))
                    {
                        series.Points[pointIndex].MarkerColor = Color.Red;
                    }
                }

                chart1.Series.Add(series);
            }
        }
        private void btnDeletePipeline_Click(object sender, EventArgs e)
        {
            if (_selectedPipeline == null) return;

            var confirm = MessageBox.Show(
                $"Удалить трубопровод '{_selectedPipeline.Name}' вместе со всеми координатами?",
                "Подтвердите удаление",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _repo.DeletePipeline(_selectedPipeline.Id);
                LoadPipelines();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["Id"].Value == null) return;

                int id = Convert.ToInt32(row.Cells["Id"].Value);
                double x = Convert.ToDouble(row.Cells["X"].Value);
                double y = Convert.ToDouble(row.Cells["Y"].Value);

                var node = new Node
                {
                    Id = id,
                    X = x,
                    Y = y,
                    PipelineId = _selectedPipeline.Id
                };

                _repo.UpdateNode(node);
                LoadNodes();
            }
        }
    }
}