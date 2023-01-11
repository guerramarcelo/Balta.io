using Balta.SharedContext;

namespace Balta.SharedContext
{
    public class Lecture : Base
    {
        public int Ordem { get; set; }
        public string Title { get; set; }
        public int DurationInMunutes { get; set; }
    }
}
