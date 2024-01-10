using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Sdk.Data
{
    public class Message
    {
        [Required]
        public DateTimeOffset DateTimeOffset { get; set; }
        [Required]
        public string Content { get; set; }
        public string? EventId { get; set; }

    }
}
