using miniProjet.Models;

namespace miniProjet.Repositories
{
    public interface IEmployeRepository
    {
        IList<Employe> GetAll();
        Employe GetById(int id);
        void Add(Employe s);
        void Edit(Employe s);
        void Delete(Employe s);
        IList<Employe> GetEmployesByEntrepriseID(int? schoolId);
        IList<Employe> FindByName(string name);
    }
}
