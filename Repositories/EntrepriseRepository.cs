using miniProjet.Models;

namespace miniProjet.Repositories
{
    public class EntrepriseRepository : IEntrepriseRepository
    {
        readonly EmployeContext context;
        public EntrepriseRepository(EmployeContext context)
        {
            this.context = context;
        }
        public IList<Entreprise> GetAll()
        {
            return context.Entreprises.OrderBy(s => s.EntrepriseName).ToList();
        }
        public Entreprise GetById(int id)
        {
            return context.Entreprises.Find(id);
        }
        public void Add(Entreprise s)
        {
            context.Entreprises.Add(s);
            context.SaveChanges();
        }
        public void Edit(Entreprise s)
        {
            Entreprise s1 = context.Entreprises.Find(s.EntrepriseID);
            if (s1 != null)
            {
                s1.EntrepriseName = s.EntrepriseName;
                s1.EntrepriseAdress = s.EntrepriseAdress;
                context.SaveChanges();
            }
        }
        public void Delete(Entreprise s)
        {
            Entreprise s1 = context.Entreprises.Find(s.EntrepriseID);
            if (s1 != null)
            {
                context.Entreprises.Remove(s1);
                context.SaveChanges();
            }
        }
        public double EmployeAgeAverage(int entrepriseID)
        {
            if (EmployeCount(entrepriseID) == 0)
                return 0;
            else
                return context.Employes.Where(s => s.EntrepriseID ==
                entrepriseID).Average(e => e.Age);
        }
        public int EmployeCount(int entrepriseID)
        {
            return context.Employes.Where(s => s.EntrepriseID ==
            entrepriseID).Count();
        }
    }

}
