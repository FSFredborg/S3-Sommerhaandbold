using System;
using System.Collections.Generic;
using System.Text;

namespace S3_Sommerhaandbold {
    interface IDatabase {
        List<Team> AllTeams();
        void DeleteTeam(Team team);
        void AddTeam(Team team);
    }

    class Team {
        int Id { get; set; }
        string Name { get; set; }
    }
}
