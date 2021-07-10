using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Entities
{
	 public sealed class Team : Entity
	 {
		  public Team(
			   Guid id,
			   string name,
			   Guid teamOwnerId,
			   string description,
			   int points,
			   State state
			   ):base (id)
		  {
			   Name = name;
			   TeamOwnerId = teamOwnerId;
			   Description = description;
			   Points = points;
			   State = state;
			   Users = new List<User.Entities.User>();
		  }

		  public string Name { get; }
		  public Guid TeamOwnerId { get; }
		  public string Description { get; private set; }
		  public int Points { get; private set; }
		  public State State { get; private set; }
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
			   if (State == State.Active)
			   {
				    return false;
			   }

			   State = State.Active;
			   return true;
		  }

		  public bool Delete()
		  {
			   if (State == State.Deleted)
			   {
				    return false;
			   }

			   State = State.Deleted;
			   return true;
		  }
	 }
}
