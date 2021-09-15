using QuickGraph;

namespace GraphSharpDemo.Model
{
    public class PocEdge : Edge<PocVertex>
    {
        public string ID { get; }

        public PocEdge(string id, PocVertex source, PocVertex target)
            : base(source, target)
        {
            ID = id;
        }

        public override string ToString()
        {
            return "";
        }
    }
}