﻿using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Campaign
{
    public int Id { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public double Budget { get; set; }

    public string ContentUrl { get; set; } = null!;

    public string AdUrl { get; set; } = null!;

    public int IdType { get; set; }

    public int IdPublisher { get; set; }

    public int IdAgeRange { get; set; }

    public int IdLocation { get; set; }

    public virtual ICollection<Click> Clicks { get; } = new List<Click>();

    public virtual AgeRange IdAgeRangeNavigation { get; set; } = null!;

    public virtual Location IdLocationNavigation { get; set; } = null!;

    public virtual Publisher IdPublisherNavigation { get; set; } = null!;

    public virtual AdType IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<O> IdOs { get; } = new List<O>();
}
