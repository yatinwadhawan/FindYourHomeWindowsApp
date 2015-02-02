using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapApplication
{
    public class Places
    {
        public String address { get; set; }
        public int rent { get; set; }
        public int rooms { get; set; }
        public String available_date { get; set; }
        public int category { get; set; }

        public Places(String address, int rent, int rooms, String availdate,int cat)
        {
            this.address = address;
            this.rent = rent;
            this.rooms = rooms;
            this.available_date = availdate;
            this.category = cat;
        }

        public Places()
        {
            // TODO: Complete member initialization
        }
    }
}
