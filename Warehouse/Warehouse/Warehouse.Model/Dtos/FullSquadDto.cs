using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
	 public sealed class FullSquadDto : SquadDto
	 {
		  private FullSquadDto(
                Guid id,
                string name,
                State state,
			    IEnumerable<UserDto>userDtos)
			   :base(id,name,state)
		  {
			   UserDtos = userDtos;
		  }

		  public IEnumerable<UserDto> UserDtos { get; }

		  public static explicit operator FullSquadDto(Squad squad)
			   => new(squad.Id,
				      squad.Name,
                      squad.State,
				      squad.Users.Select(user => (UserDto)user));
	 }
}
