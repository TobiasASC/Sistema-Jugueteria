# Sistema de Gestión para Juguetería (TN Toys) 🧸

Aplicación de escritorio integral desarrollada en C# (Windows Forms) para la administración eficiente, segura y escalable de una tienda de juguetes.

## Propósito del Proyecto
El sistema está diseñado para digitalizar y automatizar los procesos diarios del local, optimizando el tiempo del personal y garantizando la seguridad de la información. Sus módulos principales incluyen:
*   **Ventas:** Facturación rápida, detección de Consumidor Final y sistema de fidelización (canje de puntos con descuento).
*   **Inventario:** ABM de productos con control de stock actual y mínimo, y bajas lógicas.
*   **Clientes y Empleados:** Registro de socios para acumulación de puntos y gestión del personal con acceso al sistema.
*   **Pedidos:** Gestión de abastecimiento con proveedores y seguimiento de estados (En espera / Recibido).
*   **Reportes Estadísticos:** Generación automatizada de reportes visuales guardados directamente en el disco.
*   **Seguridad Avanzada:** Módulo de Backup y Restauración de Base de Datos protegido por doble verificación.

## 🏗️ Arquitectura del Sistema
El proyecto está construido utilizando el patrón de **Arquitectura en N-Capas**, garantizando un bajo acoplamiento y una alta cohesión:

1.  **Capa de Presentación (Forms):** Interfaz gráfica de usuario. Captura eventos y muestra resultados. No contiene lógica pesada.
2.  **Capa de Negocio (Business):** El "cerebro" del sistema. Aplica reglas como validación de stock, cálculo de recompensas por puntos y validación de pines (BCrypt).
3.  **Capa de Datos (Data):** Encargada exclusivamente de la comunicación con SQL Server mediante ADO.NET. Maneja transacciones seguras (`SqlTransaction`) para garantizar la integridad (ACID).
4.  **Capa de Entidades (Entities):** Clases planas que definen los modelos de datos (Usuario, Venta, Producto, etc.) y sirven para transportar información entre las demás capas.

## ⚙️ Requisitos del Sistema
Para compilar y ejecutar este proyecto, se requiere:
*   **Sistema Operativo:** Windows 10 o Windows 11.
*   **Entorno de Desarrollo:** Visual Studio 2022 (recomendado).
*   **Framework:** .NET (Compatible con Windows Forms).
*   **Base de Datos:** Microsoft SQL Server (Express o superior).
*   **Librerías de terceros (NuGet):** `BCrypt.Net-Next` (para el hasheo de contraseñas y pines).

## 🚀 Pasos para la Instalación

**1. Preparar la Base de Datos:**
* Abra SQL Server Management Studio (SSMS).
* Abra el script SQL incluido en el proyecto.
* Ejecute el script. Esto creará la base de datos `sistema_jugueteria`, las tablas, procedimientos almacenados y los usuarios predeterminados.

**2. Configurar la Conexión:**
* Abra la solución en Visual Studio.
* Diríjase a la capa **Data** y abra el archivo `Conexion.cs`.
* Asegúrese de que el `Data Source` en la `cadenaConexion` coincida con el nombre de su instancia local de SQL Server (por defecto `.\SQLEXPRESS`).

**3. Compilar y Ejecutar:**
* Restaure los paquetes NuGet si es necesario (clic derecho en la solución -> "Restaurar paquetes NuGet").
* Presione `F5` o el botón "Iniciar" en Visual Studio.

## 🔐 Accesos Iniciales
El script de base de datos incluye tres usuarios de prueba listos para usar (todos con la contraseña: **clave123**):
*   **Administrador:** Usuario: `admin` 
*   **Gerente:** Usuario: `gerente`
*   **Vendedor:** Usuario: `vendedor`

## 📂 Sistema de Archivos Locales
La aplicación genera documentos físicos de manera automatizada. Al ejecutar acciones específicas, creará las siguientes carpetas en el disco `C:\` sin necesidad de intervención manual:
*   `C:\Jugueteria_Facturas` (Comprobantes HTML de ventas)
*   `C:\Jugueteria_Reportes` (Estadísticas HTML con gráficos Chart.js)
*   `C:\Jugueteria_Backups` (Copias de seguridad `.bak`)

---
*Desarrollado como proyecto para la asignatura Taller de Programación 2.*
