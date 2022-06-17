using System.ComponentModel.DataAnnotations;

namespace miniProjet.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        [Required]
        public string EmployeName { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int EntrepriseID { get; set; }
        public Entreprise Entreprise { get; set; }

    }
}
