using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring.Class
{
    class Data
    {
        private int docId;
        private int clusterId;

        public Data(int docId)
        {
            this.docId = docId;
            this.clusterId = DataProperties.UNCLUSTERED;
        }
        public Data(int docId, int clusterId)
        {
            this.docId = docId;
            this.clusterId =clusterId;
        }
        public int DocId { get => docId; set => docId = value; }
        public int ClusterId { get => clusterId; set => clusterId = value; }
                   
    }
}
