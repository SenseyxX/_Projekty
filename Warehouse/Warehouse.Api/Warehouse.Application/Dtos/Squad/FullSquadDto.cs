using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Application.Dtos.User;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Application.Dtos.Squad
{
	 public sealed class FullSquadDto : SquadDto
	 {
		  private FullSquadDto(
                Guid id,
                string name,
                State state,
                IEnumerable<TeamDto> teams,
			    IEnumerable<UserDto> users)
			   :base(id,name,state)
		  {
			   Users = users;
			   Teams = teams;
		  }

		  public IEnumerable<TeamDto> Teams { get; }
		  public IEnumerable<UserDto> Users { get; }

		  public static explicit operator FullSquadDto(Domain.Squad.Entities.Squad squad)
			   => new(
                   squad.Id,
                   squad.Name,
                   squad.State,
                   squad.Teams.Select(team => (TeamDto)team),
                   squad.Users.Select(user => (UserDto)user));
	 }
}
