namespace usuarios.Models{
    public class Usuario{
        int ID{get; set;}
        string Nombre{get; set;}
        string Apellido{get; set;}
        string Apodo{get; set;}
        string Contrasena{get; set;}

        public Usuario(){}
        public Usuario(int id, string nombre, string apellido, string apodo, string contrasena){
            this.ID = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Apodo = apodo;
            this.Contrasena = contrasena;
        }

        public int getId(){
            return ID;
        }
        public string getName(){
            return Nombre;
        }
        public string getApellido(){
            return Apellido;
        }
        public string getApodo(){
            return Apodo;
        }
        public string getContrasena(){
            return Contrasena;
        }

        public UsuarioViewModel convertToViewModel(){
            return new UsuarioViewModel(ID, Nombre,Apellido,Apodo,Contrasena);
        }


    }
}