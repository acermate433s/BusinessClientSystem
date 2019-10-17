// <copyright file="Address.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    public sealed class Address
    {
        public int Id { get; set; }

        public int House { get; set; }

        public string Road { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}