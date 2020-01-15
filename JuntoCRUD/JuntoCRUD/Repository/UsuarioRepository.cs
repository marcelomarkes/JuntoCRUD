using JuntoCRUD.Business.Interfaces;
using JuntoCRUD.Business.Models;
using JuntoCRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuntoCRUD.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuario
    {
        private JuntoContext Context { get; set; }

        public UsuarioRepository(JuntoContext context) : base(context)
        {
            Context = context;
        }
        
    }
}
