using System.Collections.Generic;
using usuarios.Models;
using Microsoft.Data.Sqlite;


namespace usuarios.Repository{
    public class SqliteUsuariosRepository{
        private readonly string connection;
        public SqliteUsuariosRepository(){
            connection = "Filename=app.db";
        }
        //Leer todos los usuarios;
        public List<UsuarioViewModel> getUsers(){
            var users = new List<UsuarioViewModel>();
            var cmd =  new SqliteCommand("SELECT ID, Nombre, Apellidos, Apodo, Contrasena from Usuarios");
            using(var con = new SqliteConnection(connection)){
                cmd.Connection = con;
                cmd.Connection.Open();
                using(var reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        users.Add(new UsuarioViewModel((int)reader.GetInt64(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)));
                    }
                }

            }
            return users;
        }
        //obtener usuario por id
        public Usuario getUserById(int id){
            var cmd = new SqliteCommand("SELECT ID, Nombre, Apellidos, Apodo, Contrasena from Usuarios WHERE ID = @ID");
            cmd.Parameters.AddWithValue("@ID",id);
            using(var con = new SqliteConnection(connection)){
                cmd.Connection = con;
                cmd.Connection.Open();
                using(var reader = cmd.ExecuteReader()){
                    if(reader.Read()){
                        return new Usuario((int)reader.GetInt64(0),
                         reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                        );
                    }
                }
            }
            return null;
        }

        //editar usuario
        public bool editUser(Usuario user){
            var cmd = new SqliteCommand("UPDATE Usuarios set Nombre = @Nombre, Apellidos = @Apellido, Apodo = @Apodo, Contrasena = @Contrasena where ID = @ID");
            cmd.Parameters.AddWithValue("@Nombre",user.getName());
            cmd.Parameters.AddWithValue("@Apellido",user.getApellido());
            cmd.Parameters.AddWithValue("@Apodo",user.getApodo());
            cmd.Parameters.AddWithValue("@Contrasena",user.getContrasena());
            cmd.Parameters.AddWithValue("@ID",user.getId());
            return ExecuteCMD(cmd);

        }

        //crear usuario
        public bool createUser(Usuario user){
            var cmd = new SqliteCommand("INSERT INTO Usuarios (Nombre, Apellidos, Apodo, Contrasena) values (@Nombre, @Apellido, @Apodo, @Contrasena)");
            cmd.Parameters.AddWithValue("@Nombre",user.getName());
            cmd.Parameters.AddWithValue("@Apellido",user.getApellido());
            cmd.Parameters.AddWithValue("@Apodo",user.getApodo());
            cmd.Parameters.AddWithValue("@Contrasena",user.getContrasena());
            return ExecuteCMD(cmd);

        }

        //eliminar usuario
     public bool deleteUser(int  id){
            var cmd = new SqliteCommand("DELETE FROM Usuarios where ID = @ID");
            cmd.Parameters.AddWithValue("@ID",id);
            return ExecuteCMD(cmd);
        }




        public bool ExecuteCMD(SqliteCommand cmd){
            using(var con = new SqliteConnection(connection)){
                cmd.Connection = con;
                cmd.Connection.Open();
                var rows = cmd.ExecuteNonQuery();
                return rows>0;
            }
        }



    }
}