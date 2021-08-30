using System;
using Warehouse.Domain.User.Entities;
using Warehouse.Domain.User.Enumeration;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Domain.User.Factories
{
	 public static class DueFactory
     {
         public static Due Create(Guid userId, Half half, int amount, DueStatus dueStatus)
             => new(
                 Guid.NewGuid(),
                 userId,
                 half,
                 amount,
                 DueStatus.Waiting);
     }
}
