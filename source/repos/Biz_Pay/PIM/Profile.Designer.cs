namespace PIM
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.tablePaycheck = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameValue = new System.Windows.Forms.Label();
            this.emailValue = new System.Windows.Forms.Label();
            this.roleValue = new System.Windows.Forms.Label();
            this.phoneValue = new System.Windows.Forms.Label();
            this.cpfValue = new System.Windows.Forms.Label();
            this.permitionValue = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.PictureBox();
            this.selectDate = new System.Windows.Forms.ComboBox();
            this.selectSalary = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePaycheck
            // 
            this.tablePaycheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablePaycheck.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tablePaycheck.HideSelection = false;
            this.tablePaycheck.Location = new System.Drawing.Point(118, 306);
            this.tablePaycheck.Name = "tablePaycheck";
            this.tablePaycheck.Size = new System.Drawing.Size(805, 422);
            this.tablePaycheck.TabIndex = 22;
            this.tablePaycheck.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(54, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1231, 749);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // nameValue
            // 
            this.nameValue.AutoSize = true;
            this.nameValue.BackColor = System.Drawing.Color.White;
            this.nameValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nameValue.Location = new System.Drawing.Point(167, 124);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(54, 24);
            this.nameValue.TabIndex = 26;
            this.nameValue.Text = "Vazio";
            // 
            // emailValue
            // 
            this.emailValue.AutoSize = true;
            this.emailValue.BackColor = System.Drawing.Color.White;
            this.emailValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.emailValue.Location = new System.Drawing.Point(167, 223);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(54, 24);
            this.emailValue.TabIndex = 27;
            this.emailValue.Text = "Vazio";
            // 
            // roleValue
            // 
            this.roleValue.AutoSize = true;
            this.roleValue.BackColor = System.Drawing.Color.White;
            this.roleValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.roleValue.Location = new System.Drawing.Point(720, 126);
            this.roleValue.Name = "roleValue";
            this.roleValue.Size = new System.Drawing.Size(54, 24);
            this.roleValue.TabIndex = 28;
            this.roleValue.Text = "Vazio";
            // 
            // phoneValue
            // 
            this.phoneValue.AutoSize = true;
            this.phoneValue.BackColor = System.Drawing.Color.White;
            this.phoneValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.phoneValue.Location = new System.Drawing.Point(720, 223);
            this.phoneValue.Name = "phoneValue";
            this.phoneValue.Size = new System.Drawing.Size(54, 24);
            this.phoneValue.TabIndex = 29;
            this.phoneValue.Text = "Vazio";
            // 
            // cpfValue
            // 
            this.cpfValue.AutoSize = true;
            this.cpfValue.BackColor = System.Drawing.Color.White;
            this.cpfValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cpfValue.Location = new System.Drawing.Point(1005, 126);
            this.cpfValue.Name = "cpfValue";
            this.cpfValue.Size = new System.Drawing.Size(54, 24);
            this.cpfValue.TabIndex = 30;
            this.cpfValue.Text = "Vazio";
            // 
            // permitionValue
            // 
            this.permitionValue.AutoSize = true;
            this.permitionValue.BackColor = System.Drawing.Color.White;
            this.permitionValue.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.permitionValue.Location = new System.Drawing.Point(1005, 223);
            this.permitionValue.Name = "permitionValue";
            this.permitionValue.Size = new System.Drawing.Size(54, 24);
            this.permitionValue.TabIndex = 31;
            this.permitionValue.Text = "Vazio";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(949, 599);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(270, 92);
            this.btnFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFilter.TabIndex = 32;
            this.btnFilter.TabStop = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // selectDate
            // 
            this.selectDate.BackColor = System.Drawing.Color.White;
            this.selectDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDate.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Items.AddRange(new object[] {
            "Todos",
            "Mais recentes",
            "Mais antigos"});
            this.selectDate.Location = new System.Drawing.Point(1002, 408);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(186, 32);
            this.selectDate.TabIndex = 33;
            this.selectDate.SelectedIndexChanged += new System.EventHandler(this.selectDate_SelectedIndexChanged);
            // 
            // selectSalary
            // 
            this.selectSalary.BackColor = System.Drawing.Color.White;
            this.selectSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectSalary.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.selectSalary.FormattingEnabled = true;
            this.selectSalary.Items.AddRange(new object[] {
            "Todos",
            "Maior Salário",
            "Menor Salário"});
            this.selectSalary.Location = new System.Drawing.Point(1002, 518);
            this.selectSalary.Name = "selectSalary";
            this.selectSalary.Size = new System.Drawing.Size(186, 32);
            this.selectSalary.TabIndex = 34;
            this.selectSalary.SelectedIndexChanged += new System.EventHandler(this.selectSalary_SelectedIndexChanged);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1352, 852);
            this.Controls.Add(this.selectSalary);
            this.Controls.Add(this.selectDate);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.permitionValue);
            this.Controls.Add(this.cpfValue);
            this.Controls.Add(this.phoneValue);
            this.Controls.Add(this.roleValue);
            this.Controls.Add(this.emailValue);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.tablePaycheck);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView tablePaycheck;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label nameValue;
        private System.Windows.Forms.Label emailValue;
        private System.Windows.Forms.Label roleValue;
        private System.Windows.Forms.Label phoneValue;
        private System.Windows.Forms.Label cpfValue;
        private System.Windows.Forms.Label permitionValue;
        private System.Windows.Forms.PictureBox btnFilter;
        private System.Windows.Forms.ComboBox selectDate;
        private System.Windows.Forms.ComboBox selectSalary;
    }
}