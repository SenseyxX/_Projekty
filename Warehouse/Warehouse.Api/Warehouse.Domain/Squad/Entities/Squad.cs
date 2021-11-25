using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Factories;

namespace Warehouse.Domain.Squad.Entities
{
    public sealed class Squad : Aggregate
    {
        public Squad(
            Guid id,
            string name,
            Guid? squadOwnerId,
            State state)
            : base(id)
        {
            SquadOwnerId = squadOwnerId;
            Name = name;
            State = state; 
            Teams = new List<Team>();
            Users = new List<User.Entities.User>();
        }

        public Guid? SquadOwnerId { get; private set; }          
        public string Name { get; private set; }
        public State State { get;private set; }
        public ICollection<Team> Teams { get; }
        public ICollection<User.Entities.User> Users { get; }

        public bool UpdateSquadOwnerId(Guid squadOwnerId)
        {
            if (SquadOwnerId == squadOwnerId)
            {
                return false;
            }

            SquadOwnerId = squadOwnerId;
            return true;
        }

        public bool UpdateName(string name)
        {
            if (Name == name || string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
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

        public void AddTeam(string teamName,
                            Guid teamOwnerId,
                            string description)
        {
            if (Teams.Any(team => team.Name == teamName))
            {
                throw new Exception();
            }

            var team = TeamFactory.Create(teamName, teamOwnerId,Id, description);
            Teams.Add(team);
        }

        public void DeleteTeam(Guid teamId)
        {
            if (Teams.Any(team => team.Id != teamId && team.State != State.Active))
            {
                throw new Exception();
            }

            Teams
                .First(team => team.Id == teamId)
                .Delete();
        }
        
        public bool UpdateTeamPoints(Guid teamId, int points)
        {
            if (Teams.Any(team => team.Id != teamId ))
            {
                throw new Exception();
            }

            Teams
                .First(team => team.Id == teamId)
                .UpdatePoints(points);

            return true;
        }
        
        public bool UpdateTeamDescription(Guid teamId, string description)
        {
            if (Teams.Any(team => team.Id != teamId))
            {
                throw new Exception();
            }

            Teams
                .First(team => team.Id == teamId)
                .UpdateDescription(description);

            return true;
        }
        
        public bool UpdateTeamName(Guid teamId, string name)
        {
            if (Teams.Any(team => team.Id != teamId))
            {
                throw new Exception();
            }

            Teams
                .First(team => team.Id == teamId)
                .UpdateName(name);
            
            return true;
        }
        
        public bool UpdateTeamOwner(Guid teamId, Guid teamOwnerId)
        {
            if (Teams.Any(team => team.Id != teamId))
            {
                throw new Exception();
            }

            Teams
                .First(team => team.Id == teamId)
                .UpdateTeamOwner(teamOwnerId);
            
            return true;
        }
    }
}
