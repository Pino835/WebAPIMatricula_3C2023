﻿namespace WebAPI.Models
{
    public class RegisterModel
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
    }
}
