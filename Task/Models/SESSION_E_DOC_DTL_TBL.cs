using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class SESSION_E_DOC_DTL_TBL
    {
        [Key] // Primary Key
        public int RunninNO { get; set; }
        public string MST_REF_ID { get; set; }
        public string DOC_RESUME { get; set; }
        public string DOC_COVER { get; set; }
        public bool AGREEMENT { get; set; }
    }
}
