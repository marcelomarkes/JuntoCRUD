using JuntoCRUD.Business.Models;
using JuntoCRUD.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JuntoCRUD.Repository
{
    public class BaseRepository<TEntity, TCode> where TEntity : class
    {
        protected readonly JuntoContext _context;
        public readonly ICollection<TEntity> entities;

        public BaseRepository(JuntoContext context)
        {
            _context = context;
        }

        public int Atualizar(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }


        public int Cadastrar(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }


        public int Remover(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }


        public IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> predicado)
        {
            return this._context.Set<TEntity>().Where(predicado).ToList();
        }

        public IEnumerable<TEntity> Listar()
        {
            return this._context.Set<TEntity>().ToList();
        }
        
    }
}
