using Microsoft.EntityFrameworkCore;
using miniProjet.Models;

namespace miniProjet.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {
        readonly EmployeContext context;
        public EmployeRepository(EmployeContext context)
        {
            this.context = context;
        }
        public IList<Employe> GetAll()
        {
            return context.Employes.OrderBy(x => x.EmployeName).Include(x
            => x.Entreprise).ToList();
        }
        public Employe GetById(int id)
        {
            return context.Employes.Where(x => x.EmployeId ==
            id).Include(x => x.Entreprise).SingleOrDefault();
        }
        public void Add(Employe s)
        {
            context.Employes.Add(s);
            context.SaveChanges();
        }
        public void Edit(Employe s)
        {
            Employe s1 = context.Employes.Find(s.EmployeId);
            if (s1 != null)
            {
                s1.EmployeName = s.EmployeName;
                s1.Age = s.Age;
                s1.BirthDate = s.BirthDate;
                s1.EntrepriseID = s.EntrepriseID;
                context.SaveChanges();
            }
        }
        public void Delete(Employe s)
        {
            Employe s1 = context.Employes.Find(s.EmployeId);
            if (s1 != null)
            {
                context.Employes.Remove(s1);
                context.SaveChanges();
            }
        }
        public IList<Employe> GetEmployesByEntrepriseID(int? schoolId)
        {
            return context.Employes.Where(s =>
            s.EntrepriseID.Equals(schoolId))
            .OrderBy(s => s.EmployeName)
            .Include(std => std.Entreprise).ToList();
        }
        public IList<Employe> FindByName(string name)
        {
            return context.Employes.Where(s =>
            s.EmployeName.Contains(name)).Include(std =>
            std.Entreprise).ToList();
        }
    }

}
