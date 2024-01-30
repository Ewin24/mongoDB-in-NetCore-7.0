using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongotest.Models
{
    public class UpdateAuthorModel
    {
        public string Name { get; set; }

        public IEnumerable<BookModel> Books { get; set; }
    }
}