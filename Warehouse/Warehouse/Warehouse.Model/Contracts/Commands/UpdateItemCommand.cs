﻿using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateItemCommand
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
<<<<<<< HEAD
        public string Description { get; set; }
=======
        public string Description { get; set; }   
>>>>>>> main
        public int Quantity { get; set; }
    }
}
