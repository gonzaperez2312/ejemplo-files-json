﻿namespace UsuarioEntities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public DateTime? FechaEliminacion { get; set; }
    }
}
