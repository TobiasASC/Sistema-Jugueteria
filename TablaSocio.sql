CREATE TABLE Socio (
	id_socio INT IDENTITY(1,1) NOT NULL,
	dni_socio VARCHAR(50) NOT NULL,
	nombre_socio VARCHAR(50) NOT NULL,
	apellido_socio VARCHAR(50) NOT NULL,
	correo_socio VARCHAR(50) NOT NULL,
	direccion_socio VARCHAR(50) NOT NULL,
	puntos_acumulados INT NOT NULL DEFAULT 0,

	CONSTRAINT PK_Socio PRIMARY KEY (id_socio),
	CONSTRAINT UQ_Socio_Dni UNIQUE (dni_socio),
	CONSTRAINT UQ_Socio_Correo UNIQUE (correo_socio)
);