using PagedList;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Product
        public ActionResult Index(int? page, int? idCategory)
        {
            
            idCategory = 1;
            if (idCategory != null)
            {
                var listByIdCategory = _productRepository.GetByCondition(idCategory);
                return View(listByIdCategory.ToPagedList(page == null ? 1 : page.Value, 3));
            } else
            {
                var listAll = _productRepository.GetAll();
                return View(listAll.ToPagedList(page == null ? 1 : page.Value, 3));
            }

            
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Description, NumberInStock, CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(productViewModel);
                _productRepository.SaveChange();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, Description, NumberInStock, CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(productViewModel);
                _productRepository.SaveChange();
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _productRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = _productRepository.GetById(id);
            _productRepository.Delete(model);
            _productRepository.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
