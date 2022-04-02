using Models.Data;
using System.ComponentModel.DataAnnotations;

namespace PatronRepository_UnitOfWork.Models.ViewModels
{
    public class FormPersonaViewModel
    {
        [Required]
        public string? Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        public int? NacionalidadId { get; set; }

        [Display(Name = "Otra marca")]
        public string? OtraNacionalidad { get; set; }
    }
}
