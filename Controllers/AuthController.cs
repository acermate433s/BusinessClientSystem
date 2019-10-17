// <copyright file="AuthController.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace SessionManagement.Controllers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MySql.Data.MySqlClient;

    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            this.ViewData["error"] = false;
            this.ViewData["loginSuccessful"] = false;
            this.ViewData["userNotFound"] = false;
            return this.View();
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Clear(); // clearout the session
            return this.Redirect("/auth/login");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string query = $"select * from users where email = '{email}' and password = '{password}'";

            try
            {
                using (var connection = CreateConnection())
                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        this.HttpContext.Session.SetString("user", email); // setting the the session in HttpContext

                        this.ViewData["error"] = false;
                        this.ViewData["loginSuccessful"] = true;
                        this.ViewData["userNotFound"] = false;
                        return this.View();
                    }
                    else
                    {
                        this.ViewData["error"] = false;
                        this.ViewData["loginSuccessful"] = false;
                        this.ViewData["userNotFound"] = true;
                        return this.View();
                    }
                }
            }
            catch (MySqlException)
            {
                this.ViewData["error"] = true;
                this.ViewData["loginSuccessful"] = false;
                this.ViewData["userNotFound"] = false;
                return this.View();
            }
        }

        public IActionResult Register()
        {
            this.ViewData["registrationSuccessful"] = false;
            this.ViewData["error"] = false;
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string email, string password)
        {
            string query = $"insert into users(firstName, lastName, email, password) values('{firstName}', '{lastName}', '{email}', '{password}')";

            try
            {
                using (var connection = CreateConnection())
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    this.ViewData["registrationSuccessful"] = true;
                    this.ViewData["error"] = false;
                    return this.View();
                }
            }
            catch (MySqlException)
            {
                this.ViewData["error"] = true;
                this.ViewData["registrationSuccessful"] = false;
                return this.View();
            }
        }

        private static MySqlConnection CreateConnection()
        {
            string connectionString = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}