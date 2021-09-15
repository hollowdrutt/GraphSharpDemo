namespace GraphSharpDemo.Model
{
    /// <summary>
    /// A simple identifiable vertex.
    /// </summary>
    public class PocVertex
    {
        public string ID { get; }
        public bool IsMale { get; }

        public PocVertex(string id, bool isMale)
        {
            ID = id;
            IsMale = isMale;
        }

        public override string ToString()
        {
            return $"{ID}-{IsMale}";
        }
    }
}