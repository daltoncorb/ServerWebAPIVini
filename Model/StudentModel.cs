
using System.ComponentModel.DataAnnotations;
using SchoolS.Models;

namespace SchoolS.Models
{
    public class Student
    {
        public int id { get; set; }    
        [Required(ErrorMessage="Campo Requerido")]     
        [StringLength(60, ErrorMessage="Mínimo : 3 carac. e Máximo: 60", MinimumLength=3)]
        public string name { get; set; }
        public int age { get; set; }
        public string bornDate { get; set; }
        public Professor Professor { get; set; }

        [Required(ErrorMessage="Campo Requerido")]
        public int ProfessorId{get; set;}

    }
}