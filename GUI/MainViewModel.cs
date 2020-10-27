using Model;
using System.Collections.ObjectModel;

namespace GUI {
    class MainViewModel {
        public TeamsViewModel TeamsViewModel { get; private set; }

        public ObservableCollection<LayerViewModel> Layers { get; private set; }

        public MainViewModel(IDatabase database) {
            Layers = new ObservableCollection<LayerViewModel>();
            for (int i = 1; i <= 4; ++i) Layers.Add(new LayerViewModel(i));

            TeamsViewModel = new TeamsViewModel(database);
        }
    }
}
