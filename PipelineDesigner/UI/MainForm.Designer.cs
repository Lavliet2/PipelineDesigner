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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.comboPipelines = new System.Windows.Forms.ComboBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.btnAddPipeline = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDeletePipeline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboPipelines
            // 
            this.comboPipelines.Location = new System.Drawing.Point(12, 12);
            this.comboPipelines.Name = "comboPipelines";
            this.comboPipelines.Size = new System.Drawing.Size(100, 21);
            this.comboPipelines.TabIndex = 1;
            this.comboPipelines.SelectedIndexChanged += new System.EventHandler(this.comboPipelines_SelectedIndexChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(26, 42);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(49, 20);
            this.txtX.TabIndex = 4;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(107, 43);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(46, 20);
            this.txtY.TabIndex = 6;
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(12, 45);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(20, 20);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.Location = new System.Drawing.Point(81, 45);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(20, 20);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "Y:";
            // 
            // btnAddPipeline
            // 
            this.btnAddPipeline.Location = new System.Drawing.Point(120, 10);
            this.btnAddPipeline.Name = "btnAddPipeline";
            this.btnAddPipeline.Size = new System.Drawing.Size(100, 23);
            this.btnAddPipeline.TabIndex = 2;
            this.btnAddPipeline.Text = "Добавить трубу";
            this.btnAddPipeline.Click += new System.EventHandler(this.btnAddPipeline_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(159, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(234, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(0, 0);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 9;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(12, 70);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(90, 30);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "Коллизии";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(12, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(312, 780);
            this.dataGridView1.TabIndex = 11;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(330, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(922, 878);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnDeletePipeline
            // 
            this.btnDeletePipeline.Location = new System.Drawing.Point(226, 11);
            this.btnDeletePipeline.Name = "btnDeletePipeline";
            this.btnDeletePipeline.Size = new System.Drawing.Size(98, 23);
            this.btnDeletePipeline.TabIndex = 0;
            this.btnDeletePipeline.Text = "Удалить трубу";
            this.btnDeletePipeline.Click += new System.EventHandler(this.btnDeletePipeline_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1264, 911);
            this.Controls.Add(this.btnDeletePipeline);
            this.Controls.Add(this.comboPipelines);
            this.Controls.Add(this.btnAddPipeline);
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
            this.PerformLayout();

        }
    }
}