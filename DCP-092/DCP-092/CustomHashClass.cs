using System;
using System.Collections;
using System.Collections.Generic;

namespace DCP_092
{
    public class NIKHashClass
    {

        public string key;
        public List<string> contents;

        public NIKHashClass(string key, List<string> contents)
        {
            this.key = key;
            this.contents = contents;
        }
    }
}
