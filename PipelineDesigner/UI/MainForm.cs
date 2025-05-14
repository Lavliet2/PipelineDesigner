using PipelineDesigner.Data;
using PipelineDesigner.Models;
using PipelineDesigner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PipelineDesigner
{
    public partial class MainForm : Form
    {
        private PipelineRepository _repo;
        private string connStr;
        //private string connStr = "Data Source=Database\\pipeline.db;Version=3;";
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
            DatabaseInitializer.Initialize(connStr);
            LoadNodes();
        }

        private void LoadNodes()
        {
            _nodes = _repo.GetNodes();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _nodes;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawPipelines(_nodes);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var collisions = CollisionChecker.FindCollisions(_nodes);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var id = (int)row.Cells["Id"].Value;
                row.DefaultCellStyle.BackColor = collisions.Any(n => n.Id == id) ? Color.Red : Color.White;
            }
            DrawPipelines(_nodes, collisions.Select(n => n.Id).ToHashSet());
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
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                _repo.DeleteNode(id);
                LoadNodes();
            }
        }

        private void DrawPipelines(List<Node> nodes, HashSet<int> highlight = null)
        {
            var g = panel1.CreateGraphics();
            g.Clear(Color.White);

            var grouped = nodes.GroupBy(n => n.PipelineId);
            foreach (var group in grouped)
            {
                var list = group.OrderBy(n => n.Id).ToList();
                for (int i = 0; i < list.Count - 1; i++)
                {
                    g.DrawLine(Pens.Blue,
                        (float)list[i].X * 10, (float)list[i].Y * 10,
                        (float)list[i + 1].X * 10, (float)list[i + 1].Y * 10);
                }

                foreach (var n in list)
                {
                    Brush brush = highlight != null && highlight.Contains(n.Id) ? Brushes.Red : Brushes.Black;
                    g.FillEllipse(brush, (float)n.X * 10 - 3, (float)n.Y * 10 - 3, 6, 6);
                }
            }
        }
    }
}