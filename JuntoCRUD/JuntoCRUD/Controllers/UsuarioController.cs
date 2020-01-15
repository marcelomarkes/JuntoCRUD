using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuntoCRUD.Business.Interfaces;
using JuntoCRUD.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JuntoCRUD.Controllers
{
    [Produces("application/json")]
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario { get; set; }

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Metodo de busca todos os registro sem necessidade de parametro para localização
        /// </summary>
        /// <returns>Lista de Itens cadastrados</returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Usuario>> Buscar()
        {
            var user = _usuario.Listar();
            return user.ToList();
        }

        /// <summary>
        /// Metodo de busca todos os registro sem necessidade de parametro para localização
        /// </summary>
        /// <returns>Lista de Itens cadastrados</returns>
        [HttpGet]
        // GET: Categoria
        public ActionResult<IEnumerable<Usuario>> Index()
        {
            var user = _usuario.Listar();
            return user.ToList();
        }

        /// <summary>
        /// Utilizando Metodo GET da WebApi para busca item especifico com necessidade de parametro para localização 
        /// do id do item.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:int},{nome}, {cat}")]
        // GET: Categoria/Details/5
        public ActionResult<Usuario> Details(int id)
        {
            var user = _usuario.Listar(x => x.IdUsuario == id);
            return user.FirstOrDefault();
        }

        /// <summary>
        /// Metodo POST utilizado para inclusão de um novo item.
        /// </summary>
        /// <returns>Cadastro de Novo Item</returns>
        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _usuario.Cadastrar(usuario);
                    return Ok();
                }
                else
                    return NotFound();

            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Metodo PUT utilizado para alteração de um item de especifico ID.
        /// </summary>
        /// <param name="id"></param>
        // PUT: Categoria/Edit/5
        [HttpPut]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuario.Atualizar(usuario);

                    return Ok();
                }
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Metodo DELETE utilizado para exclusão de um item de especifico ID.
        /// </summary>
        /// <param name="id"></param>
        // DELETE: Categoria/Delete/5
        [HttpDelete]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add delete logic here

                    _usuario.Remover(usuario);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}