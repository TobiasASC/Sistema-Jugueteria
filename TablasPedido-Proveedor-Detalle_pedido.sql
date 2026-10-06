CREATE TABLE Proveedor (
	id_proveedor INT IDENTITY(1,1) NOT NULL,
	nombre_proveedor VARCHAR(50) NOT NULL,

	CONSTRAINT PK_Proveedor PRIMARY KEY (id_proveedor),
	CONSTRAINT UQ_Proveedor_nombre UNIQUE (nombre_proveedor)
);

CREATE TABLE Pedido (
	id_pedido INT IDENTITY(1,1) NOT NULL,
	fecha_pedido DATETIME DEFAULT GETDATE() NOT NULL,
	fecha_entrega DATETIME NULL,
	total_pedido DECIMAL(10,2) NOT NULL,
	estado_pedido VARCHAR(50) DEFAULT 'EN ESPERA' NOT NULL,
	id_proveedor INT NOT NULL,
	id_usuario INT NOT NULL,

	CONSTRAINT PK_Pedido PRIMARY KEY (id_pedido),
	CONSTRAINT FK_Pedido_Proveedor FOREIGN KEY (id_proveedor) REFERENCES Proveedor (id_proveedor),
	CONSTRAINT FK_Pedido_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
	CONSTRAINT CK_Pedido_Estado CHECK (estado_pedido IN ('EN ESPERA', 'RECIBIDO'))
);

CREATE TABLE Detalle_pedido (
	id_pedido INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	precio_unitario DECIMAL(10,2) NOT NULL,
	subtotal DECIMAL(10,2) NOT NULL,

	CONSTRAINT PK_Detalle_pedido PRIMARY KEY (id_pedido, id_producto),
	CONSTRAINT FK_Detalle_pedido_Pedido FOREIGN KEY (id_pedido) REFERENCES Pedido (id_pedido),
	CONSTRAINT FK_Detalle_pedido_Producto FOREIGN KEY (id_producto) REFERENCES Producto (id_producto),
	CONSTRAINT CK_Detalle_cantidad CHECK (cantidad > 0)
);

INSERT INTO Proveedor (nombre_proveedor) VALUES
(ToysNet),
(Vulcanita),
(TecniToys),
(Fun express);