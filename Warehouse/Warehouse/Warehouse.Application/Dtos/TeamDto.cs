using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos
{
	 public class TeamDto
	 {
		  protected TeamDto(
			   Guid id,
			   string name,
			   Guid teamOwnerId,
			   int points,
			   IEnumerable<UserDto>userDtos)
		  {
			   Id = id;
			   Name = name;
			   TeamOwnerId = teamOwnerId;
			   Points = points;
			   UserDtos = userDtos;
          }

		  public Guid Id { get; }
		  public string Name { get; set; }
		  public Guid TeamOwnerId { get; }
		  public int Points { get; set; }
		  public IEnumerable<UserDto> UserDtos { get; }

		  public static explicit operator TeamDto(Team team)
			   =>new TeamDto(
				    team.Id,
				    team.Name,
				    team.TeamOwnerId,
				    team.Points,
				    team.Users.Select(user => (UserDto)user));
	 }
}
