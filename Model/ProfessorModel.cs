
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolS.Models
{
    public class Professor
    {
        public int id { get; set; }
        [Required(ErrorMessage="Campo Requerido" )]
        [StringLength(60, ErrorMessage="Mínimo : 3 carac. e Máximo: 60", MinimumLength=3)]
        public string name { get; set; }
        public List<Student> Students { get; set; }
    }
}