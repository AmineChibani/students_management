using Student_Management.ModelView;
using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Abonnement
{
    public int IdAbonnement { get; set; }

    public string TypeAbonnement { get; set; } = null!;

    public DateTime DateDeCreation { get; set; }

    public double Solde { get; set; }

    public int StudentId { get; set; }

    public virtual ICollection<AbonnementLigne> AbonnementLignes { get; } = new List<AbonnementLigne>();

    public virtual Student Student { get; set; } = null!;



    public Abonnement() { }

    public Abonnement(AjouterAbonnement ab) 
    { 
        this.TypeAbonnement = ab.TypeAbonnement;
        this.DateDeCreation = ab.DateDeCreation;
        this.Solde = ab.Solde;
        this.StudentId = ab.StudentId;
        this.AbonnementLignes = ab.ListAbonnementLignes;
    }

}
