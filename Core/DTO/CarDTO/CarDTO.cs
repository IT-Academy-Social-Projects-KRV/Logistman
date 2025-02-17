﻿using System;

namespace Core.DTO
{
    public class CarDTO
    {
        public int Id {get; set;}
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public string TechnicalPassport { get; set; }
        public float LoadCapacity { get; set; }
        public string Color { get; set; }
        public string Vin { get; set; }
        public string Category { get; set; }
        public bool IsVerified { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
