using Newtonsoft.Json;
using UsuarioEntities;

namespace UsuarioData
{
    public static class UsuariosFiles
    {
        const string rutaArchivo = @"C:\ucse\prog1-perez\usuario.json";

        // Método para escribir un usuario a un archivo JSON
        public static void EscribirUsuarioAJson(Usuario usuario)
        {
            List<Usuario> usuarios = LeerUsuariosDesdeJson();

            if (usuario.Id == 0)
            {
                usuario.Id = usuarios.Count() + 1;
            }
            else
            {
                usuarios.RemoveAll(x => x.Id == usuario.Id);
            }

            usuarios.Add(usuario);

            string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        // Método para leer un usuario desde un archivo JSON
        public static List<Usuario> LeerUsuariosDesdeJson()
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
            else
            {
                return new List<Usuario>();
            }
        }
    }
}
