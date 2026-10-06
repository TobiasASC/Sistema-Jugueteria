CREATE TABLE Metodo_pago (
	id_metodo_pago INT IDENTITY(1,1) NOT NULL,
	descripcion_metodo VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Metodo_pago PRIMARY KEY (id_metodo_pago),
	CONSTRAINT UQ_Metodo_pago UNIQUE (descripcion_metodo)
);

CREATE TABLE Venta (
	id_venta INT IDENTITY(1,1) NOT NULL,
	fecha_venta DATETIME DEFAULT GETDATE() NOT NULL,
	subtotal_venta DECIMAL(10,2) NOT NULL,
	total_venta DECIMAL(10,2) NOT NULL,
	puntos_generados INT NULL,
	id_metodo_pago INT NOT NULL,
	id_usuario INT NOT NULL,
	id_socio INT NOT NULL,

	CONSTRAINT PK_Venta PRIMARY KEY (id_venta),
	CONSTRAINT FK_Venta_Metodo FOREIGN KEY (id_metodo_pago) REFERENCES Metodo_pago (id_metodo_pago),
	CONSTRAINT FK_Venta_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
	CONSTRAINT FK_Venta_Socio FOREIGN KEY (id_socio) REFERENCES Socio (id_socio)
);

CREATE TABLE Detalle_venta (
	id_venta INT NOT NULL,
	id_producto VARCHAR(50) NOT NULL,
	cantidad INT NOT NULL,
	precio_unitario DECIMAL(10,2) NOT NULL,
	subtotal DECIMAL(10,2) NOT NULL,

	CONSTRAINT PK_Detalle_venta PRIMARY KEY (id_venta, id_producto),
	CONSTRAINT FK_Detalle_venta_Venta FOREIGN KEY (id_venta) REFERENCES Venta (id_venta),
	CONSTRAINT FK_Detalle_venta_Producto FOREIGN KEY (id_producto) REFERENCES Producto (id_producto),
	CONSTRAINT CK_Detalle_venta_Cantidad CHECK (cantidad > 0)
);

INSERT INTO Metodo_pago (descripcion_metodo) VALUES
('tarjeta debito'),
('tarjeta credito'),
('efectivo'),
('transferencia bancaria');