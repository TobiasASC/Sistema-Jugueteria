namespace SistemaJugueteria
{
    partial class FormProductos
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
            dgvProductos = new DataGridView();
            ColumCodigo = new DataGridViewTextBoxColumn();
            DescripColum = new DataGridViewTextBoxColumn();
            CategoriaColum = new DataGridViewTextBoxColumn();
            precioColum = new DataGridViewTextBoxColumn();
            StockColum = new DataGridViewTextBoxColumn();
            ColumStockM = new DataGridViewTextBoxColumn();
            columModificar = new DataGridViewButtonColumn();
            columEliminar = new DataGridViewButtonColumn();
            button1 = new Button();
            label10 = new Label();
            cyberTextBox7 = new ReaLTaiizor.Controls.CyberTextBox();
            button5 = new Button();
            label9 = new Label();
            cyberTextBox6 = new ReaLTaiizor.Controls.CyberTextBox();
            label8 = new Label();
            txtCantidadProductos = new ReaLTaiizor.Controls.CyberTextBox();
            label5 = new Label();
            button3 = new Button();
            label7 = new Label();
            panel2 = new ReaLTaiizor.Controls.Panel();
            cyberButton4 = new ReaLTaiizor.Controls.CyberButton();
            button6 = new Button();
            stockMinimo = new ReaLTaiizor.Controls.DungeonNumeric();
            btnGuardar = new ReaLTaiizor.Controls.CyberButton();
            stockActual = new ReaLTaiizor.Controls.DungeonNumeric();
            btnLimpiarProducto = new ReaLTaiizor.Controls.CyberButton();
            categoriaProducto = new ReaLTaiizor.Controls.CyberComboBox();
            cyberButton3 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton1 = new ReaLTaiizor.Controls.CyberButton();
            cyberButton2 = new ReaLTaiizor.Controls.CyberButton();
            label4 = new Label();
            label3 = new Label();
            txtPrecioProducto = new ReaLTaiizor.Controls.CyberTextBox();
            label2 = new Label();
            label1 = new Label();
            txtDescripcionProducto = new ReaLTaiizor.Controls.CyberTextBox();
            label13 = new Label();
            label12 = new Label();
            label14 = new Label();
            txtCodigoProducto = new ReaLTaiizor.Controls.CyberTextBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(255, 227, 227);
            panel3.Controls.Add(dgvProductos);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(cyberTextBox7);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(cyberTextBox6);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtCantidadProductos);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label7);
            panel3.EdgeColor = Color.FromArgb(32, 41, 50);
            panel3.Location = new Point(8, 206);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(893, 334);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 58;
            panel3.Text = "panel3";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { ColumCodigo, DescripColum, CategoriaColum, precioColum, StockColum, ColumStockM, columModificar, columEliminar });
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = SystemColors.ScrollBar;
            dgvProductos.Location = new Point(17, 160);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.Size = new Size(868, 122);
            dgvProductos.TabIndex = 74;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // ColumCodigo
            // 
            ColumCodigo.HeaderText = "Codigo";
            ColumCodigo.Name = "ColumCodigo";
            ColumCodigo.ReadOnly = true;
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
            // precioColum
            // 
            precioColum.HeaderText = "Precio";
            precioColum.Name = "precioColum";
            precioColum.ReadOnly = true;
            // 
            // StockColum
            // 
            StockColum.HeaderText = "Stock Actual";
            StockColum.Name = "StockColum";
            StockColum.ReadOnly = true;
            // 
            // ColumStockM
            // 
            ColumStockM.HeaderText = "Stock Minimo";
            ColumStockM.Name = "ColumStockM";
            ColumStockM.ReadOnly = true;
            // 
            // columModificar
            // 
            columModificar.HeaderText = "Modificar";
            columModificar.Name = "columModificar";
            columModificar.ReadOnly = true;
            columModificar.Resizable = DataGridViewTriState.True;
            columModificar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // columEliminar
            // 
            columEliminar.HeaderText = "Eliminar";
            columEliminar.Name = "columEliminar";
            columEliminar.ReadOnly = true;
            columEliminar.Resizable = DataGridViewTriState.True;
            columEliminar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.akar_icons__shipping_box_01;
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
            label10.Location = new Point(246, 61);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 60;
            label10.Text = "Descripción";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cyberTextBox7
            // 
            cyberTextBox7.Alpha = 20;
            cyberTextBox7.BackColor = Color.Transparent;
            cyberTextBox7.Background_WidthPen = 3F;
            cyberTextBox7.BackgroundPen = true;
            cyberTextBox7.ColorBackground = Color.White;
            cyberTextBox7.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            cyberTextBox7.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox7.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberTextBox7.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberTextBox7.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox7.Font = new Font("Arial", 8F);
            cyberTextBox7.ForeColor = Color.Black;
            cyberTextBox7.Lighting = false;
            cyberTextBox7.LinearGradientPen = false;
            cyberTextBox7.Location = new Point(242, 79);
            cyberTextBox7.Name = "cyberTextBox7";
            cyberTextBox7.PenWidth = 15;
            cyberTextBox7.RGB = false;
            cyberTextBox7.Rounding = true;
            cyberTextBox7.RoundingInt = 60;
            cyberTextBox7.Size = new Size(358, 32);
            cyberTextBox7.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox7.TabIndex = 66;
            cyberTextBox7.Tag = "Cyber";
            cyberTextBox7.TextButton = "";
            cyberTextBox7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox7.Timer_RGB = 300;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 227, 227);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources.boxicons__search_alt;
            button5.Location = new Point(618, 79);
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
            label9.Size = new Size(45, 15);
            label9.TabIndex = 64;
            label9.Text = "Codigo";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cyberTextBox6
            // 
            cyberTextBox6.Alpha = 20;
            cyberTextBox6.BackColor = Color.Transparent;
            cyberTextBox6.Background_WidthPen = 3F;
            cyberTextBox6.BackgroundPen = true;
            cyberTextBox6.ColorBackground = Color.White;
            cyberTextBox6.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            cyberTextBox6.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox6.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberTextBox6.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberTextBox6.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox6.Font = new Font("Arial", 8F);
            cyberTextBox6.ForeColor = Color.Black;
            cyberTextBox6.Lighting = false;
            cyberTextBox6.LinearGradientPen = false;
            cyberTextBox6.Location = new Point(20, 79);
            cyberTextBox6.Name = "cyberTextBox6";
            cyberTextBox6.PenWidth = 15;
            cyberTextBox6.RGB = false;
            cyberTextBox6.Rounding = true;
            cyberTextBox6.RoundingInt = 60;
            cyberTextBox6.Size = new Size(194, 32);
            cyberTextBox6.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox6.TabIndex = 63;
            cyberTextBox6.Tag = "Cyber";
            cyberTextBox6.TextButton = "";
            cyberTextBox6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox6.Timer_RGB = 300;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(57, 28);
            label8.Name = "label8";
            label8.Size = new Size(152, 20);
            label8.TabIndex = 65;
            label8.Text = "BUSCAR PRODUCTO";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCantidadProductos
            // 
            txtCantidadProductos.Alpha = 20;
            txtCantidadProductos.BackColor = Color.Transparent;
            txtCantidadProductos.Background_WidthPen = 3F;
            txtCantidadProductos.BackgroundPen = true;
            txtCantidadProductos.ColorBackground = Color.White;
            txtCantidadProductos.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtCantidadProductos.ColorLighting = Color.FromArgb(29, 200, 238);
            txtCantidadProductos.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtCantidadProductos.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtCantidadProductos.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtCantidadProductos.Enabled = false;
            txtCantidadProductos.Font = new Font("Arial", 8F, FontStyle.Bold);
            txtCantidadProductos.ForeColor = Color.Black;
            txtCantidadProductos.Lighting = false;
            txtCantidadProductos.LinearGradientPen = false;
            txtCantidadProductos.Location = new Point(155, 291);
            txtCantidadProductos.Name = "txtCantidadProductos";
            txtCantidadProductos.PenWidth = 15;
            txtCantidadProductos.RGB = false;
            txtCantidadProductos.Rounding = true;
            txtCantidadProductos.RoundingInt = 60;
            txtCantidadProductos.Size = new Size(59, 32);
            txtCantidadProductos.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtCantidadProductos.TabIndex = 59;
            txtCantidadProductos.Tag = "Cyber";
            txtCantidadProductos.TextButton = "";
            txtCantidadProductos.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtCantidadProductos.Timer_RGB = 300;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 300);
            label5.Name = "label5";
            label5.Size = new Size(134, 15);
            label5.TabIndex = 58;
            label5.Text = "Cantidad de Productos:";
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
            label7.Text = "LISTA DE PRODUCTOS";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 227, 227);
            panel2.Controls.Add(cyberButton4);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(stockMinimo);
            panel2.Controls.Add(btnGuardar);
            panel2.Controls.Add(stockActual);
            panel2.Controls.Add(btnLimpiarProducto);
            panel2.Controls.Add(categoriaProducto);
            panel2.Controls.Add(cyberButton3);
            panel2.Controls.Add(cyberButton1);
            panel2.Controls.Add(cyberButton2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtPrecioProducto);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtDescripcionProducto);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(txtCodigoProducto);
            panel2.EdgeColor = Color.FromArgb(32, 41, 50);
            panel2.Location = new Point(8, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(893, 188);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 57;
            panel2.Text = "panel2";
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
            cyberButton4.Location = new Point(702, 132);
            cyberButton4.Name = "cyberButton4";
            cyberButton4.PenWidth = 15;
            cyberButton4.Rounding = true;
            cyberButton4.RoundingInt = 70;
            cyberButton4.Size = new Size(141, 38);
            cyberButton4.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberButton4.TabIndex = 73;
            cyberButton4.Tag = "Cyber";
            cyberButton4.TextButton = "CANCELAR";
            cyberButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberButton4.Timer_Effect_1 = 5;
            cyberButton4.Timer_RGB = 300;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.akar_icons__shipping_box_01;
            button6.Location = new Point(17, 15);
            button6.Name = "button6";
            button6.Size = new Size(34, 26);
            button6.TabIndex = 72;
            button6.UseVisualStyleBackColor = true;
            // 
            // stockMinimo
            // 
            stockMinimo.BackColor = Color.Transparent;
            stockMinimo.BackColorA = Color.FromArgb(246, 246, 246);
            stockMinimo.BackColorB = Color.FromArgb(254, 254, 254);
            stockMinimo.BorderColor = Color.FromArgb(180, 180, 180);
            stockMinimo.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            stockMinimo.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            stockMinimo.Font = new Font("Tahoma", 11F);
            stockMinimo.ForeColor = Color.FromArgb(76, 76, 76);
            stockMinimo.Location = new Point(473, 72);
            stockMinimo.Maximum = 100L;
            stockMinimo.Minimum = 0L;
            stockMinimo.MinimumSize = new Size(93, 28);
            stockMinimo.Name = "stockMinimo";
            stockMinimo.Size = new Size(188, 28);
            stockMinimo.TabIndex = 71;
            stockMinimo.Text = "dungeonNumeric2";
            stockMinimo.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            stockMinimo.Value = 0L;
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
            btnGuardar.Location = new Point(702, 88);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.PenWidth = 15;
            btnGuardar.Rounding = true;
            btnGuardar.RoundingInt = 70;
            btnGuardar.Size = new Size(141, 38);
            btnGuardar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnGuardar.TabIndex = 64;
            btnGuardar.Tag = "Cyber";
            btnGuardar.TextButton = "GUARDAR";
            btnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnGuardar.Timer_Effect_1 = 5;
            btnGuardar.Timer_RGB = 300;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // stockActual
            // 
            stockActual.BackColor = Color.Transparent;
            stockActual.BackColorA = Color.FromArgb(246, 246, 246);
            stockActual.BackColorB = Color.FromArgb(254, 254, 254);
            stockActual.BorderColor = Color.FromArgb(180, 180, 180);
            stockActual.ButtonForeColorA = Color.FromArgb(75, 75, 75);
            stockActual.ButtonForeColorB = Color.FromArgb(75, 75, 75);
            stockActual.Font = new Font("Tahoma", 11F);
            stockActual.ForeColor = Color.FromArgb(76, 76, 76);
            stockActual.Location = new Point(473, 130);
            stockActual.Maximum = 100L;
            stockActual.Minimum = 0L;
            stockActual.MinimumSize = new Size(93, 28);
            stockActual.Name = "stockActual";
            stockActual.Size = new Size(188, 28);
            stockActual.TabIndex = 70;
            stockActual.Text = "dungeonNumeric1";
            stockActual.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            stockActual.Value = 0L;
            // 
            // btnLimpiarProducto
            // 
            btnLimpiarProducto.Alpha = 20;
            btnLimpiarProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpiarProducto.BackColor = Color.Transparent;
            btnLimpiarProducto.Background = true;
            btnLimpiarProducto.Background_WidthPen = 4F;
            btnLimpiarProducto.BackgroundPen = true;
            btnLimpiarProducto.ColorBackground = Color.FromArgb(0, 192, 0);
            btnLimpiarProducto.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnLimpiarProducto.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnLimpiarProducto.ColorBackground_Pen = Color.FromArgb(255, 200, 200);
            btnLimpiarProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            btnLimpiarProducto.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnLimpiarProducto.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnLimpiarProducto.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnLimpiarProducto.Effect_1 = true;
            btnLimpiarProducto.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnLimpiarProducto.Effect_1_Transparency = 25;
            btnLimpiarProducto.Effect_2 = true;
            btnLimpiarProducto.Effect_2_ColorBackground = Color.White;
            btnLimpiarProducto.Effect_2_Transparency = 20;
            btnLimpiarProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiarProducto.ForeColor = Color.FromArgb(245, 245, 245);
            btnLimpiarProducto.Lighting = false;
            btnLimpiarProducto.LinearGradient_Background = false;
            btnLimpiarProducto.LinearGradientPen = false;
            btnLimpiarProducto.Location = new Point(702, 44);
            btnLimpiarProducto.Name = "btnLimpiarProducto";
            btnLimpiarProducto.PenWidth = 15;
            btnLimpiarProducto.Rounding = true;
            btnLimpiarProducto.RoundingInt = 70;
            btnLimpiarProducto.Size = new Size(141, 38);
            btnLimpiarProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnLimpiarProducto.TabIndex = 63;
            btnLimpiarProducto.Tag = "Cyber";
            btnLimpiarProducto.TextButton = "NUEVO";
            btnLimpiarProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnLimpiarProducto.Timer_Effect_1 = 5;
            btnLimpiarProducto.Timer_RGB = 300;
            btnLimpiarProducto.Click += btnLimpiarProducto_Click;
            // 
            // categoriaProducto
            // 
            categoriaProducto.BackColor = Color.White;
            categoriaProducto.ColorArrow = Color.FromArgb(252, 173, 159);
            categoriaProducto.ColorBackground = Color.White;
            categoriaProducto.ColorBackground_Pen = Color.FromArgb(252, 173, 159);
            categoriaProducto.ColorItemHover = Color.FromArgb(255, 224, 192);
            categoriaProducto.ColorPen_1 = Color.FromArgb(29, 200, 238);
            categoriaProducto.ColorPen_2 = Color.FromArgb(37, 52, 68);
            categoriaProducto.CyberComboBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            categoriaProducto.DrawMode = DrawMode.OwnerDrawFixed;
            categoriaProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            categoriaProducto.FlatStyle = FlatStyle.Flat;
            categoriaProducto.Font = new Font("Arial", 11F);
            categoriaProducto.ForeColor = Color.Black;
            categoriaProducto.FormattingEnabled = true;
            categoriaProducto.ItemHeight = 28;
            categoriaProducto.Items.AddRange(new object[] { "Infancias", "Peluches", "Didacticos", "Juegos de mesa" });
            categoriaProducto.Location = new Point(246, 126);
            categoriaProducto.Name = "categoriaProducto";
            categoriaProducto.RGB = false;
            categoriaProducto.Size = new Size(188, 34);
            categoriaProducto.TabIndex = 69;
            categoriaProducto.Timer_RGB = 300;
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
            cyberButton3.Location = new Point(1408, 191);
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
            cyberButton1.Location = new Point(1408, 147);
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
            cyberButton2.Location = new Point(1408, 99);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(243, 111);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 27;
            label4.Text = "Categoria";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(473, 54);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 25;
            label3.Text = "Stock Minimo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.Alpha = 20;
            txtPrecioProducto.BackColor = Color.Transparent;
            txtPrecioProducto.Background_WidthPen = 3F;
            txtPrecioProducto.BackgroundPen = true;
            txtPrecioProducto.ColorBackground = Color.White;
            txtPrecioProducto.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtPrecioProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            txtPrecioProducto.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtPrecioProducto.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtPrecioProducto.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtPrecioProducto.Font = new Font("Arial", 8F);
            txtPrecioProducto.ForeColor = Color.Black;
            txtPrecioProducto.Lighting = false;
            txtPrecioProducto.LinearGradientPen = false;
            txtPrecioProducto.Location = new Point(17, 126);
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.PenWidth = 15;
            txtPrecioProducto.RGB = false;
            txtPrecioProducto.Rounding = true;
            txtPrecioProducto.RoundingInt = 60;
            txtPrecioProducto.Size = new Size(191, 32);
            txtPrecioProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtPrecioProducto.TabIndex = 24;
            txtPrecioProducto.Tag = "Cyber";
            txtPrecioProducto.TextButton = "";
            txtPrecioProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtPrecioProducto.Timer_RGB = 300;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 111);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 23;
            label2.Text = "Precio";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(473, 112);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 21;
            label1.Text = "Stock Actual";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDescripcionProducto
            // 
            txtDescripcionProducto.Alpha = 20;
            txtDescripcionProducto.BackColor = Color.Transparent;
            txtDescripcionProducto.Background_WidthPen = 3F;
            txtDescripcionProducto.BackgroundPen = true;
            txtDescripcionProducto.ColorBackground = Color.White;
            txtDescripcionProducto.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtDescripcionProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            txtDescripcionProducto.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtDescripcionProducto.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtDescripcionProducto.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtDescripcionProducto.Font = new Font("Arial", 8F);
            txtDescripcionProducto.ForeColor = Color.Black;
            txtDescripcionProducto.Lighting = false;
            txtDescripcionProducto.LinearGradientPen = false;
            txtDescripcionProducto.Location = new Point(242, 72);
            txtDescripcionProducto.Name = "txtDescripcionProducto";
            txtDescripcionProducto.PenWidth = 15;
            txtDescripcionProducto.RGB = false;
            txtDescripcionProducto.Rounding = true;
            txtDescripcionProducto.RoundingInt = 60;
            txtDescripcionProducto.Size = new Size(191, 32);
            txtDescripcionProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtDescripcionProducto.TabIndex = 20;
            txtDescripcionProducto.Tag = "Cyber";
            txtDescripcionProducto.TextButton = "";
            txtDescripcionProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtDescripcionProducto.Timer_RGB = 300;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(245, 57);
            label13.Name = "label13";
            label13.Size = new Size(72, 15);
            label13.TabIndex = 17;
            label13.Text = "Descripción";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(54, 21);
            label12.Name = "label12";
            label12.Size = new Size(172, 20);
            label12.TabIndex = 19;
            label12.Text = "DATOS DEL PRODUCTO";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(20, 57);
            label14.Name = "label14";
            label14.Size = new Size(45, 15);
            label14.TabIndex = 15;
            label14.Text = "Codigo";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCodigoProducto
            // 
            txtCodigoProducto.Alpha = 20;
            txtCodigoProducto.BackColor = Color.Transparent;
            txtCodigoProducto.Background_WidthPen = 3F;
            txtCodigoProducto.BackgroundPen = true;
            txtCodigoProducto.ColorBackground = Color.White;
            txtCodigoProducto.ColorBackground_Pen = Color.FromArgb(255, 192, 192);
            txtCodigoProducto.ColorLighting = Color.FromArgb(29, 200, 238);
            txtCodigoProducto.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtCodigoProducto.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtCodigoProducto.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtCodigoProducto.Font = new Font("Arial", 8F);
            txtCodigoProducto.ForeColor = Color.Black;
            txtCodigoProducto.Lighting = false;
            txtCodigoProducto.LinearGradientPen = false;
            txtCodigoProducto.Location = new Point(17, 72);
            txtCodigoProducto.Name = "txtCodigoProducto";
            txtCodigoProducto.PenWidth = 15;
            txtCodigoProducto.RGB = false;
            txtCodigoProducto.Rounding = true;
            txtCodigoProducto.RoundingInt = 60;
            txtCodigoProducto.Size = new Size(191, 32);
            txtCodigoProducto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtCodigoProducto.TabIndex = 14;
            txtCodigoProducto.Tag = "Cyber";
            txtCodigoProducto.TextButton = "";
            txtCodigoProducto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtCodigoProducto.Timer_RGB = 300;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            ClientSize = new Size(913, 566);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "FormProductos";
            Text = "FormProductos";
            Load += FormProductos_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panel3;
        private Label label10;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox7;
        private Button button5;
        private Label label9;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox6;
        private Label label8;
        private ReaLTaiizor.Controls.CyberTextBox txtCantidadProductos;
        private Label label5;
        private Button button3;
        private Label label7;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.CyberButton cyberButton3;
        private ReaLTaiizor.Controls.CyberButton cyberButton1;
        private ReaLTaiizor.Controls.CyberButton cyberButton2;
        private Label label4;
        private Label label3;
        private ReaLTaiizor.Controls.CyberTextBox txtPrecioProducto;
        private Label label2;
        private Label label1;
        private ReaLTaiizor.Controls.CyberTextBox txtDescripcionProducto;
        private Label label13;
        private Label label12;
        private Label label14;
        private ReaLTaiizor.Controls.CyberTextBox txtCodigoProducto;
        private ReaLTaiizor.Controls.CyberComboBox categoriaProducto;
        private ReaLTaiizor.Controls.DungeonNumeric stockActual;
        private ReaLTaiizor.Controls.DungeonNumeric stockMinimo;
        private ReaLTaiizor.Controls.CyberButton btnGuardar;
        private ReaLTaiizor.Controls.CyberButton btnLimpiarProducto;
        private Button button1;
        private Button button6;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn ColumCodigo;
        private DataGridViewTextBoxColumn DescripColum;
        private DataGridViewTextBoxColumn CategoriaColum;
        private DataGridViewTextBoxColumn precioColum;
        private DataGridViewTextBoxColumn StockColum;
        private DataGridViewTextBoxColumn ColumStockM;
        private DataGridViewButtonColumn columModificar;
        private DataGridViewButtonColumn columEliminar;
        private ReaLTaiizor.Controls.CyberButton cyberButton4;
    }
}