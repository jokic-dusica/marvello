using System;
using System.Collections.Generic;

namespace Marvello.Data.Entities
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Project> Projects { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ProjectType()
        {
            Projects = new List<Project>();
        }
    }
}