using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class TestVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string NumberTemplate => $"This object has number - {this.Number.ToString()}";
    }
}
