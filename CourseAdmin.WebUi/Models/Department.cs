using System.ComponentModel.DataAnnotations;

namespace CourseAdmin.WebUi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [MaxLength(50,ErrorMessage ="El nombre del departamento no puede mayor a 50")]
       
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Campo requerido")]
        public decimal? Budget { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string StartDate { get; set; }
        
        [Range(5,10,ErrorMessage ="Campo inválido")]
        public int? Administrador { get; set; }

     



    }
}
