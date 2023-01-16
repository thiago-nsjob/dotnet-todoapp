using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiagoToDo.Api.Contracts.Requests
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Item { get; set; }
    }
}
