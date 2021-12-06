using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class Sounds
    {

        public Sounds(string effect)
        {
            if (effect == "Pop")
            {
                Pop();
                return;
            }

            if (effect == "Victory")
            {
                Victory();
                return;
            }
        }
        public Sounds()
        {
        }

        public void Pop()
        {
            using (var player = new SoundPlayer("PopWav.wav"))
            {
                player.Play();
            }
        }

        public void Victory()
        {
            using (var player = new SoundPlayer("Victory.wav"))
            {
                player.Play();
            }
        }
    }
}
