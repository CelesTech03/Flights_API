﻿using System;
namespace FlightsAPI.Models
{
	public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public object? Data { get; set; }
    }
}

