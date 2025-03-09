using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class SESSION_C_QUAL_DTL_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        [Required]
        public string MST_REF_ID { get; set; }
        [Required]
        public string QUAL { get; set; }
        [Required]
        public string CERT { get; set; }
        [Required]
        public string SKILL { get; set; }
    }
}
