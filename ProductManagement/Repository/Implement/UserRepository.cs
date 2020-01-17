using AutoMapper;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRepository()
        {
                
        }

        public UserRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(UserViewModel entity)
        {
            var model = _mapper.Map<UserViewModel, User>(entity);
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public void Delete(UserViewModel entity)
        {
            var model = _mapper.Map<UserViewModel, User>(entity);
            _context.Users.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var listModel = _context.Users.ToList();
            return _mapper.Map<List<User>, List<UserViewModel>>(listModel);
        }

        public UserViewModel GetById(long id)
        {
            var model = _context.Users.FirstOrDefault(u => u.ID == id);
            return _mapper.Map<User, UserViewModel>(model);
        }

        public IEnumerable<UserViewModel> GetByRole(int? id)
        {
            var listModel = _context.Users.Where(u => u.RoleID == id).ToList();
            return _mapper.Map<List<User>, List<UserViewModel>>(listModel);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(UserViewModel user)
        {
            var model = _mapper.Map<UserViewModel, User>(user);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserViewModel> Login(string userNmae, string passWord)
        {
            var model = _context.Users.Where(u => u.UserName == userNmae && u.Password == passWord).ToList();
            return model;
        }
    }
}