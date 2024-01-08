﻿using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Student
{
    public int IdStudent { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Cen { get; set; } = null!;

    public string Cin { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Etat { get; set; }

    public int Cartier { get; set; }

    public virtual ICollection<Abonnement> Abonnements { get; } = new List<Abonnement>();

    public virtual Cartier CartierNavigation { get; set; } = null!;

    public virtual ICollection<Click> Clicks { get; } = new List<Click>();

    public virtual ICollection<Historique> Historiques { get; } = new List<Historique>();
}
