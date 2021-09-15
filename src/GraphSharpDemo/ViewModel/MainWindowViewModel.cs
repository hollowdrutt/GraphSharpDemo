using GraphSharp.Algorithms.Layout;
using GraphSharpDemo.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphSharpDemo.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public PocGraph Graph { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _layoutAlgorithmType = "";

        public MainWindowViewModel()
        {
            Graph = new PocGraph();
            var existingVertices = new List<PocVertex>
            {
                new PocVertex("Sacha Barber", true),//0
                new PocVertex("Sarah Barber", false),//1
                new PocVertex("Marlon Grech", true),//2
                new PocVertex("Daniel Vaughan", true),//3
                new PocVertex("Bea Costa", false)//4
            };
            foreach (var vertex in existingVertices)
            {
                Graph.AddVertex(vertex);
            }

            //add some edges to the graph
            AddNewGraphEdge(existingVertices[0], existingVertices[1]);
            AddNewGraphEdge(existingVertices[0], existingVertices[2]);
            AddNewGraphEdge(existingVertices[0], existingVertices[3]);
            AddNewGraphEdge(existingVertices[0], existingVertices[4]);

            AddNewGraphEdge(existingVertices[1], existingVertices[0]);
            AddNewGraphEdge(existingVertices[1], existingVertices[2]);
            AddNewGraphEdge(existingVertices[1], existingVertices[3]);

            AddNewGraphEdge(existingVertices[2], existingVertices[0]);
            AddNewGraphEdge(existingVertices[2], existingVertices[1]);
            AddNewGraphEdge(existingVertices[2], existingVertices[3]);
            AddNewGraphEdge(existingVertices[2], existingVertices[4]);

            AddNewGraphEdge(existingVertices[3], existingVertices[0]);
            AddNewGraphEdge(existingVertices[3], existingVertices[1]);
            AddNewGraphEdge(existingVertices[3], existingVertices[3]);
            AddNewGraphEdge(existingVertices[3], existingVertices[4]);

            AddNewGraphEdge(existingVertices[4], existingVertices[0]);
            AddNewGraphEdge(existingVertices[4], existingVertices[2]);
            AddNewGraphEdge(existingVertices[4], existingVertices[3]);

            var edgeString = $"{existingVertices[0].ID}-{existingVertices[0].ID} Connected";
            Graph.AddEdge(new PocEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new PocEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new PocEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new PocEdge(edgeString, existingVertices[0], existingVertices[1]));

            //Add Layout Algorithm Types
            var layoutAlgorithmFactory = new StandardLayoutAlgorithmFactory<PocVertex, PocEdge, PocGraph>();
            LayoutAlgorithmTypes.AddRange(layoutAlgorithmFactory.AlgorithmTypes);
            //Pick a default Layout Algorithm Type
            LayoutAlgorithmType = "LinLog";

        }
        private void AddNewGraphEdge(PocVertex from, PocVertex to)
        {
            var edgeString = $"{from.ID}-{to.ID} Connected";
            var newEdge = new PocEdge(edgeString, from, to);
            Graph.AddEdge(newEdge);
        }
        public List<string> LayoutAlgorithmTypes { get; } = new List<string>();


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LayoutAlgorithmType
        {
            get => _layoutAlgorithmType;
            set
            {
                if (value == _layoutAlgorithmType)
                {
                    return;
                }
                _layoutAlgorithmType = value;
                OnPropertyChanged();
            }
        }
    }
}
