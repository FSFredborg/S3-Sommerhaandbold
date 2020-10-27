using Model;
using System.Collections.ObjectModel;

namespace GUI {
    class MainViewModel {
        public ObservableCollection<Team> Teams { get; private set; }

        public ObservableCollection<LayerViewModel> Layers { get; private set; }

        public MainViewModel(IDatabase database) {
            Layers = new ObservableCollection<LayerViewModel>();
            for (int i = 1; i <= 4; ++i) Layers.Add(new LayerViewModel(i));

            Teams = new ObservableCollection<Team>();
            foreach (var team in database.AllTeams()) {
                Teams.Add(team);
            }
        }
    }
}
