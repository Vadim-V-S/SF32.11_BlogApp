﻿using BlogApp.Models;
using BlogApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
                _repo= repo;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
