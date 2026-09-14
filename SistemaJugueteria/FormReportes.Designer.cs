namespace SistemaJugueteria
{
    partial class FormReportes
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            hopeTextBox3 = new ReaLTaiizor.Controls.HopeTextBox();
            label3 = new Label();
            hopeTextBox1 = new ReaLTaiizor.Controls.HopeTextBox();
            label2 = new Label();
            label1 = new Label();
            hopeTextBox2 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox4 = new ReaLTaiizor.Controls.HopeTextBox();
            label4 = new Label();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            descripcionProducto = new DataGridViewTextBoxColumn();
            precioProducto = new DataGridViewTextBoxColumn();
            stockProducto = new DataGridViewTextBoxColumn();
            categoriaProducto = new DataGridViewTextBoxColumn();
            eliminarProducto = new DataGridViewButtonColumn();
            hopeButton2 = new ReaLTaiizor.Controls.HopeButton();
            hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // hopeTextBox3
            // 
            hopeTextBox3.BackColor = Color.White;
            hopeTextBox3.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox3.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox3.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox3.Font = new Font("Segoe UI", 12F);
            hopeTextBox3.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox3.Hint = "Filtrar Por...";
            hopeTextBox3.Location = new Point(472, 73);
            hopeTextBox3.MaxLength = 32767;
            hopeTextBox3.Multiline = false;
            hopeTextBox3.Name = "hopeTextBox3";
            hopeTextBox3.PasswordChar = '\0';
            hopeTextBox3.ScrollBars = ScrollBars.None;
            hopeTextBox3.SelectedText = "";
            hopeTextBox3.SelectionLength = 0;
            hopeTextBox3.SelectionStart = 0;
            hopeTextBox3.Size = new Size(211, 38);
            hopeTextBox3.TabIndex = 33;
            hopeTextBox3.TabStop = false;
            hopeTextBox3.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(434, 38);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 32;
            label3.Click += label3_Click;
            // 
            // hopeTextBox1
            // 
            hopeTextBox1.BackColor = Color.White;
            hopeTextBox1.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox1.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox1.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox1.Font = new Font("Segoe UI", 12F);
            hopeTextBox1.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox1.Hint = "";
            hopeTextBox1.Location = new Point(31, 73);
            hopeTextBox1.MaxLength = 32767;
            hopeTextBox1.Multiline = false;
            hopeTextBox1.Name = "hopeTextBox1";
            hopeTextBox1.PasswordChar = '\0';
            hopeTextBox1.ScrollBars = ScrollBars.None;
            hopeTextBox1.SelectedText = "";
            hopeTextBox1.SelectionLength = 0;
            hopeTextBox1.SelectionStart = 0;
            hopeTextBox1.Size = new Size(356, 38);
            hopeTextBox1.TabIndex = 31;
            hopeTextBox1.TabStop = false;
            hopeTextBox1.UseSystemPasswordChar = false;
            hopeTextBox1.Click += hopeTextBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 41);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 30;
            label2.Text = "Tipo de Reporte";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 20);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 29;
            // 
            // hopeTextBox2
            // 
            hopeTextBox2.BackColor = Color.White;
            hopeTextBox2.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox2.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox2.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox2.Font = new Font("Segoe UI", 12F);
            hopeTextBox2.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox2.Hint = "";
            hopeTextBox2.Location = new Point(31, 151);
            hopeTextBox2.MaxLength = 32767;
            hopeTextBox2.Multiline = false;
            hopeTextBox2.Name = "hopeTextBox2";
            hopeTextBox2.PasswordChar = '\0';
            hopeTextBox2.ScrollBars = ScrollBars.None;
            hopeTextBox2.SelectedText = "";
            hopeTextBox2.SelectionLength = 0;
            hopeTextBox2.SelectionStart = 0;
            hopeTextBox2.Size = new Size(155, 38);
            hopeTextBox2.TabIndex = 39;
            hopeTextBox2.TabStop = false;
            hopeTextBox2.UseSystemPasswordChar = false;
            // 
            // hopeTextBox4
            // 
            hopeTextBox4.BackColor = Color.White;
            hopeTextBox4.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox4.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox4.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox4.Font = new Font("Segoe UI", 12F);
            hopeTextBox4.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox4.Hint = "";
            hopeTextBox4.Location = new Point(232, 151);
            hopeTextBox4.MaxLength = 32767;
            hopeTextBox4.Multiline = false;
            hopeTextBox4.Name = "hopeTextBox4";
            hopeTextBox4.PasswordChar = '\0';
            hopeTextBox4.ScrollBars = ScrollBars.None;
            hopeTextBox4.SelectedText = "";
            hopeTextBox4.SelectionLength = 0;
            hopeTextBox4.SelectionStart = 0;
            hopeTextBox4.Size = new Size(155, 38);
            hopeTextBox4.TabIndex = 40;
            hopeTextBox4.TabStop = false;
            hopeTextBox4.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 128);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 41;
            label4.Text = "Desde...";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(232, 128);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 42;
            label5.Text = "Hasta...";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Silver;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { descripcionProducto, precioProducto, stockProducto, categoriaProducto, eliminarProducto });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(31, 229);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(716, 108);
            dataGridView1.TabIndex = 43;
            // 
            // descripcionProducto
            // 
            descripcionProducto.HeaderText = "";
            descripcionProducto.Name = "descripcionProducto";
            // 
            // precioProducto
            // 
            precioProducto.HeaderText = "";
            precioProducto.Name = "precioProducto";
            // 
            // stockProducto
            // 
            stockProducto.HeaderText = "";
            stockProducto.Name = "stockProducto";
            // 
            // categoriaProducto
            // 
            categoriaProducto.HeaderText = "";
            categoriaProducto.Name = "categoriaProducto";
            // 
            // eliminarProducto
            // 
            eliminarProducto.HeaderText = "";
            eliminarProducto.Name = "eliminarProducto";
            // 
            // hopeButton2
            // 
            hopeButton2.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton2.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton2.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeButton2.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton2.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton2.Location = new Point(595, 151);
            hopeButton2.Name = "hopeButton2";
            hopeButton2.PrimaryColor = Color.FromArgb(255, 116, 108);
            hopeButton2.Size = new Size(128, 38);
            hopeButton2.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton2.TabIndex = 45;
            hopeButton2.Text = "Generar PDF";
            hopeButton2.TextColor = Color.White;
            hopeButton2.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // hopeButton1
            // 
            hopeButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton1.Location = new Point(457, 151);
            hopeButton1.Name = "hopeButton1";
            hopeButton1.PrimaryColor = Color.FromArgb(128, 239, 128);
            hopeButton1.Size = new Size(132, 38);
            hopeButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton1.TabIndex = 44;
            hopeButton1.Text = "Generar Reporte";
            hopeButton1.TextColor = Color.White;
            hopeButton1.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(800, 450);
            Controls.Add(hopeButton2);
            Controls.Add(hopeButton1);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(hopeTextBox4);
            Controls.Add(hopeTextBox2);
            Controls.Add(hopeTextBox3);
            Controls.Add(label3);
            Controls.Add(hopeTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormReportes";
            Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox3;
        private Label label3;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private Label label2;
        private Label label1;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox2;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox4;
        private Label label4;
        private Label label5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn descripcionProducto;
        private DataGridViewTextBoxColumn precioProducto;
        private DataGridViewTextBoxColumn stockProducto;
        private DataGridViewTextBoxColumn categoriaProducto;
        private DataGridViewButtonColumn eliminarProducto;
        private ReaLTaiizor.Controls.HopeButton hopeButton2;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
    }
}