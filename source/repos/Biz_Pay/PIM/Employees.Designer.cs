using System.Windows.Forms;

namespace PIM
{
    partial class Employees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFilter = new System.Windows.Forms.PictureBox();
            this.btnClearFilter = new System.Windows.Forms.PictureBox();
            this.tableEmployees = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputFilterName = new System.Windows.Forms.TextBox();
            this.selectFilterPermition = new System.Windows.Forms.ComboBox();
            this.selectFilterStatus = new System.Windows.Forms.ComboBox();
            this.selectFilterRole = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFilter)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1032, 732);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(835, 145);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(167, 58);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.TabStop = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnClearFilter.Image")));
            this.btnClearFilter.Location = new System.Drawing.Point(651, 145);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(167, 58);
            this.btnClearFilter.TabIndex = 2;
            this.btnClearFilter.TabStop = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // tableEmployees
            // 
            this.tableEmployees.ContextMenuStrip = this.contextMenuStrip1;
            this.tableEmployees.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tableEmployees.HideSelection = false;
            this.tableEmployees.Location = new System.Drawing.Point(96, 230);
            this.tableEmployees.Name = "tableEmployees";
            this.tableEmployees.Size = new System.Drawing.Size(906, 420);
            this.tableEmployees.TabIndex = 3;
            this.tableEmployees.UseCompatibleStateImageBehavior = false;
            this.tableEmployees.SelectedIndexChanged += new System.EventHandler(this.tableEmployees_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 82);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 26);
            this.toolStripMenuItem1.Text = "Desativar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 26);
            this.toolStripMenuItem2.Text = "Editar";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 26);
            this.toolStripMenuItem3.Text = "Gerar Holerite";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // inputFilterName
            // 
            this.inputFilterName.BackColor = System.Drawing.Color.White;
            this.inputFilterName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputFilterName.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.inputFilterName.Location = new System.Drawing.Point(126, 82);
            this.inputFilterName.Margin = new System.Windows.Forms.Padding(0);
            this.inputFilterName.Name = "inputFilterName";
            this.inputFilterName.Size = new System.Drawing.Size(179, 27);
            this.inputFilterName.TabIndex = 24;
            this.inputFilterName.Text = "Filtrar por nome...";
            this.inputFilterName.TextChanged += new System.EventHandler(this.inputLoginPass_TextChanged);
            this.inputFilterName.Enter += new System.EventHandler(this.inputFilterName_Focus);
            this.inputFilterName.Leave += new System.EventHandler(this.inputFilterName_RemoveFocus);
            // 
            // selectFilterPermition
            // 
            this.selectFilterPermition.BackColor = System.Drawing.Color.White;
            this.selectFilterPermition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectFilterPermition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFilterPermition.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.selectFilterPermition.FormattingEnabled = true;
            this.selectFilterPermition.Items.AddRange(new object[] {
            "Todos",
            "Admin",
            "Usuário"});
            this.selectFilterPermition.Location = new System.Drawing.Point(631, 77);
            this.selectFilterPermition.Name = "selectFilterPermition";
            this.selectFilterPermition.Size = new System.Drawing.Size(137, 32);
            this.selectFilterPermition.TabIndex = 34;
            // 
            // selectFilterStatus
            // 
            this.selectFilterStatus.BackColor = System.Drawing.Color.White;
            this.selectFilterStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFilterStatus.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.selectFilterStatus.FormattingEnabled = true;
            this.selectFilterStatus.Items.AddRange(new object[] {
            "Todos",
            "Ativo",
            "Inativo"});
            this.selectFilterStatus.Location = new System.Drawing.Point(859, 77);
            this.selectFilterStatus.Name = "selectFilterStatus";
            this.selectFilterStatus.Size = new System.Drawing.Size(134, 32);
            this.selectFilterStatus.TabIndex = 35;
            this.selectFilterStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // selectFilterRole
            // 
            this.selectFilterRole.BackColor = System.Drawing.Color.White;
            this.selectFilterRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectFilterRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFilterRole.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.selectFilterRole.FormattingEnabled = true;
            this.selectFilterRole.Items.AddRange(new object[] {
            "Todos",
            "Desenvolvedor",
            "Marketing",
            "Designer"});
            this.selectFilterRole.Location = new System.Drawing.Point(391, 77);
            this.selectFilterRole.Name = "selectFilterRole";
            this.selectFilterRole.Size = new System.Drawing.Size(153, 32);
            this.selectFilterRole.TabIndex = 36;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(966, 665);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 41);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Employees
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1348, 934);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.selectFilterRole);
            this.Controls.Add(this.selectFilterStatus);
            this.Controls.Add(this.selectFilterPermition);
            this.Controls.Add(this.inputFilterName);
            this.Controls.Add(this.tableEmployees);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Employees";
            this.Text = "Cadastrar Funcionário";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFilter)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private PictureBox btnFilter;
        private PictureBox btnClearFilter;
        private ListView tableEmployees;
        private TextBox inputFilterName;
        private ComboBox selectFilterPermition;
        private ComboBox selectFilterStatus;
        private ComboBox selectFilterRole;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private PictureBox pictureBox2;
    }
}