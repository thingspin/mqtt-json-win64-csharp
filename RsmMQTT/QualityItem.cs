using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsmMQTT
{
    class QualityItem
    {
        public int id = 0;
        public String name = "";
        public String description = "";

        public QualityItem(int id, String name, String description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override string ToString()
        {
            return id + "";
        }
    }
}
