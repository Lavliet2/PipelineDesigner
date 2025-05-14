namespace PipelineDesigner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Size = new System.Drawing.Size(500, 200);
            this.dataGridView1.Name = "dataGridView1";

            this.panel1.Location = new System.Drawing.Point(12, 220);
            this.panel1.Size = new System.Drawing.Size(600, 300);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Name = "panel1";

            this.btnDraw.Location = new System.Drawing.Point(520, 12);
            this.btnDraw.Size = new System.Drawing.Size(90, 30);
            this.btnDraw.Text = "Нарисовать";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);

            this.btnCheck.Location = new System.Drawing.Point(520, 52);
            this.btnCheck.Size = new System.Drawing.Size(90, 30);
            this.btnCheck.Text = "Коллизии";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            this.btnAdd.Location = new System.Drawing.Point(520, 92);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(520, 132);
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.ClientSize = new System.Drawing.Size(640, 540);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Name = "MainForm";
            this.Text = "Проектирование трубопроводов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}