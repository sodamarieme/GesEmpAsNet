using System;

namespace GesEmpAspNet.Models
{
    public class Account
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string Holder { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // e.g., Épargne, Chèque
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty; // e.g., Actif, Bloqué
    }
}
