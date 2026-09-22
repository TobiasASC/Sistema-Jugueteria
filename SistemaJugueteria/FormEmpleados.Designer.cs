namespace SistemaJugueteria
{
    partial class FormEmpleados
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
            panel3 = new ReaLTaiizor.Controls.Panel();
            label18 = new Label();
            chkEstado = new ReaLTaiizor.Controls.CyberSwitch();
            dgvEmpleados = new DataGridView();
            Rol = new DataGridViewTextBoxColumn();
            dniColum = new DataGridViewTextBoxColumn();
            nombreColum = new DataGridViewTextBoxColumn();
            DirecColum = new DataGridViewTextBoxColumn();
            emailColum = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Modificar = new DataGridViewButtonColumn();
            Eliminar = new DataGridViewButtonColumn();
            label10 = new Label();
            txtNombreBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            button5 = new Button();
            label9 = new Label();
            button4 = new Button();
            txtDniBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            label8 = new Label();
            txtCantidadEmpleados = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            button3 = new Button();
            label7 = new Label();
            cmbRol = new ReaLTaiizor.Controls.CyberComboBox();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            button1 = new Button();
            label1 = new Label();
            txtApellidoEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            label2 = new Label();
            txtEmailEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            label3 = new Label();
            txtDireccionEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            cyberButton2 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton3 = new ReaLTaiizor.Controls.CyberButton();
            panel2 = new ReaLTaiizor.Controls.Panel();
            label19 = new Label();
            txtTelefonoEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            txtNombreEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            txtDniEmpleado = new ReaLTaiizor.Controls.CyberTextBox();
            btnGuardarEmpleado = new ReaLTaiizor.Controls.CyberButton();
            btnCancelarEmpleado = new ReaLTaiizor.Controls.CyberButton();
            panel1 = new ReaLTaiizor.Controls.Panel();
            btnCancelarUsuario = new ReaLTaiizor.Controls.CyberButton();
            btnAgregarUsuario = new ReaLTaiizor.Controls.CyberButton();
            btnLupaDniEmpleado = new Button();
            txtDniEmpleadoBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            label17 = new Label();
            label4 = new Label();
            txtConfirmarContraseña = new ReaLTaiizor.Controls.CyberTextBox();
            label6 = new Label();
            txtContraseña = new ReaLTaiizor.Controls.CyberTextBox();
            label11 = new Label();
            label15 = new Label();
            txtUsuario = new ReaLTaiizor.Controls.CyberTextBox();
            cyberButton4 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton5 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton6 = new ReaLTaiizor.Controls.CyberButton();
            button2 = new Button();
            label16 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(label18);
            panel3.Controls.Add(chkEstado);
            panel3.Controls.Add(dgvEmpleados);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(txtNombreBuscar);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(txtDniBuscar);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtCantidadEmpleados);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label7);
            panel3.EdgeColor = Color.FromArgb(32, 41, 50);
            panel3.Location = new Point(12, 276);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 329);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 57;
            panel3.Text = "panel3";
            panel3.Click += panel3_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(252, 130);
            label18.Name = "label18";
            label18.Size = new Size(109, 15);
            label18.TabIndex = 71;
            label18.Text = "Activos / Inactivos";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            label18.Click += label18_Click;
            // 
            // chkEstado
            // 
            chkEstado.Alpha = 50;
            chkEstado.BackColor = Color.Transparent;
            chkEstado.Background = true;
            chkEstado.Background_WidthPen = 2F;
            chkEstado.BackgroundPen = true;
            chkEstado.Checked = false;
            chkEstado.ColorBackground = Color.White;
            chkEstado.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            chkEstado.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            chkEstado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            chkEstado.ColorBackground_Value_1 = Color.FromArgb(255, 192, 192);
            chkEstado.ColorBackground_Value_2 = Color.FromArgb(100, 208, 232);
            chkEstado.ColorLighting = Color.FromArgb(255, 192, 192);
            chkEstado.ColorPen_1 = Color.FromArgb(37, 52, 68);
            chkEstado.ColorPen_2 = Color.FromArgb(41, 63, 86);
            chkEstado.ColorValue = Color.FromArgb(255, 192, 192);
            chkEstado.CyberSwitchStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            chkEstado.Font = new Font("Arial", 11F);
            chkEstado.ForeColor = Color.FromArgb(245, 245, 245);
            chkEstado.Lighting = false;
            chkEstado.LinearGradient_Background = false;
            chkEstado.LinearGradient_Value = false;
            chkEstado.LinearGradientPen = false;
            chkEstado.Location = new Point(367, 124);
            chkEstado.Name = "chkEstado";
            chkEstado.PenWidth = 10;
            chkEstado.RGB = false;
            chkEstado.Rounding = true;
            chkEstado.RoundingInt = 90;
            chkEstado.Size = new Size(53, 26);
            chkEstado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            chkEstado.TabIndex = 70;
            chkEstado.Tag = "Cyber";
            chkEstado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            chkEstado.Timer_RGB = 300;
            chkEstado.Click += chkEstado_Click;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.AllowUserToResizeColumns = false;
            dgvEmpleados.AllowUserToResizeRows = false;
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.BorderStyle = BorderStyle.None;
            dgvEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { Rol, dniColum, nombreColum, DirecColum, emailColum, Telefono, Modificar, Eliminar });
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.GridColor = SystemColors.ScrollBar;
            dgvEmpleados.Location = new Point(17, 156);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.Size = new Size(868, 121);
            dgvEmpleados.TabIndex = 67;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;
            // 
            // Rol
            // 
            Rol.HeaderText = "Rol";
            Rol.Name = "Rol";
            Rol.ReadOnly = true;
            // 
            // dniColum
            // 
            dniColum.HeaderText = "DNI";
            dniColum.Name = "dniColum";
            dniColum.ReadOnly = true;
            // 
            // nombreColum
            // 
            nombreColum.HeaderText = "Nom y Ape";
            nombreColum.Name = "nombreColum";
            nombreColum.ReadOnly = true;
            // 
            // DirecColum
            // 
            DirecColum.HeaderText = "Dirección";
            DirecColum.Name = "DirecColum";
            DirecColum.ReadOnly = true;
            // 
            // emailColum
            // 
            emailColum.HeaderText = "Email";
            emailColum.Name = "emailColum";
            emailColum.ReadOnly = true;
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Teléfono";
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // Modificar
            // 
            Modificar.HeaderText = "";
            Modificar.Name = "Modificar";
            Modificar.ReadOnly = true;
            Modificar.Resizable = DataGridViewTriState.True;
            Modificar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "";
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            Eliminar.Resizable = DataGridViewTriState.True;
            Eliminar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(246, 61);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 60;
            label10.Text = "Nombre y Apellido";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNombreBuscar
            // 
            txtNombreBuscar.Alpha = 20;
            txtNombreBuscar.BackColor = Color.Transparent;
            txtNombreBuscar.Background_WidthPen = 3F;
            txtNombreBuscar.BackgroundPen = true;
            txtNombreBuscar.ColorBackground = Color.White;
            txtNombreBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNombreBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNombreBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNombreBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNombreBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNombreBuscar.Font = new Font("Arial", 8F);
            txtNombreBuscar.ForeColor = Color.Black;
            txtNombreBuscar.Lighting = false;
            txtNombreBuscar.LinearGradientPen = false;
            txtNombreBuscar.Location = new Point(240, 73);
            txtNombreBuscar.Name = "txtNombreBuscar";
            txtNombreBuscar.PenWidth = 15;
            txtNombreBuscar.RGB = false;
            txtNombreBuscar.Rounding = true;
            txtNombreBuscar.RoundingInt = 60;
            txtNombreBuscar.Size = new Size(358, 32);
            txtNombreBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNombreBuscar.TabIndex = 66;
            txtNombreBuscar.Tag = "Cyber";
            txtNombreBuscar.TextButton = "";
            txtNombreBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNombreBuscar.Timer_RGB = 300;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 227, 227);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.boxicons__search_alt;
            button5.Location = new Point(613, 73);
            button5.Name = "button5";
            button5.Size = new Size(34, 32);
            button5.TabIndex = 61;
            button5.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 61);
            label9.Name = "label9";
            label9.Size = new Size(29, 15);
            label9.TabIndex = 64;
            label9.Text = "DNI";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = Properties.Resources.boxicons__user_filled;
            button4.Location = new Point(14, 19);
            button4.Name = "button4";
            button4.Size = new Size(34, 26);
            button4.TabIndex = 62;
            button4.UseVisualStyleBackColor = true;
            // 
            // txtDniBuscar
            // 
            txtDniBuscar.Alpha = 20;
            txtDniBuscar.BackColor = Color.Transparent;
            txtDniBuscar.Background_WidthPen = 3F;
            txtDniBuscar.BackgroundPen = true;
            txtDniBuscar.ColorBackground = Color.White;
            txtDniBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDniBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDniBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDniBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDniBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDniBuscar.Font = new Font("Arial", 8F);
            txtDniBuscar.ForeColor = Color.Black;
            txtDniBuscar.Lighting = false;
            txtDniBuscar.LinearGradientPen = false;
            txtDniBuscar.Location = new Point(17, 73);
            txtDniBuscar.Name = "txtDniBuscar";
            txtDniBuscar.PenWidth = 15;
            txtDniBuscar.RGB = false;
            txtDniBuscar.Rounding = true;
            txtDniBuscar.RoundingInt = 60;
            txtDniBuscar.Size = new Size(194, 32);
            txtDniBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDniBuscar.TabIndex = 63;
            txtDniBuscar.Tag = "Cyber";
            txtDniBuscar.TextButton = "";
            txtDniBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDniBuscar.Timer_RGB = 300;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(57, 28);
            label8.Name = "label8";
            label8.Size = new Size(152, 20);
            label8.TabIndex = 65;
            label8.Text = "BUSCAR EMPLEADO";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCantidadEmpleados
            // 
            txtCantidadEmpleados.Alpha = 20;
            txtCantidadEmpleados.BackColor = Color.Transparent;
            txtCantidadEmpleados.Background_WidthPen = 3F;
            txtCantidadEmpleados.BackgroundPen = true;
            txtCantidadEmpleados.ColorBackground = Color.White;
            txtCantidadEmpleados.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtCantidadEmpleados.ColorLighting = Color.FromArgb(29, 200, 238);
            txtCantidadEmpleados.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtCantidadEmpleados.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtCantidadEmpleados.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtCantidadEmpleados.Enabled = false;
            txtCantidadEmpleados.Font = new Font("Arial", 8F, FontStyle.Bold);
            txtCantidadEmpleados.ForeColor = Color.Black;
            txtCantidadEmpleados.Lighting = false;
            txtCantidadEmpleados.LinearGradientPen = false;
            txtCantidadEmpleados.Location = new Point(156, 288);
            txtCantidadEmpleados.Name = "txtCantidadEmpleados";
            txtCantidadEmpleados.PenWidth = 15;
            txtCantidadEmpleados.RGB = false;
            txtCantidadEmpleados.Rounding = true;
            txtCantidadEmpleados.RoundingInt = 60;
            txtCantidadEmpleados.Size = new Size(59, 32);
            txtCantidadEmpleados.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtCantidadEmpleados.TabIndex = 59;
            txtCantidadEmpleados.Tag = "Cyber";
            txtCantidadEmpleados.TextButton = "";
            txtCantidadEmpleados.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtCantidadEmpleados.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 300);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 58;
            label5.Text = "Cantidad de Empleados:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = Properties.Resources.ant_design__bars_outlined;
            button3.Location = new Point(11, 124);
            button3.Name = "button3";
            button3.Size = new Size(34, 26);
            button3.TabIndex = 14;
            button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 130);
            label7.Name = "label7";
            label7.Size = new Size(164, 20);
            label7.TabIndex = 15;
            label7.Text = "LISTA DE EMPLEADOS";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbRol
            // 
            cmbRol.BackColor = Color.White;
            cmbRol.ColorArrow = Color.FromArgb(252, 173, 159);
            cmbRol.ColorBackground = Color.White;
            cmbRol.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            cmbRol.ColorItemHover = Color.FromArgb(255, 224, 192);
            cmbRol.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cmbRol.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cmbRol.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cmbRol.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FlatStyle = FlatStyle.Flat;
            cmbRol.Font = new Font("Arial", 11F);
            cmbRol.ForeColor = Color.Black;
            cmbRol.FormattingEnabled = true;
            cmbRol.ItemHeight = 28;
            cmbRol.Location = new Point(223, 94);
            cmbRol.Name = "cmbRol";
            cmbRol.RGB = false;
            cmbRol.Size = new Size(188, 34);
            cmbRol.TabIndex = 68;
            cmbRol.Timer_RGB = 300;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(18, 55);
            label14.Name = "label14";
            label14.Size = new Size(29, 15);
            label14.TabIndex = 15;
            label14.Text = "DNI";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(54, 21);
            label12.Name = "label12";
            label12.Size = new Size(172, 20);
            label12.TabIndex = 19;
            label12.Text = "DATOS DEL EMPLEADO";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(18, 111);
            label13.Name = "label13";
            label13.Size = new Size(63, 15);
            label13.TabIndex = 17;
            label13.Text = "Nombre/s";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.bi__person_fill_add;
            button1.Location = new Point(14, 11);
            button1.Name = "button1";
            button1.Size = new Size(37, 31);
            button1.TabIndex = 17;
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 165);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 21;
            label1.Text = "Apellido/s";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApellidoEmpleado
            // 
            txtApellidoEmpleado.Alpha = 20;
            txtApellidoEmpleado.BackColor = Color.Transparent;
            txtApellidoEmpleado.Background_WidthPen = 3F;
            txtApellidoEmpleado.BackgroundPen = true;
            txtApellidoEmpleado.ColorBackground = Color.White;
            txtApellidoEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtApellidoEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtApellidoEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtApellidoEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtApellidoEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtApellidoEmpleado.Font = new Font("Arial", 8F);
            txtApellidoEmpleado.ForeColor = Color.Black;
            txtApellidoEmpleado.Lighting = false;
            txtApellidoEmpleado.LinearGradientPen = false;
            txtApellidoEmpleado.Location = new Point(15, 180);
            txtApellidoEmpleado.Name = "txtApellidoEmpleado";
            txtApellidoEmpleado.PenWidth = 15;
            txtApellidoEmpleado.RGB = false;
            txtApellidoEmpleado.Rounding = true;
            txtApellidoEmpleado.RoundingInt = 60;
            txtApellidoEmpleado.Size = new Size(182, 32);
            txtApellidoEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtApellidoEmpleado.TabIndex = 22;
            txtApellidoEmpleado.Tag = "Cyber";
            txtApellidoEmpleado.TextButton = "";
            txtApellidoEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtApellidoEmpleado.Timer_RGB = 300;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(223, 109);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 23;
            label2.Text = "Email";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtEmailEmpleado
            // 
            txtEmailEmpleado.Alpha = 20;
            txtEmailEmpleado.BackColor = Color.Transparent;
            txtEmailEmpleado.Background_WidthPen = 3F;
            txtEmailEmpleado.BackgroundPen = true;
            txtEmailEmpleado.ColorBackground = Color.White;
            txtEmailEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtEmailEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtEmailEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtEmailEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtEmailEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtEmailEmpleado.Font = new Font("Arial", 8F);
            txtEmailEmpleado.ForeColor = Color.Black;
            txtEmailEmpleado.Lighting = false;
            txtEmailEmpleado.LinearGradientPen = false;
            txtEmailEmpleado.Location = new Point(220, 124);
            txtEmailEmpleado.Name = "txtEmailEmpleado";
            txtEmailEmpleado.PenWidth = 15;
            txtEmailEmpleado.RGB = false;
            txtEmailEmpleado.Rounding = true;
            txtEmailEmpleado.RoundingInt = 60;
            txtEmailEmpleado.Size = new Size(191, 32);
            txtEmailEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtEmailEmpleado.TabIndex = 24;
            txtEmailEmpleado.Tag = "Cyber";
            txtEmailEmpleado.TextButton = "";
            txtEmailEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtEmailEmpleado.Timer_RGB = 300;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(223, 55);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 25;
            label3.Text = "Dirección";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDireccionEmpleado
            // 
            txtDireccionEmpleado.Alpha = 20;
            txtDireccionEmpleado.BackColor = Color.Transparent;
            txtDireccionEmpleado.Background_WidthPen = 3F;
            txtDireccionEmpleado.BackgroundPen = true;
            txtDireccionEmpleado.ColorBackground = Color.White;
            txtDireccionEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDireccionEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDireccionEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDireccionEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDireccionEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDireccionEmpleado.Font = new Font("Arial", 8F);
            txtDireccionEmpleado.ForeColor = Color.Black;
            txtDireccionEmpleado.Lighting = false;
            txtDireccionEmpleado.LinearGradientPen = false;
            txtDireccionEmpleado.Location = new Point(220, 70);
            txtDireccionEmpleado.Name = "txtDireccionEmpleado";
            txtDireccionEmpleado.PenWidth = 15;
            txtDireccionEmpleado.RGB = false;
            txtDireccionEmpleado.Rounding = true;
            txtDireccionEmpleado.RoundingInt = 60;
            txtDireccionEmpleado.Size = new Size(191, 32);
            txtDireccionEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDireccionEmpleado.TabIndex = 26;
            txtDireccionEmpleado.Tag = "Cyber";
            txtDireccionEmpleado.TextButton = "";
            txtDireccionEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDireccionEmpleado.Timer_RGB = 300;
            // 
            // cyberButton2
            // 
            cyberButton2.Alpha = 20;
            cyberButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton2.BackColor = Color.Transparent;
            cyberButton2.Background = true;
            cyberButton2.Background_WidthPen = 4F;
            cyberButton2.BackgroundPen = true;
            cyberButton2.ColorBackground = Color.FromArgb(0, 192, 0);
            cyberButton2.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton2.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton2.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton2.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton2.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton2.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton2.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton2.Effect_1 = true;
            cyberButton2.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton2.Effect_1_Transparency = 25;
            cyberButton2.Effect_2 = true;
            cyberButton2.Effect_2_ColorBackground = Color.White;
            cyberButton2.Effect_2_Transparency = 20;
            cyberButton2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton2.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton2.Lighting = false;
            cyberButton2.LinearGradient_Background = false;
            cyberButton2.LinearGradientPen = false;
            cyberButton2.Location = new Point(962, 169);
            cyberButton2.Name = "cyberButton2";
            cyberButton2.PenWidth = 15;
            cyberButton2.Rounding = true;
            cyberButton2.RoundingInt = 70;
            cyberButton2.Size = new Size(141, 38);
            cyberButton2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton2.TabIndex = 61;
            cyberButton2.Tag = "Cyber";
            cyberButton2.TextButton = "NUEVO";
            cyberButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton2.Timer_Effect_1 = 5;
            cyberButton2.Timer_RGB = 300;
            // 
            // cyberButton3
            // 
            cyberButton3.Alpha = 20;
            cyberButton3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton3.BackColor = Color.Transparent;
            cyberButton3.Background = true;
            cyberButton3.Background_WidthPen = 4F;
            cyberButton3.BackgroundPen = true;
            cyberButton3.ColorBackground = Color.FromArgb(255, 128, 128);
            cyberButton3.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton3.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton3.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton3.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton3.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton3.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton3.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton3.Effect_1 = true;
            cyberButton3.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton3.Effect_1_Transparency = 25;
            cyberButton3.Effect_2 = true;
            cyberButton3.Effect_2_ColorBackground = Color.White;
            cyberButton3.Effect_2_Transparency = 20;
            cyberButton3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton3.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton3.Lighting = false;
            cyberButton3.LinearGradient_Background = false;
            cyberButton3.LinearGradientPen = false;
            cyberButton3.Location = new Point(962, 261);
            cyberButton3.Name = "cyberButton3";
            cyberButton3.PenWidth = 15;
            cyberButton3.Rounding = true;
            cyberButton3.RoundingInt = 70;
            cyberButton3.Size = new Size(141, 38);
            cyberButton3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton3.TabIndex = 62;
            cyberButton3.Tag = "Cyber";
            cyberButton3.TextButton = "ELIMINAR";
            cyberButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton3.Timer_Effect_1 = 5;
            cyberButton3.Timer_RGB = 300;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(txtTelefonoEmpleado);
            panel2.Controls.Add(txtNombreEmpleado);
            panel2.Controls.Add(txtDniEmpleado);
            panel2.Controls.Add(btnGuardarEmpleado);
            panel2.Controls.Add(btnCancelarEmpleado);
            panel2.Controls.Add(cyberButton3);
            panel2.Controls.Add(cyberButton2);
            panel2.Controls.Add(txtDireccionEmpleado);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtEmailEmpleado);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtApellidoEmpleado);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.EdgeColor = Color.FromArgb(32, 41, 50);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(447, 258);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 56;
            panel2.Text = "panel2";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(223, 165);
            label19.Name = "label19";
            label19.Size = new Size(56, 15);
            label19.TabIndex = 69;
            label19.Text = "Teléfono";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTelefonoEmpleado
            // 
            txtTelefonoEmpleado.Alpha = 20;
            txtTelefonoEmpleado.BackColor = Color.Transparent;
            txtTelefonoEmpleado.Background_WidthPen = 3F;
            txtTelefonoEmpleado.BackgroundPen = true;
            txtTelefonoEmpleado.ColorBackground = Color.White;
            txtTelefonoEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtTelefonoEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtTelefonoEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtTelefonoEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtTelefonoEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtTelefonoEmpleado.Font = new Font("Arial", 8F);
            txtTelefonoEmpleado.ForeColor = Color.Black;
            txtTelefonoEmpleado.Lighting = false;
            txtTelefonoEmpleado.LinearGradientPen = false;
            txtTelefonoEmpleado.Location = new Point(220, 180);
            txtTelefonoEmpleado.Name = "txtTelefonoEmpleado";
            txtTelefonoEmpleado.PenWidth = 15;
            txtTelefonoEmpleado.RGB = false;
            txtTelefonoEmpleado.Rounding = true;
            txtTelefonoEmpleado.RoundingInt = 60;
            txtTelefonoEmpleado.Size = new Size(191, 32);
            txtTelefonoEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtTelefonoEmpleado.TabIndex = 68;
            txtTelefonoEmpleado.Tag = "Cyber";
            txtTelefonoEmpleado.TextButton = "";
            txtTelefonoEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtTelefonoEmpleado.Timer_RGB = 300;
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.Alpha = 20;
            txtNombreEmpleado.BackColor = Color.Transparent;
            txtNombreEmpleado.Background_WidthPen = 3F;
            txtNombreEmpleado.BackgroundPen = true;
            txtNombreEmpleado.ColorBackground = Color.White;
            txtNombreEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNombreEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNombreEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNombreEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNombreEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNombreEmpleado.Font = new Font("Arial", 8F);
            txtNombreEmpleado.ForeColor = Color.Black;
            txtNombreEmpleado.Lighting = false;
            txtNombreEmpleado.LinearGradientPen = false;
            txtNombreEmpleado.Location = new Point(14, 129);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.PenWidth = 15;
            txtNombreEmpleado.RGB = false;
            txtNombreEmpleado.Rounding = true;
            txtNombreEmpleado.RoundingInt = 60;
            txtNombreEmpleado.Size = new Size(183, 32);
            txtNombreEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNombreEmpleado.TabIndex = 67;
            txtNombreEmpleado.Tag = "Cyber";
            txtNombreEmpleado.TextButton = "";
            txtNombreEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNombreEmpleado.Timer_RGB = 300;
            // 
            // txtDniEmpleado
            // 
            txtDniEmpleado.Alpha = 20;
            txtDniEmpleado.BackColor = Color.Transparent;
            txtDniEmpleado.Background_WidthPen = 3F;
            txtDniEmpleado.BackgroundPen = true;
            txtDniEmpleado.ColorBackground = Color.White;
            txtDniEmpleado.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDniEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDniEmpleado.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDniEmpleado.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDniEmpleado.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDniEmpleado.Font = new Font("Arial", 8F);
            txtDniEmpleado.ForeColor = Color.Black;
            txtDniEmpleado.Lighting = false;
            txtDniEmpleado.LinearGradientPen = false;
            txtDniEmpleado.Location = new Point(15, 70);
            txtDniEmpleado.Name = "txtDniEmpleado";
            txtDniEmpleado.PenWidth = 15;
            txtDniEmpleado.RGB = false;
            txtDniEmpleado.Rounding = true;
            txtDniEmpleado.RoundingInt = 60;
            txtDniEmpleado.Size = new Size(182, 32);
            txtDniEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDniEmpleado.TabIndex = 66;
            txtDniEmpleado.Tag = "Cyber";
            txtDniEmpleado.TextButton = "";
            txtDniEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDniEmpleado.Timer_RGB = 300;
            txtDniEmpleado.Load += txtDniEmpleado_Load;
            txtDniEmpleado.KeyPress += txtDniEmpleado_KeyPress;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.Alpha = 20;
            btnGuardarEmpleado.BackColor = Color.Transparent;
            btnGuardarEmpleado.Background = true;
            btnGuardarEmpleado.Background_WidthPen = 4F;
            btnGuardarEmpleado.BackgroundPen = true;
            btnGuardarEmpleado.ColorBackground = Color.FromArgb(128, 128, 255);
            btnGuardarEmpleado.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnGuardarEmpleado.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnGuardarEmpleado.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnGuardarEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            btnGuardarEmpleado.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnGuardarEmpleado.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnGuardarEmpleado.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnGuardarEmpleado.Effect_1 = true;
            btnGuardarEmpleado.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnGuardarEmpleado.Effect_1_Transparency = 25;
            btnGuardarEmpleado.Effect_2 = true;
            btnGuardarEmpleado.Effect_2_ColorBackground = Color.White;
            btnGuardarEmpleado.Effect_2_Transparency = 20;
            btnGuardarEmpleado.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarEmpleado.ForeColor = Color.FromArgb(245, 245, 245);
            btnGuardarEmpleado.Lighting = false;
            btnGuardarEmpleado.LinearGradient_Background = false;
            btnGuardarEmpleado.LinearGradientPen = false;
            btnGuardarEmpleado.Location = new Point(314, 216);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.PenWidth = 15;
            btnGuardarEmpleado.Rounding = true;
            btnGuardarEmpleado.RoundingInt = 70;
            btnGuardarEmpleado.Size = new Size(97, 32);
            btnGuardarEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnGuardarEmpleado.TabIndex = 65;
            btnGuardarEmpleado.Tag = "Cyber";
            btnGuardarEmpleado.TextButton = "GUARDAR";
            btnGuardarEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnGuardarEmpleado.Timer_Effect_1 = 5;
            btnGuardarEmpleado.Timer_RGB = 300;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // btnCancelarEmpleado
            // 
            btnCancelarEmpleado.Alpha = 20;
            btnCancelarEmpleado.BackColor = Color.Transparent;
            btnCancelarEmpleado.Background = true;
            btnCancelarEmpleado.Background_WidthPen = 4F;
            btnCancelarEmpleado.BackgroundPen = true;
            btnCancelarEmpleado.ColorBackground = Color.FromArgb(255, 128, 128);
            btnCancelarEmpleado.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnCancelarEmpleado.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnCancelarEmpleado.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnCancelarEmpleado.ColorLighting = Color.FromArgb(29, 200, 238);
            btnCancelarEmpleado.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnCancelarEmpleado.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnCancelarEmpleado.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnCancelarEmpleado.Effect_1 = true;
            btnCancelarEmpleado.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnCancelarEmpleado.Effect_1_Transparency = 25;
            btnCancelarEmpleado.Effect_2 = true;
            btnCancelarEmpleado.Effect_2_ColorBackground = Color.White;
            btnCancelarEmpleado.Effect_2_Transparency = 20;
            btnCancelarEmpleado.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarEmpleado.ForeColor = Color.FromArgb(245, 245, 245);
            btnCancelarEmpleado.Lighting = false;
            btnCancelarEmpleado.LinearGradient_Background = false;
            btnCancelarEmpleado.LinearGradientPen = false;
            btnCancelarEmpleado.Location = new Point(220, 216);
            btnCancelarEmpleado.Name = "btnCancelarEmpleado";
            btnCancelarEmpleado.PenWidth = 15;
            btnCancelarEmpleado.Rounding = true;
            btnCancelarEmpleado.RoundingInt = 70;
            btnCancelarEmpleado.Size = new Size(96, 32);
            btnCancelarEmpleado.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnCancelarEmpleado.TabIndex = 64;
            btnCancelarEmpleado.Tag = "Cyber";
            btnCancelarEmpleado.TextButton = "LIMPIAR";
            btnCancelarEmpleado.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnCancelarEmpleado.Timer_Effect_1 = 5;
            btnCancelarEmpleado.Timer_RGB = 300;
            btnCancelarEmpleado.Click += btnLimpiarEmpleado_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 227, 227);
            panel1.Controls.Add(cmbRol);
            panel1.Controls.Add(btnCancelarUsuario);
            panel1.Controls.Add(btnAgregarUsuario);
            panel1.Controls.Add(btnLupaDniEmpleado);
            panel1.Controls.Add(txtDniEmpleadoBuscar);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtConfirmarContraseña);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(cyberButton4);
            panel1.Controls.Add(cyberButton5);
            panel1.Controls.Add(cyberButton6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label16);
            panel1.EdgeColor = Color.FromArgb(32, 41, 50);
            panel1.Location = new Point(465, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8);
            panel1.Size = new Size(440, 258);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 63;
            panel1.Text = "panel1";
            panel1.Click += panel1_Click;
            // 
            // btnCancelarUsuario
            // 
            btnCancelarUsuario.Alpha = 20;
            btnCancelarUsuario.BackColor = Color.Transparent;
            btnCancelarUsuario.Background = true;
            btnCancelarUsuario.Background_WidthPen = 4F;
            btnCancelarUsuario.BackgroundPen = true;
            btnCancelarUsuario.ColorBackground = Color.FromArgb(255, 128, 128);
            btnCancelarUsuario.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnCancelarUsuario.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnCancelarUsuario.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnCancelarUsuario.ColorLighting = Color.FromArgb(29, 200, 238);
            btnCancelarUsuario.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnCancelarUsuario.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnCancelarUsuario.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnCancelarUsuario.Effect_1 = true;
            btnCancelarUsuario.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnCancelarUsuario.Effect_1_Transparency = 25;
            btnCancelarUsuario.Effect_2 = true;
            btnCancelarUsuario.Effect_2_ColorBackground = Color.White;
            btnCancelarUsuario.Effect_2_Transparency = 20;
            btnCancelarUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarUsuario.ForeColor = Color.FromArgb(245, 245, 245);
            btnCancelarUsuario.Lighting = false;
            btnCancelarUsuario.LinearGradient_Background = false;
            btnCancelarUsuario.LinearGradientPen = false;
            btnCancelarUsuario.Location = new Point(213, 205);
            btnCancelarUsuario.Name = "btnCancelarUsuario";
            btnCancelarUsuario.PenWidth = 15;
            btnCancelarUsuario.Rounding = true;
            btnCancelarUsuario.RoundingInt = 70;
            btnCancelarUsuario.Size = new Size(96, 32);
            btnCancelarUsuario.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnCancelarUsuario.TabIndex = 66;
            btnCancelarUsuario.Tag = "Cyber";
            btnCancelarUsuario.TextButton = "CANCELAR";
            btnCancelarUsuario.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnCancelarUsuario.Timer_Effect_1 = 5;
            btnCancelarUsuario.Timer_RGB = 300;
            btnCancelarUsuario.Click += btnCancelarUsuario_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Alpha = 20;
            btnAgregarUsuario.BackColor = Color.Transparent;
            btnAgregarUsuario.Background = true;
            btnAgregarUsuario.Background_WidthPen = 4F;
            btnAgregarUsuario.BackgroundPen = true;
            btnAgregarUsuario.ColorBackground = Color.FromArgb(0, 192, 0);
            btnAgregarUsuario.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnAgregarUsuario.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnAgregarUsuario.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnAgregarUsuario.ColorLighting = Color.FromArgb(29, 200, 238);
            btnAgregarUsuario.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnAgregarUsuario.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnAgregarUsuario.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnAgregarUsuario.Effect_1 = true;
            btnAgregarUsuario.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnAgregarUsuario.Effect_1_Transparency = 25;
            btnAgregarUsuario.Effect_2 = true;
            btnAgregarUsuario.Effect_2_ColorBackground = Color.White;
            btnAgregarUsuario.Effect_2_Transparency = 20;
            btnAgregarUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.ForeColor = Color.FromArgb(245, 245, 245);
            btnAgregarUsuario.Lighting = false;
            btnAgregarUsuario.LinearGradient_Background = false;
            btnAgregarUsuario.LinearGradientPen = false;
            btnAgregarUsuario.Location = new Point(110, 205);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.PenWidth = 15;
            btnAgregarUsuario.Rounding = true;
            btnAgregarUsuario.RoundingInt = 70;
            btnAgregarUsuario.Size = new Size(97, 32);
            btnAgregarUsuario.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnAgregarUsuario.TabIndex = 65;
            btnAgregarUsuario.Tag = "Cyber";
            btnAgregarUsuario.TextButton = "AGREGAR";
            btnAgregarUsuario.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnAgregarUsuario.Timer_Effect_1 = 5;
            btnAgregarUsuario.Timer_RGB = 300;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // btnLupaDniEmpleado
            // 
            btnLupaDniEmpleado.BackColor = Color.FromArgb(255, 227, 227);
            btnLupaDniEmpleado.FlatAppearance.BorderSize = 0;
            btnLupaDniEmpleado.FlatStyle = FlatStyle.Flat;
            btnLupaDniEmpleado.Image = Properties.Resources.boxicons__search_alt;
            btnLupaDniEmpleado.Location = new Point(294, 38);
            btnLupaDniEmpleado.Name = "btnLupaDniEmpleado";
            btnLupaDniEmpleado.Size = new Size(34, 32);
            btnLupaDniEmpleado.TabIndex = 68;
            btnLupaDniEmpleado.UseVisualStyleBackColor = false;
            btnLupaDniEmpleado.Click += btnLupaDniEmpleado_Click;
            // 
            // txtDniEmpleadoBuscar
            // 
            txtDniEmpleadoBuscar.Alpha = 20;
            txtDniEmpleadoBuscar.BackColor = Color.Transparent;
            txtDniEmpleadoBuscar.Background_WidthPen = 3F;
            txtDniEmpleadoBuscar.BackgroundPen = true;
            txtDniEmpleadoBuscar.ColorBackground = Color.White;
            txtDniEmpleadoBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDniEmpleadoBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDniEmpleadoBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDniEmpleadoBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDniEmpleadoBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDniEmpleadoBuscar.Font = new Font("Arial", 8F);
            txtDniEmpleadoBuscar.ForeColor = Color.Black;
            txtDniEmpleadoBuscar.Lighting = false;
            txtDniEmpleadoBuscar.LinearGradientPen = false;
            txtDniEmpleadoBuscar.Location = new Point(110, 38);
            txtDniEmpleadoBuscar.Name = "txtDniEmpleadoBuscar";
            txtDniEmpleadoBuscar.PenWidth = 15;
            txtDniEmpleadoBuscar.RGB = false;
            txtDniEmpleadoBuscar.Rounding = true;
            txtDniEmpleadoBuscar.RoundingInt = 60;
            txtDniEmpleadoBuscar.Size = new Size(178, 32);
            txtDniEmpleadoBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDniEmpleadoBuscar.TabIndex = 72;
            txtDniEmpleadoBuscar.Tag = "Cyber";
            txtDniEmpleadoBuscar.TextButton = "";
            txtDniEmpleadoBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDniEmpleadoBuscar.Timer_RGB = 300;
            txtDniEmpleadoBuscar.Load += txtDniEmpleadoBuscar_Load;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(18, 50);
            label17.Name = "label17";
            label17.Size = new Size(86, 15);
            label17.TabIndex = 71;
            label17.Text = "DNI Empleado";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(223, 79);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 69;
            label4.Text = "Rol";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtConfirmarContraseña
            // 
            txtConfirmarContraseña.Alpha = 20;
            txtConfirmarContraseña.BackColor = Color.Transparent;
            txtConfirmarContraseña.Background_WidthPen = 3F;
            txtConfirmarContraseña.BackgroundPen = true;
            txtConfirmarContraseña.ColorBackground = Color.White;
            txtConfirmarContraseña.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtConfirmarContraseña.ColorLighting = Color.FromArgb(29, 200, 238);
            txtConfirmarContraseña.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtConfirmarContraseña.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtConfirmarContraseña.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtConfirmarContraseña.Font = new Font("Arial", 8F);
            txtConfirmarContraseña.ForeColor = Color.Black;
            txtConfirmarContraseña.Lighting = false;
            txtConfirmarContraseña.LinearGradientPen = false;
            txtConfirmarContraseña.Location = new Point(220, 148);
            txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            txtConfirmarContraseña.Password = true;
            txtConfirmarContraseña.PenWidth = 15;
            txtConfirmarContraseña.RGB = false;
            txtConfirmarContraseña.Rounding = true;
            txtConfirmarContraseña.RoundingInt = 60;
            txtConfirmarContraseña.Size = new Size(191, 32);
            txtConfirmarContraseña.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtConfirmarContraseña.TabIndex = 68;
            txtConfirmarContraseña.Tag = "Cyber";
            txtConfirmarContraseña.TextButton = "";
            txtConfirmarContraseña.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtConfirmarContraseña.Timer_RGB = 300;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(223, 133);
            label6.Name = "label6";
            label6.Size = new Size(128, 15);
            label6.TabIndex = 67;
            label6.Text = "Confirmar Contraseña";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtContraseña
            // 
            txtContraseña.Alpha = 20;
            txtContraseña.BackColor = Color.Transparent;
            txtContraseña.Background_WidthPen = 3F;
            txtContraseña.BackgroundPen = true;
            txtContraseña.ColorBackground = Color.White;
            txtContraseña.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtContraseña.ColorLighting = Color.FromArgb(29, 200, 238);
            txtContraseña.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtContraseña.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtContraseña.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtContraseña.Font = new Font("Arial", 8F);
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.Lighting = false;
            txtContraseña.LinearGradientPen = false;
            txtContraseña.Location = new Point(15, 150);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Password = true;
            txtContraseña.PenWidth = 15;
            txtContraseña.RGB = false;
            txtContraseña.Rounding = true;
            txtContraseña.RoundingInt = 60;
            txtContraseña.Size = new Size(183, 32);
            txtContraseña.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtContraseña.TabIndex = 66;
            txtContraseña.Tag = "Cyber";
            txtContraseña.TextButton = "";
            txtContraseña.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtContraseña.Timer_RGB = 300;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(18, 135);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 65;
            label11.Text = "Contraseña";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(18, 79);
            label15.Name = "label15";
            label15.Size = new Size(49, 15);
            label15.TabIndex = 64;
            label15.Text = "Usuario";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            txtUsuario.Alpha = 20;
            txtUsuario.BackColor = Color.Transparent;
            txtUsuario.Background_WidthPen = 3F;
            txtUsuario.BackgroundPen = true;
            txtUsuario.ColorBackground = Color.White;
            txtUsuario.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtUsuario.ColorLighting = Color.FromArgb(29, 200, 238);
            txtUsuario.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtUsuario.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtUsuario.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtUsuario.Font = new Font("Arial", 8F);
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Lighting = false;
            txtUsuario.LinearGradientPen = false;
            txtUsuario.Location = new Point(15, 94);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PenWidth = 15;
            txtUsuario.RGB = false;
            txtUsuario.Rounding = true;
            txtUsuario.RoundingInt = 60;
            txtUsuario.Size = new Size(182, 32);
            txtUsuario.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtUsuario.TabIndex = 63;
            txtUsuario.Tag = "Cyber";
            txtUsuario.TextButton = "";
            txtUsuario.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtUsuario.Timer_RGB = 300;
            // 
            // cyberButton4
            // 
            cyberButton4.Alpha = 20;
            cyberButton4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton4.BackColor = Color.Transparent;
            cyberButton4.Background = true;
            cyberButton4.Background_WidthPen = 4F;
            cyberButton4.BackgroundPen = true;
            cyberButton4.ColorBackground = Color.FromArgb(255, 128, 128);
            cyberButton4.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton4.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton4.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton4.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton4.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton4.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton4.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton4.Effect_1 = true;
            cyberButton4.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton4.Effect_1_Transparency = 25;
            cyberButton4.Effect_2 = true;
            cyberButton4.Effect_2_ColorBackground = Color.White;
            cyberButton4.Effect_2_Transparency = 20;
            cyberButton4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton4.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton4.Lighting = false;
            cyberButton4.LinearGradient_Background = false;
            cyberButton4.LinearGradientPen = false;
            cyberButton4.Location = new Point(1197, 379);
            cyberButton4.Name = "cyberButton4";
            cyberButton4.PenWidth = 15;
            cyberButton4.Rounding = true;
            cyberButton4.RoundingInt = 70;
            cyberButton4.Size = new Size(141, 38);
            cyberButton4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton4.TabIndex = 62;
            cyberButton4.Tag = "Cyber";
            cyberButton4.TextButton = "ELIMINAR";
            cyberButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton4.Timer_Effect_1 = 5;
            cyberButton4.Timer_RGB = 300;
            // 
            // cyberButton5
            // 
            cyberButton5.Alpha = 20;
            cyberButton5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton5.BackColor = Color.Transparent;
            cyberButton5.Background = true;
            cyberButton5.Background_WidthPen = 4F;
            cyberButton5.BackgroundPen = true;
            cyberButton5.ColorBackground = Color.FromArgb(128, 128, 255);
            cyberButton5.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton5.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton5.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton5.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton5.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton5.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton5.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton5.Effect_1 = true;
            cyberButton5.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton5.Effect_1_Transparency = 25;
            cyberButton5.Effect_2 = true;
            cyberButton5.Effect_2_ColorBackground = Color.White;
            cyberButton5.Effect_2_Transparency = 20;
            cyberButton5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton5.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton5.Lighting = false;
            cyberButton5.LinearGradient_Background = false;
            cyberButton5.LinearGradientPen = false;
            cyberButton5.Location = new Point(1197, 335);
            cyberButton5.Name = "cyberButton5";
            cyberButton5.PenWidth = 15;
            cyberButton5.Rounding = true;
            cyberButton5.RoundingInt = 70;
            cyberButton5.Size = new Size(141, 38);
            cyberButton5.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton5.TabIndex = 62;
            cyberButton5.Tag = "Cyber";
            cyberButton5.TextButton = "GUARDAR";
            cyberButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton5.Timer_Effect_1 = 5;
            cyberButton5.Timer_RGB = 300;
            // 
            // cyberButton6
            // 
            cyberButton6.Alpha = 20;
            cyberButton6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton6.BackColor = Color.Transparent;
            cyberButton6.Background = true;
            cyberButton6.Background_WidthPen = 4F;
            cyberButton6.BackgroundPen = true;
            cyberButton6.ColorBackground = Color.FromArgb(0, 192, 0);
            cyberButton6.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton6.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton6.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton6.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton6.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton6.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton6.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton6.Effect_1 = true;
            cyberButton6.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton6.Effect_1_Transparency = 25;
            cyberButton6.Effect_2 = true;
            cyberButton6.Effect_2_ColorBackground = Color.White;
            cyberButton6.Effect_2_Transparency = 20;
            cyberButton6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton6.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton6.Lighting = false;
            cyberButton6.LinearGradient_Background = false;
            cyberButton6.LinearGradientPen = false;
            cyberButton6.Location = new Point(1197, 287);
            cyberButton6.Name = "cyberButton6";
            cyberButton6.PenWidth = 15;
            cyberButton6.Rounding = true;
            cyberButton6.RoundingInt = 70;
            cyberButton6.Size = new Size(141, 38);
            cyberButton6.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton6.TabIndex = 61;
            cyberButton6.Tag = "Cyber";
            cyberButton6.TextButton = "NUEVO";
            cyberButton6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton6.Timer_Effect_1 = 5;
            cyberButton6.Timer_RGB = 300;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.bi__person_fill_add;
            button2.Location = new Point(10, 5);
            button2.Name = "button2";
            button2.Size = new Size(37, 31);
            button2.TabIndex = 17;
            button2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(53, 15);
            label16.Name = "label16";
            label16.Size = new Size(151, 20);
            label16.TabIndex = 19;
            label16.Text = "DATOS DE USUARIO";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 606);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "FormEmpleados";
            Text = "FormEmpleados";
            Load += FormEmpleados_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.Panel panel3;
        private Label label10;
        private ReaLTaiizor.Controls.CyberTextBox txtNombreBuscar;
        private Button button5;
        private Label label9;
        private Button button4;
        private ReaLTaiizor.Controls.CyberTextBox txtDniBuscar;
        private Label label8;
        private ReaLTaiizor.Controls.CyberTextBox txtCantidadEmpleados;
        private Label label5;
        private Button button3;
        private Label label7;
        private DataGridView dgvEmpleados;
        private Label label14;
        private Label label12;
        private Label label13;
        private Button button1;
        private Label label1;
        private ReaLTaiizor.Controls.CyberTextBox txtApellidoEmpleado;
        private Label label2;
        private ReaLTaiizor.Controls.CyberTextBox txtEmailEmpleado;
        private Label label3;
        private ReaLTaiizor.Controls.CyberTextBox txtDireccionEmpleado;
        private ReaLTaiizor.Controls.CyberButton cyberButton2;
        private ReaLTaiizor.Controls.CyberButton cyberButton3;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.CyberButton cyberButton4;
        private ReaLTaiizor.Controls.CyberButton cyberButton5;
        private ReaLTaiizor.Controls.CyberButton cyberButton6;
        private Button button2;
        private Label label16;
        private Button btnLupaDniEmpleado;
        private ReaLTaiizor.Controls.CyberTextBox txtDniEmpleadoBuscar;
        private Label label17;
        private Label label4;
        private ReaLTaiizor.Controls.CyberTextBox txtConfirmarContraseña;
        private Label label6;
        private ReaLTaiizor.Controls.CyberTextBox txtContraseña;
        private Label label11;
        private Label label15;
        private ReaLTaiizor.Controls.CyberTextBox txtUsuario;
        private ReaLTaiizor.Controls.CyberButton btnCancelarEmpleado;
        private ReaLTaiizor.Controls.CyberButton btnCancelarUsuario;
        private ReaLTaiizor.Controls.CyberButton btnAgregarUsuario;
        private ReaLTaiizor.Controls.CyberButton btnGuardarEmpleado;
        private ReaLTaiizor.Controls.CyberComboBox cmbRol;
        private ReaLTaiizor.Controls.CyberTextBox txtDniEmpleado;
        private ReaLTaiizor.Controls.CyberTextBox txtNombreEmpleado;
        private Label label18;
        private ReaLTaiizor.Controls.CyberSwitch chkEstado;
        private Label label19;
        private ReaLTaiizor.Controls.CyberTextBox txtTelefonoEmpleado;
        private DataGridViewTextBoxColumn Rol;
        private DataGridViewTextBoxColumn dniColum;
        private DataGridViewTextBoxColumn nombreColum;
        private DataGridViewTextBoxColumn DirecColum;
        private DataGridViewTextBoxColumn emailColum;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewButtonColumn Modificar;
        private DataGridViewButtonColumn Eliminar;
    }
}