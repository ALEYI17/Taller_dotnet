-- Crea la tabla de usuarios
CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);

-- Inserta algunos usuarios
INSERT INTO usuarios (nombre, email) VALUES ('Usuario 1', 'usuario1@example.com');
INSERT INTO usuarios (nombre, email) VALUES ('Usuario 2', 'usuario2@example.com');
INSERT INTO usuarios (nombre, email) VALUES ('Usuario 3', 'usuario3@example.com');
