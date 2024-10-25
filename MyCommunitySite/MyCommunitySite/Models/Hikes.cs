using System.Collections;

namespace MyCommunitySite.Models
{
    public class Hikes : IEnumerable<Hike>
    {
        public Hike NewHike { get; set; }
        public List<Hike> HikesList { get; set; } = new List<Hike>();

        public int Count
        {
            get
            {
                return HikesList.Count;
            }
        }

        public void Add(Hike hike)
        {
            HikesList.Add(hike);
        }

        public IEnumerator<Hike> GetEnumerator()
        {
            return ((IEnumerable<Hike>)HikesList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)HikesList).GetEnumerator();
        }
    }
}
