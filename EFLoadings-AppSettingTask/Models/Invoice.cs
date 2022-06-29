using System.ComponentModel.DataAnnotations.Schema;

namespace EFLoadings_AppSettingTask.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }

}
