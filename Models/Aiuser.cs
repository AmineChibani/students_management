using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Aiuser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AudioDatum> AudioData { get; } = new List<AudioDatum>();

    public virtual ICollection<BannedUser> BannedUsers { get; } = new List<BannedUser>();
}
