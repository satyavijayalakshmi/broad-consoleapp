using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Br.Sorter
{
    public interface IWordSorter
    {
        Dictionary<string, int> Sorter(Dictionary<string, int> wordCountResult);
    }
}
