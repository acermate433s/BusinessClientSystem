// <copyright file="BusinessClient.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;

    public class BusinessClient
    {
        public MySqlConnection CreateConnection()
        {
            string connectionString = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void AddClientToDB(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            string query = $"insert into clients values({client.Id}, '{client.Salutation}', '{client.FirstName}', '{client.LastName}', '{client.Gender}', '{client.DateOfBirth}','{client.Address1}','{client.Address2}', {client.Phone1}, {client.Phone2}, '{client.Email}')";

            using (var connection = this.CreateConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClientToDB(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            string query = $"update clients set id={client.Id}, salutation='{client.Salutation}', firstname='{client.FirstName}', lastname='{client.LastName}', gender='{client.Gender}', dateofbirth='{client.DateOfBirth}', address1='{client.Address1}', address2='{client.Address2}', phone1={client.Phone1}, phone2={client.Phone2}, email='{client.Email}' where id={client.Id}";

            using (var connection = this.CreateConnection())
            using (var commandcmd = new MySqlCommand(query, connection))
            {
                commandcmd.ExecuteNonQuery();
            }
        }

        public List<Client> GetClientsFromDb()
        {
            const string connectionString = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306";

            List<Client> clients = new List<Client>();

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("select * from clients", connection))
            {
                connection.Open();

                var result = command.ExecuteReader();

                while (result.Read())
                {
                    Client c = new Client
                    {
                        Id = Convert.ToInt32(result["id"], null),
                        Salutation = result["salutation"].ToString(),
                        FirstName = result["firstName"].ToString(),
                        LastName = result["lastName"].ToString(),
                        Gender = result["gender"].ToString(),
                        DateOfBirth = DateTimeOffset.Parse(result["dateofbirth"].ToString(), null),
                        Address1 = result["address1"].ToString(),
                        Address2 = result["address2"].ToString(),
                        Phone1 = result["phone1"].ToString(),
                        Phone2 = result["phone2"].ToString(),
                        Email = result["email"].ToString(),
                    };
                    clients.Add(c);
                }

                return clients;
            }
        }

        public Client GetClients(int id)
        {
            string cmdText = $"select * from clients where id = {id}";

            using (var connection = this.CreateConnection())
            using (var command = new MySqlCommand(cmdText, connection))
            {
                var result = command.ExecuteReader();
                var client = new Client();
                while (result.Read())
                {
                    client.Id = Convert.ToInt32(result["id"], null);
                    client.Salutation = result["salutation"].ToString();
                    client.FirstName = result["firstName"].ToString();
                    client.LastName = result["lastName"].ToString();
                    client.Gender = result["gender"].ToString();
                    client.DateOfBirth = DateTimeOffset.Parse(result["dateofbirth"].ToString(), null);
                    client.Address1 = result["address1"].ToString();
                    client.Address2 = result["address2"].ToString();
                    client.Phone1 = result["phone1"].ToString();
                    client.Phone2 = result["phone2"].ToString();
                    client.Email = result["email"].ToString();
                }

                return client;
            }
        }

        public void DeleteClient(int id)
        {
            string query = $"delete from clients where id = {id}";

            using (var connection = this.CreateConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
