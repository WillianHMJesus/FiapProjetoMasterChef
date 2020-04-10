using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using MasterChef.Models;
using Domain.Entities;

namespace MasterChef.Areas.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categoriasModel = new List<CategoriaModel>();
            var categorias = _service.GetTodosCategoria();
            foreach(var categoria in categorias)
            {
                var categoriaModel = MapperDomainToViewModel(categoria);
                categoriasModel.Add(categoriaModel);
            }
            return View("~/Areas/Admin/Views/Categoria/Index.cshtml", categoriasModel);
        }

        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Categoria/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = MapperViewModelToDomain(categoriaModel);
                _service.AdicionarOuAtualizarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View("~/Areas/Admin/Views/Categoria/Create.cshtml", categoriaModel);
        }

        public IActionResult Edit(int id)
        {
            var categoria = _service.GetCategoriaPorId(id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            var categoriaModel = MapperDomainToViewModel(categoria);
            return View("~/Areas/Admin/Views/Categoria/Edit.cshtml", categoriaModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoriaModel categoriaModel)
        {
            if(ModelState.IsValid)
            {
                var categoria = _service.GetCategoriaPorId(categoriaModel.Id);
                categoria = ConverterModeloParaEdicao(ref categoria, categoriaModel);
                _service.AdicionarOuAtualizarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View("~/Areas/Admin/Views/Categoria/Edit.cshtml", categoriaModel);
        }

        public IActionResult Delete(int id)
        {
            var categoria = _service.GetCategoriaPorId(id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            var categoriaModel = MapperDomainToViewModel(categoria);
            return View("~/Areas/Admin/Views/Categoria/Delete.cshtml", categoriaModel);
        }

        [HttpPost]
        public IActionResult Delete(CategoriaModel categoriaModel)
        {
            _service.DeletarCategoria(categoriaModel.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var categoria = _service.GetCategoriaPorId(id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            var categoriaModel = MapperDomainToViewModel(categoria);
            return View("~/Areas/Admin/Views/Categoria/Details.cshtml", categoriaModel);
        }

        private CategoriaModel MapperDomainToViewModel(Categoria categoria)
        {
            return _mapper.Map<Categoria, CategoriaModel>(categoria);
        }

        private Categoria MapperViewModelToDomain(CategoriaModel categoriaModel)
        {
            return _mapper.Map<CategoriaModel, Categoria>(categoriaModel);
        }

        public Categoria ConverterModeloParaEdicao(ref Categoria categoria, CategoriaModel categoriaModel)
        {
            categoria.Nome = categoriaModel.Nome;
            categoria.Descricao = categoria.Descricao;
            return categoria;
        }
    }
}