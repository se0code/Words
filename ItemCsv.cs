using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    public class ItemCsv
    {
        public ItemCsv()
        {

        }

        public ItemCsv(string word, int count)
        {
            this.Word = word;

            this.Count = count;
        }
        public string Word { get; set; }

        public int Count { get; set; }
    }
}
