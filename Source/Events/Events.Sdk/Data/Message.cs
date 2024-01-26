using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Sdk.Data;

public class Message
{
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public required string Content { get; set; }

    public required string TopicId { get; set; }

}
