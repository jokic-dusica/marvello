using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Service.DTOs
{
    public class ProjectTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
