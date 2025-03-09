using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class SESSION_B_EMPL_DTL_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        [Required]
        public string MST_REF_ID { get; set; }
        [Required]
        public string EMPL_TITLE { get; set; }
        [Required]
        public string EMPL_COMP_NAME { get; set; }
        [Required]
        public string EMPL_EXP { get; set; }
    }
}
