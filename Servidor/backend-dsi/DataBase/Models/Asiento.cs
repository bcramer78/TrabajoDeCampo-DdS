using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Asiento
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }
    }
}
