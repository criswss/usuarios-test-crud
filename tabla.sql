CREATE TABLE IF NOT EXISTS Usuarios(
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre varchar(200) not null,
    Apellidos varchar(200) not null,
    Apodo varchar(200) not null,
    Contrasena varchar(200) not null
)