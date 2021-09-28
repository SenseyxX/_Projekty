﻿using System;
using Warehouse.Domain.User.Enumeration;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Application.Contracts.Commands.User
{
	 public sealed class CreateDueCommand
	 {
		  public Guid UserId { get; init; }
		  public Half Half { get; init; }
		  public int Amount { get; init; }
		  public DueStatus DueStatus { get; init; }
	 }
}
