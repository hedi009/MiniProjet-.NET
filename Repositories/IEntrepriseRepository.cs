using miniProjet.Models;

namespace miniProjet.Repositories
{
    public interface IEntrepriseRepository
    {
        IList<Entreprise> GetAll();
        Entreprise GetById(int id);
        void Add(Entreprise s);
        void Edit(Entreprise s);
        void Delete(Entreprise s);
        double EmployeAgeAverage(int entrepriseId);
        int EmployeCount(int entrepriseId);

    }
}
