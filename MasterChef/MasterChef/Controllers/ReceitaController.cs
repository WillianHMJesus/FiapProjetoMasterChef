using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using MasterChef.Models;
using Domain.Entities;

namespace MasterChef.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IReceitaService _service;
        private readonly IMapper _mapper;
        private readonly IComentarioService _serviceComentario;

        public ReceitaController(IReceitaService service, IMapper mapper, IComentarioService serviceComentario)
        {
            _service = service;
            _mapper = mapper;
            _serviceComentario = serviceComentario;
        }

        public IActionResult Index()
        {
            var receitasModel = new List<ReceitaModel>();
            var receitas = _service.ObterTodos();

            foreach (var receita in receitas)
            {
                var receitaModel = MapperDomainToViewModel(receita);
                var comentarios = _serviceComentario.ObterTodos().Where(x => x.Receita.Id == receita.Id).ToList();

                receitaModel.QtdeComentarios = comentarios.Count();
                receitaModel.Comentarios = RetornaComentarios(comentarios);
                receitasModel.Add(receitaModel);
            }

            return View(receitasModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var receita = _service.ObterPorId(id);

            if (receita == null) throw new ArgumentException("Receita não encontrada");

            var receitaModel = MapperDomainToViewModel(receita);
            receitaModel.Comentarios = RetornaComentarios(_serviceComentario.ObterTodos().Where(x => x.Receita.Id == receitaModel.Id).ToList());

            return View(receitaModel);
        }

        private ReceitaModel MapperDomainToViewModel(Receita receita)
        {
            return _mapper.Map<Receita, ReceitaModel>(receita);
        }

        private ComentarioModel MapperDomainToViewModelComentario(Comentario comentario)
        {
            return _mapper.Map<Comentario, ComentarioModel>(comentario);
        }

        private List<ComentarioModel> RetornaComentarios(List<Comentario> comentarios)
        {
            var comentariosModel = new List<ComentarioModel>();

            foreach (var comentario in comentarios)
            {
                comentariosModel.Add(MapperDomainToViewModelComentario(comentario));
            }

            return comentariosModel;
        }
    }
}