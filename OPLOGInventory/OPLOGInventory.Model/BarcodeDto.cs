﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Model
{
    public class BarcodeDto
    {
        [Required]
        public string Label { get; set; }
    }
}
