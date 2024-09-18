using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Br.Counter
{
    public interface IWordCounter
    {
        Task<Dictionary<string, int>> Counter(string inputLine);
    }
}
