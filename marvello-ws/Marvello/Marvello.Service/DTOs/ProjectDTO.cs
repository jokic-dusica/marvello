using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int TypeId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ProjectTypeDTO ProjectType { get; set; }
    }
}
