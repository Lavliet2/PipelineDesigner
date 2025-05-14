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

            string dbFolder = System.IO.Path.Combine(Application.StartupPath, "Database");
            if (!System.IO.Directory.Exists(dbFolder))
                System.IO.Directory.CreateDirectory(dbFolder);

            connStr = $"Data Source={System.IO.Path.Combine(dbFolder, "pipeline.db")};Version=3;";
            _repo = new PipelineRepository(connStr);
            _nodes = new List<Node>();
            if (!System.IO.File.Exists(Path.Combine(dbFolder, "pipeline.db")))
            {
                DatabaseInitializer.Initialize(connStr);
            }
            //MessageBox.Show(connStr);
            LoadNodes();
        }

        private void LoadNodes()
        {
            _nodes = _repo.GetNodes();

            var table = new DataTable();
            table.Columns.Add("№", typeof(int));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            foreach (var group in _nodes.GroupBy(n => n.PipelineId))
            {
                foreach (var node in group)
                {
                    table.Rows.Add(group.Key, node.X, node.Y);
                }
            }

            dataGridView1.DataSource = table;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawPipelines(_nodes);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var collisions = CollisionChecker.FindCollisions(_nodes);
            var collisionSet = collisions.Select(c => (c.X, c.Y)).ToHashSet();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double x = Convert.ToDouble(row.Cells["X"].Value);
                double y = Convert.ToDouble(row.Cells["Y"].Value);
                row.DefaultCellStyle.BackColor = collisionSet.Contains((x, y)) ? Color.Gold : Color.White;
            }

            DrawPipelines(_nodes, collisionSet);
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
                double x = Convert.ToDouble(dataGridView1.CurrentRow.Cells["X"].Value);
                double y = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Y"].Value);

                var toDelete = _nodes.FirstOrDefault(n => n.X == x && n.Y == y);
                if (toDelete != null)
                {
                    _repo.DeleteNode(toDelete.Id);
                    LoadNodes();
                }
            }
        }

        private void DrawPipelines(List<Node> nodes, HashSet<(double X, double Y)> highlight = null)
        {
            var g = panel1.CreateGraphics();
            g.Clear(Color.White);

            var colors = new[] { Pens.Blue, Pens.Orange, Pens.Gray };
            var brushes = new[] { Brushes.Blue, Brushes.Orange, Brushes.Gray };

            var groups = nodes.GroupBy(n => n.PipelineId).ToList();
            for (int index = 0; index < groups.Count; index++)
            {
                var group = groups[index].OrderBy(n => n.Id).ToList();
                var pen = colors[index % colors.Length];
                var brush = brushes[index % brushes.Length];

                for (int i = 0; i < group.Count - 1; i++)
                {
                    g.DrawLine(pen,
                        (float)group[i].X * 40, (float)(300 - group[i].Y * 20),
                        (float)group[i + 1].X * 40, (float)(300 - group[i + 1].Y * 20));
                }

                foreach (var node in group)
                {
                    Brush b = (highlight != null && highlight.Contains((node.X, node.Y))) ? Brushes.Gold : brush;
                    g.FillEllipse(b, (float)(node.X * 40 - 3), (float)(300 - node.Y * 20 - 3), 6, 6);
                }
            }

            // легенда
            g.DrawString("1", new Font("Arial", 8), Brushes.Blue, 500, 20);
            g.DrawString("2", new Font("Arial", 8), Brushes.Orange, 500, 40);
            g.DrawString("3", new Font("Arial", 8), Brushes.Gray, 500, 60);
        }
    }
}