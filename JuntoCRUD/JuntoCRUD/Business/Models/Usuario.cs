using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuntoCRUD.Business.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
}
