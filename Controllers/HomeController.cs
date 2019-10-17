// <copyright file="HomeController.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Controllers
{
    using System.Diagnostics;

    using BusinessClientSystem.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            // check whether user has a valid session or not. if not we wanna restrict the user from about page
            var user = this.HttpContext.Session.GetString("user");
            if (user == null)
            {
                return this.Redirect("/auth/login");
            }
            else
            {
                this.ViewData["Message"] = "Your application description page.";
                return this.View();
            }
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
