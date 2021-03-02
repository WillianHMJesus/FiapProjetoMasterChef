using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using Domain.Entities;
using MasterChef.Models;

namespace MasterChef.Areas.Admin.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _service;
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var comentariosModel = new List<ComentarioModel>();
            var comentarios = _service.ObterTodos();

            foreach (var comentario in comentarios)
            {
                var comentarioModel = MapperDomainToViewModel(comentario);
                comentariosModel.Add(comentarioModel);
            }

            return View("~/Areas/Admin/Views/Comentario/Index.cshtml", comentariosModel);
        }

        public IActionResult Delete(int id)
        {
            var comentario = _service.ObterPorId(id);

            if (comentario == null) throw new Exception("Comentario não encontrado");

            var comentarioModel = MapperDomainToViewModel(comentario);

            return View("~/Areas/Admin/Views/Comentario/Delete.cshtml", comentarioModel);
        }

        [HttpPost]
        public IActionResult Delete(ComentarioModel comentarioModel)
        {
            _service.Deletar(comentarioModel.Id);

            return RedirectToAction("Index");
        }

        private ComentarioModel MapperDomainToViewModel(Comentario comentario)
        {
            return _mapper.Map<Comentario, ComentarioModel>(comentario);
        }
    }
}