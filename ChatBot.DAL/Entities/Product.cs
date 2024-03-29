﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageFileName { get; set; } = null!;
        public string AudioFileName { get; set; } = null!;
        public int CategoryId { get; set; }

        // navigation properties
        public Category Category { get; set; } = null!;
    }
}
