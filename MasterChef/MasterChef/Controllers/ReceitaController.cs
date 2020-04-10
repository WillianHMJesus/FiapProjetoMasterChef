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
            var receitas = _service.GetTodosReceita();
            foreach (var receita in receitas)
            {
                var receitaModel = MapperDomainToViewModel(receita);
                receitaModel.QtdeComentarios = _serviceComentario.GetTodosComentarios().Where(m => m.ReceitaId == receitaModel.Id).Count();
                var comentarios = _serviceComentario.GetTodosComentarios().Where(p => p.ReceitaId == receita.Id).ToList();

                List<Comentario> lComentario = new List<Comentario>();
                lComentario.AddRange(comentarios);

                receitaModel.Comentarios = RetornaComentarios(lComentario);
                receitasModel.Add(receitaModel);
            }
            return View(receitasModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var receita = _service.GetReceitaPorId(id);
            if (receita == null)
            {
                throw new ArgumentException("Receita não encontrada");
            }
            var receitaModel = MapperDomainToViewModel(receita);
            receitaModel.Comentarios = MapperDomainToViewModelComentarioList(_serviceComentario.GetTodosComentarios().Where(m => m.ReceitaId == receitaModel.Id));
            return View(receitaModel);
        }

        private ReceitaModel MapperDomainToViewModel(Receita receita)
        {
            return _mapper.Map<Receita, ReceitaModel>(receita);
        }

        private Receita MapperViewModelToDomain(ReceitaModel receitaModel)
        {
            return _mapper.Map<ReceitaModel, Receita>(receitaModel);
        }

        private ComentarioModel MapperDomainToViewModelComentario(Comentario comentario)
        {
            return _mapper.Map<Comentario, ComentarioModel>(comentario);
        }

        private IEnumerable<ComentarioModel> MapperDomainToViewModelComentarioList(IEnumerable<Comentario> comentario)
        {
            var lista = new List<ComentarioModel>();
            foreach (var item in comentario)
                lista.Add(MapperDomainToViewModelComentario(item));

            return lista.AsEnumerable();
        }

        private Comentario MapperViewModelToDomainComentario(ComentarioModel comentarioModel)
        {
            return _mapper.Map<ComentarioModel, Comentario>(comentarioModel);
        }

        private IEnumerable<ComentarioModel> RetornaComentarios(List<Comentario> lista)
        {
            foreach (var item in lista)
            {
                ComentarioModel model = new ComentarioModel();
                model.ComentarioTexto = item.ComentarioTexto;
                model.Nome = item.Nome;

                yield return model;
            }
        }
    }
}