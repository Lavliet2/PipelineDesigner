namespace PipelineDesigner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboPipelines;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Button btnAddPipeline;
        private System.Windows.Forms.Button btnDeletePipeline;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboPipelines = new System.Windows.Forms.ComboBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.btnAddPipeline = new System.Windows.Forms.Button();
            this.btnDeletePipeline = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // comboPipelines
            this.comboPipelines.Location = new System.Drawing.Point(12, 12);
            this.comboPipelines.Size = new System.Drawing.Size(220, 21);
            this.comboPipelines.SelectedIndexChanged += new System.EventHandler(this.comboPipelines_SelectedIndexChanged);

            // btnAddPipeline
            this.btnAddPipeline.Location = new System.Drawing.Point(240, 10);
            this.btnAddPipeline.Size = new System.Drawing.Size(110, 23);
            this.btnAddPipeline.Text = "Добавить трубу";
            this.btnAddPipeline.Click += new System.EventHandler(this.btnAddPipeline_Click);

            // btnDeletePipeline
            this.btnDeletePipeline.Location = new System.Drawing.Point(360, 10);
            this.btnDeletePipeline.Size = new System.Drawing.Size(110, 23);
            this.btnDeletePipeline.Text = "Удалить трубу";
            this.btnDeletePipeline.Click += new System.EventHandler(this.btnDeletePipeline_Click);

            // lblX
            this.lblX.Text = "X:";
            this.lblX.Location = new System.Drawing.Point(12, 45);
            this.lblX.Size = new System.Drawing.Size(20, 20);

            // txtX
            this.txtX.Location = new System.Drawing.Point(30, 42);
            this.txtX.Size = new System.Drawing.Size(60, 20);

            // lblY
            this.lblY.Text = "Y:";
            this.lblY.Location = new System.Drawing.Point(100, 45);
            this.lblY.Size = new System.Drawing.Size(20, 20);

            // txtY
            this.txtY.Location = new System.Drawing.Point(120, 42);
            this.txtY.Size = new System.Drawing.Size(60, 20);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(200, 40);
            this.btnAdd.Size = new System.Drawing.Size(90, 23);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(300, 40);
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnDraw
            this.btnDraw.Location = new System.Drawing.Point(400, 40);
            this.btnDraw.Size = new System.Drawing.Size(90, 23);
            this.btnDraw.Text = "Нарисовать";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);

            // btnCheck
            this.btnCheck.Location = new System.Drawing.Point(500, 40);
            this.btnCheck.Size = new System.Drawing.Size(90, 23);
            this.btnCheck.Text = "Коллизии";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Size = new System.Drawing.Size(580, 600);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);

            // chart1
            this.chart1.Location = new System.Drawing.Point(610, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(640, 668);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            // MainForm
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.comboPipelines);
            this.Controls.Add(this.btnAddPipeline);
            this.Controls.Add(this.btnDeletePipeline);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Name = "MainForm";
            this.Text = "Проектирование трубопроводов";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}