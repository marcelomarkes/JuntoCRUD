using JuntoCRUD.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuntoCRUD.Business.Interfaces
{
    public interface IUsuario
    {
        int Atualizar(Usuario usuario);
        int Cadastrar(Usuario usuario);
        IEnumerable<Usuario> Listar();
        IEnumerable<Usuario>
            Listar(Expression<Func<Usuario, bool>> predicado);
        int Remover(Usuario usuario);
    }
}
