using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class SESSION_A_APPL_DTL_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        [Required]
        public string MST_REF_ID { get; set; }
        [Required]
        public string APPL_NAME { get; set; }
        [Required]
        public string APPL_EMAIL { get; set; }
        [Required]
        public string APPL_PHONE { get; set; }
    }
}