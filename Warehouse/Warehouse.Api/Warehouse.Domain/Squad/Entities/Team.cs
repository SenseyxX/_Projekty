using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Squad.Entities
{
	 public sealed class Team : Entity
	 {
		  public Team(
			   Guid id,
			   string name,
			   Guid teamOwnerId,
			   string description,
			   int points,
			   CategoryState categoryState
			   ):base (id)
		  {
			   Name = name;
			   TeamOwnerId = teamOwnerId;
			   Description = description;
			   Points = points;
			   CategoryState = categoryState;
			   Users = new List<User.Entities.User>();
		  }

		  public string Name { get; }
		  public Guid TeamOwnerId { get; }
		  public string Description { get; private set; }
		  public int Points { get; private set; }
		  public CategoryState CategoryState { get; private set; }
		  public ICollection<User.Entities.User> Users { get; }

		  public bool UpdateDescription(string description)
		  {
			   if (Description == description)
			   {
				    return false;
			   }

			   Description = description;
			   return true;
		  }

		  public bool UpdatePoints(int points)
		  {
			   if (Points == points)
			   {
				    return false;
			   }

			   Points = points;
			   return true;
		  }

		  public bool Activate()
		  {
			   if (CategoryState == CategoryState.Active)
			   {
				    return false;
			   }

			   CategoryState = CategoryState.Active;
			   return true;
		  }

		  public bool Delete()
		  {
			   if (CategoryState == CategoryState.Deleted)
			   {
				    return false;
			   }

			   CategoryState = CategoryState.Deleted;
			   return true;
		  }
	 }
}
