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
            txtDniCliente = new ReaLTaiizor.Controls.CyberTextBox();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            button1 = new Button();
            txtNombreCliente = new ReaLTaiizor.Controls.CyberTextBox();
            label1 = new Label();
            txtApellidoCliente = new ReaLTaiizor.Controls.CyberTextBox();
            label2 = new Label();
            txtEmailCliente = new ReaLTaiizor.Controls.CyberTextBox();
            label3 = new Label();
            txtDireccionCliente = new ReaLTaiizor.Controls.CyberTextBox();
            label4 = new Label();
            cyberTextBox5 = new ReaLTaiizor.Controls.CyberTextBox();
            btnNuevo = new ReaLTaiizor.Controls.CyberButton();
            btnGuardar = new ReaLTaiizor.Controls.CyberButton();
            btnEliminar = new ReaLTaiizor.Controls.CyberButton();
            dgvClientes = new DataGridView();
            dniColum = new DataGridViewTextBoxColumn();
            nombreColum = new DataGridViewTextBoxColumn();
            DirecColum = new DataGridViewTextBoxColumn();
            emailColum = new DataGridViewTextBoxColumn();
            PuntosColum = new DataGridViewTextBoxColumn();
            modifColum = new DataGridViewButtonColumn();
            eliminarColum = new DataGridViewButtonColumn();
            panel2 = new ReaLTaiizor.Controls.Panel();
            panel3 = new ReaLTaiizor.Controls.Panel();
            label10 = new Label();
            txtNombreClienteBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            button5 = new Button();
            label9 = new Label();
            button4 = new Button();
            txtDniClienteBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            label8 = new Label();
            contadorClientes = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            button3 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtDniCliente
            // 
            txtDniCliente.Alpha = 20;
            txtDniCliente.BackColor = Color.Transparent;
            txtDniCliente.Background_WidthPen = 3F;
            txtDniCliente.BackgroundPen = true;
            txtDniCliente.ColorBackground = Color.White;
            txtDniCliente.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDniCliente.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDniCliente.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDniCliente.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDniCliente.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDniCliente.Font = new Font("Arial", 8F);
            txtDniCliente.ForeColor = Color.Black;
            txtDniCliente.Lighting = false;
            txtDniCliente.LinearGradientPen = false;
            txtDniCliente.Location = new Point(17, 72);
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.PenWidth = 15;
            txtDniCliente.RGB = false;
            txtDniCliente.Rounding = true;
            txtDniCliente.RoundingInt = 60;
            txtDniCliente.Size = new Size(191, 32);
            txtDniCliente.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDniCliente.TabIndex = 14;
            txtDniCliente.Tag = "Cyber";
            txtDniCliente.TextButton = "";
            txtDniCliente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDniCliente.Timer_RGB = 300;
            txtDniCliente.Load += cyberTextBox10_Load;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(17, 54);
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
            label12.Location = new Point(51, 18);
            label12.Name = "label12";
            label12.Size = new Size(151, 20);
            label12.TabIndex = 19;
            label12.Text = "DATOS DEL CLIENTE";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(242, 54);
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
            // txtNombreCliente
            // 
            txtNombreCliente.Alpha = 20;
            txtNombreCliente.BackColor = Color.Transparent;
            txtNombreCliente.Background_WidthPen = 3F;
            txtNombreCliente.BackgroundPen = true;
            txtNombreCliente.ColorBackground = Color.White;
            txtNombreCliente.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNombreCliente.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNombreCliente.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNombreCliente.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNombreCliente.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNombreCliente.Font = new Font("Arial", 8F);
            txtNombreCliente.ForeColor = Color.Black;
            txtNombreCliente.Lighting = false;
            txtNombreCliente.LinearGradientPen = false;
            txtNombreCliente.Location = new Point(242, 72);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.PenWidth = 15;
            txtNombreCliente.RGB = false;
            txtNombreCliente.Rounding = true;
            txtNombreCliente.RoundingInt = 60;
            txtNombreCliente.Size = new Size(191, 32);
            txtNombreCliente.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNombreCliente.TabIndex = 20;
            txtNombreCliente.Tag = "Cyber";
            txtNombreCliente.TextButton = "";
            txtNombreCliente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNombreCliente.Timer_RGB = 300;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(470, 54);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 21;
            label1.Text = "Apellido/s";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Alpha = 20;
            txtApellidoCliente.BackColor = Color.Transparent;
            txtApellidoCliente.Background_WidthPen = 3F;
            txtApellidoCliente.BackgroundPen = true;
            txtApellidoCliente.ColorBackground = Color.White;
            txtApellidoCliente.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtApellidoCliente.ColorLighting = Color.FromArgb(29, 200, 238);
            txtApellidoCliente.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtApellidoCliente.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtApellidoCliente.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtApellidoCliente.Font = new Font("Arial", 8F);
            txtApellidoCliente.ForeColor = Color.Black;
            txtApellidoCliente.Lighting = false;
            txtApellidoCliente.LinearGradientPen = false;
            txtApellidoCliente.Location = new Point(470, 72);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.PenWidth = 15;
            txtApellidoCliente.RGB = false;
            txtApellidoCliente.Rounding = true;
            txtApellidoCliente.RoundingInt = 60;
            txtApellidoCliente.Size = new Size(191, 32);
            txtApellidoCliente.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtApellidoCliente.TabIndex = 22;
            txtApellidoCliente.Tag = "Cyber";
            txtApellidoCliente.TextButton = "";
            txtApellidoCliente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtApellidoCliente.Timer_RGB = 300;
            txtApellidoCliente.Load += txtApellidoCliente_Load;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 123);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 23;
            label2.Text = "Email";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Alpha = 20;
            txtEmailCliente.BackColor = Color.Transparent;
            txtEmailCliente.Background_WidthPen = 3F;
            txtEmailCliente.BackgroundPen = true;
            txtEmailCliente.ColorBackground = Color.White;
            txtEmailCliente.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtEmailCliente.ColorLighting = Color.FromArgb(29, 200, 238);
            txtEmailCliente.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtEmailCliente.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtEmailCliente.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtEmailCliente.Font = new Font("Arial", 8F);
            txtEmailCliente.ForeColor = Color.Black;
            txtEmailCliente.Lighting = false;
            txtEmailCliente.LinearGradientPen = false;
            txtEmailCliente.Location = new Point(17, 141);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.PenWidth = 15;
            txtEmailCliente.RGB = false;
            txtEmailCliente.Rounding = true;
            txtEmailCliente.RoundingInt = 60;
            txtEmailCliente.Size = new Size(191, 32);
            txtEmailCliente.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtEmailCliente.TabIndex = 24;
            txtEmailCliente.Tag = "Cyber";
            txtEmailCliente.TextButton = "";
            txtEmailCliente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtEmailCliente.Timer_RGB = 300;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(242, 123);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 25;
            label3.Text = "Dirección";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDireccionCliente
            // 
            txtDireccionCliente.Alpha = 20;
            txtDireccionCliente.BackColor = Color.Transparent;
            txtDireccionCliente.Background_WidthPen = 3F;
            txtDireccionCliente.BackgroundPen = true;
            txtDireccionCliente.ColorBackground = Color.White;
            txtDireccionCliente.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDireccionCliente.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDireccionCliente.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDireccionCliente.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDireccionCliente.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDireccionCliente.Font = new Font("Arial", 8F);
            txtDireccionCliente.ForeColor = Color.Black;
            txtDireccionCliente.Lighting = false;
            txtDireccionCliente.LinearGradientPen = false;
            txtDireccionCliente.Location = new Point(242, 141);
            txtDireccionCliente.Name = "txtDireccionCliente";
            txtDireccionCliente.PenWidth = 15;
            txtDireccionCliente.RGB = false;
            txtDireccionCliente.Rounding = true;
            txtDireccionCliente.RoundingInt = 60;
            txtDireccionCliente.Size = new Size(191, 32);
            txtDireccionCliente.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDireccionCliente.TabIndex = 26;
            txtDireccionCliente.Tag = "Cyber";
            txtDireccionCliente.TextButton = "";
            txtDireccionCliente.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDireccionCliente.Timer_RGB = 300;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(470, 123);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 27;
            label4.Text = "Puntos Acumulados";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cyberTextBox5
            // 
            cyberTextBox5.Alpha = 20;
            cyberTextBox5.BackColor = Color.Transparent;
            cyberTextBox5.Background_WidthPen = 3F;
            cyberTextBox5.BackgroundPen = true;
            cyberTextBox5.ColorBackground = Color.White;
            cyberTextBox5.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            cyberTextBox5.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox5.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberTextBox5.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberTextBox5.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox5.Enabled = false;
            cyberTextBox5.Font = new Font("Arial", 8F);
            cyberTextBox5.ForeColor = Color.Black;
            cyberTextBox5.Lighting = false;
            cyberTextBox5.LinearGradientPen = false;
            cyberTextBox5.Location = new Point(470, 141);
            cyberTextBox5.Name = "cyberTextBox5";
            cyberTextBox5.PenWidth = 15;
            cyberTextBox5.RGB = false;
            cyberTextBox5.Rounding = true;
            cyberTextBox5.RoundingInt = 60;
            cyberTextBox5.Size = new Size(115, 32);
            cyberTextBox5.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox5.TabIndex = 28;
            cyberTextBox5.Tag = "Cyber";
            cyberTextBox5.TextButton = "";
            cyberTextBox5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox5.Timer_RGB = 300;
            // 
            // btnNuevo
            // 
            btnNuevo.Alpha = 20;
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevo.BackColor = Color.Transparent;
            btnNuevo.Background = true;
            btnNuevo.Background_WidthPen = 4F;
            btnNuevo.BackgroundPen = true;
            btnNuevo.ColorBackground = Color.FromArgb(0, 192, 0);
            btnNuevo.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnNuevo.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnNuevo.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnNuevo.ColorLighting = Color.FromArgb(29, 200, 238);
            btnNuevo.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnNuevo.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnNuevo.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnNuevo.Effect_1 = true;
            btnNuevo.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnNuevo.Effect_1_Transparency = 25;
            btnNuevo.Effect_2 = true;
            btnNuevo.Effect_2_ColorBackground = Color.White;
            btnNuevo.Effect_2_Transparency = 20;
            btnNuevo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.FromArgb(245, 245, 245);
            btnNuevo.Lighting = false;
            btnNuevo.LinearGradient_Background = false;
            btnNuevo.LinearGradientPen = false;
            btnNuevo.Location = new Point(705, 66);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.PenWidth = 15;
            btnNuevo.Rounding = true;
            btnNuevo.RoundingInt = 70;
            btnNuevo.Size = new Size(141, 38);
            btnNuevo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnNuevo.TabIndex = 61;
            btnNuevo.Tag = "Cyber";
            btnNuevo.TextButton = "NUEVO";
            btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnNuevo.Timer_Effect_1 = 5;
            btnNuevo.Timer_RGB = 300;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Alpha = 20;
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.Background = true;
            btnGuardar.Background_WidthPen = 4F;
            btnGuardar.BackgroundPen = true;
            btnGuardar.ColorBackground = Color.FromArgb(128, 128, 255);
            btnGuardar.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnGuardar.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnGuardar.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnGuardar.ColorLighting = Color.FromArgb(29, 200, 238);
            btnGuardar.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnGuardar.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnGuardar.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnGuardar.Effect_1 = true;
            btnGuardar.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnGuardar.Effect_1_Transparency = 25;
            btnGuardar.Effect_2 = true;
            btnGuardar.Effect_2_ColorBackground = Color.White;
            btnGuardar.Effect_2_Transparency = 20;
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.FromArgb(245, 245, 245);
            btnGuardar.Lighting = false;
            btnGuardar.LinearGradient_Background = false;
            btnGuardar.LinearGradientPen = false;
            btnGuardar.Location = new Point(705, 100);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.PenWidth = 15;
            btnGuardar.Rounding = true;
            btnGuardar.RoundingInt = 70;
            btnGuardar.Size = new Size(141, 38);
            btnGuardar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnGuardar.TabIndex = 62;
            btnGuardar.Tag = "Cyber";
            btnGuardar.TextButton = "GUARDAR";
            btnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnGuardar.Timer_Effect_1 = 5;
            btnGuardar.Timer_RGB = 300;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Alpha = 20;
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Background = true;
            btnEliminar.Background_WidthPen = 4F;
            btnEliminar.BackgroundPen = true;
            btnEliminar.ColorBackground = Color.FromArgb(255, 128, 128);
            btnEliminar.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnEliminar.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnEliminar.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnEliminar.ColorLighting = Color.FromArgb(29, 200, 238);
            btnEliminar.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnEliminar.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnEliminar.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnEliminar.Effect_1 = true;
            btnEliminar.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnEliminar.Effect_1_Transparency = 25;
            btnEliminar.Effect_2 = true;
            btnEliminar.Effect_2_ColorBackground = Color.White;
            btnEliminar.Effect_2_Transparency = 20;
            btnEliminar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.FromArgb(245, 245, 245);
            btnEliminar.Lighting = false;
            btnEliminar.LinearGradient_Background = false;
            btnEliminar.LinearGradientPen = false;
            btnEliminar.Location = new Point(705, 135);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.PenWidth = 15;
            btnEliminar.Rounding = true;
            btnEliminar.RoundingInt = 70;
            btnEliminar.Size = new Size(141, 38);
            btnEliminar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnEliminar.TabIndex = 62;
            btnEliminar.Tag = "Cyber";
            btnEliminar.TextButton = "CANCELAR";
            btnEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnEliminar.Timer_Effect_1 = 5;
            btnEliminar.Timer_RGB = 300;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeColumns = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { dniColum, nombreColum, DirecColum, emailColum, PuntosColum, modifColum, eliminarColum });
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.GridColor = SystemColors.ScrollBar;
            dgvClientes.Location = new Point(14, 156);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.Size = new Size(868, 126);
            dgvClientes.TabIndex = 56;
            dgvClientes.CellClick += dgvClientes_CellClick;
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
            // PuntosColum
            // 
            PuntosColum.HeaderText = "Puntos";
            PuntosColum.Name = "PuntosColum";
            PuntosColum.ReadOnly = true;
            // 
            // modifColum
            // 
            modifColum.HeaderText = "Modificar";
            modifColum.Name = "modifColum";
            modifColum.ReadOnly = true;
            modifColum.Resizable = DataGridViewTriState.True;
            modifColum.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // eliminarColum
            // 
            eliminarColum.HeaderText = "Eliminar";
            eliminarColum.Name = "eliminarColum";
            eliminarColum.ReadOnly = true;
            eliminarColum.Resizable = DataGridViewTriState.True;
            eliminarColum.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(btnNuevo);
            panel2.Controls.Add(cyberTextBox5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDireccionCliente);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtEmailCliente);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtApellidoCliente);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtNombreCliente);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(txtDniCliente);
            panel2.EdgeColor = Color.Transparent;
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(893, 193);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 55;
            panel2.Text = "panel2";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(txtNombreClienteBuscar);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(txtDniClienteBuscar);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(contadorClientes);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(dgvClientes);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label7);
            panel3.EdgeColor = Color.Transparent;
            panel3.Location = new Point(12, 211);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 334);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 56;
            panel3.Text = "panel3";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(243, 58);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 60;
            label10.Text = "Nombre";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNombreClienteBuscar
            // 
            txtNombreClienteBuscar.Alpha = 20;
            txtNombreClienteBuscar.BackColor = Color.Transparent;
            txtNombreClienteBuscar.Background_WidthPen = 3F;
            txtNombreClienteBuscar.BackgroundPen = true;
            txtNombreClienteBuscar.ColorBackground = Color.White;
            txtNombreClienteBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNombreClienteBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNombreClienteBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNombreClienteBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNombreClienteBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNombreClienteBuscar.Font = new Font("Arial", 8F);
            txtNombreClienteBuscar.ForeColor = Color.Black;
            txtNombreClienteBuscar.Lighting = false;
            txtNombreClienteBuscar.LinearGradientPen = false;
            txtNombreClienteBuscar.Location = new Point(240, 73);
            txtNombreClienteBuscar.Name = "txtNombreClienteBuscar";
            txtNombreClienteBuscar.PenWidth = 15;
            txtNombreClienteBuscar.RGB = false;
            txtNombreClienteBuscar.Rounding = true;
            txtNombreClienteBuscar.RoundingInt = 60;
            txtNombreClienteBuscar.Size = new Size(358, 32);
            txtNombreClienteBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNombreClienteBuscar.TabIndex = 66;
            txtNombreClienteBuscar.Tag = "Cyber";
            txtNombreClienteBuscar.TextButton = "";
            txtNombreClienteBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNombreClienteBuscar.Timer_RGB = 300;
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
            label9.Location = new Point(20, 58);
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
            // txtDniClienteBuscar
            // 
            txtDniClienteBuscar.Alpha = 20;
            txtDniClienteBuscar.BackColor = Color.Transparent;
            txtDniClienteBuscar.Background_WidthPen = 3F;
            txtDniClienteBuscar.BackgroundPen = true;
            txtDniClienteBuscar.ColorBackground = Color.White;
            txtDniClienteBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDniClienteBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDniClienteBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDniClienteBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDniClienteBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDniClienteBuscar.Font = new Font("Arial", 8F);
            txtDniClienteBuscar.ForeColor = Color.Black;
            txtDniClienteBuscar.Lighting = false;
            txtDniClienteBuscar.LinearGradientPen = false;
            txtDniClienteBuscar.Location = new Point(17, 73);
            txtDniClienteBuscar.Name = "txtDniClienteBuscar";
            txtDniClienteBuscar.PenWidth = 15;
            txtDniClienteBuscar.RGB = false;
            txtDniClienteBuscar.Rounding = true;
            txtDniClienteBuscar.RoundingInt = 60;
            txtDniClienteBuscar.Size = new Size(194, 32);
            txtDniClienteBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDniClienteBuscar.TabIndex = 63;
            txtDniClienteBuscar.Tag = "Cyber";
            txtDniClienteBuscar.TextButton = "";
            txtDniClienteBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDniClienteBuscar.Timer_RGB = 300;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(54, 25);
            label8.Name = "label8";
            label8.Size = new Size(131, 20);
            label8.TabIndex = 65;
            label8.Text = "BUSCAR CLIENTE";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contadorClientes
            // 
            contadorClientes.Alpha = 20;
            contadorClientes.BackColor = Color.Transparent;
            contadorClientes.Background_WidthPen = 3F;
            contadorClientes.BackgroundPen = true;
            contadorClientes.ColorBackground = Color.White;
            contadorClientes.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            contadorClientes.ColorLighting = Color.FromArgb(29, 200, 238);
            contadorClientes.ColorPen_1 = Color.FromArgb(29, 200, 238);
            contadorClientes.ColorPen_2 = Color.FromArgb(37, 52, 68);
            contadorClientes.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            contadorClientes.Enabled = false;
            contadorClientes.Font = new Font("Arial", 8F);
            contadorClientes.ForeColor = Color.Black;
            contadorClientes.Lighting = false;
            contadorClientes.LinearGradientPen = false;
            contadorClientes.Location = new Point(143, 288);
            contadorClientes.Name = "contadorClientes";
            contadorClientes.PenWidth = 15;
            contadorClientes.RGB = false;
            contadorClientes.Rounding = true;
            contadorClientes.RoundingInt = 60;
            contadorClientes.Size = new Size(59, 32);
            contadorClientes.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            contadorClientes.TabIndex = 59;
            contadorClientes.Tag = "Cyber";
            contadorClientes.TextButton = "";
            contadorClientes.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            contadorClientes.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 297);
            label5.Name = "label5";
            label5.Size = new Size(122, 15);
            label5.TabIndex = 58;
            label5.Text = "Cantidad de Clientes:";
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
            label7.Size = new Size(143, 20);
            label7.TabIndex = 15;
            label7.Text = "LISTA DE CLIENTES";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 570);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "FormClientes";
            Text = "FormClientes";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.CyberTextBox txtDniCliente;
        private Label label14;
        private Label label12;
        private Label label13;
        private Button button1;
        private ReaLTaiizor.Controls.CyberTextBox txtNombreCliente;
        private Label label1;
        private ReaLTaiizor.Controls.CyberTextBox txtApellidoCliente;
        private Label label2;
        private ReaLTaiizor.Controls.CyberTextBox txtEmailCliente;
        private Label label3;
        private ReaLTaiizor.Controls.CyberTextBox txtDireccionCliente;
        private Label label4;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox5;
        private ReaLTaiizor.Controls.CyberButton btnNuevo;
        private ReaLTaiizor.Controls.CyberButton btnGuardar;
        private ReaLTaiizor.Controls.CyberButton btnEliminar;
        private DataGridView dgvClientes;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.Panel panel3;
        private Button button3;
        private Label label7;
        private Label label5;
        private ReaLTaiizor.Controls.CyberTextBox contadorClientes;
        private Label label10;
        private ReaLTaiizor.Controls.CyberTextBox txtNombreClienteBuscar;
        private Button button5;
        private Label label9;
        private Button button4;
        private ReaLTaiizor.Controls.CyberTextBox txtDniClienteBuscar;
        private Label label8;
        private DataGridViewTextBoxColumn dniColum;
        private DataGridViewTextBoxColumn nombreColum;
        private DataGridViewTextBoxColumn DirecColum;
        private DataGridViewTextBoxColumn emailColum;
        private DataGridViewTextBoxColumn PuntosColum;
        private DataGridViewButtonColumn modifColum;
        private DataGridViewButtonColumn eliminarColum;
    }
}