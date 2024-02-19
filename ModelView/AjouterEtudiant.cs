using System.ComponentModel.DataAnnotations;

namespace Student_Management.ModelView
{
    public class AjouterEtudiant
    {
        [Required(ErrorMessage = "Le champ Id de l'étudiant est requis.")]
        public int IdStudent { get; set; }

        [Required(ErrorMessage = "Le champ Nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est requis.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Cen est requis.")]
        public string Cen { get; set; }

        [Required(ErrorMessage = "Le champ Cin est requis.")]
        public string Cin { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est requis.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est requis.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse email valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Mot de passe est requis.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Le champ Etat est requis.")]
        public bool Etat { get; set; }

        [Required(ErrorMessage = "Le champ Cartier est requis.")]
        public int Cartier { get; set; }
    }
}
