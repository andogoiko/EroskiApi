using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TxoskiApi.Models
{
    public class Ticket
    {
        [Key]
        public string seccion { get; set; }
        public int N_Ticket { get; set; }
    }
}