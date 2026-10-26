CREATE TABLE Tipo_Reporte (
    id_tipo_reporte INT IDENTITY(1,1) NOT NULL,
    nombre_tipo VARCHAR(30) NOT NULL,

    CONSTRAINT PK_Tipo_Reporte PRIMARY KEY (id_tipo_reporte),

    CONSTRAINT UQ_Tipo_Reporte_Nombre UNIQUE (nombre_tipo)
);

CREATE TABLE Reporte (
    id_reporte INT IDENTITY(1,1) NOT NULL,
    id_tipo_reporte INT NOT NULL,
    fecha_generacion DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    id_usuario INT NOT NULL,
    filtros_aplicados NVARCHAR(MAX) NULL,
    incluye_detalle BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_Reporte PRIMARY KEY (id_reporte),

    CONSTRAINT FK_Reporte_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_Reporte_Tipo_Reporte FOREIGN KEY (id_tipo_reporte) REFERENCES Tipo_Reporte(id_tipo_reporte)
);

INSERT INTO Tipo_Reporte (nombre_tipo)
VALUES
    ('Ventas'),
    ('Productos'),
    ('Pedidos'),
    ('Clientes'),
    ('Empleados');