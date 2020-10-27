using System;
using System.Collections.Generic;
using System.Text;

namespace GUI {
    class LayerViewModel {
        private readonly int layer;

        public LayerViewModel(int layer) {
            this.layer = layer;
        }

        public string Title { get => $"Layer {layer}"; }
    }
}
