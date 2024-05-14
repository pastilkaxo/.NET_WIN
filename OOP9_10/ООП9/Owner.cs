using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{

    [Serializable]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birth { get; set; }
        public string PassportSeries { get; set; }

        [Index(IsUnique = true)]
        public int PassportNumber { get; set; }

        public virtual ICollection<ClientCheck> ClientChecks { get; set; }
    }
}
