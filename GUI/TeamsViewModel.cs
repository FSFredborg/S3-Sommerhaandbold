using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;
using System.ComponentModel;

namespace GUI
{
    class TeamsViewModel
    {
        private IDatabase Db { get; }

        public ObservableCollection<Team> Teams { get; private set; }

        public TeamsViewModel(IDatabase database)
        {
            Db = database;
            Teams = new ObservableCollection<Team>();
            foreach (var team in Db.AllTeams())
            {
                team.PropertyChanged += TeamsCollectionItemChanged;
                Teams.Add(team);
            }

            Teams.CollectionChanged += TeamsCollectionChanged;
        }

        public void NewTeamAdded(string name, string seed) {
            // TODO: Initialize Pot, handle error when parsing seed.
            Teams.Add(new Team { Id = -1, Name = name, Seed = int.Parse(seed), Pot = -1 });
        }

        private void TeamsCollectionItemChanged(object sender, PropertyChangedEventArgs e)
        {
            Db.UpdateTeam((Team)sender);
        }

        private void TeamsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null) {
                        foreach (Team team in e.NewItems)
                        {
                            team.PropertyChanged += TeamsCollectionItemChanged;
                            Db.AddTeam(team);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (Team team in e.OldItems)
                        {
                            team.PropertyChanged -= TeamsCollectionItemChanged;
                            Db.DeleteTeam(team);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
}
