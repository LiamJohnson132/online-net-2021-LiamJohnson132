﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Make
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
    }
}
