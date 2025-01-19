using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackleberryModels.DTOs.FileServiceDTOs
{
    public class FileDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public FileDTO(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }
        public FileDTO(Guid id, string name, string url) : this(id, name)
        {
            Url = url;
        }
    }
}
