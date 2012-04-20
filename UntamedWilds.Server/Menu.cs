using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UntamedWilds.Server
{
    public class Menu
    {
        public Menu()
        {
            this.Options = new List<Option>();
        }

        public List<Option> Options { get; set; }

        public class Option
        {
            public Option() { }
            public Option(string text, int value)
                : this()
            {
                this.Text = text;
                this.Value = value;
            }

            public string Text { get; set; }
            public int Value { get; set; }
        }
    }
}