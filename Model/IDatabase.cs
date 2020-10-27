using System.Collections.Generic;

namespace Model {
    public interface IDatabase {
        List<Team> AllTeams();

        // Delete the given team if it exists. Only the Id property is used.
        void DeleteTeam(Team team);

        // Add the given team to the database. The Id property is updated to
        // match the database.
        void AddTeam(Team team);

        // Update the matching database record (by Id), such that any changes
        // to properties are changed.
        void UpdateTeam(Team team);
    }

    // Team is a plain object. You may change its properties; to save such
    // changes, use IDatabase.UpdateTeam.
    //
    // Structs are not supported by EF Core. Use classes
    public class Team {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seed { get; set; }
        public int Pot { get; set; }
    }
}
