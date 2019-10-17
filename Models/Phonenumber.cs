// <copyright file="PhoneNumber.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string AreaCode { get; set; }

        public string Number { get; set; }

        public string PhoneType { get; set; }
    }
}