namespace usuarios.Models{
    public class UsuarioViewModel{

        public int Id{get; set;}
        public string Nombre{get; set;}
        public string Apellido{get; set;}
        public string Apodo{get; set;}
        public string Contrasena{get; set;}

    public UsuarioViewModel(){}
    public UsuarioViewModel(int id, string nombre, string apellido, string apodo, string contrasena){
        this.Id = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Apodo = apodo;
        this.Contrasena = contrasena;
        }

        public Usuario convertToUser(){
            return new Usuario(Id, Nombre, Apellido, Apodo, Contrasena);
        }

    }
}