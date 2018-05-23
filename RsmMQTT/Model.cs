using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsmMQTT
{
    class Model
    {
        public String id = "";
        public String desc = "";

        public Model(String id, String desc) {
            this.id = id;
            this.desc = desc;
        }

        public override string ToString()
        {
            return this.id;
        }
    }
}
