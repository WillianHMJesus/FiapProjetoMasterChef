using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using MasterChef.Models;
using AutoMapper;
using Domain.Entities;

namespace MasterChef.Areas.Admin.Controllers
{
    public class ReceitaAdminController : Controller
    {
        private readonly IReceitaService _service;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public ReceitaAdminController(IReceitaService service, IMapper mapper, ICategoriaService categoriaService)
        {
            _service = service;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var receitasModel = new List<ReceitaModel>();
            var receitas = _service.GetTodosReceita();
            foreach (var receita in receitas)
            {
                var receitaModel = MapperDomainToViewModel(receita);
                receitasModel.Add(receitaModel);
            }
            return View("~/Areas/Admin/Views/Receita/Index.cshtml", receitasModel);
        }

        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Receita/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceitaModel receitaModel)
        {
            if (ModelState.IsValid)
            {
                var receita = MapperViewModelToDomain(receitaModel);
                _service.AdicionarOuAtualizarReceita(receita);
                return RedirectToAction("Index");
            }
            return View("~/Areas/Admin/Views/Receita/Create.cshtml", receitaModel);
        }

        public IActionResult Edit(int id)
        {
            var receita = _service.GetReceitaPorId(id);
            if (receita == null)
            {
                throw new Exception("Receita não encontrada");
            }
            var receitaModel = MapperDomainToViewModel(receita);
            return View("~/Areas/Admin/Views/Receita/Edit.cshtml", receitaModel);
        }

        [HttpPost]
        public IActionResult Edit(ReceitaModel receitaModel)
        {
            if (ModelState.IsValid)
            {
                var receita = _service.GetReceitaPorId(receitaModel.Id);
                receita = ConverterModeloParaEdicao(ref receita, receitaModel);
                _service.AdicionarOuAtualizarReceita(receita);
                return RedirectToAction("Index");
            }
            return View("~/Areas/Admin/Views/Receita/Edit.cshtml", receitaModel);
        }

        public IActionResult Delete(int id)
        {
            var receita = _service.GetReceitaPorId(id);
            if (receita == null)
            {
                throw new Exception("Receita não encontrada");
            }
            var receitaModel = MapperDomainToViewModel(receita);
            return View("~/Areas/Admin/Views/Receita/Delete.cshtml", receitaModel);
        }

        [HttpPost]
        public IActionResult Delete(ReceitaModel receitaModel)
        {
            _service.DeletarReceita(receitaModel.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var receita = _service.GetReceitaPorId(id);
            if (receita == null)
            {
                throw new Exception("Receita não encontrada");
            }
            var receitaModel = MapperDomainToViewModel(receita);
            return View("~/Areas/Admin/Views/Receita/Details.cshtml", receitaModel);
        }

        private ReceitaModel MapperDomainToViewModel(Receita receita)
        {
            return _mapper.Map<Receita, ReceitaModel>(receita);
        }

        private Receita MapperViewModelToDomain(ReceitaModel receitaModel)
        {
            return _mapper.Map<ReceitaModel, Receita>(receitaModel);
        }

        private Receita ConverterModeloParaEdicao(ref Receita receita, ReceitaModel receitaModel)
        {
            receita.Nome = receitaModel.Nome;
            receita.TempoPreparo = receitaModel.TempoPreparo;
            receita.RendimentoPorcoes = receitaModel.RendimentoPorcoes;
            receita.Ingredientes = receitaModel.Ingredientes;
            receita.ModoPreparo = receitaModel.ModoPreparo;
            receita.Cobertura = receitaModel.Cobertura;
            receita.InfoAdicional = receitaModel.InfoAdicional;
            receita.CaminhoImagem = receitaModel.CaminhoImagem;
            return receita;
        }
    }
}