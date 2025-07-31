using CadastroProdutos.Context;
using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }
           
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
