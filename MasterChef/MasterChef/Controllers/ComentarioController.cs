using AutoMapper;
using Domain.Entities;
using MasterChef.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;

namespace MasterChef.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _service;
        private readonly IReceitaService _serviceReceita;
        private readonly IMapper _mapper;

        public ComentarioController(IReceitaService serviceReceita, IMapper mapper, IComentarioService comentarioService)
        {
            _service = comentarioService;
            _mapper = mapper;
            _serviceReceita = serviceReceita;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = MapperViewModelToDomain(comentarioModel);
                _service.Adicionar(comentario);

                return RedirectToAction("Details", "Receita", new { id = comentarioModel.ReceitaId });
            }

            return View(comentarioModel);
        }

        private Comentario MapperViewModelToDomain(ComentarioModel comentarioModel)
        {
            return _mapper.Map<ComentarioModel, Comentario>(comentarioModel);
        }
    }
}