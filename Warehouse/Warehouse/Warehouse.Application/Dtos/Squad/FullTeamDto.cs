using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Application.Dtos.User;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos.Squad
{
	 public sealed class FullTeamDto : TeamDto
	 {
		  private FullTeamDto(
			   Guid id,
			   string name,
			   Guid squadId,
			   Guid teamOwnerId,
			   int points,
			   IEnumerable<UserDto> userDtos)
			  :base(id,name,squadId)
		  {
			   TeamOwnerId = teamOwnerId;
			   Points = points;
			   UserDtos = userDtos;
          }
		  
		  public Guid TeamOwnerId { get; }
		  public int Points { get; set; }
		  public IEnumerable<UserDto> UserDtos { get; }

		  public static explicit operator FullTeamDto(Team team)
			   =>new (
				    team.Id,
				    team.Name,
				    team.SquadId,
				    team.TeamOwnerId,
				    team.Points,
				    team.Users.Select(user => (UserDto)user));
	 }
}
