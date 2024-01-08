using Student_Management.Models;

namespace Student_Management.ModelView
{
    public class ModifierAbonnementViewModel
    {
        public int Id { get; set; }
        public string TypeAbonnement { get; set; }
        public DateTime DateDeCreation { get; set; }
        public double Solde { get; set; }
        public int SelectedStudentId { get; set; }
        public List<int> SelectedLineIds { get; set; }

        public List<LineViewModel> Lines { get; set; }
    }
    public class LineViewModel
    {
        public int LigneId { get; set; }
        public int NumLine { get; set; }
        public bool IsChecked { get; set; }
    }
}
