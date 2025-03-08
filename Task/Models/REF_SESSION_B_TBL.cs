using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class REF_SESSION_B_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        public int MST_REF_ID { get; set; }
        public string COLUMN1 { get; set; }
        public string COLUMN2 { get; set; }
        public string COLUMN3 { get; set; }
    }
}
