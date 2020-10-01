using System;
using System.Collections.Generic;

using Model;

namespace GUI {
    class PlaceholderDatabase : IDatabase {
        void IDatabase.AddTeam(Team team) {
            System.Windows.MessageBox.Show($"Added team '{team.Name}'.");
        }

        List<Team> IDatabase.AllTeams() {
            return new List<Team> {
                new Team { Id = 0, Name = "Team 0" },
                new Team { Id = 1, Name = "Team 1" },
                new Team { Id = 2, Name = "Team 2" },
            };
        }

        void IDatabase.DeleteTeam(Team team) {
            System.Windows.MessageBox.Show($"Deleted team with ID '{team.Id}'.");
        }

        public void UpdateTeam(Team team) {
            System.Windows.MessageBox.Show($"Updated team with ID '{team.Id}'.");
        }
    }
}
