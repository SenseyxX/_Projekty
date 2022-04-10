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

        public void AddUser(User.Entities.User user)
        {
            if (Users.Any(u => u.Id == user.Id))
            {
                throw new Exception();
            }

            Users.Add(user);
        }

        public void AddTeam(string teamName,
            Guid teamOwnerId,
            string description)
        {
            if (Teams.Any(team => team.Name == teamName))
            {
                throw new Exception();
            }

            var user = Users.FirstOrDefault(user => user.Id == teamOwnerId)
                ?? throw new Exception();

            var team = TeamFactory.Create(teamName, teamOwnerId,Id, description);

            team.AddUser(user);
            Teams.Add(team);
        }

        public void DeleteTeam(Guid teamId)
            => GetTeamById(teamId)
                .Delete();

        public bool UpdateTeamPoints(Guid teamId, int points)
            => GetTeamById(teamId)
                .UpdatePoints(points);

        public bool UpdateTeamDescription(Guid teamId, string description)
            => GetTeamById(teamId)
                .UpdateDescription(description);

        public bool UpdateTeamName(Guid teamId, string name)
            => GetTeamById(teamId)
                .UpdateName(name);

        public bool UpdateTeamOwner(Guid teamId, Guid teamOwnerId)
            => GetTeamById(teamId)
                .UpdateTeamOwner(teamOwnerId);

        // ToDo: Wystarczy podać userId, wybrać użytkownika ze składu
        public void AddTeamUser(Guid teamId, User.Entities.User user)
        {
            var team = GetTeamById(teamId);

            team.AddUser(user);
        }

        private Team GetTeamById(Guid teamId)
            => Teams.FirstOrDefault(team => team.Id == teamId)
                ?? throw new Exception();
    }
}
