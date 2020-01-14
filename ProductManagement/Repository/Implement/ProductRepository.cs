using AutoMapper;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProductManagement.Repository.Implement
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(ProductViewModel products)
        {
            var model = _mapper.Map<ProductViewModel, Product>(products);
            _context.Products.Add(model);
            _context.SaveChanges();
        }

        public void Delete(ProductViewModel products)
        {
            var model = _mapper.Map<ProductViewModel, Product>(products);
            _context.Products.Remove(model);
            _context.SaveChanges();
        }

        public void Update(ProductViewModel products)
        {
            var model = _mapper.Map<ProductViewModel, Product>(products);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var listModel = _context.Products.ToList();
            return _mapper.Map<List<Product>, List<ProductViewModel>>(listModel);
        }

        public IEnumerable<ProductViewModel> GetByCondition(int? id)
        {
            var listModel = _context.Products.Where(p => p.CategoryID == id).ToList();
            return _mapper.Map<List<Product>, List<ProductViewModel>>(listModel);
        }

        public ProductViewModel GetById(int id)
        {
            var model = _context.Products.FirstOrDefault(p => p.ID == id);
            return _mapper.Map<Product, ProductViewModel>(model);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}