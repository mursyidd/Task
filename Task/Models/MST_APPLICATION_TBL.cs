using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class MST_APPLICATION_TBL
    {

        [Key] // Primary Key
        public int RunninNO { get; set; }
        [Required]
        public string ApplicationID { get; set; }
        [Required]
        public int StageID { get; set; }
        [Required]
        public int SessionID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ActiveStatus { get; set; }
    }
}
