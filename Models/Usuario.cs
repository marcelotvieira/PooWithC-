using System;

namespace Poo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsRandomPassword { get; set; }
    }
}