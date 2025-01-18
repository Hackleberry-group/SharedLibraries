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
        public string? Url { get; set; } = null;
        public FileDTO() { }
        public FileDTO(Guid guid, string name) 
        {
            Id = guid;
            Name = name;
        }
        public FileDTO(Guid guid, string name, string url) : this(guid, name)
        {
            Url = url;
        }
    }
}
