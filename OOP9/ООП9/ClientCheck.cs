using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    [Serializable]
    public class ClientCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }
        public string CheckType { get; set; }

        public double Balance { get; set; }

        [ForeignKey("Owner")]
        public int ClientID { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
