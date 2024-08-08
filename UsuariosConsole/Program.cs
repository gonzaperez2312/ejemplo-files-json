// See https://aka.ms/new-console-template for more information

using EjemploArchivos_2024;
using UsuarioEntities;

UsuariosService usuarioService = new UsuariosService();

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Crear Usuario");
    Console.WriteLine("2. Obtener Todos los Usuarios");
    Console.WriteLine("3. Obtener Usuario por ID");
    Console.WriteLine("4. Actualizar Usuario");
    Console.WriteLine("5. Eliminar Usuario");
    Console.WriteLine("6. Salir");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Ingrese el Nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Correo Electrónico:");
            string correo = Console.ReadLine();

            Console.WriteLine("Ingrese la Fecha de Nacimiento (yyyy-mm-dd):");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Usuario usuario = new Usuario()
            {
                Nombre = nombre,
                CorreoElectronico = correo,
                FechaDeNacimiento = fecha,
            };

            usuarioService.CrearUsuario(usuario);

            Console.WriteLine("Usuario creado exitosamente.");

            break;
        case "2":
            List<Usuario> usuarios = usuarioService.ObtenerTodosLosUsuarios();
            foreach (var item in usuarios)
            {
                Console.WriteLine(item.Nombre);
            }

            break;
        case "3":
            Console.WriteLine("Ingrese el ID:");
            int id = int.Parse(Console.ReadLine());

            Usuario usuarioEncontrado = usuarioService.ObtenerUsuarioPorId(id);
            if (usuarioEncontrado != null)
            {
                Console.WriteLine(usuarioEncontrado);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }

            break;
        case "4":
            Console.WriteLine("Ingrese el ID del usuario a actualizar:");
            int idUser = int.Parse(Console.ReadLine());

            Usuario usuarioEditado = new Usuario();
            usuarioEditado.Id = idUser;

            Console.WriteLine("Ingrese el Nuevo Nombre:");
            usuarioEditado.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Nuevo Correo Electrónico:");
            usuarioEditado.CorreoElectronico = Console.ReadLine();

            Console.WriteLine("Ingrese la Nueva Fecha de Nacimiento (yyyy-mm-dd):");
            usuarioEditado.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());

            if (usuarioService.ActualizarUsuario(usuarioEditado))
            {
                Console.WriteLine("Usuario actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }

            break;
        case "5":
            Console.WriteLine("Ingrese el ID del usuario a eliminar:");
            int idAEliminar = int.Parse(Console.ReadLine());

            if (usuarioService.EliminarUsuario(idAEliminar))
            {
                Console.WriteLine("Usuario eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}