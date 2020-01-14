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
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario { get; set; }

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Usuario>> Busca()
        {
            var usuario = _usuario.Listar();
            return usuario.ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Index()
        {
            var usuario = _usuario.Listar();
            return usuario.ToList();
        }

        [HttpGet("{id}")]
        // GET: Categoria/Details/5
        public ActionResult<Usuario> Details(int id)
        {
            var cat = _categoria.Listar(x => x.Id == id);
            return cat.FirstOrDefault();
        }
    }
}