﻿using System;
namespace InterdimensionalThings.Models
{
    public class Thing
    {





        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }
        public int Id { get; set; }


        public Thing()
        {
        }
    }
}
