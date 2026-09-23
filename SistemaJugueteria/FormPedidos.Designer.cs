namespace SistemaJugueteria
{
    partial class FormPedidos
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
            panel1 = new ReaLTaiizor.Controls.Panel();
            dtpFechaEstimadaPedido = new DateTimePicker();
            dtpFechaRealizacion = new DateTimePicker();
            label3 = new Label();
            label1 = new Label();
            button1 = new Button();
            cyberButton4 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton5 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton6 = new ReaLTaiizor.Controls.CyberButton();
            cbProveedor = new ReaLTaiizor.Controls.CyberComboBox();
            cyberButton3 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton2 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton7 = new ReaLTaiizor.Controls.CyberButton();
            label4 = new Label();
            txtUsuario = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNumeroPedido = new ReaLTaiizor.Controls.CyberTextBox();
            panel3 = new ReaLTaiizor.Controls.Panel();
            cbProveedorBuscar = new ReaLTaiizor.Controls.CyberComboBox();
            dgvListaPedidos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            usuarioColum = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewButtonColumn();
            button2 = new Button();
            label10 = new Label();
            button5 = new Button();
            label9 = new Label();
            txtNumeroPedidoBuscar = new ReaLTaiizor.Controls.CyberTextBox();
            label8 = new Label();
            contadorPedidos = new ReaLTaiizor.Controls.CyberTextBox();
            label2 = new Label();
            button3 = new Button();
            label11 = new Label();
            txtCodigoPedido = new ReaLTaiizor.Controls.CyberTextBox();
            label14 = new Label();
            label12 = new Label();
            txtDescripcionPedido = new ReaLTaiizor.Controls.CyberTextBox();
            button6 = new Button();
            label13 = new Label();
            panel4 = new ReaLTaiizor.Controls.Panel();
            cyberButton1 = new ReaLTaiizor.Controls.CyberButton();
            btnAgregarProducto = new ReaLTaiizor.Controls.CyberButton();
            numCantidad = new ReaLTaiizor.Controls.DungeonNumeric();
            label17 = new Label();
            nombreProducto = new ReaLTaiizor.Controls.CyberTextBox();
            label16 = new Label();
            dgvDetallePedido = new DataGridView();
            ColumCodigo = new DataGridViewTextBoxColumn();
            nomProducto = new DataGridViewTextBoxColumn();
            DescripColum = new DataGridViewTextBoxColumn();
            CategoriaColum = new DataGridViewTextBoxColumn();
            CantidadColum = new DataGridViewTextBoxColumn();
            eliminarColum = new DataGridViewButtonColumn();
            btnConfirmar = new ReaLTaiizor.Controls.CyberButton();
            btnCancelar = new ReaLTaiizor.Controls.CyberButton();
            panel2 = new ReaLTaiizor.Controls.Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaPedidos).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 227, 227);
            panel1.Controls.Add(dtpFechaEstimadaPedido);
            panel1.Controls.Add(dtpFechaRealizacion);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(cyberButton4);
            panel1.Controls.Add(cyberButton5);
            panel1.Controls.Add(cyberButton6);
            panel1.Controls.Add(cbProveedor);
            panel1.Controls.Add(cyberButton3);
            panel1.Controls.Add(cyberButton2);
            panel1.Controls.Add(cyberButton7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtNumeroPedido);
            panel1.EdgeColor = Color.Transparent;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8);
            panel1.Size = new Size(893, 96);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 58;
            panel1.Text = "panel1";
            panel1.Click += panel1_Click;
            // 
            // dtpFechaEstimadaPedido
            // 
            dtpFechaEstimadaPedido.Format = DateTimePickerFormat.Custom;
            dtpFechaEstimadaPedido.Location = new Point(535, 56);
            dtpFechaEstimadaPedido.Name = "dtpFechaEstimadaPedido";
            dtpFechaEstimadaPedido.Size = new Size(95, 23);
            dtpFechaEstimadaPedido.TabIndex = 80;
            // 
            // dtpFechaRealizacion
            // 
            dtpFechaRealizacion.Format = DateTimePickerFormat.Custom;
            dtpFechaRealizacion.Location = new Point(359, 56);
            dtpFechaRealizacion.Name = "dtpFechaRealizacion";
            dtpFechaRealizacion.Size = new Size(95, 23);
            dtpFechaRealizacion.TabIndex = 79;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(359, 38);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 75;
            label3.Text = "Fecha de Realización";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(535, 38);
            label1.Name = "label1";
            label1.Size = new Size(154, 15);
            label1.TabIndex = 73;
            label1.Text = "Fecha Estimada de Entrega";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.akar_icons__shipping_box_01;
            button1.Location = new Point(8, 6);
            button1.Name = "button1";
            button1.Size = new Size(34, 26);
            button1.TabIndex = 72;
            button1.UseVisualStyleBackColor = true;
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
            cyberButton4.Location = new Point(1405, 99);
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
            cyberButton5.Location = new Point(1405, 55);
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
            cyberButton6.Location = new Point(1405, 7);
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
            // cbProveedor
            // 
            cbProveedor.BackColor = Color.White;
            cbProveedor.ColorArrow = Color.FromArgb(252, 173, 159);
            cbProveedor.ColorBackground = Color.White;
            cbProveedor.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            cbProveedor.ColorItemHover = Color.FromArgb(255, 224, 192);
            cbProveedor.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cbProveedor.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cbProveedor.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cbProveedor.DrawMode = DrawMode.OwnerDrawFixed;
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProveedor.FlatStyle = FlatStyle.Flat;
            cbProveedor.Font = new Font("Arial", 11F);
            cbProveedor.ForeColor = Color.Black;
            cbProveedor.FormattingEnabled = true;
            cbProveedor.ItemHeight = 28;
            cbProveedor.Items.AddRange(new object[] { "ToysNet", "Vulcanita", "TecniToys", "Fun express" });
            cbProveedor.Location = new Point(733, 53);
            cbProveedor.Name = "cbProveedor";
            cbProveedor.RGB = false;
            cbProveedor.Size = new Size(149, 34);
            cbProveedor.TabIndex = 69;
            cbProveedor.Timer_RGB = 300;
            cbProveedor.SelectedIndexChanged += cbProveedor_SelectedIndexChanged;
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
            cyberButton3.Location = new Point(2111, 167);
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
            // cyberButton2
            // 
            cyberButton2.Alpha = 20;
            cyberButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton2.BackColor = Color.Transparent;
            cyberButton2.Background = true;
            cyberButton2.Background_WidthPen = 4F;
            cyberButton2.BackgroundPen = true;
            cyberButton2.ColorBackground = Color.FromArgb(128, 128, 255);
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
            cyberButton2.Location = new Point(2111, 123);
            cyberButton2.Name = "cyberButton2";
            cyberButton2.PenWidth = 15;
            cyberButton2.Rounding = true;
            cyberButton2.RoundingInt = 70;
            cyberButton2.Size = new Size(141, 38);
            cyberButton2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton2.TabIndex = 62;
            cyberButton2.Tag = "Cyber";
            cyberButton2.TextButton = "GUARDAR";
            cyberButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton2.Timer_Effect_1 = 5;
            cyberButton2.Timer_RGB = 300;
            // 
            // cyberButton7
            // 
            cyberButton7.Alpha = 20;
            cyberButton7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cyberButton7.BackColor = Color.Transparent;
            cyberButton7.Background = true;
            cyberButton7.Background_WidthPen = 4F;
            cyberButton7.BackgroundPen = true;
            cyberButton7.ColorBackground = Color.FromArgb(0, 192, 0);
            cyberButton7.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberButton7.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberButton7.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            cyberButton7.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberButton7.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberButton7.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberButton7.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberButton7.Effect_1 = true;
            cyberButton7.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            cyberButton7.Effect_1_Transparency = 25;
            cyberButton7.Effect_2 = true;
            cyberButton7.Effect_2_ColorBackground = Color.White;
            cyberButton7.Effect_2_Transparency = 20;
            cyberButton7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cyberButton7.ForeColor = Color.FromArgb(245, 245, 245);
            cyberButton7.Lighting = false;
            cyberButton7.LinearGradient_Background = false;
            cyberButton7.LinearGradientPen = false;
            cyberButton7.Location = new Point(2111, 75);
            cyberButton7.Name = "cyberButton7";
            cyberButton7.PenWidth = 15;
            cyberButton7.Rounding = true;
            cyberButton7.RoundingInt = 70;
            cyberButton7.Size = new Size(141, 38);
            cyberButton7.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton7.TabIndex = 61;
            cyberButton7.Tag = "Cyber";
            cyberButton7.TextButton = "NUEVO";
            cyberButton7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton7.Timer_Effect_1 = 5;
            cyberButton7.Timer_RGB = 300;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(734, 35);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 27;
            label4.Text = "Proveedor";
            label4.TextAlign = ContentAlignment.MiddleCenter;
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
            txtUsuario.Location = new Point(175, 53);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PenWidth = 15;
            txtUsuario.RGB = false;
            txtUsuario.Rounding = true;
            txtUsuario.RoundingInt = 60;
            txtUsuario.Size = new Size(160, 32);
            txtUsuario.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtUsuario.TabIndex = 20;
            txtUsuario.Tag = "Cyber";
            txtUsuario.TextButton = "";
            txtUsuario.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtUsuario.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(179, 38);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 17;
            label5.Text = "Usuario";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(48, 12);
            label6.Name = "label6";
            label6.Size = new Size(147, 20);
            label6.TabIndex = 19;
            label6.Text = "DATOS DEL PEDIDO";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(11, 38);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 15;
            label7.Text = "N° Pedido";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroPedido
            // 
            txtNumeroPedido.Alpha = 20;
            txtNumeroPedido.BackColor = Color.Transparent;
            txtNumeroPedido.Background_WidthPen = 3F;
            txtNumeroPedido.BackgroundPen = true;
            txtNumeroPedido.ColorBackground = Color.White;
            txtNumeroPedido.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNumeroPedido.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNumeroPedido.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNumeroPedido.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNumeroPedido.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNumeroPedido.Font = new Font("Arial", 8F);
            txtNumeroPedido.ForeColor = Color.Black;
            txtNumeroPedido.Lighting = false;
            txtNumeroPedido.LinearGradientPen = false;
            txtNumeroPedido.Location = new Point(8, 53);
            txtNumeroPedido.Name = "txtNumeroPedido";
            txtNumeroPedido.PenWidth = 15;
            txtNumeroPedido.RGB = false;
            txtNumeroPedido.Rounding = true;
            txtNumeroPedido.RoundingInt = 60;
            txtNumeroPedido.Size = new Size(152, 32);
            txtNumeroPedido.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNumeroPedido.TabIndex = 14;
            txtNumeroPedido.Tag = "Cyber";
            txtNumeroPedido.TextButton = "";
            txtNumeroPedido.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNumeroPedido.Timer_RGB = 300;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(cbProveedorBuscar);
            panel3.Controls.Add(dgvListaPedidos);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(txtNumeroPedidoBuscar);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(contadorPedidos);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label11);
            panel3.EdgeColor = Color.Transparent;
            panel3.Location = new Point(12, 393);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 223);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 59;
            panel3.Text = "panel3";
            panel3.Click += panel3_Click;
            // 
            // cbProveedorBuscar
            // 
            cbProveedorBuscar.BackColor = Color.White;
            cbProveedorBuscar.ColorArrow = Color.FromArgb(252, 173, 159);
            cbProveedorBuscar.ColorBackground = Color.White;
            cbProveedorBuscar.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            cbProveedorBuscar.ColorItemHover = Color.FromArgb(50, 70, 90);
            cbProveedorBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cbProveedorBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cbProveedorBuscar.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cbProveedorBuscar.DrawMode = DrawMode.OwnerDrawFixed;
            cbProveedorBuscar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProveedorBuscar.FlatStyle = FlatStyle.Flat;
            cbProveedorBuscar.Font = new Font("Arial", 11F);
            cbProveedorBuscar.ForeColor = Color.Black;
            cbProveedorBuscar.FormattingEnabled = true;
            cbProveedorBuscar.ItemHeight = 28;
            cbProveedorBuscar.Items.AddRange(new object[] { "ToysNet", "Vulcanita", "TecniToys", "Fun express" });
            cbProveedorBuscar.Location = new Point(379, 31);
            cbProveedorBuscar.Name = "cbProveedorBuscar";
            cbProveedorBuscar.RGB = false;
            cbProveedorBuscar.Size = new Size(149, 34);
            cbProveedorBuscar.TabIndex = 74;
            cbProveedorBuscar.Timer_RGB = 300;
            // 
            // dgvListaPedidos
            // 
            dgvListaPedidos.AllowUserToAddRows = false;
            dgvListaPedidos.AllowUserToDeleteRows = false;
            dgvListaPedidos.AllowUserToResizeColumns = false;
            dgvListaPedidos.AllowUserToResizeRows = false;
            dgvListaPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaPedidos.BackgroundColor = Color.White;
            dgvListaPedidos.BorderStyle = BorderStyle.None;
            dgvListaPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvListaPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaPedidos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, usuarioColum, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvListaPedidos.EnableHeadersVisualStyles = false;
            dgvListaPedidos.GridColor = SystemColors.ScrollBar;
            dgvListaPedidos.Location = new Point(14, 92);
            dgvListaPedidos.Name = "dgvListaPedidos";
            dgvListaPedidos.ReadOnly = true;
            dgvListaPedidos.RowHeadersVisible = false;
            dgvListaPedidos.Size = new Size(868, 83);
            dgvListaPedidos.TabIndex = 66;
            dgvListaPedidos.CellClick += dgvListaPedidos_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Numero";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // usuarioColum
            // 
            usuarioColum.HeaderText = "Usuario";
            usuarioColum.Name = "usuarioColum";
            usuarioColum.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Fecha Realización";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Fecha Estimada Entrega";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Proveedor";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Eliminar";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.akar_icons__shipping_box_01;
            button2.Location = new Point(14, 6);
            button2.Name = "button2";
            button2.Size = new Size(34, 26);
            button2.TabIndex = 73;
            button2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(307, 40);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 60;
            label10.Text = "Proveedor";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 227, 227);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.boxicons__search_alt;
            button5.Location = new Point(591, 31);
            button5.Name = "button5";
            button5.Size = new Size(34, 32);
            button5.TabIndex = 61;
            button5.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(19, 40);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 64;
            label9.Text = "N° Pedido";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroPedidoBuscar
            // 
            txtNumeroPedidoBuscar.Alpha = 20;
            txtNumeroPedidoBuscar.BackColor = Color.Transparent;
            txtNumeroPedidoBuscar.Background_WidthPen = 3F;
            txtNumeroPedidoBuscar.BackgroundPen = true;
            txtNumeroPedidoBuscar.ColorBackground = Color.White;
            txtNumeroPedidoBuscar.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtNumeroPedidoBuscar.ColorLighting = Color.FromArgb(29, 200, 238);
            txtNumeroPedidoBuscar.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtNumeroPedidoBuscar.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtNumeroPedidoBuscar.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtNumeroPedidoBuscar.Font = new Font("Arial", 8F);
            txtNumeroPedidoBuscar.ForeColor = Color.Black;
            txtNumeroPedidoBuscar.Lighting = false;
            txtNumeroPedidoBuscar.LinearGradientPen = false;
            txtNumeroPedidoBuscar.Location = new Point(87, 31);
            txtNumeroPedidoBuscar.Name = "txtNumeroPedidoBuscar";
            txtNumeroPedidoBuscar.PenWidth = 15;
            txtNumeroPedidoBuscar.RGB = false;
            txtNumeroPedidoBuscar.Rounding = true;
            txtNumeroPedidoBuscar.RoundingInt = 60;
            txtNumeroPedidoBuscar.Size = new Size(194, 32);
            txtNumeroPedidoBuscar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtNumeroPedidoBuscar.TabIndex = 63;
            txtNumeroPedidoBuscar.Tag = "Cyber";
            txtNumeroPedidoBuscar.TextButton = "";
            txtNumeroPedidoBuscar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtNumeroPedidoBuscar.Timer_RGB = 300;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(48, 8);
            label8.Name = "label8";
            label8.Size = new Size(127, 20);
            label8.TabIndex = 65;
            label8.Text = "BUSCAR PEDIDO";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Click += label8_Click;
            // 
            // contadorPedidos
            // 
            contadorPedidos.Alpha = 20;
            contadorPedidos.BackColor = Color.Transparent;
            contadorPedidos.Background_WidthPen = 3F;
            contadorPedidos.BackgroundPen = true;
            contadorPedidos.ColorBackground = Color.White;
            contadorPedidos.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            contadorPedidos.ColorLighting = Color.FromArgb(29, 200, 238);
            contadorPedidos.ColorPen_1 = Color.FromArgb(29, 200, 238);
            contadorPedidos.ColorPen_2 = Color.FromArgb(37, 52, 68);
            contadorPedidos.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            contadorPedidos.Enabled = false;
            contadorPedidos.Font = new Font("Arial", 8F, FontStyle.Bold);
            contadorPedidos.ForeColor = Color.Black;
            contadorPedidos.Lighting = false;
            contadorPedidos.LinearGradientPen = false;
            contadorPedidos.Location = new Point(150, 181);
            contadorPedidos.Name = "contadorPedidos";
            contadorPedidos.PenWidth = 15;
            contadorPedidos.RGB = false;
            contadorPedidos.Rounding = true;
            contadorPedidos.RoundingInt = 60;
            contadorPedidos.Size = new Size(59, 32);
            contadorPedidos.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            contadorPedidos.TabIndex = 59;
            contadorPedidos.Tag = "Cyber";
            contadorPedidos.TextButton = "";
            contadorPedidos.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            contadorPedidos.Timer_RGB = 300;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 193);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 58;
            label2.Text = "Cantidad de Productos:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = Properties.Resources.ant_design__bars_outlined;
            button3.Location = new Point(10, 60);
            button3.Name = "button3";
            button3.Size = new Size(32, 26);
            button3.TabIndex = 14;
            button3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(48, 66);
            label11.Name = "label11";
            label11.Size = new Size(139, 20);
            label11.TabIndex = 15;
            label11.Text = "LISTA DE PEDIDOS";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCodigoPedido
            // 
            txtCodigoPedido.Alpha = 20;
            txtCodigoPedido.BackColor = Color.Transparent;
            txtCodigoPedido.Background_WidthPen = 3F;
            txtCodigoPedido.BackgroundPen = true;
            txtCodigoPedido.ColorBackground = Color.White;
            txtCodigoPedido.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtCodigoPedido.ColorLighting = Color.FromArgb(29, 200, 238);
            txtCodigoPedido.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtCodigoPedido.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtCodigoPedido.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtCodigoPedido.Font = new Font("Arial", 8F);
            txtCodigoPedido.ForeColor = Color.Black;
            txtCodigoPedido.Lighting = false;
            txtCodigoPedido.LinearGradientPen = false;
            txtCodigoPedido.Location = new Point(66, 35);
            txtCodigoPedido.Name = "txtCodigoPedido";
            txtCodigoPedido.PenWidth = 15;
            txtCodigoPedido.RGB = false;
            txtCodigoPedido.Rounding = true;
            txtCodigoPedido.RoundingInt = 60;
            txtCodigoPedido.Size = new Size(143, 32);
            txtCodigoPedido.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtCodigoPedido.TabIndex = 56;
            txtCodigoPedido.Tag = "Cyber";
            txtCodigoPedido.TextButton = "";
            txtCodigoPedido.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtCodigoPedido.Timer_RGB = 300;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(15, 45);
            label14.Name = "label14";
            label14.Size = new Size(45, 15);
            label14.TabIndex = 57;
            label14.Text = "Codigo";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(48, 12);
            label12.Name = "label12";
            label12.Size = new Size(172, 20);
            label12.TabIndex = 62;
            label12.Text = "DATOS DEL PRODUCTO";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDescripcionPedido
            // 
            txtDescripcionPedido.Alpha = 20;
            txtDescripcionPedido.BackColor = Color.Transparent;
            txtDescripcionPedido.Background_WidthPen = 3F;
            txtDescripcionPedido.BackgroundPen = true;
            txtDescripcionPedido.ColorBackground = Color.White;
            txtDescripcionPedido.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDescripcionPedido.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDescripcionPedido.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDescripcionPedido.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDescripcionPedido.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDescripcionPedido.Font = new Font("Arial", 8F);
            txtDescripcionPedido.ForeColor = Color.Black;
            txtDescripcionPedido.Lighting = false;
            txtDescripcionPedido.LinearGradientPen = false;
            txtDescripcionPedido.Location = new Point(318, 35);
            txtDescripcionPedido.Name = "txtDescripcionPedido";
            txtDescripcionPedido.PenWidth = 15;
            txtDescripcionPedido.RGB = false;
            txtDescripcionPedido.Rounding = true;
            txtDescripcionPedido.RoundingInt = 60;
            txtDescripcionPedido.Size = new Size(349, 32);
            txtDescripcionPedido.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDescripcionPedido.TabIndex = 58;
            txtDescripcionPedido.Tag = "Cyber";
            txtDescripcionPedido.TextButton = "";
            txtDescripcionPedido.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDescripcionPedido.Timer_RGB = 300;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.akar_icons__shipping_box_01;
            button6.Location = new Point(8, 6);
            button6.Name = "button6";
            button6.Size = new Size(34, 26);
            button6.TabIndex = 61;
            button6.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(240, 45);
            label13.Name = "label13";
            label13.Size = new Size(72, 15);
            label13.TabIndex = 59;
            label13.Text = "Descripción";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(255, 200, 200);
            panel4.Controls.Add(cyberButton1);
            panel4.Controls.Add(btnAgregarProducto);
            panel4.Controls.Add(numCantidad);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(nombreProducto);
            panel4.Controls.Add(label16);
            panel4.EdgeColor = Color.Transparent;
            panel4.Location = new Point(14, 73);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(8);
            panel4.Size = new Size(868, 62);
            panel4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel4.TabIndex = 63;
            panel4.Text = "panel4";
            // 
            // cyberButton1
            // 
            cyberButton1.Alpha = 20;
            cyberButton1.BackColor = Color.Transparent;
            cyberButton1.Background = true;
            cyberButton1.Background_WidthPen = 4F;
            cyberButton1.BackgroundPen = true;
            cyberButton1.ColorBackground = Color.FromArgb(255, 128, 128);
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
            cyberButton1.Location = new Point(589, 21);
            cyberButton1.Name = "cyberButton1";
            cyberButton1.PenWidth = 15;
            cyberButton1.Rounding = true;
            cyberButton1.RoundingInt = 70;
            cyberButton1.Size = new Size(112, 32);
            cyberButton1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton1.TabIndex = 66;
            cyberButton1.Tag = "Cyber";
            cyberButton1.TextButton = "CANCELAR";
            cyberButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton1.Timer_Effect_1 = 5;
            cyberButton1.Timer_RGB = 300;
            cyberButton1.Click += cyberButton1_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Alpha = 20;
            btnAgregarProducto.BackColor = Color.Transparent;
            btnAgregarProducto.Background = true;
            btnAgregarProducto.Background_WidthPen = 4F;
            btnAgregarProducto.BackgroundPen = true;
            btnAgregarProducto.ColorBackground = Color.FromArgb(0, 192, 0);
            btnAgregarProducto.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnAgregarProducto.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnAgregarProducto.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnAgregarProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            btnAgregarProducto.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnAgregarProducto.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnAgregarProducto.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnAgregarProducto.Effect_1 = true;
            btnAgregarProducto.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnAgregarProducto.Effect_1_Transparency = 25;
            btnAgregarProducto.Effect_2 = true;
            btnAgregarProducto.Effect_2_ColorBackground = Color.White;
            btnAgregarProducto.Effect_2_Transparency = 20;
            btnAgregarProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarProducto.ForeColor = Color.FromArgb(245, 245, 245);
            btnAgregarProducto.Lighting = false;
            btnAgregarProducto.LinearGradient_Background = false;
            btnAgregarProducto.LinearGradientPen = false;
            btnAgregarProducto.Location = new Point(471, 21);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.PenWidth = 15;
            btnAgregarProducto.Rounding = true;
            btnAgregarProducto.RoundingInt = 70;
            btnAgregarProducto.Size = new Size(112, 32);
            btnAgregarProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnAgregarProducto.TabIndex = 55;
            btnAgregarProducto.Tag = "Cyber";
            btnAgregarProducto.TextButton = "AGREGAR";
            btnAgregarProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnAgregarProducto.Timer_Effect_1 = 5;
            btnAgregarProducto.Timer_RGB = 300;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // numCantidad
            // 
            numCantidad.BackColor = Color.Transparent;
            numCantidad.BackColorA = Color.FromArgb(246, 246, 246);
            numCantidad.BackColorB = Color.FromArgb(254, 254, 254);
            numCantidad.BorderColor = Color.FromArgb(180, 180, 180);
            numCantidad.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            numCantidad.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            numCantidad.Font = new Font("Tahoma", 11F);
            numCantidad.ForeColor = Color.FromArgb(76, 76, 76);
            numCantidad.Location = new Point(345, 23);
            numCantidad.Maximum = 100L;
            numCantidad.Minimum = 0L;
            numCantidad.MinimumSize = new Size(93, 28);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(108, 28);
            numCantidad.TabIndex = 55;
            numCantidad.Text = "dungeonNumeric1";
            numCantidad.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            numCantidad.Value = 0L;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(345, 8);
            label17.Name = "label17";
            label17.Size = new Size(55, 15);
            label17.TabIndex = 59;
            label17.Text = "Cantidad";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nombreProducto
            // 
            nombreProducto.Alpha = 20;
            nombreProducto.BackColor = Color.Transparent;
            nombreProducto.Background_WidthPen = 3F;
            nombreProducto.BackgroundPen = true;
            nombreProducto.ColorBackground = Color.White;
            nombreProducto.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            nombreProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            nombreProducto.ColorPen_1 = Color.FromArgb(29, 200, 238);
            nombreProducto.ColorPen_2 = Color.FromArgb(37, 52, 68);
            nombreProducto.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            nombreProducto.Font = new Font("Arial", 8F);
            nombreProducto.ForeColor = Color.Black;
            nombreProducto.Lighting = false;
            nombreProducto.LinearGradientPen = false;
            nombreProducto.Location = new Point(11, 21);
            nombreProducto.Name = "nombreProducto";
            nombreProducto.PenWidth = 15;
            nombreProducto.RGB = false;
            nombreProducto.Rounding = true;
            nombreProducto.RoundingInt = 60;
            nombreProducto.Size = new Size(310, 32);
            nombreProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            nombreProducto.TabIndex = 55;
            nombreProducto.Tag = "Cyber";
            nombreProducto.TextButton = "";
            nombreProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            nombreProducto.Timer_RGB = 300;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(14, 8);
            label16.Name = "label16";
            label16.Size = new Size(127, 15);
            label16.TabIndex = 56;
            label16.Text = "Nombre del producto";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.AllowUserToDeleteRows = false;
            dgvDetallePedido.AllowUserToResizeColumns = false;
            dgvDetallePedido.AllowUserToResizeRows = false;
            dgvDetallePedido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallePedido.BackgroundColor = Color.White;
            dgvDetallePedido.BorderStyle = BorderStyle.None;
            dgvDetallePedido.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Columns.AddRange(new DataGridViewColumn[] { ColumCodigo, nomProducto, DescripColum, CategoriaColum, CantidadColum, eliminarColum });
            dgvDetallePedido.EnableHeadersVisualStyles = false;
            dgvDetallePedido.GridColor = SystemColors.ScrollBar;
            dgvDetallePedido.Location = new Point(14, 141);
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.RowHeadersVisible = false;
            dgvDetallePedido.Size = new Size(868, 83);
            dgvDetallePedido.TabIndex = 64;
            dgvDetallePedido.CellClick += dgvDetallePedido_CellClick;
            // 
            // ColumCodigo
            // 
            ColumCodigo.HeaderText = "Codigo";
            ColumCodigo.Name = "ColumCodigo";
            ColumCodigo.ReadOnly = true;
            // 
            // nomProducto
            // 
            nomProducto.HeaderText = "Nombre";
            nomProducto.Name = "nomProducto";
            nomProducto.ReadOnly = true;
            // 
            // DescripColum
            // 
            DescripColum.HeaderText = "Descripción";
            DescripColum.Name = "DescripColum";
            DescripColum.ReadOnly = true;
            // 
            // CategoriaColum
            // 
            CategoriaColum.HeaderText = "Categoria";
            CategoriaColum.Name = "CategoriaColum";
            CategoriaColum.ReadOnly = true;
            // 
            // CantidadColum
            // 
            CantidadColum.HeaderText = "Cantidad";
            CantidadColum.Name = "CantidadColum";
            CantidadColum.ReadOnly = true;
            // 
            // eliminarColum
            // 
            eliminarColum.HeaderText = "Eliminar";
            eliminarColum.Name = "eliminarColum";
            eliminarColum.ReadOnly = true;
            eliminarColum.Resizable = DataGridViewTriState.True;
            eliminarColum.SortMode = DataGridViewColumnSortMode.Automatic;
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
            btnConfirmar.Location = new Point(11, 235);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.PenWidth = 15;
            btnConfirmar.Rounding = true;
            btnConfirmar.RoundingInt = 70;
            btnConfirmar.Size = new Size(112, 32);
            btnConfirmar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnConfirmar.TabIndex = 60;
            btnConfirmar.Tag = "Cyber";
            btnConfirmar.TextButton = "CONFIRMAR";
            btnConfirmar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnConfirmar.Timer_Effect_1 = 5;
            btnConfirmar.Timer_RGB = 300;
            btnConfirmar.Click += btnConfirmar_Click;
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
            btnCancelar.Location = new Point(129, 235);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.PenWidth = 15;
            btnCancelar.Rounding = true;
            btnCancelar.RoundingInt = 70;
            btnCancelar.Size = new Size(112, 32);
            btnCancelar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnCancelar.TabIndex = 65;
            btnCancelar.Tag = "Cyber";
            btnCancelar.TextButton = "CANCELAR";
            btnCancelar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnCancelar.Timer_Effect_1 = 5;
            btnCancelar.Timer_RGB = 300;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnConfirmar);
            panel2.Controls.Add(dgvDetallePedido);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(txtDescripcionPedido);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(txtCodigoPedido);
            panel2.EdgeColor = Color.Transparent;
            panel2.Location = new Point(12, 114);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(893, 273);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 55;
            panel2.Text = "panel2";
            // 
            // FormPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 623);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "FormPedidos";
            Text = "FormPedidos";
            Load += FormPedidos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaPedidos).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.Panel panel1;
        private Button button1;
        private ReaLTaiizor.Controls.CyberButton cyberButton4;
        private ReaLTaiizor.Controls.CyberButton cyberButton5;
        private ReaLTaiizor.Controls.CyberButton cyberButton6;
        private ReaLTaiizor.Controls.CyberComboBox cbProveedor;
        private ReaLTaiizor.Controls.CyberButton cyberButton3;
        private ReaLTaiizor.Controls.CyberButton cyberButton2;
        private ReaLTaiizor.Controls.CyberButton cyberButton7;
        private Label label4;
        private Label label6;
        private Label label7;
        private ReaLTaiizor.Controls.CyberTextBox txtNumeroPedido;
        private Label label1;
        private Label label3;
        private ReaLTaiizor.Controls.Panel panel3;
        private Button button2;
        private Label label10;
        private Button button5;
        private Label label9;
        private ReaLTaiizor.Controls.CyberTextBox txtNumeroPedidoBuscar;
        private Label label8;
        private ReaLTaiizor.Controls.CyberTextBox contadorPedidos;
        private Label label2;
        private Button button3;
        private Label label11;
        private DataGridView dgvListaPedidos;
        private ReaLTaiizor.Controls.CyberTextBox txtUsuario;
        private Label label5;
        private ReaLTaiizor.Controls.CyberComboBox cbProveedorBuscar;
        private DateTimePicker dtpFechaEstimadaPedido;
        private DateTimePicker dtpFechaRealizacion;
        private ReaLTaiizor.Controls.CyberTextBox txtCodigoPedido;
        private Label label14;
        private Label label12;
        private ReaLTaiizor.Controls.CyberTextBox txtDescripcionPedido;
        private Button button6;
        private Label label13;
        private ReaLTaiizor.Controls.Panel panel4;
        private ReaLTaiizor.Controls.CyberButton btnAgregarProducto;
        private ReaLTaiizor.Controls.DungeonNumeric numCantidad;
        private Label label17;
        private ReaLTaiizor.Controls.CyberTextBox nombreProducto;
        private Label label16;
        private DataGridView dgvDetallePedido;
        private ReaLTaiizor.Controls.CyberButton btnConfirmar;
        private ReaLTaiizor.Controls.CyberButton btnCancelar;
        private ReaLTaiizor.Controls.Panel panel2;
        private DataGridViewTextBoxColumn ColumCodigo;
        private DataGridViewTextBoxColumn nomProducto;
        private DataGridViewTextBoxColumn DescripColum;
        private DataGridViewTextBoxColumn CategoriaColum;
        private DataGridViewTextBoxColumn CantidadColum;
        private DataGridViewButtonColumn eliminarColum;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn usuarioColum;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn dataGridViewTextBoxColumn5;
        private ReaLTaiizor.Controls.CyberButton cyberButton1;
    }
}