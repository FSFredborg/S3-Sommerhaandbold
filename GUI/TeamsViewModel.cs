using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;

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
                Teams.Add(team);
            }

            Teams.CollectionChanged += TeamsCollectionChanged;
        }

        private void TeamsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null) {
                        foreach (Team team in e.NewItems)
                        {
                            Db.AddTeam(team);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (Team team in e.OldItems)
                        {
                            Db.DeleteTeam(team);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldItems != null)
                    {
                        foreach (Team team in e.OldItems)
                        {
                            Db.DeleteTeam(team);
                        }
                    }
                    if (e.NewItems != null)
                    {
                        foreach (Team team in e.NewItems)
                        {
                            Db.AddTeam(team);
                        }
                    }
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
