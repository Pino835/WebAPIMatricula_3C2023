﻿using System.ComponentModel.DataAnnotations;
namespace WebAPI.Entities
{
    public class Usuario
    {
        [Key]
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Estado { get; set; }
    }
}
