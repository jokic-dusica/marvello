using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Data.Entities
{
   public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int TypeId { get; set; }
        public virtual ProjectType Type { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Task> Tasks { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Project()
        {
            Users = new List<User>(); /*Kreiranje prazne Liste objekata user*/
            Tasks = new List<Task>();
        }
 
    }
}
