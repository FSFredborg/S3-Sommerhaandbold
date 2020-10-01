using Model;
using System.Collections.ObjectModel;

namespace GUI {
    class MainViewModel {
        public ObservableCollection<Team> Teams { get; private set; }

        public MainViewModel(IDatabase database) {
            Teams = new ObservableCollection<Team>();
            foreach (var team in database.AllTeams()) {
                Teams.Add(team);
            }
        }
    }
}
