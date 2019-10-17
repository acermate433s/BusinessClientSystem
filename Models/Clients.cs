// <copyright file="Clients.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    using System;

    public sealed class Clients
    {
        public int Id { get; set; }

        public string Salutation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Email { get; set; }
    }
}
