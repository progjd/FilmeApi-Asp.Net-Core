using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage= "Titulo obrigatorio")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Titulo obrigatorio")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Titulo Genero")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "Duracao obrigatorio")]
        public int Duracao { get; set; }




    }
}
