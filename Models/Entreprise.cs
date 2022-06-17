namespace miniProjet.Models
{
    public class Entreprise
    {
        public int EntrepriseID { get; set; }
        public string EntrepriseName { get; set; }
        public string EntrepriseAdress { get; set; }
        public ICollection<Employe> Employes { get; set; }

    }
}
