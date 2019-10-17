// <copyright file="ErrorViewModel.cs" company="Ryan Claw">
// Copyright (c) Ryan Claw. All rights reserved.
// </copyright>

namespace BusinessClientSystem.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}