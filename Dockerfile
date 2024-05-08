# Usa la imagen oficial de MySQL como base
FROM mysql:latest

# Variables de entorno para configurar la base de datos
ENV MYSQL_ROOT_PASSWORD=1234
ENV MYSQL_DATABASE=DB_prueba
ENV MYSQL_USER=user
ENV MYSQL_PASSWORD=123

# Copia el script SQL para crear la tabla de usuarios e insertar datos
COPY ./init.sql /docker-entrypoint-initdb.d/

# Exponer el puerto por defecto de MySQL
EXPOSE 3306
