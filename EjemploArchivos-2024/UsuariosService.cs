using UsuarioData;
using UsuarioEntities;

namespace EjemploArchivos_2024
{
    public class UsuariosService
    {
        public void CrearUsuario(Usuario usuario)
        {
            UsuariosFiles.EscribirUsuarioAJson(usuario);
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return UsuariosFiles.LeerUsuariosDesdeJson();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return UsuariosFiles.LeerUsuariosDesdeJson().FirstOrDefault(x => x.Id == id);
        }

        public bool ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = ObtenerUsuarioPorId(usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.Nombre = usuarioActualizado.Nombre;
                usuario.CorreoElectronico = usuarioActualizado.CorreoElectronico;
                usuario.FechaDeNacimiento = usuarioActualizado.FechaDeNacimiento;

                UsuariosFiles.EscribirUsuarioAJson(usuario);

                return true;
            }
            return false;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario != null)
            {
                usuario.FechaEliminacion = DateTime.Now;

                UsuariosFiles.EscribirUsuarioAJson(usuario);

                return true;
            }

            return false;
        }
}
}
