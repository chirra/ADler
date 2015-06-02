using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADler.Model
{
    public class Client
    {
        public string X { get; set; }
        public string Y { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Client()
        {
        }

        public Client(string x, string y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }

}
