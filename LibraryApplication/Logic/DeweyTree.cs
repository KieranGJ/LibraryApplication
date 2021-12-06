using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    /// <summary>
    /// Tree structure
    /// </summary>
    public class DeweyTree
    {
        public string call;
        public string category;
        public List<DeweyTree> t1 = new List<DeweyTree>();

    }
}
