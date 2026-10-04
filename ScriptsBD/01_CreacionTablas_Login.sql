-- Creación de la base de datos
CREATE DATABASE sistema_jugueteria;
GO

-- Usar la base de datos
USE sistema_jugueteria;
GO

-- 1. Crear la tabla Rol
CREATE TABLE Rol (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    nombre_rol VARCHAR(50) NOT NULL
);
GO

-- 2. Crear la tabla Empleado
CREATE TABLE Empleado (
    id_empleado INT IDENTITY(1,1) PRIMARY KEY,
    dni_empleado VARCHAR(20) NOT NULL UNIQUE, 
    nombre_empleado VARCHAR(100) NOT NULL,
    apellido_empleado VARCHAR(100) NOT NULL,
    correo_empleado VARCHAR(100) NOT NULL,
    telefono_empleado VARCHAR(20) NOT NULL,
    direccion_empleado VARCHAR(200) NOT NULL,
    estado INT DEFAULT 1 -- 1: Activo, 0: Inactivo
);
GO

-- 3. Crear la tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    id_empleado INT NOT NULL UNIQUE, 
    estado INT DEFAULT 1, 
    CONSTRAINT fk_usuario_rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    CONSTRAINT fk_usuario_empleado FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);
GO

-- Insertar los 3 roles en la tabla rol
INSERT INTO Rol (nombre_rol) VALUES 
('administrador'), 
('vendedor'), 
('gerente');
GO

-- 1. Insertamos a las 3 personas físicas (Empleados)
INSERT INTO Empleado (dni_empleado, nombre_empleado, apellido_empleado, correo_empleado, telefono_empleado, direccion_empleado) VALUES 
('11222333', 'Admin', 'Prueba', 'admin@jugueteria.com', '3794000001', 'Av. San Martin 123'),
('44555666', 'Vendedor', 'Prueba', 'vendedor@jugueteria.com', '3794000002', 'Belgrano 456'),
('77888999', 'Gerente', 'Prueba', 'gerente@jugueteria.com', '3794000003', 'Av. Sarmiento 789');
GO

-- 2. Insertamos a los 3 usuarios con las contraseñas hasheadas (clave123)
INSERT INTO Usuario (nombre_usuario, contraseña, id_rol, id_empleado) VALUES 
('admin', '$2a$11$Iedw4I3wRNvC42XzWaCUWeX7CweSRGd5ibWRMs5KFIiZOLpreFmyW', 1, 1),
('vendedor', '$2a$11$Iedw4I3wRNvC42XzWaCUWeX7CweSRGd5ibWRMs5KFIiZOLpreFmyW', 2, 2),
('gerente', '$2a$11$Iedw4I3wRNvC42XzWaCUWeX7CweSRGd5ibWRMs5KFIiZOLpreFmyW', 3, 3);
GO

-- Procedimiento almacenado para validar el login
CREATE PROCEDURE sp_ValidarUsuario
    @p_nombre_usuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        u.id_usuario, 
        u.nombre_usuario, 
        u.contraseña, 
        u.id_rol, 
        u.id_empleado,
        u.estado -- COLUMNA NECESARIA PARA QUE C# LANCE EL AVISO DE BAJA    
    FROM Usuario u
    INNER JOIN Empleado e ON u.id_empleado = e.id_empleado -- Unimos con el empleado    
    WHERE u.nombre_usuario = @p_nombre_usuario; 
END
GO

-- Procedimientos almacenados para ABM de empleados
CREATE PROCEDURE sp_ABM_Empleado
    @p_Operacion CHAR(1), 
    @p_id_empleado INT = NULL, 
    @p_dni_empleado VARCHAR(20) = NULL,
    @p_nombre_empleado VARCHAR(100) = NULL, 
    @p_apellido_empleado VARCHAR(100) = NULL,
    @p_correo_empleado VARCHAR(100) = NULL, 
    @p_telefono_empleado VARCHAR(20) = NULL,  
    @p_direccion_empleado VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET @p_Operacion = UPPER(@p_Operacion);

    IF @p_Operacion = 'A'
    BEGIN
        INSERT INTO Empleado (dni_empleado, nombre_empleado, apellido_empleado, correo_empleado, telefono_empleado, direccion_empleado)
        VALUES (@p_dni_empleado, @p_nombre_empleado, @p_apellido_empleado, @p_correo_empleado, @p_telefono_empleado, @p_direccion_empleado);
        
        -- Devuelve el último ID generado en esta operación                
        SELECT SCOPE_IDENTITY() AS NuevoId_empleado;
    END
    ELSE IF @p_Operacion = 'M'
    BEGIN
        UPDATE Empleado SET 
            dni_empleado = @p_dni_empleado, 
            nombre_empleado = @p_nombre_empleado,
            apellido_empleado = @p_apellido_empleado, 
            correo_empleado = @p_correo_empleado, 
            telefono_empleado = @p_telefono_empleado,   
            direccion_empleado = @p_direccion_empleado
        WHERE id_empleado = @p_id_empleado;
    END
    ELSE IF @p_Operacion = 'B'
    BEGIN
        UPDATE Empleado SET estado = 0 WHERE id_empleado = @p_id_empleado;
    END
    ELSE
    BEGIN
        -- Equivalente a SIGNAL SQLSTATE en SQL Server                
        THROW 50000, 'Operación no válida.', 1;
    END
END
GO

-- Procedimiento almacenado para ABM de usuarios
CREATE PROCEDURE sp_ABM_Usuario
    @p_Operacion CHAR(1), 
    @p_id_usuario INT = NULL, 
    @p_nombre_usuario VARCHAR(50) = NULL,
    @p_contraseña VARCHAR(255) = NULL, 
    @p_id_rol INT = NULL, 
    @p_id_empleado INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET @p_Operacion = UPPER(@p_Operacion);

    IF @p_Operacion = 'A'
    BEGIN
        INSERT INTO Usuario (nombre_usuario, contraseña, id_rol, id_empleado)
        VALUES (@p_nombre_usuario, @p_contraseña, @p_id_rol, @p_id_empleado);
        
        SELECT SCOPE_IDENTITY() AS NuevoId_usuario;
    END
    ELSE IF @p_Operacion = 'M'
    BEGIN
        UPDATE Usuario SET 
            nombre_usuario = @p_nombre_usuario, 
            contraseña = @p_contraseña,
            id_rol = @p_id_rol, 
            id_empleado = @p_id_empleado
        WHERE id_usuario = @p_id_usuario;
    END
    ELSE IF @p_Operacion = 'B'
    BEGIN
        UPDATE Usuario SET estado = 0 WHERE id_usuario = @p_id_usuario;
    END
    ELSE
    BEGIN
        THROW 50000, 'Operación no válida.', 1;
    END
END
GO