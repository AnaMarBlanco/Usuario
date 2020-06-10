using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Usuario.Entidades
{
    class Usuarios
    {[Key]//sirve para saber el ide de el usuario//
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set;  }

    }
}
