using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Application.Dtos
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

		  public static explicit operator FullSquadDto(Squad squad)
			   => new(squad.Id,
				      squad.Name,
                      squad.CategoryState,
				      squad.Users.Select(user => (UserDto)user));
	 }
}
