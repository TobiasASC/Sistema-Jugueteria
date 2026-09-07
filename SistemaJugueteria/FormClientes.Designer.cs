namespace SistemaJugueteria
{
    partial class FormClientes
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            hopeTextBox1 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox2 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox3 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox4 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox5 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox6 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox7 = new ReaLTaiizor.Controls.HopeTextBox();
            dataGridView1 = new DataGridView();
            dniCliente = new DataGridViewTextBoxColumn();
            nombreYApellidoCliente = new DataGridViewTextBoxColumn();
            correoCliente = new DataGridViewTextBoxColumn();
            direccionCliente = new DataGridViewTextBoxColumn();
            puntosCliente = new DataGridViewTextBoxColumn();
            modificarCliente = new DataGridViewButtonColumn();
            eliminarProducto = new DataGridViewButtonColumn();
            hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            hopeButton2 = new ReaLTaiizor.Controls.HopeButton();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 25);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 1;
            label1.Text = "NUEVO CLIENTE";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 64);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 3;
            label2.Text = "D.N.I";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 108);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 4;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 152);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 5;
            label4.Text = "Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(364, 64);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 6;
            label5.Text = "Correo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(364, 108);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 7;
            label6.Text = "Dirección";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(28, 199);
            label7.Name = "label7";
            label7.Size = new Size(139, 21);
            label7.TabIndex = 8;
            label7.Text = "BUSCAR CLIENTE";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(28, 231);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 18;
            label8.Text = "Cliente";
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
            hopeTextBox1.Location = new Point(101, 55);
            hopeTextBox1.MaxLength = 32767;
            hopeTextBox1.Multiline = false;
            hopeTextBox1.Name = "hopeTextBox1";
            hopeTextBox1.PasswordChar = '\0';
            hopeTextBox1.ScrollBars = ScrollBars.None;
            hopeTextBox1.SelectedText = "";
            hopeTextBox1.SelectionLength = 0;
            hopeTextBox1.SelectionStart = 0;
            hopeTextBox1.Size = new Size(152, 38);
            hopeTextBox1.TabIndex = 19;
            hopeTextBox1.TabStop = false;
            hopeTextBox1.UseSystemPasswordChar = false;
            hopeTextBox1.Click += hopeTextBox1_Click;
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
            hopeTextBox2.Location = new Point(101, 99);
            hopeTextBox2.MaxLength = 32767;
            hopeTextBox2.Multiline = false;
            hopeTextBox2.Name = "hopeTextBox2";
            hopeTextBox2.PasswordChar = '\0';
            hopeTextBox2.ScrollBars = ScrollBars.None;
            hopeTextBox2.SelectedText = "";
            hopeTextBox2.SelectionLength = 0;
            hopeTextBox2.SelectionStart = 0;
            hopeTextBox2.Size = new Size(152, 38);
            hopeTextBox2.TabIndex = 20;
            hopeTextBox2.TabStop = false;
            hopeTextBox2.UseSystemPasswordChar = false;
            // 
            // hopeTextBox3
            // 
            hopeTextBox3.BackColor = Color.White;
            hopeTextBox3.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox3.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox3.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox3.Font = new Font("Segoe UI", 12F);
            hopeTextBox3.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox3.Hint = "";
            hopeTextBox3.Location = new Point(101, 143);
            hopeTextBox3.MaxLength = 32767;
            hopeTextBox3.Multiline = false;
            hopeTextBox3.Name = "hopeTextBox3";
            hopeTextBox3.PasswordChar = '\0';
            hopeTextBox3.ScrollBars = ScrollBars.None;
            hopeTextBox3.SelectedText = "";
            hopeTextBox3.SelectionLength = 0;
            hopeTextBox3.SelectionStart = 0;
            hopeTextBox3.Size = new Size(152, 38);
            hopeTextBox3.TabIndex = 21;
            hopeTextBox3.TabStop = false;
            hopeTextBox3.UseSystemPasswordChar = false;
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
            hopeTextBox4.Location = new Point(444, 55);
            hopeTextBox4.MaxLength = 32767;
            hopeTextBox4.Multiline = false;
            hopeTextBox4.Name = "hopeTextBox4";
            hopeTextBox4.PasswordChar = '\0';
            hopeTextBox4.ScrollBars = ScrollBars.None;
            hopeTextBox4.SelectedText = "";
            hopeTextBox4.SelectionLength = 0;
            hopeTextBox4.SelectionStart = 0;
            hopeTextBox4.Size = new Size(207, 38);
            hopeTextBox4.TabIndex = 22;
            hopeTextBox4.TabStop = false;
            hopeTextBox4.UseSystemPasswordChar = false;
            // 
            // hopeTextBox5
            // 
            hopeTextBox5.BackColor = Color.White;
            hopeTextBox5.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox5.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox5.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox5.Font = new Font("Segoe UI", 12F);
            hopeTextBox5.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox5.Hint = "";
            hopeTextBox5.Location = new Point(444, 99);
            hopeTextBox5.MaxLength = 32767;
            hopeTextBox5.Multiline = false;
            hopeTextBox5.Name = "hopeTextBox5";
            hopeTextBox5.PasswordChar = '\0';
            hopeTextBox5.ScrollBars = ScrollBars.None;
            hopeTextBox5.SelectedText = "";
            hopeTextBox5.SelectionLength = 0;
            hopeTextBox5.SelectionStart = 0;
            hopeTextBox5.Size = new Size(207, 38);
            hopeTextBox5.TabIndex = 23;
            hopeTextBox5.TabStop = false;
            hopeTextBox5.UseSystemPasswordChar = false;
            // 
            // hopeTextBox6
            // 
            hopeTextBox6.BackColor = Color.White;
            hopeTextBox6.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox6.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox6.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox6.Font = new Font("Segoe UI", 12F);
            hopeTextBox6.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox6.Hint = "D.N.I";
            hopeTextBox6.Location = new Point(28, 254);
            hopeTextBox6.MaxLength = 32767;
            hopeTextBox6.Multiline = false;
            hopeTextBox6.Name = "hopeTextBox6";
            hopeTextBox6.PasswordChar = '\0';
            hopeTextBox6.ScrollBars = ScrollBars.None;
            hopeTextBox6.SelectedText = "";
            hopeTextBox6.SelectionLength = 0;
            hopeTextBox6.SelectionStart = 0;
            hopeTextBox6.Size = new Size(166, 38);
            hopeTextBox6.TabIndex = 24;
            hopeTextBox6.TabStop = false;
            hopeTextBox6.UseSystemPasswordChar = false;
            // 
            // hopeTextBox7
            // 
            hopeTextBox7.BackColor = Color.White;
            hopeTextBox7.BaseColor = Color.FromArgb(252, 173, 159);
            hopeTextBox7.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox7.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox7.Font = new Font("Segoe UI", 12F);
            hopeTextBox7.ForeColor = Color.FromArgb(48, 49, 51);
            hopeTextBox7.Hint = "Nombre";
            hopeTextBox7.Location = new Point(216, 254);
            hopeTextBox7.MaxLength = 32767;
            hopeTextBox7.Multiline = false;
            hopeTextBox7.Name = "hopeTextBox7";
            hopeTextBox7.PasswordChar = '\0';
            hopeTextBox7.ScrollBars = ScrollBars.None;
            hopeTextBox7.SelectedText = "";
            hopeTextBox7.SelectionLength = 0;
            hopeTextBox7.SelectionStart = 0;
            hopeTextBox7.Size = new Size(313, 38);
            hopeTextBox7.TabIndex = 25;
            hopeTextBox7.TabStop = false;
            hopeTextBox7.UseSystemPasswordChar = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dniCliente, nombreYApellidoCliente, correoCliente, direccionCliente, puntosCliente, modificarCliente, eliminarProducto });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(28, 307);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(710, 131);
            dataGridView1.TabIndex = 26;
            // 
            // dniCliente
            // 
            dniCliente.HeaderText = "DNI";
            dniCliente.Name = "dniCliente";
            // 
            // nombreYApellidoCliente
            // 
            nombreYApellidoCliente.HeaderText = "Nombre y Apellido";
            nombreYApellidoCliente.Name = "nombreYApellidoCliente";
            // 
            // correoCliente
            // 
            correoCliente.HeaderText = "Correo";
            correoCliente.Name = "correoCliente";
            // 
            // direccionCliente
            // 
            direccionCliente.HeaderText = "Dirección";
            direccionCliente.Name = "direccionCliente";
            // 
            // puntosCliente
            // 
            puntosCliente.HeaderText = "Puntos";
            puntosCliente.Name = "puntosCliente";
            // 
            // modificarCliente
            // 
            modificarCliente.HeaderText = "Modificar";
            modificarCliente.Name = "modificarCliente";
            // 
            // eliminarProducto
            // 
            eliminarProducto.HeaderText = "Eliminar";
            eliminarProducto.Name = "eliminarProducto";
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
            hopeButton1.Location = new Point(444, 142);
            hopeButton1.Name = "hopeButton1";
            hopeButton1.PrimaryColor = Color.FromArgb(128, 239, 128);
            hopeButton1.Size = new Size(86, 30);
            hopeButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton1.TabIndex = 27;
            hopeButton1.Text = "Confirmar";
            hopeButton1.TextColor = Color.White;
            hopeButton1.WarningColor = Color.FromArgb(230, 162, 60);
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
            hopeButton2.Location = new Point(571, 142);
            hopeButton2.Name = "hopeButton2";
            hopeButton2.PrimaryColor = Color.FromArgb(255, 116, 108);
            hopeButton2.Size = new Size(80, 30);
            hopeButton2.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton2.TabIndex = 28;
            hopeButton2.Text = "Cancelar";
            hopeButton2.TextColor = Color.White;
            hopeButton2.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // button1
            // 
            button1.Image = Properties.Resources.icono_lupa;
            button1.Location = new Point(535, 254);
            button1.Name = "button1";
            button1.Size = new Size(37, 38);
            button1.TabIndex = 29;
            button1.UseVisualStyleBackColor = true;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(hopeButton2);
            Controls.Add(hopeButton1);
            Controls.Add(dataGridView1);
            Controls.Add(hopeTextBox7);
            Controls.Add(hopeTextBox6);
            Controls.Add(hopeTextBox5);
            Controls.Add(hopeTextBox4);
            Controls.Add(hopeTextBox3);
            Controls.Add(hopeTextBox2);
            Controls.Add(hopeTextBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormClientes";
            Text = "FormClientes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox2;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox3;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox4;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox5;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox6;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dniCliente;
        private DataGridViewTextBoxColumn nombreYApellidoCliente;
        private DataGridViewTextBoxColumn correoCliente;
        private DataGridViewTextBoxColumn direccionCliente;
        private DataGridViewTextBoxColumn puntosCliente;
        private DataGridViewButtonColumn modificarCliente;
        private DataGridViewButtonColumn eliminarProducto;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private ReaLTaiizor.Controls.HopeButton hopeButton2;
        private Button button1;
    }
}