﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEshop.Shared.DTO
{
    public class OrderOverviewResponseDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Product { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
