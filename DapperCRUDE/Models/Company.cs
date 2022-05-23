﻿using System.ComponentModel.DataAnnotations;

namespace DapperCRUDE.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

    }
}
