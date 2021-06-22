﻿using System;

namespace Warehouse.Model.Contracts.Commands
{
    public sealed class UpdateItemCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}