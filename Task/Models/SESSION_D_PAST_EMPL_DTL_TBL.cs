using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class SESSION_D_PAST_EMPL_DTL_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        [Required]
        public string MST_REF_ID { get; set; }
        [Required]
        public string PAST_COMP_NAME { get; set; }
        [Required]
        public string PAST_JOB_TITLE { get; set; }
        [Required]
        public string PAST_EXP { get; set; }
    }
}
