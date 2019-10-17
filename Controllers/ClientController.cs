// <copyright file="ClientController.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Controllers
{
    using BusinessClientSystem.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ClientController : Controller
    {
        public IActionResult New()
        {
            return this.View();
        }

        public IActionResult New1()
        {
            return this.View();
        }

        public IActionResult Sample()
        {
            return this.View();
        }

        [HttpPost]
        public RedirectResult New1(
            string salutation,
            string firstname,
            string lastname,
            string gender,
            DateTimeOffset dateofbirth,
            string address1,
            string address2,
            string phone1,
            string phone2,
            string email)
        {
            BusinessClient businessClient = new BusinessClient();
            Clients client = new Clients
            {
                // newClient.id = id;
                Salutation = salutation,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                DateOfBirth = dateofbirth,
                Address1 = address1,
                Address2 = address2,
                Phone1 = phone1,
                Phone2 = phone2,
                Email = email,
            };
            businessClient.AddClientToDB(client);
            return this.Redirect("/Client");
        }

        public IActionResult Profile(int id)
        {
            BusinessClient cs = new BusinessClient();
            this.ViewData["clients"] = cs.GetClients(id);
            return this.View();
        }

        [HttpPost]
        public RedirectResult New(
            string salutation,
            string firstname,
            string lastname,
            string gender,
            DateTimeOffset dateofbirth,
            string address1,
            string address2,
            string phone1,
            string phone2,
            string email)
        {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients
            {
                // newClient.id = id;
                Salutation = salutation,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                DateOfBirth = dateofbirth,
                Address1 = address1,
                Address2 = address2,
                Phone1 = phone1,
                Phone2 = phone2,
            };
            newClient.Gender = gender;
            newClient.Email = email;
            cs.AddClientToDB(newClient);
            return this.Redirect("/Client");
        }

        public IActionResult Update(int id)
        {
            BusinessClient cs = new BusinessClient();
            this.ViewData["clients"] = cs.GetClients(id);
            return this.View();
        }

        [HttpPost]
        public RedirectResult Update(
            int id,
            string salutation,
            string firstname,
            string lastname,
            string gender,
            DateTimeOffset dateofBirth,
            string address1,
            string address2,
            string phone1,
            string phone2,
            string email)
        {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients
            {
                Id = id,
                Salutation = salutation,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                DateOfBirth = dateofBirth,
                Address1 = address1,
                Address2 = address2,
                Phone1 = phone1,
                Phone2 = phone2,
                Email = email,
            };
            cs.UpdateClientToDB(newClient);
            return this.Redirect("/Client");
        }

        public IActionResult Update1(int id)
        {
            BusinessClient cs = new BusinessClient();
            this.ViewData["clients"] = cs.GetClients(id);
            return this.View();
        }

        [HttpPost]
        public RedirectResult Update1(
            int id,
            string salutation,
            string firstname,
            string lastname,
            string gender,
            DateTimeOffset dateofBirth,
            string address1,
            string address2,
            string phone1,
            string phone2,
            string email)
        {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients
            {
                Id = id,
                Salutation = salutation,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                DateOfBirth = dateofBirth,
                Address1 = address1,
                Address2 = address2,
                Phone1 = phone1,
                Phone2 = phone2,
                Email = email,
            };
            cs.UpdateClientToDB(newClient);
            return this.Redirect("/Client");
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public RedirectResult Delete(int id)
        {
            BusinessClient cs = new BusinessClient();
            cs.DeleteClient(id);
            return this.Redirect("/client");
        }

        public IActionResult Index()
        {
            var user = this.HttpContext.Session.GetString("user");
            if (user == null)
            {
                return this.Redirect("/auth/login");
            }
            else
            {
                BusinessClient cs = new BusinessClient();
                this.ViewData["clients"] = cs.GetClientsFromDb();
                return this.View();
            }
        }
    }
}
