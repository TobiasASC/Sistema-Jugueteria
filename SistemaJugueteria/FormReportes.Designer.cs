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
            panel2 = new ReaLTaiizor.Controls.Panel();
            dtpFechaReporte = new DateTimePicker();
            cbMotivo = new ReaLTaiizor.Controls.CyberComboBox();
            btnCancelar = new ReaLTaiizor.Controls.CyberButton();
            btnGenerarReportePDF = new ReaLTaiizor.Controls.CyberButton();
            label3 = new Label();
            txtNumeroReporte = new ReaLTaiizor.Controls.CyberTextBox();
            button6 = new Button();
            cyberButton4 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton5 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton6 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton3 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton1 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton2 = new ReaLTaiizor.Controls.CyberButton();
            label13 = new Label();
            label12 = new Label();
            label14 = new Label();
            panel3 = new ReaLTaiizor.Controls.Panel();
            dtpFechaReporteBuscar = new DateTimePicker();
            label2 = new Label();
            dgvReportes = new DataGridView();
            ColumCodigo = new DataGridViewTextBoxColumn();
            DescripColum = new DataGridViewTextBoxColumn();
            CategoriaColum = new DataGridViewTextBoxColumn();
            eliminarColum = new DataGridViewButtonColumn();
            button1 = new Button();
            label1 = new Label();
            label4 = new Label();
            label10 = new Label();
            button5 = new Button();
            txtNumeroReporteBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            contadorReportes = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            button3 = new Button();
            label7 = new Label();
            motivoReportesBuscar = new ReaLTaiizor.Controls.CyberComboBox();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(dtpFechaReporte);
            panel2.Controls.Add(cbMotivo);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnGenerarReportePDF);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtNumeroReporte);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(cyberButton4);
            panel2.Controls.Add(cyberButton5);
            panel2.Controls.Add(cyberButton6);
            panel2.Controls.Add(cyberButton3);
            panel2.Controls.Add(cyberButton1);
            panel2.Controls.Add(cyberButton2);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.EdgeColor = Color.FromArgb(32, 41, 50);
            panel2.Location = new Point(8, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(893, 155);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 60;
            panel2.Text = "panel2";
            // 
            // dtpFechaReporte
            // 
            dtpFechaReporte.Format = DateTimePickerFormat.Custom;
            dtpFechaReporte.Location = new Point(230, 75);
            dtpFechaReporte.Name = "dtpFechaReporte";
            dtpFechaReporte.Size = new Size(95, 23);
            dtpFechaReporte.TabIndex = 78;
            // 
            // cbMotivo
            // 
            cbMotivo.BackColor = Color.White;
            cbMotivo.ColorArrow = Color.FromArgb(252, 173, 159);
            cbMotivo.ColorBackground = Color.White;
            cbMotivo.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            cbMotivo.ColorItemHover = Color.FromArgb(50, 70, 90);
            cbMotivo.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cbMotivo.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cbMotivo.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cbMotivo.DrawMode = DrawMode.OwnerDrawFixed;
            cbMotivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMotivo.FlatStyle = FlatStyle.Flat;
            cbMotivo.Font = new Font("Arial", 11F);
            cbMotivo.ForeColor = Color.Black;
            cbMotivo.FormattingEnabled = true;
            cbMotivo.ItemHeight = 28;
            cbMotivo.Items.AddRange(new object[] { "Clientes", "Ventas", "Empleados", "Backups", "Pedidos" });
            cbMotivo.Location = new Point(362, 70);
            cbMotivo.Name = "cbMotivo";
            cbMotivo.RGB = false;
            cbMotivo.Size = new Size(269, 34);
            cbMotivo.TabIndex = 77;
            cbMotivo.Timer_RGB = 300;
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
            btnCancelar.Location = new Point(168, 112);
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
            // btnGenerarReportePDF
            // 
            btnGenerarReportePDF.Alpha = 20;
            btnGenerarReportePDF.BackColor = Color.Transparent;
            btnGenerarReportePDF.Background = true;
            btnGenerarReportePDF.Background_WidthPen = 4F;
            btnGenerarReportePDF.BackgroundPen = true;
            btnGenerarReportePDF.ColorBackground = Color.FromArgb(0, 192, 0);
            btnGenerarReportePDF.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnGenerarReportePDF.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnGenerarReportePDF.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnGenerarReportePDF.ColorLighting = Color.FromArgb(29, 200, 238);
            btnGenerarReportePDF.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnGenerarReportePDF.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnGenerarReportePDF.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnGenerarReportePDF.Effect_1 = true;
            btnGenerarReportePDF.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnGenerarReportePDF.Effect_1_Transparency = 25;
            btnGenerarReportePDF.Effect_2 = true;
            btnGenerarReportePDF.Effect_2_ColorBackground = Color.White;
            btnGenerarReportePDF.Effect_2_Transparency = 20;
            btnGenerarReportePDF.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarReportePDF.ForeColor = Color.FromArgb(245, 245, 245);
            btnGenerarReportePDF.Lighting = false;
            btnGenerarReportePDF.LinearGradient_Background = false;
            btnGenerarReportePDF.LinearGradientPen = false;
            btnGenerarReportePDF.Location = new Point(17, 112);
            btnGenerarReportePDF.Name = "btnGenerarReportePDF";
            btnGenerarReportePDF.PenWidth = 15;
            btnGenerarReportePDF.Rounding = true;
            btnGenerarReportePDF.RoundingInt = 70;
            btnGenerarReportePDF.Size = new Size(145, 32);
            btnGenerarReportePDF.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnGenerarReportePDF.TabIndex = 75;
            btnGenerarReportePDF.Tag = "Cyber";
            btnGenerarReportePDF.TextButton = "GENERAR PDF";
            btnGenerarReportePDF.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnGenerarReportePDF.Timer_Effect_1 = 5;
            btnGenerarReportePDF.Timer_RGB = 300;
            btnGenerarReportePDF.Click += btnGenerarReportePDF_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 57);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 74;
            label3.Text = "N° Reporte";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroReporte
            // 
            txtNumeroReporte.Alpha = 20;
            txtNumeroReporte.BackColor = Color.Transparent;
            txtNumeroReporte.Background_WidthPen = 3F;
            txtNumeroReporte.BackgroundPen = true;
            txtNumeroReporte.ColorBackground = Color.White;
            txtNumeroReporte.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNumeroReporte.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNumeroReporte.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNumeroReporte.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNumeroReporte.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNumeroReporte.Font = new Font("Arial", 8F);
            txtNumeroReporte.ForeColor = Color.Black;
            txtNumeroReporte.Lighting = false;
            txtNumeroReporte.LinearGradientPen = false;
            txtNumeroReporte.Location = new Point(17, 72);
            txtNumeroReporte.Name = "txtNumeroReporte";
            txtNumeroReporte.PenWidth = 15;
            txtNumeroReporte.RGB = false;
            txtNumeroReporte.Rounding = true;
            txtNumeroReporte.RoundingInt = 60;
            txtNumeroReporte.Size = new Size(191, 32);
            txtNumeroReporte.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNumeroReporte.TabIndex = 73;
            txtNumeroReporte.Tag = "Cyber";
            txtNumeroReporte.TextButton = "";
            txtNumeroReporte.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNumeroReporte.Timer_RGB = 300;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.f7__doc_chart;
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
            cyberButton4.Location = new Point(2108, 193);
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
            cyberButton5.Location = new Point(2108, 149);
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
            cyberButton6.Location = new Point(2108, 101);
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
            cyberButton3.Location = new Point(2814, 261);
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
            cyberButton1.Location = new Point(2814, 217);
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
            cyberButton2.Location = new Point(2814, 169);
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
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(362, 52);
            label13.Name = "label13";
            label13.Size = new Size(47, 15);
            label13.TabIndex = 17;
            label13.Text = "Motivo";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(56, 21);
            label12.Name = "label12";
            label12.Size = new Size(148, 20);
            label12.TabIndex = 19;
            label12.Text = "GENERAR REPORTE";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(230, 57);
            label14.Name = "label14";
            label14.Size = new Size(39, 15);
            label14.TabIndex = 15;
            label14.Text = "Fecha";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(motivoReportesBuscar);
            panel3.Controls.Add(dtpFechaReporteBuscar);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(dgvReportes);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(txtNumeroReporteBuscar);
            panel3.Controls.Add(contadorReportes);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label7);
            panel3.EdgeColor = Color.FromArgb(32, 41, 50);
            panel3.Location = new Point(8, 182);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 334);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 61;
            panel3.Text = "panel3";
            panel3.Click += panel3_Click;
            // 
            // dtpFechaReporteBuscar
            // 
            dtpFechaReporteBuscar.Format = DateTimePickerFormat.Custom;
            dtpFechaReporteBuscar.Location = new Point(230, 82);
            dtpFechaReporteBuscar.Name = "dtpFechaReporteBuscar";
            dtpFechaReporteBuscar.Size = new Size(95, 23);
            dtpFechaReporteBuscar.TabIndex = 81;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(362, 61);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 78;
            label2.Text = "Motivo";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.AllowUserToResizeColumns = false;
            dgvReportes.AllowUserToResizeRows = false;
            dgvReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.BackgroundColor = Color.White;
            dgvReportes.BorderStyle = BorderStyle.None;
            dgvReportes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Columns.AddRange(new DataGridViewColumn[] { ColumCodigo, DescripColum, CategoriaColum, eliminarColum });
            dgvReportes.EnableHeadersVisualStyles = false;
            dgvReportes.GridColor = SystemColors.ScrollBar;
            dgvReportes.Location = new Point(17, 163);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.RowHeadersVisible = false;
            dgvReportes.Size = new Size(868, 122);
            dgvReportes.TabIndex = 79;
            // 
            // ColumCodigo
            // 
            ColumCodigo.HeaderText = "N° Reporte";
            ColumCodigo.Name = "ColumCodigo";
            ColumCodigo.ReadOnly = true;
            // 
            // DescripColum
            // 
            DescripColum.HeaderText = "Fecha";
            DescripColum.Name = "DescripColum";
            DescripColum.ReadOnly = true;
            // 
            // CategoriaColum
            // 
            CategoriaColum.HeaderText = "Motivo";
            CategoriaColum.Name = "CategoriaColum";
            CategoriaColum.ReadOnly = true;
            // 
            // eliminarColum
            // 
            eliminarColum.HeaderText = "Detalles";
            eliminarColum.Name = "eliminarColum";
            eliminarColum.ReadOnly = true;
            eliminarColum.Resizable = DataGridViewTriState.True;
            eliminarColum.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.f7__doc_chart;
            button1.Location = new Point(17, 14);
            button1.Name = "button1";
            button1.Size = new Size(34, 26);
            button1.TabIndex = 78;
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(56, 20);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 77;
            label1.Text = "BUSCAR REPORTE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 61);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 75;
            label4.Text = "N° Reporte";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(230, 61);
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
            button5.Location = new Point(646, 82);
            button5.Name = "button5";
            button5.Size = new Size(34, 32);
            button5.TabIndex = 61;
            button5.UseVisualStyleBackColor = false;
            // 
            // txtNumeroReporteBuscar
            // 
            txtNumeroReporteBuscar.Alpha = 20;
            txtNumeroReporteBuscar.BackColor = Color.Transparent;
            txtNumeroReporteBuscar.Background_WidthPen = 3F;
            txtNumeroReporteBuscar.BackgroundPen = true;
            txtNumeroReporteBuscar.ColorBackground = Color.White;
            txtNumeroReporteBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNumeroReporteBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNumeroReporteBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNumeroReporteBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNumeroReporteBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNumeroReporteBuscar.Font = new Font("Arial", 8F);
            txtNumeroReporteBuscar.ForeColor = Color.Black;
            txtNumeroReporteBuscar.Lighting = false;
            txtNumeroReporteBuscar.LinearGradientPen = false;
            txtNumeroReporteBuscar.Location = new Point(20, 79);
            txtNumeroReporteBuscar.Name = "txtNumeroReporteBuscar";
            txtNumeroReporteBuscar.PenWidth = 15;
            txtNumeroReporteBuscar.RGB = false;
            txtNumeroReporteBuscar.Rounding = true;
            txtNumeroReporteBuscar.RoundingInt = 60;
            txtNumeroReporteBuscar.Size = new Size(194, 32);
            txtNumeroReporteBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNumeroReporteBuscar.TabIndex = 63;
            txtNumeroReporteBuscar.Tag = "Cyber";
            txtNumeroReporteBuscar.TextButton = "";
            txtNumeroReporteBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNumeroReporteBuscar.Timer_RGB = 300;
            // 
            // contadorReportes
            // 
            contadorReportes.Alpha = 20;
            contadorReportes.BackColor = Color.Transparent;
            contadorReportes.Background_WidthPen = 3F;
            contadorReportes.BackgroundPen = true;
            contadorReportes.ColorBackground = Color.White;
            contadorReportes.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            contadorReportes.ColorLighting = Color.FromArgb(29, 200, 238);
            contadorReportes.ColorPen_1 = Color.FromArgb(29, 200, 238);
            contadorReportes.ColorPen_2 = Color.FromArgb(37, 52, 68);
            contadorReportes.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            contadorReportes.Enabled = false;
            contadorReportes.Font = new Font("Arial", 8F, FontStyle.Bold);
            contadorReportes.ForeColor = Color.FromArgb(245, 245, 245);
            contadorReportes.Lighting = false;
            contadorReportes.LinearGradientPen = false;
            contadorReportes.Location = new Point(155, 291);
            contadorReportes.Name = "contadorReportes";
            contadorReportes.PenWidth = 15;
            contadorReportes.RGB = false;
            contadorReportes.Rounding = true;
            contadorReportes.RoundingInt = 60;
            contadorReportes.Size = new Size(59, 32);
            contadorReportes.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            contadorReportes.TabIndex = 59;
            contadorReportes.Tag = "Cyber";
            contadorReportes.TextButton = "";
            contadorReportes.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            contadorReportes.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 302);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 58;
            label5.Text = "Cantidad de Reportes:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = Properties.Resources.ant_design__bars_outlined;
            button3.Location = new Point(14, 131);
            button3.Name = "button3";
            button3.Size = new Size(34, 26);
            button3.TabIndex = 14;
            button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(54, 133);
            label7.Name = "label7";
            label7.Size = new Size(149, 20);
            label7.TabIndex = 15;
            label7.Text = "LISTA DE REPORTES";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // motivoReportesBuscar
            // 
            motivoReportesBuscar.BackColor = Color.White;
            motivoReportesBuscar.ColorArrow = Color.FromArgb(252, 173, 159);
            motivoReportesBuscar.ColorBackground = Color.White;
            motivoReportesBuscar.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            motivoReportesBuscar.ColorItemHover = Color.FromArgb(50, 70, 90);
            motivoReportesBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            motivoReportesBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            motivoReportesBuscar.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            motivoReportesBuscar.DrawMode = DrawMode.OwnerDrawFixed;
            motivoReportesBuscar.DropDownStyle = ComboBoxStyle.DropDownList;
            motivoReportesBuscar.FlatStyle = FlatStyle.Flat;
            motivoReportesBuscar.Font = new Font("Arial", 11F);
            motivoReportesBuscar.ForeColor = Color.Black;
            motivoReportesBuscar.FormattingEnabled = true;
            motivoReportesBuscar.ItemHeight = 28;
            motivoReportesBuscar.Items.AddRange(new object[] { "Clientes", "Ventas", "Empleados", "Backups", "Pedidos" });
            motivoReportesBuscar.Location = new Point(362, 80);
            motivoReportesBuscar.Name = "motivoReportesBuscar";
            motivoReportesBuscar.RGB = false;
            motivoReportesBuscar.Size = new Size(269, 34);
            motivoReportesBuscar.TabIndex = 82;
            motivoReportesBuscar.Timer_RGB = 300;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 566);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "FormReportes";
            Text = "FormReportes";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.CyberButton btnCancelar;
        private ReaLTaiizor.Controls.CyberButton btnGenerarReportePDF;
        private Label label3;
        private ReaLTaiizor.Controls.CyberTextBox txtNumeroReporte;
        private Button button6;
        private ReaLTaiizor.Controls.CyberButton cyberButton4;
        private ReaLTaiizor.Controls.CyberButton cyberButton5;
        private ReaLTaiizor.Controls.CyberButton cyberButton6;
        private ReaLTaiizor.Controls.CyberButton cyberButton3;
        private ReaLTaiizor.Controls.CyberButton cyberButton1;
        private ReaLTaiizor.Controls.CyberButton cyberButton2;
        private Label label13;
        private Label label12;
        private Label label14;
        private ReaLTaiizor.Controls.CyberComboBox cbMotivo;
        private ReaLTaiizor.Controls.Panel panel3;
        private Label label4;
        private Label label10;
        private Button button5;
        private ReaLTaiizor.Controls.CyberTextBox txtNumeroReporteBuscar;
        private ReaLTaiizor.Controls.CyberTextBox contadorReportes;
        private Label label5;
        private Button button3;
        private Label label7;
        private Button button1;
        private Label label1;
        private Label label2;
        private DataGridView dgvReportes;
        private DateTimePicker dtpFechaReporte;
        private DateTimePicker dtpFechaReporteBuscar;
        private DataGridViewTextBoxColumn ColumCodigo;
        private DataGridViewTextBoxColumn DescripColum;
        private DataGridViewTextBoxColumn CategoriaColum;
        private DataGridViewButtonColumn eliminarColum;
        private ReaLTaiizor.Controls.CyberComboBox motivoReportesBuscar;
    }
}