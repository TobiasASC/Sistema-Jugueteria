namespace SistemaJugueteria
{
    partial class FormBackup
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
            label2 = new Label();
            panel3 = new ReaLTaiizor.Controls.Panel();
            dateTimePicker1 = new DateTimePicker();
            dgvBackups = new DataGridView();
            ColumCodigo = new DataGridViewTextBoxColumn();
            DescripColum = new DataGridViewTextBoxColumn();
            CategoriaColum = new DataGridViewTextBoxColumn();
            CantidadColum = new DataGridViewTextBoxColumn();
            eliminarColum = new DataGridViewTextBoxColumn();
            label4 = new Label();
            button1 = new Button();
            label10 = new Label();
            button5 = new Button();
            numeroBackupBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            label8 = new Label();
            contadorBackups = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            button3 = new Button();
            label7 = new Label();
            panel2 = new ReaLTaiizor.Controls.Panel();
            dtpFechaBackup = new DateTimePicker();
            btnCancelar = new ReaLTaiizor.Controls.CyberButton();
            btnConfirmar = new ReaLTaiizor.Controls.CyberButton();
            label3 = new Label();
            txtNumeroBackup = new ReaLTaiizor.Controls.CyberTextBox();
            button6 = new Button();
            cyberButton4 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton5 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton6 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton3 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton1 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton2 = new ReaLTaiizor.Controls.CyberButton();
            label1 = new Label();
            label12 = new Label();
            label14 = new Label();
            txtBD = new ReaLTaiizor.Controls.CyberTextBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBackups).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 52);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(dgvBackups);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(numeroBackupBuscar);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(contadorBackups);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label7);
            panel3.EdgeColor = Color.FromArgb(32, 41, 50);
            panel3.Location = new Point(10, 189);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 334);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 60;
            panel3.Text = "panel3";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(249, 88);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(95, 23);
            dateTimePicker1.TabIndex = 79;
            // 
            // dgvBackups
            // 
            dgvBackups.AllowUserToAddRows = false;
            dgvBackups.AllowUserToDeleteRows = false;
            dgvBackups.AllowUserToResizeColumns = false;
            dgvBackups.AllowUserToResizeRows = false;
            dgvBackups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBackups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBackups.BackgroundColor = Color.White;
            dgvBackups.BorderStyle = BorderStyle.None;
            dgvBackups.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBackups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBackups.Columns.AddRange(new DataGridViewColumn[] { ColumCodigo, DescripColum, CategoriaColum, CantidadColum, eliminarColum });
            dgvBackups.EnableHeadersVisualStyles = false;
            dgvBackups.GridColor = SystemColors.ScrollBar;
            dgvBackups.Location = new Point(11, 163);
            dgvBackups.Name = "dgvBackups";
            dgvBackups.ReadOnly = true;
            dgvBackups.RowHeadersVisible = false;
            dgvBackups.Size = new Size(868, 122);
            dgvBackups.TabIndex = 76;
            // 
            // ColumCodigo
            // 
            ColumCodigo.HeaderText = "N° Backup";
            ColumCodigo.Name = "ColumCodigo";
            ColumCodigo.ReadOnly = true;
            // 
            // DescripColum
            // 
            DescripColum.HeaderText = "Base de Datos";
            DescripColum.Name = "DescripColum";
            DescripColum.ReadOnly = true;
            // 
            // CategoriaColum
            // 
            CategoriaColum.HeaderText = "Ruta";
            CategoriaColum.Name = "CategoriaColum";
            CategoriaColum.ReadOnly = true;
            // 
            // CantidadColum
            // 
            CantidadColum.HeaderText = "Fecha";
            CantidadColum.Name = "CantidadColum";
            CantidadColum.ReadOnly = true;
            // 
            // eliminarColum
            // 
            eliminarColum.HeaderText = "Detalles";
            eliminarColum.Name = "eliminarColum";
            eliminarColum.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 64);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 75;
            label4.Text = "N° Backup";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.lets_icons__arhive_load_fill;
            button1.Location = new Point(20, 22);
            button1.Name = "button1";
            button1.Size = new Size(34, 26);
            button1.TabIndex = 73;
            button1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(249, 64);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 60;
            label10.Text = "Fecha";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 227, 227);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.boxicons__search_alt;
            button5.Location = new Point(366, 79);
            button5.Name = "button5";
            button5.Size = new Size(34, 32);
            button5.TabIndex = 61;
            button5.UseVisualStyleBackColor = false;
            // 
            // numeroBackupBuscar
            // 
            numeroBackupBuscar.Alpha = 20;
            numeroBackupBuscar.BackColor = Color.Transparent;
            numeroBackupBuscar.Background_WidthPen = 3F;
            numeroBackupBuscar.BackgroundPen = true;
            numeroBackupBuscar.ColorBackground = Color.White;
            numeroBackupBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            numeroBackupBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            numeroBackupBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            numeroBackupBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            numeroBackupBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            numeroBackupBuscar.Font = new Font("Arial", 8F);
            numeroBackupBuscar.ForeColor = Color.Black;
            numeroBackupBuscar.Lighting = false;
            numeroBackupBuscar.LinearGradientPen = false;
            numeroBackupBuscar.Location = new Point(20, 79);
            numeroBackupBuscar.Name = "numeroBackupBuscar";
            numeroBackupBuscar.PenWidth = 15;
            numeroBackupBuscar.RGB = false;
            numeroBackupBuscar.Rounding = true;
            numeroBackupBuscar.RoundingInt = 60;
            numeroBackupBuscar.Size = new Size(194, 32);
            numeroBackupBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            numeroBackupBuscar.TabIndex = 63;
            numeroBackupBuscar.Tag = "Cyber";
            numeroBackupBuscar.TextButton = "";
            numeroBackupBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            numeroBackupBuscar.Timer_RGB = 300;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(60, 31);
            label8.Name = "label8";
            label8.Size = new Size(132, 20);
            label8.TabIndex = 65;
            label8.Text = "BUSCAR BACKUP";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contadorBackups
            // 
            contadorBackups.Alpha = 20;
            contadorBackups.BackColor = Color.Transparent;
            contadorBackups.Background_WidthPen = 3F;
            contadorBackups.BackgroundPen = true;
            contadorBackups.ColorBackground = Color.White;
            contadorBackups.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            contadorBackups.ColorLighting = Color.FromArgb(29, 200, 238);
            contadorBackups.ColorPen_1 = Color.FromArgb(29, 200, 238);
            contadorBackups.ColorPen_2 = Color.FromArgb(37, 52, 68);
            contadorBackups.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            contadorBackups.Enabled = false;
            contadorBackups.Font = new Font("Arial", 8F, FontStyle.Bold);
            contadorBackups.ForeColor = Color.FromArgb(245, 245, 245);
            contadorBackups.Lighting = false;
            contadorBackups.LinearGradientPen = false;
            contadorBackups.Location = new Point(155, 291);
            contadorBackups.Name = "contadorBackups";
            contadorBackups.PenWidth = 15;
            contadorBackups.RGB = false;
            contadorBackups.Rounding = true;
            contadorBackups.RoundingInt = 60;
            contadorBackups.Size = new Size(59, 32);
            contadorBackups.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            contadorBackups.TabIndex = 59;
            contadorBackups.Tag = "Cyber";
            contadorBackups.TextButton = "";
            contadorBackups.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            contadorBackups.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 303);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 58;
            label5.Text = "Cantidad de backups:";
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
            label7.Size = new Size(144, 20);
            label7.TabIndex = 15;
            label7.Text = "LISTA DE BACKUPS";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(dtpFechaBackup);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnConfirmar);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtNumeroBackup);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(cyberButton4);
            panel2.Controls.Add(cyberButton5);
            panel2.Controls.Add(cyberButton6);
            panel2.Controls.Add(cyberButton3);
            panel2.Controls.Add(cyberButton1);
            panel2.Controls.Add(cyberButton2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(txtBD);
            panel2.EdgeColor = Color.FromArgb(32, 41, 50);
            panel2.Location = new Point(10, 19);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(893, 155);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 59;
            panel2.Text = "panel2";
            panel2.Click += panel2_Click;
            // 
            // dtpFechaBackup
            // 
            dtpFechaBackup.Format = DateTimePickerFormat.Custom;
            dtpFechaBackup.Location = new Point(464, 81);
            dtpFechaBackup.Name = "dtpFechaBackup";
            dtpFechaBackup.Size = new Size(95, 23);
            dtpFechaBackup.TabIndex = 79;
            // 
            // btnCancelar
            // 
            btnCancelar.Alpha = 20;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Background = true;
            btnCancelar.Background_WidthPen = 4F;
            btnCancelar.BackgroundPen = true;
            btnCancelar.ColorBackground = Color.FromArgb(255, 128, 128);
            btnCancelar.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnCancelar.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnCancelar.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnCancelar.ColorLighting = Color.FromArgb(29, 200, 238);
            btnCancelar.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnCancelar.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnCancelar.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnCancelar.Effect_1 = true;
            btnCancelar.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnCancelar.Effect_1_Transparency = 25;
            btnCancelar.Effect_2 = true;
            btnCancelar.Effect_2_ColorBackground = Color.White;
            btnCancelar.Effect_2_Transparency = 20;
            btnCancelar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(245, 245, 245);
            btnCancelar.Lighting = false;
            btnCancelar.LinearGradient_Background = false;
            btnCancelar.LinearGradientPen = false;
            btnCancelar.Location = new Point(135, 112);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.PenWidth = 15;
            btnCancelar.Rounding = true;
            btnCancelar.RoundingInt = 70;
            btnCancelar.Size = new Size(112, 32);
            btnCancelar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnCancelar.TabIndex = 76;
            btnCancelar.Tag = "Cyber";
            btnCancelar.TextButton = "CANCELAR";
            btnCancelar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnCancelar.Timer_Effect_1 = 5;
            btnCancelar.Timer_RGB = 300;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Alpha = 20;
            btnConfirmar.BackColor = Color.Transparent;
            btnConfirmar.Background = true;
            btnConfirmar.Background_WidthPen = 4F;
            btnConfirmar.BackgroundPen = true;
            btnConfirmar.ColorBackground = Color.FromArgb(0, 192, 0);
            btnConfirmar.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnConfirmar.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnConfirmar.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnConfirmar.ColorLighting = Color.FromArgb(29, 200, 238);
            btnConfirmar.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnConfirmar.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnConfirmar.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnConfirmar.Effect_1 = true;
            btnConfirmar.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnConfirmar.Effect_1_Transparency = 25;
            btnConfirmar.Effect_2 = true;
            btnConfirmar.Effect_2_ColorBackground = Color.White;
            btnConfirmar.Effect_2_Transparency = 20;
            btnConfirmar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = Color.FromArgb(245, 245, 245);
            btnConfirmar.Lighting = false;
            btnConfirmar.LinearGradient_Background = false;
            btnConfirmar.LinearGradientPen = false;
            btnConfirmar.Location = new Point(17, 112);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.PenWidth = 15;
            btnConfirmar.Rounding = true;
            btnConfirmar.RoundingInt = 70;
            btnConfirmar.Size = new Size(112, 32);
            btnConfirmar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnConfirmar.TabIndex = 75;
            btnConfirmar.Tag = "Cyber";
            btnConfirmar.TextButton = "CONFIRMAR";
            btnConfirmar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnConfirmar.Timer_Effect_1 = 5;
            btnConfirmar.Timer_RGB = 300;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 54);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 74;
            label3.Text = "N° Backup";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroBackup
            // 
            txtNumeroBackup.Alpha = 20;
            txtNumeroBackup.BackColor = Color.Transparent;
            txtNumeroBackup.Background_WidthPen = 3F;
            txtNumeroBackup.BackgroundPen = true;
            txtNumeroBackup.ColorBackground = Color.White;
            txtNumeroBackup.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNumeroBackup.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNumeroBackup.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNumeroBackup.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNumeroBackup.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNumeroBackup.Font = new Font("Arial", 8F);
            txtNumeroBackup.ForeColor = Color.Black;
            txtNumeroBackup.Lighting = false;
            txtNumeroBackup.LinearGradientPen = false;
            txtNumeroBackup.Location = new Point(17, 72);
            txtNumeroBackup.Name = "txtNumeroBackup";
            txtNumeroBackup.PenWidth = 15;
            txtNumeroBackup.RGB = false;
            txtNumeroBackup.Rounding = true;
            txtNumeroBackup.RoundingInt = 60;
            txtNumeroBackup.Size = new Size(191, 32);
            txtNumeroBackup.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNumeroBackup.TabIndex = 73;
            txtNumeroBackup.Tag = "Cyber";
            txtNumeroBackup.TextButton = "";
            txtNumeroBackup.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNumeroBackup.Timer_RGB = 300;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.lets_icons__arhive_load_fill;
            button6.Location = new Point(17, 15);
            button6.Name = "button6";
            button6.Size = new Size(34, 26);
            button6.TabIndex = 72;
            button6.UseVisualStyleBackColor = true;
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
            cyberButton4.Location = new Point(1405, 158);
            cyberButton4.Name = "cyberButton4";
            cyberButton4.PenWidth = 15;
            cyberButton4.Rounding = true;
            cyberButton4.RoundingInt = 70;
            cyberButton4.Size = new Size(141, 38);
            cyberButton4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton4.TabIndex = 65;
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
            cyberButton5.Location = new Point(1405, 114);
            cyberButton5.Name = "cyberButton5";
            cyberButton5.PenWidth = 15;
            cyberButton5.Rounding = true;
            cyberButton5.RoundingInt = 70;
            cyberButton5.Size = new Size(141, 38);
            cyberButton5.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton5.TabIndex = 64;
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
            cyberButton6.Location = new Point(1405, 66);
            cyberButton6.Name = "cyberButton6";
            cyberButton6.PenWidth = 15;
            cyberButton6.Rounding = true;
            cyberButton6.RoundingInt = 70;
            cyberButton6.Size = new Size(141, 38);
            cyberButton6.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton6.TabIndex = 63;
            cyberButton6.Tag = "Cyber";
            cyberButton6.TextButton = "NUEVO";
            cyberButton6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton6.Timer_Effect_1 = 5;
            cyberButton6.Timer_RGB = 300;
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
            cyberButton3.Location = new Point(2111, 226);
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
            // cyberButton1
            // 
            cyberButton1.Alpha = 20;
            cyberButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton1.BackColor = Color.Transparent;
            cyberButton1.Background = true;
            cyberButton1.Background_WidthPen = 4F;
            cyberButton1.BackgroundPen = true;
            cyberButton1.ColorBackground = Color.FromArgb(128, 128, 255);
            cyberButton1.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton1.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton1.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton1.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton1.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton1.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton1.Effect_1 = true;
            cyberButton1.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton1.Effect_1_Transparency = 25;
            cyberButton1.Effect_2 = true;
            cyberButton1.Effect_2_ColorBackground = Color.White;
            cyberButton1.Effect_2_Transparency = 20;
            cyberButton1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton1.Lighting = false;
            cyberButton1.LinearGradient_Background = false;
            cyberButton1.LinearGradientPen = false;
            cyberButton1.Location = new Point(2111, 182);
            cyberButton1.Name = "cyberButton1";
            cyberButton1.PenWidth = 15;
            cyberButton1.Rounding = true;
            cyberButton1.RoundingInt = 70;
            cyberButton1.Size = new Size(141, 38);
            cyberButton1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton1.TabIndex = 62;
            cyberButton1.Tag = "Cyber";
            cyberButton1.TextButton = "GUARDAR";
            cyberButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton1.Timer_Effect_1 = 5;
            cyberButton1.Timer_RGB = 300;
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
            cyberButton2.Location = new Point(2111, 134);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(464, 54);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 23;
            label1.Text = "Fecha";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(57, 24);
            label12.Name = "label12";
            label12.Size = new Size(152, 20);
            label12.TabIndex = 19;
            label12.Text = "DATOS DEL BACKUP";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(246, 54);
            label14.Name = "label14";
            label14.Size = new Size(85, 15);
            label14.TabIndex = 15;
            label14.Text = "Base de Datos";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBD
            // 
            txtBD.Alpha = 20;
            txtBD.BackColor = Color.Transparent;
            txtBD.Background_WidthPen = 3F;
            txtBD.BackgroundPen = true;
            txtBD.ColorBackground = Color.White;
            txtBD.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtBD.ColorLighting = Color.FromArgb(29, 200, 238);
            txtBD.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtBD.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtBD.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtBD.Font = new Font("Arial", 8F);
            txtBD.ForeColor = Color.Black;
            txtBD.Lighting = false;
            txtBD.LinearGradientPen = false;
            txtBD.Location = new Point(242, 72);
            txtBD.Name = "txtBD";
            txtBD.PenWidth = 15;
            txtBD.RGB = false;
            txtBD.Rounding = true;
            txtBD.RoundingInt = 60;
            txtBD.Size = new Size(191, 32);
            txtBD.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtBD.TabIndex = 14;
            txtBD.Tag = "Cyber";
            txtBD.TextButton = "";
            txtBD.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtBD.Timer_RGB = 300;
            // 
            // FormBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 566);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label2);
            Name = "FormBackup";
            Text = "FormBackup";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBackups).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private ReaLTaiizor.Controls.Panel panel3;
        private Button button1;
        private Label label10;
        private Button button5;
        private ReaLTaiizor.Controls.CyberTextBox numeroBackupBuscar;
        private Label label8;
        private ReaLTaiizor.Controls.CyberTextBox contadorBackups;
        private Label label5;
        private Button button3;
        private Label label7;
        private ReaLTaiizor.Controls.Panel panel2;
        private Button button6;
        private ReaLTaiizor.Controls.CyberButton cyberButton4;
        private ReaLTaiizor.Controls.CyberButton cyberButton5;
        private ReaLTaiizor.Controls.CyberButton cyberButton6;
        private ReaLTaiizor.Controls.CyberButton cyberButton3;
        private ReaLTaiizor.Controls.CyberButton cyberButton1;
        private ReaLTaiizor.Controls.CyberButton cyberButton2;
        private Label label1;
        private Label label12;
        private Label label14;
        private ReaLTaiizor.Controls.CyberTextBox txtBD;
        private Label label3;
        private ReaLTaiizor.Controls.CyberTextBox txtNumeroBackup;
        private Label label4;
        private DataGridView dgvBackups;
        private DataGridViewTextBoxColumn ColumCodigo;
        private DataGridViewTextBoxColumn DescripColum;
        private DataGridViewTextBoxColumn CategoriaColum;
        private DataGridViewTextBoxColumn CantidadColum;
        private DataGridViewTextBoxColumn eliminarColum;
        private ReaLTaiizor.Controls.CyberButton btnConfirmar;
        private ReaLTaiizor.Controls.CyberButton btnCancelar;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dtpFechaBackup;
    }
}