-- Creación de la base de datos sistema_jugueteria 
create database sistema_jugueteria;

-- 1. Crear la tabla Rol
CREATE TABLE Rol (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    nombre_rol VARCHAR(50) NOT NULL
);

-- 2. Crear la tabla Empleado (Necesaria por la llave foránea)
CREATE TABLE Empleado (
    id_empleado INT AUTO_INCREMENT PRIMARY KEY,
    dni_empleado VARCHAR(20) NOT NULL,
    nombre_empleado VARCHAR(100) NOT NULL,
    apellido_empleado VARCHAR(100) NOT NULL,
    correo_empleado VARCHAR(100) NOT NULL,
    direccion_empleado VARCHAR(200)
);

-- 3. Crear la tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL,
    contraseña VARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    id_empleado INT NOT NULL,
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);

-- Procedimiento almacenado para validar el login
DELIMITER //

CREATE PROCEDURE sp_ValidarUsuario(
    IN p_nombre_usuario VARCHAR(50),
    IN p_contraseña VARCHAR(255)
)
BEGIN
    -- Busca al usuario que coincida con las credenciales
    SELECT id_usuario, nombre_usuario, id_rol, id_empleado 
    FROM Usuario 
    WHERE nombre_usuario = p_nombre_usuario AND contraseña = p_contraseña;
END //

DELIMITER ;