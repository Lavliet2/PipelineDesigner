namespace PipelineDesigner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Size = new System.Drawing.Size(400, 300);
            this.dataGridView1.Name = "dataGridView1";

            // chart1
            this.chart1.Location = new System.Drawing.Point(430, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(600, 400);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            // btnDraw
            this.btnDraw.Location = new System.Drawing.Point(12, 330);
            this.btnDraw.Size = new System.Drawing.Size(90, 30);
            this.btnDraw.Text = "Нарисовать";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);

            // btnCheck
            this.btnCheck.Location = new System.Drawing.Point(108, 330);
            this.btnCheck.Size = new System.Drawing.Size(90, 30);
            this.btnCheck.Text = "Коллизии";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(204, 330);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(300, 330);
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1050, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Name = "MainForm";
            this.Text = "Проектирование трубопроводов";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}