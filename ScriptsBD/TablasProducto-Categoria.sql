-- Tabla Categoria
CREATE TABLE Categoria (
    id_categoria INT IDENTITY(1,1) NOT NULL,
    nombre_categoria VARCHAR(100) NOT NULL,
    activo BIT DEFAULT 1 NOT NULL,

    -- Restriccion para que el nombre de la categoria sea unico
    CONSTRAINT UQ_NombreCategoria UNIQUE (nombre_categoria),
    CONSTRAINT PK_Categoria PRIMARY KEY (id_categoria)
);

-- Tabla Producto
CREATE TABLE Producto (
    id_producto VARCHAR(50) NOT NULL, -- Sin IDENTITY para que se ingrese manualmente
    descripcion_producto VARCHAR(255) NOT NULL,
    precio_venta DECIMAL(18,2) NOT NULL,
    stock_actual INT DEFAULT 0 NOT NULL,
    stock_minimo INT DEFAULT 0 NOT NULL,
    id_categoria INT NOT NULL,
    activo BIT DEFAULT 1 NOT NULL,
    
    -- Restricción que asegura que el id_producto solo contenga caracteres del 0 al 9
    CONSTRAINT CHK_CodigoSoloNumeros CHECK (id_producto NOT LIKE '%[^0-9]%'),

    -- Restricciones para evitar que el stock baje de cero
    CONSTRAINT CHK_StockActual_NoNegativo CHECK (stock_actual >= 0),
    CONSTRAINT CHK_StockMinimo_NoNegativo CHECK (stock_minimo >= 0),

    -- Restriccion para que el precio sea mayor a 0
    CONSTRAINT CHK_PrecioVenta_MayorCero CHECK (precio_venta > 0),
    
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (id_categoria)
    REFERENCES Categoria(id_categoria),
    CONSTRAINT PK_Producto PRIMARY KEY (id_producto)
);

-- Inserción de datos en tabla Categoria
INSERT INTO Categoria (nombre_categoria, activo) VALUES
('Infancias', 1),
('Peluches', 1),
('Didacticos', 1),
('Juegos de mesa', 1);



