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
                CategoryState categoryState,
			    IEnumerable<UserDto>userDtos)
			   :base(id,name,categoryState)
		  {
			   UserDtos = userDtos;
		  }

		  public IEnumerable<UserDto> UserDtos { get; }

		  public static explicit operator FullSquadDto(Domain.Squad.Entities.Squad squad)
			   => new(squad.Id,
				      squad.Name,
                      squad.CategoryState,
				      squad.Users.Select(user => (UserDto)user));
	 }
}
