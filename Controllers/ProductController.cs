// <copyright file="ProductController.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace SessionManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using MySql.Data.MySqlClient;

    using SessionManagement.Models;

    public class ProductController : Controller
    {
        public IActionResult List()
        {
            string query = $"select * from products";

            using (var connection = this.CreateConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                var result = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (result.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt32(result["id"], null),
                        Name = result["name"].ToString(),
                        Price = Convert.ToDouble(result["price"], null),
                        PictureUrl = result["pictureUrl"].ToString(),
                    };
                    products.Add(product);
                }

                this.ViewBag.Products = products;
                return this.View();
            }
        }

        public IActionResult View(int id)
        {
            string query = $"select * from products where id = {id}";

            using (var connection = this.CreateConnection())
            using (var cm = new MySqlCommand(query, connection))
            {
                var result = cm.ExecuteReader();
                while (result.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt32(result["id"], null),
                        Name = result["name"].ToString(),
                        Price = Convert.ToDouble(result["price"], null),
                        PictureUrl = result["pictureUrl"].ToString(),
                    };
                    this.ViewBag.Product = product;
                }

                return this.View();
            }
        }

        public IActionResult Add()
        {
            if (this.InvalidSession())
            {
                return this.ReturnToLogin();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(string name, double price, IFormFile picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            string pictureUrl = null;
            if (picture.Length > 0)
            {
                var fileName = Path.GetFileName(picture.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

                pictureUrl = "/images/" + fileName;
            }

            string query = $"insert into products(name, price, pictureUrl) values('{name}', {price}, '{pictureUrl}'); select last_insert_id();";
            using (var connection = this.CreateConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                return this.Redirect($"/product/view/?id={command.LastInsertedId}");
            }
        }

        private MySqlConnection CreateConnection()
        {
            var connectionString = "server=localhost;database=SessionManagement;user=root;password=root;port=3306"; // declaring a connection string
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private IActionResult ReturnToLogin()
        {
            return this.Redirect("/auth/login");
        }

        private bool InvalidSession()
        {
            return this.HttpContext.Session.GetString("user") == null;
        }
    }
}