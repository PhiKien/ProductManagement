﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.ViewModels;

namespace ProductManagement.Controllers
{
    public class UserController : Controller
    {
   
        IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            var listUser = _userRepository.GetAll();
            return View(listUser);
        }

        // GET: User/Details/5
        public ActionResult Details(long id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = _userRepository.GetById(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(userViewModel);
                _userRepository.SaveChange();
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }

        // GET: User/Edit/5
        public ActionResult Edit(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _userRepository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,Name,Address,Email,Phone,CreateDate,ModifiedDate,Status,RoleID")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Update(userViewModel);
                _userRepository.Update(userViewModel);
                _userRepository.SaveChange();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public ActionResult Delete(long id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userViewModel = _userRepository.GetById(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var userViewModel = _userRepository.GetById(id);
            _userRepository.Delete(userViewModel);
            _userRepository.SaveChange();   
            return RedirectToAction("Index");
        }

        public bool Login(string userName, string passWord)
        {
            var result = _userRepository.Login(userName, passWord);
            if(result.Count() < 1)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

    }
}
