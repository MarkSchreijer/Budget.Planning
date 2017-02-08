﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Planning.DataAccess.Models
{
    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}