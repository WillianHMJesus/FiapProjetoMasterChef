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
            try
            {
                if (ModelState.IsValid)
                {                    
                    _service.AdicionarOuAtualizarComentario(
                        new Comentario
                        {
                            Id = comentarioModel.Id,
                            Nome = comentarioModel.Nome,
                            ComentarioTexto = comentarioModel.ComentarioTexto,
                            ReceitaId = comentarioModel.ReceitaId,
                            CreatedOn = DateTime.Now
                        });

                    return RedirectToAction("Details", "Receita", new { id = comentarioModel.ReceitaId });
                }

                return View(comentarioModel);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        private ComentarioModel MapperDomainToViewModel(Comentario comentario)
        {
            return _mapper.Map<Comentario, ComentarioModel>(comentario);
        }

        private Comentario MapperViewModelToDomain(ComentarioModel comentarioModel)
        {
            return _mapper.Map<ComentarioModel, Comentario>(comentarioModel);
        }

        private ReceitaModel MapperDomainToViewModelReceita(Receita receita)
        {
            return _mapper.Map<Receita, ReceitaModel>(receita);
        }

        private Receita MapperViewModelToDomainReceita(ReceitaModel receitaModel)
        {
            return _mapper.Map<ReceitaModel, Receita>(receitaModel);
        }

    }
}