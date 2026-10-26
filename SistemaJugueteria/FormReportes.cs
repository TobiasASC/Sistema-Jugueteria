
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Business;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormReportes : Form
    {
        private int contadorNumeroReporte = 1;

        private readonly ReporteBusiness _reporteBusiness =
            new ReporteBusiness();

        private bool cargandoFiltrosHistorial = false;

        public FormReportes()
        {
            InitializeComponent();

            Validaciones.ConfigurarSoloNumeros(txtNumeroReporteBuscar);

            OcultarTodosLosPaneles();
            ConfigurarMotivos();

            TextBox txtReporteReal =
                txtNumeroReporte.Controls.OfType<TextBox>()
                .FirstOrDefault();

            if (txtReporteReal != null)
            {
                txtReporteReal.Enabled = false;
                txtReporteReal.BackColor = SystemColors.Control;
            }
            else
            {
                txtNumeroReporte.Enabled = false;
            }

            CargarDatosInicialesBD();

            ConfigurarBusquedaHistorial();
            CargarHistorialReportes();
        }

        // =========================================================
        // INICIALIZACIÓN
        // =========================================================

        private void CargarDatosInicialesBD()
        {
            try
            {
                GenerarSiguienteNumeroReporte();

                if (dtpFechaReporte != null)
                    dtpFechaReporte.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos iniciales.\n" +
                    ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void OcultarTodosLosPaneles()
        {
            if (panelVentas != null) panelVentas.Visible = false;
            if (panelClientes != null) panelClientes.Visible = false;
            if (panelEmpleados != null) panelEmpleados.Visible = false;
            if (panelPedidos != null) panelPedidos.Visible = false;
            if (panelProductos != null) panelProductos.Visible = false;
        }

        private void ConfigurarMotivos()
        {
            cbMotivo.Items.Clear();

            cbMotivo.Items.Add("Ventas");
            cbMotivo.Items.Add("Clientes");
            cbMotivo.Items.Add("Empleados");
            cbMotivo.Items.Add("Pedidos");
            cbMotivo.Items.Add("Productos");

            cbMotivo.SelectedIndexChanged -=
                cbMotivo_SelectedIndexChanged;

            cbMotivo.SelectedIndexChanged +=
                cbMotivo_SelectedIndexChanged;
        }

        private void cbMotivo_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            OcultarTodosLosPaneles();

            string motivo = cbMotivo.Text.Trim();

            if (motivo.Equals("Ventas",
                StringComparison.OrdinalIgnoreCase))
            {
                panelVentas.Visible = true;
                panelVentas.BringToFront();
                CargarEmpleadosEnCyberCombo(cyberComboBox1);
            }
            else if (motivo.Equals("Clientes",
                StringComparison.OrdinalIgnoreCase))
            {
                panelClientes.Visible = true;
                panelClientes.BringToFront();
                CargarFiltrosClientes();
            }
            else if (motivo.Equals("Empleados",
                StringComparison.OrdinalIgnoreCase))
            {
                panelEmpleados.Visible = true;
                panelEmpleados.BringToFront();
                CargarFiltrosEmpleados();
            }
            else if (motivo.Equals("Pedidos",
                StringComparison.OrdinalIgnoreCase))
            {
                panelPedidos.Visible = true;
                panelPedidos.BringToFront();
                CargarFiltrosPedidos();
            }
            else if (motivo.Equals("Productos",
                StringComparison.OrdinalIgnoreCase))
            {
                panelProductos.Visible = true;
                panelProductos.BringToFront();
                CargarFiltrosProductos();
            }
        }

        // =========================================================
        // CARGA DE COMBOS
        // =========================================================

        private void CargarEmpleadosEnCyberCombo(Control control)
        {
            if (control == null)
                return;

            try
            {
                EmpleadoBusiness negocio = new EmpleadoBusiness();
                DataTable dtEmpleados =
                    negocio.ObtenerEmpleadosTabla();

                DataRow filaTodos = dtEmpleados.NewRow();
                filaTodos["ID"] = DBNull.Value;
                filaTodos["Nombre Completo"] = "Todos los empleados";
                dtEmpleados.Rows.InsertAt(filaTodos, 0);

                if (control is not ComboBox combo)
                {
                    MessageBox.Show(
                        "El control recibido no es un ComboBox.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                combo.DataSource = null;
                combo.DisplayMember = "Nombre Completo";
                combo.ValueMember = "ID";
                combo.DataSource = dtEmpleados;
                combo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los empleados: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarFiltrosClientes()
        {
            if (cyberComboBox2 == null)
                return;

            cyberComboBox2.Items.Clear();
            cyberComboBox2.Items.Add("Mayores compradores");
            cyberComboBox2.Items.Add("Más tiempo registrados");
            cyberComboBox2.Items.Add("Mayor cantidad de puntos");

            cyberComboBox2.SelectedIndex = 0;
        }

        private void CargarFiltrosEmpleados()
        {
            if (cyberComboBox3 == null)
                return;

            cyberComboBox3.DataSource = null;
            cyberComboBox3.Items.Clear();

            cyberComboBox3.Items.Add("Todos");
            cyberComboBox3.Items.Add("Gerente");
            cyberComboBox3.Items.Add("Vendedor");

            cyberComboBox3.SelectedIndex = 0;
        }

        private void CargarFiltrosPedidos()
        {
            if (cyberComboBox4 == null)
                return;

            cyberComboBox4.Items.Clear();

            cyberComboBox4.Items.Add("Todos los Estados");
            cyberComboBox4.Items.Add("En espera");
            cyberComboBox4.Items.Add("Recibidos");

            cyberComboBox4.SelectedIndex = 0;
        }

        private void CargarFiltrosProductos()
        {
            if (cyberComboBox5 == null)
                return;

            cyberComboBox5.Items.Clear();

            cyberComboBox5.Items.Add("Todos");
            cyberComboBox5.Items.Add("Sin stock");
            cyberComboBox5.Items.Add("Stock mínimo");
            cyberComboBox5.Items.Add("Con stock");
            cyberComboBox5.Items.Add("Mayor stock");
            cyberComboBox5.Items.Add("Menor stock");

            cyberComboBox5.SelectedIndex = 0;
        }

        private string ObtenerTexto(Control control)
        {
            if (control == null)
                return "";

            var propiedad =
                control.GetType().GetProperty("TextButton");

            if (propiedad != null)
            {
                string valor =
                    propiedad.GetValue(control, null)?.ToString();

                if (!string.IsNullOrWhiteSpace(valor))
                    return valor.Trim();
            }

            return control.Text.Trim();
        }

        private void GenerarSiguienteNumeroReporte()
        {
            try
            {
                int siguienteNumero;

                using (SqlConnection conexion =
                    Conexion.ObtenerConexion())
                {
                    string query = @"
                        SELECT ISNULL(MAX(id_reporte), 0) + 1
                        FROM Reporte;";

                    using (SqlCommand comando =
                        new SqlCommand(query, conexion))
                    {
                        if (conexion.State != ConnectionState.Open)
                            conexion.Open();

                        siguienteNumero =
                            Convert.ToInt32(comando.ExecuteScalar());
                    }
                }

                contadorNumeroReporte = siguienteNumero;

                var propiedadTextButton =
                    txtNumeroReporte.GetType()
                    .GetProperty("TextButton");

                if (propiedadTextButton != null)
                {
                    propiedadTextButton.SetValue(
                        txtNumeroReporte,
                        siguienteNumero.ToString(),
                        null
                    );
                }

                txtNumeroReporte.Text = siguienteNumero.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al obtener el número del reporte: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // HISTORIAL Y BÚSQUEDA DE REPORTES
        // =========================================================

        private void ConfigurarBusquedaHistorial()
        {
            cargandoFiltrosHistorial = true;

            try
            {
                if (motivoReportesBuscar != null)
                {
                    motivoReportesBuscar.Items.Clear();

                    motivoReportesBuscar.Items.Add("Todos los reportes");
                    motivoReportesBuscar.Items.Add("Ventas");
                    motivoReportesBuscar.Items.Add("Productos");
                    motivoReportesBuscar.Items.Add("Pedidos");
                    motivoReportesBuscar.Items.Add("Clientes");
                    motivoReportesBuscar.Items.Add("Empleados");

                    motivoReportesBuscar.SelectedIndex = 0;
                }

                if (dtpFechaReporteBuscar != null)
                {
                    dtpFechaReporteBuscar.ShowCheckBox = true;
                    dtpFechaReporteBuscar.Checked = false;
                }
            }
            finally
            {
                cargandoFiltrosHistorial = false;
            }

            if (motivoReportesBuscar != null)
            {
                motivoReportesBuscar.SelectedIndexChanged -=
                    motivoReportesBuscar_SelectedIndexChanged;

                motivoReportesBuscar.SelectedIndexChanged +=
                    motivoReportesBuscar_SelectedIndexChanged;
            }

            if (dtpFechaReporteBuscar != null)
            {
                dtpFechaReporteBuscar.ValueChanged -=
                    dtpFechaReporteBuscar_ValueChanged;

                dtpFechaReporteBuscar.ValueChanged +=
                    dtpFechaReporteBuscar_ValueChanged;

                dtpFechaReporteBuscar.CloseUp -=
                    dtpFechaReporteBuscar_CloseUp;

                dtpFechaReporteBuscar.CloseUp +=
                    dtpFechaReporteBuscar_CloseUp;
            }

            // Vincular el buscador por número una sola vez.
            VincularEventoInterno(txtNumeroReporteBuscar);
        }

        private void VincularEventoInterno(
            ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            if (cyberCaja == null)
                return;

            foreach (Control controlInterno in cyberCaja.Controls)
            {
                if (controlInterno is TextBox cajaReal)
                {
                    cajaReal.KeyUp -= CajasDeBusqueda_KeyUp;
                    cajaReal.KeyUp += CajasDeBusqueda_KeyUp;
                    break;
                }
            }
        }

        private void CajasDeBusqueda_KeyUp(
            object sender, KeyEventArgs e)
        {
            FiltrarReportes();
        }

        private void FiltrarReportes()
        {
            if (dgvReportes.DataSource is not DataTable tabla)
                return;

            AplicarFiltroNumeroReporte(tabla);
            ActualizarContador();
        }

        private void AplicarFiltroNumeroReporte(DataTable tabla)
        {
            string numeroBuscado =
                ObtenerTexto(txtNumeroReporteBuscar);

            if (string.IsNullOrWhiteSpace(numeroBuscado))
            {
                tabla.DefaultView.RowFilter = "";
                return;
            }

            // La consulta del historial devuelve el número como
            // "N.º Reporte". También admitimos nombres alternativos.
            DataColumn columnaNumero = tabla.Columns
                .Cast<DataColumn>()
                .FirstOrDefault(c =>
                    c.ColumnName.Equals(
                        "id_reporte",
                        StringComparison.OrdinalIgnoreCase));

            if (columnaNumero == null)
            {
                columnaNumero = tabla.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(c =>
                        c.ColumnName.Equals(
                            "N.º Reporte",
                            StringComparison.OrdinalIgnoreCase));
            }

            if (columnaNumero == null)
            {
                columnaNumero = tabla.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(c =>
                        c.ColumnName.IndexOf(
                            "reporte",
                            StringComparison.OrdinalIgnoreCase) >= 0
                        || c.ColumnName.IndexOf(
                            "numero",
                            StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (columnaNumero == null)
            {
                tabla.DefaultView.RowFilter = "";
                return;
            }

            string nombreColumna =
                columnaNumero.ColumnName.Replace("]", "]]");

            string numeroSeguro =
                numeroBuscado.Replace("'", "''");

            tabla.DefaultView.RowFilter =
                $"Convert([{nombreColumna}], 'System.String') " +
                $"LIKE '%{numeroSeguro}%'";
        }

        private void motivoReportesBuscar_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (!cargandoFiltrosHistorial)
                CargarHistorialReportes();
        }

        private void dtpFechaReporteBuscar_ValueChanged(
            object sender, EventArgs e)
        {
            if (!cargandoFiltrosHistorial)
                CargarHistorialReportes();
        }

        private void dtpFechaReporteBuscar_CloseUp(
            object sender, EventArgs e)
        {
            if (!cargandoFiltrosHistorial)
                CargarHistorialReportes();
        }

        private void CargarHistorialReportes()
        {
            try
            {
                int? idTipoReporte = null;
                DateTime? fecha = null;

                string tipoSeleccionado =
                    motivoReportesBuscar?.SelectedItem?.ToString();

                if (!string.IsNullOrWhiteSpace(tipoSeleccionado) &&
                    tipoSeleccionado != "Todos los reportes")
                {
                    idTipoReporte =
                        _reporteBusiness.ObtenerIdTipoReportePorNombre(
                            tipoSeleccionado);
                }

                if (dtpFechaReporteBuscar != null &&
                    dtpFechaReporteBuscar.Checked)
                {
                    fecha = dtpFechaReporteBuscar.Value.Date;
                }

                DataTable tabla =
                    _reporteBusiness.ListarReportes(
                        idTipoReporte, fecha);

                // Aplicar el número antes de enlazar la tabla a la grilla.
                AplicarFiltroNumeroReporte(tabla);

                dgvReportes.DataSource = null;
                dgvReportes.AutoGenerateColumns = false;
                dgvReportes.DataSource = tabla;

                if (dgvReportes.Columns.Contains("NumeroColum"))
                    dgvReportes.Columns["NumeroColum"].Width = 90;

                if (dgvReportes.Columns.Contains("FechaColum"))
                {
                    dgvReportes.Columns["FechaColum"].Width = 150;
                    dgvReportes.Columns["FechaColum"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                if (dgvReportes.Columns.Contains("MotivoColum"))
                    dgvReportes.Columns["MotivoColum"].Width = 130;

                if (dgvReportes.Columns.Contains("detalleColum"))
                {
                    dgvReportes.Columns["detalleColum"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }

                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el historial de reportes.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ActualizarContador()
        {
            // Cuenta solo las filas visibles después de aplicar el filtro.
            int cantidad = dgvReportes.Rows
                .Cast<DataGridViewRow>()
                .Count(fila => !fila.IsNewRow);

            var propiedad =
                contadorReportes.GetType().GetProperty("TextButton");

            if (propiedad != null)
            {
                propiedad.SetValue(
                    contadorReportes,
                    cantidad.ToString(),
                    null
                );
            }
            else
            {
                contadorReportes.Text = cantidad.ToString();
            }
        }

        // =========================================================
        // CANCELAR / LIMPIAR
        // =========================================================

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarDatosInicialesBD();

            cbMotivo.SelectedIndex = -1;
            OcultarTodosLosPaneles();
        }

        // =========================================================
        // GENERAR Y REGISTRAR REPORTE
        // =========================================================

        private void btnGenerarReportePDF_Click(
            object sender, EventArgs e)
        {
            string numero = ObtenerTexto(txtNumeroReporte);
            string motivo = cbMotivo.Text.Trim();

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show(
                    "Debe seleccionar un motivo para generar el reporte.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (Sesion.IdUsuario <= 0)
            {
                MessageBox.Show(
                    "No se pudo identificar al usuario que inició sesión. " +
                    "Verifique que Sesion.IdUsuario se asigne al ingresar.",
                    "Sesión inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string fechaEmision = dtpFechaReporte != null
                ? dtpFechaReporte.Value.ToString("dd/MM/yyyy")
                : DateTime.Now.ToString("dd/MM/yyyy");

            bool guardadoExitoso =
                GenerarReporteFisicoConFiltros(
                    numero, fechaEmision, motivo);

            if (!guardadoExitoso)
                return;

            try
            {
                string filtrosAplicados =
                    ObtenerFiltrosAplicados(motivo);

                bool incluyeDetalle =
                    ObtenerSiIncluyeDetalle(motivo);

                int idTipoReporte =
                    _reporteBusiness.ObtenerIdTipoReportePorNombre(motivo);

                Reporte reporte = new Reporte
                {
                    IdTipoReporte = idTipoReporte,
                    IdUsuario = Sesion.IdUsuario,
                    FiltrosAplicados = filtrosAplicados,
                    IncluyeDetalle = incluyeDetalle
                };

                int idReporteRegistrado =
                    _reporteBusiness.RegistrarReporte(reporte);

                MessageBox.Show(
                    "El archivo se guardó y el reporte quedó registrado " +
                    "en la base de datos.\n\n" +
                    "ID del registro: " + idReporteRegistrado,
                    "Reporte registrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarHistorialReportes();

                GenerarSiguienteNumeroReporte();

                if (dtpFechaReporte != null)
                    dtpFechaReporte.Value = DateTime.Now;

                cbMotivo.SelectedIndex = -1;
                OcultarTodosLosPaneles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "El archivo se guardó, pero no se pudo registrar " +
                    "el reporte en la base de datos.\n\n" + ex.Message,
                    "Error al registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string ObtenerFiltrosAplicados(string motivo)
        {
            List<string> filtros = new List<string>();

            switch (motivo.ToLowerInvariant())
            {
                case "ventas":
                    filtros.Add(
                        $"Desde: {dateTimePicker1.Value:dd/MM/yyyy}");

                    filtros.Add(
                        $"Hasta: {dateTimePicker2.Value:dd/MM/yyyy}");

                    if (cyberComboBox1.SelectedIndex >= 0)
                        filtros.Add($"Empleado: {cyberComboBox1.Text}");

                    filtros.Add(
                        $"Detalle: {(chkEstado.Checked ? "Sí" : "No")}");
                    break;

                case "clientes":
                    filtros.Add($"Orden: {cyberComboBox2.Text}");
                    filtros.Add(
                        $"Estado: {(cyberSwitch1.Checked ? "Activos" : "Inactivos")}");
                    break;

                case "empleados":
                    filtros.Add($"Rol: {cyberComboBox3.Text}");
                    filtros.Add(
                        $"Estado: {(cyberSwitch2.Checked ? "Activos" : "Inactivos")}");
                    break;

                case "pedidos":
                    filtros.Add(
                        $"Desde: {dateTimePicker3.Value:dd/MM/yyyy}");

                    filtros.Add(
                        $"Hasta: {dateTimePicker4.Value:dd/MM/yyyy}");

                    filtros.Add($"Estado: {cyberComboBox4.Text}");

                    filtros.Add(
                        $"Detalle: {(cyberSwitch3.Checked ? "Sí" : "No")}");
                    break;

                case "productos":
                    filtros.Add(
                        $"Estado: {(cyberSwitch4.Checked ? "Inactivos" : "Activos")}");

                    filtros.Add($"Stock: {cyberComboBox5.Text}");
                    break;
            }

            return string.Join(" | ", filtros);
        }

        private bool ObtenerSiIncluyeDetalle(string motivo)
        {
            switch (motivo.ToLowerInvariant())
            {
                case "ventas":
                    return chkEstado.Checked;

                case "pedidos":
                    return cyberSwitch3.Checked;

                case "productos":
                    return cyberSwitch4.Checked;

                case "clientes":
                    return cyberSwitch1.Checked;

                case "empleados":
                    return cyberSwitch2.Checked;

                default:
                    return false;
            }
        }

        private int? ObtenerIdEmpleadoSeleccionado()
        {
            object valor = cyberComboBox1
                .GetType()
                .GetProperty("SelectedValue")
                ?.GetValue(cyberComboBox1);

            if (valor == null || valor == DBNull.Value)
                return null;

            if (int.TryParse(valor.ToString(), out int idEmpleado))
                return idEmpleado;

            return null;
        }

        // =========================================================
        // GENERAR ARCHIVO HTML
        // =========================================================

        private bool GenerarReporteFisicoConFiltros(
            string numReporte,
            string fechaEmision,
            string motivo)
        {
            if (motivo.Equals("Ventas",
                StringComparison.OrdinalIgnoreCase))
            {
                if (dateTimePicker1.Value.Date >
                    dateTimePicker2.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha desde no puede ser posterior a la fecha hasta.",
                        "Fechas incorrectas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }
            else if (motivo.Equals("Pedidos",
                StringComparison.OrdinalIgnoreCase))
            {
                if (dateTimePicker3.Value.Date >
                    dateTimePicker4.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha desde no puede ser posterior a la fecha hasta.",
                        "Fechas incorrectas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter =
                    "Documento HTML (*.html)|*.html";

                saveFileDialog.FileName =
                    $"Reporte_{motivo.Replace(" ", "_")}_{numReporte}.html";

                saveFileDialog.Title = "Guardar Reporte del Sistema";
                saveFileDialog.DefaultExt = "html";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    DataTable dtDatos = new DataTable();

                    // REPORTE DE VENTAS
                    if (motivo.Equals("Ventas",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        DateTime desde = dateTimePicker1.Value.Date;
                        DateTime hasta = dateTimePicker2.Value.Date;
                        bool detallado = chkEstado.Checked;

                        object valorEmpleado = cyberComboBox1
                            .GetType()
                            .GetProperty("SelectedValue")
                            ?.GetValue(cyberComboBox1);

                        int? idEmpleado = null;

                        if (valorEmpleado != null &&
                            valorEmpleado != DBNull.Value &&
                            int.TryParse(
                                valorEmpleado.ToString(),
                                out int idSeleccionado))
                        {
                            idEmpleado = idSeleccionado;
                        }

                        VentaBusiness negocioVentas =
                            new VentaBusiness();

                        dtDatos = negocioVentas.ObtenerReporteVentas(
                            desde, hasta, idEmpleado, detallado);
                    }

                    // REPORTE DE CLIENTES
                    else if (motivo.Equals("Clientes",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        string orden = cyberComboBox2.Text;
                        bool soloActivos = cyberSwitch1.Checked;

                        SocioBusiness negocioSocios =
                            new SocioBusiness();

                        dtDatos = negocioSocios.ObtenerReporteClientes(
                            incluirActivos: soloActivos,
                            incluirInactivos: !soloActivos,
                            criterioOrden: orden);
                    }

                    // REPORTE DE EMPLEADOS
                    else if (motivo.Equals("Empleados",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        bool soloActivos = cyberSwitch2.Checked;
                        string rolSeleccionado = cyberComboBox3.Text;

                        EmpleadoBusiness negocioEmpleados =
                            new EmpleadoBusiness();

                        dtDatos = negocioEmpleados.ObtenerReporteEmpleados(
                            incluirActivos: soloActivos,
                            incluirInactivos: !soloActivos,
                            rolBuscado: rolSeleccionado);
                    }

                    // REPORTE DE PEDIDOS
                    else if (motivo.Equals("Pedidos",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        DateTime desde = dateTimePicker3.Value.Date;
                        DateTime hasta = dateTimePicker4.Value.Date;

                        string estadoPedido = cyberComboBox4.Text;
                        bool incluirDetalle = cyberSwitch3.Checked;

                        PedidoBusiness negocioPedidos =
                            new PedidoBusiness();

                        dtDatos = negocioPedidos.ObtenerReportePedidos(
                            desde, hasta, estadoPedido, incluirDetalle);
                    }

                    // REPORTE DE PRODUCTOS
                    else if (motivo.Equals("Productos",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        bool verSoloInactivos = cyberSwitch4.Checked;
                        string criterioStock = cyberComboBox5.Text;

                        ProductoBusiness negocioProductos =
                            new ProductoBusiness();

                        dtDatos = negocioProductos.ObtenerReporteProductos(
                            verSoloInactivos, criterioStock);
                    }

                    CrearDocumentoReporteConGrafico(
                        saveFileDialog.FileName,
                        numReporte,
                        fechaEmision,
                        motivo,
                        dtDatos);

                    MessageBox.Show(
                        "Reporte generado exitosamente.",
                        "Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ocurrió un error al generar el reporte: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }
        }

        private void CrearDocumentoReporteConGrafico(
            string rutaArchivo,
            string numReporte,
            string fecha,
            string motivo,
            DataTable dtDatos)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head><meta charset='utf-8'>");
            html.AppendLine(
                $"<title>Reporte de {System.Net.WebUtility.HtmlEncode(motivo)}</title>");

            html.AppendLine("<style>");
            html.AppendLine(
                "body{font-family:Segoe UI,Arial,sans-serif;margin:30px;color:#333;background:#fff;}");
            html.AppendLine(
                ".header{text-align:center;border-bottom:3px solid #ff7b7b;padding-bottom:15px;margin-bottom:20px;}");
            html.AppendLine(
                ".header h1{color:#d9534f;margin:0;font-size:26px;}");
            html.AppendLine(
                ".header h3{color:#555;margin:5px 0 0;font-weight:normal;}");
            html.AppendLine(
                ".info{display:flex;justify-content:space-between;background:#fff5f5;padding:12px 20px;margin-bottom:25px;border:1px solid #ffe0e0;}");
            html.AppendLine(
                "table{width:100%;border-collapse:collapse;margin-top:10px;}");
            html.AppendLine(
                "th,td{border:1px solid #e0e0e0;padding:10px;text-align:left;font-size:13px;}");
            html.AppendLine(
                "th{background:#ff9999;color:white;font-weight:bold;}");
            html.AppendLine(
                "tr:nth-child(even){background:#fcfcfc;}");
            html.AppendLine(
                ".footer{margin-top:40px;font-size:11px;text-align:center;color:#888;border-top:1px solid #eee;padding-top:15px;}");
            html.AppendLine("</style></head><body>");

            string motivoHtml =
                System.Net.WebUtility.HtmlEncode(motivo);

            string usuarioHtml =
                System.Net.WebUtility.HtmlEncode(
                    Sesion.NombreCompleto ?? Sesion.NombreUsuario ?? "");

            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>SISTEMA JUGUETERÍA</h1>");
            html.AppendLine(
                $"<h3>Reporte oficial - Módulo: {motivoHtml}</h3>");
            html.AppendLine("</div>");

            html.AppendLine("<div class='info'>");
            html.AppendLine("<div>");

            html.AppendLine(
                $"<p><strong>N.º de reporte:</strong> " +
                $"{System.Net.WebUtility.HtmlEncode(numReporte)}</p>");

            html.AppendLine(
                $"<p><strong>Fecha de emisión:</strong> " +
                $"{System.Net.WebUtility.HtmlEncode(fecha)}</p>");

            html.AppendLine("</div><div>");

            html.AppendLine(
                $"<p><strong>Tipo:</strong> {motivoHtml}</p>");

            html.AppendLine(
                $"<p><strong>Generado por:</strong> {usuarioHtml}</p>");

            html.AppendLine("</div></div>");

            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                html.AppendLine("<table><thead><tr>");

                foreach (DataColumn columna in dtDatos.Columns)
                {
                    html.AppendLine(
                        "<th>" +
                        System.Net.WebUtility.HtmlEncode(
                            columna.ColumnName) +
                        "</th>");
                }

                html.AppendLine("</tr></thead><tbody>");

                foreach (DataRow fila in dtDatos.Rows)
                {
                    html.AppendLine("<tr>");

                    foreach (object item in fila.ItemArray)
                    {
                        string valor = item == DBNull.Value
                            ? ""
                            : Convert.ToString(item) ?? "";

                        html.AppendLine(
                            "<td>" +
                            System.Net.WebUtility.HtmlEncode(valor) +
                            "</td>");
                    }

                    html.AppendLine("</tr>");
                }

                html.AppendLine("</tbody></table>");
            }
            else
            {
                html.AppendLine(
                    "<p style='text-align:center;padding:20px;color:#666;'>" +
                    "No hay datos disponibles para mostrar en este reporte.</p>");
            }

            html.AppendLine("<div class='footer'>");
            html.AppendLine(
                "<p>Documento generado desde el Sistema de Gestión de Juguetería.</p>");
            html.AppendLine("</div>");

            html.AppendLine("</body></html>");

            File.WriteAllText(
                rutaArchivo,
                html.ToString(),
                new UTF8Encoding(true)
            );
        }

        // =========================================================
        // EVENTOS REQUERIDOS POR EL DISEÑADOR
        // =========================================================

        private void panel2_Click(object sender, EventArgs e) { }

        private void label19_Click(object sender, EventArgs e) { }

        private void hopeTextBox1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void panel3_Click(object sender, EventArgs e) { }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Bloquear la fecha de emisión para que no pueda modificarse.
            dtpFechaReporte.Enabled = false;

            CargarHistorialReportes();
        }
    }
}
