using AutoMapper;
using Domain.Entities;
using MasterChef.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;

namespace MasterChef.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;

        public ComentarioController(IMapper mapper, IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var comentariosModel = new List<ComentarioModel>();
            var comentarios = _comentarioService.ObterTodos();

            foreach (var comentario in comentarios)
            {
                var comentarioModel = MapperDomainToViewModel(comentario);
                comentariosModel.Add(comentarioModel);
            }

            return View(comentariosModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = MapperViewModelToDomain(comentarioModel);
                _comentarioService.Adicionar(comentario);

                return RedirectToAction("Details", "Receita", new { id = comentarioModel.ReceitaId });
            }

            return View(comentarioModel);
        }

        public IActionResult Delete(int id)
        {
            var comentario = _comentarioService.ObterPorId(id);

            if (comentario == null) throw new Exception("Comentario não encontrado");

            var comentarioModel = MapperDomainToViewModel(comentario);

            return View(comentarioModel);
        }

        [HttpPost]
        public IActionResult Delete(ComentarioModel comentarioModel)
        {
            _comentarioService.Deletar(comentarioModel.Id);

            return RedirectToAction("Index");
        }

        private ComentarioModel MapperDomainToViewModel(Comentario comentario)
        {
            return _mapper.Map<Comentario, ComentarioModel>(comentario);
        }

        private Comentario MapperViewModelToDomain(ComentarioModel comentarioModel)
        {
            return _mapper.Map<ComentarioModel, Comentario>(comentarioModel);
        }
    }
}