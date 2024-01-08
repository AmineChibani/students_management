using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class AudioDatum
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public byte[]? Audio { get; set; }

    public int? AiuserId { get; set; }

    public virtual Aiuser? Aiuser { get; set; }
}
