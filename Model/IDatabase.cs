using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
    public class Team : INotifyPropertyChanged {
        public int Id { get; set; }

        public string Name 
        { 
            get
            {
                return _name;
            }

            set
            { 
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            } 
        }

        public int Seed 
        {
            get
            {
                return _seed;
            }

            set
            {
                if (_seed != value)
                {
                    _seed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Pot 
        {
            get
            {
                return _pot;
            }

            set
            {
                if (_pot != value)
                {
                    _pot = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _name;
        private int _seed;
        private int _pot;
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
