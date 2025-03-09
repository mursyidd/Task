namespace Task.Models
{
    public class ReviewModel
    {
        public SESSION_A_APPL_DTL_TBL SESSION_A { get; set; } = new SESSION_A_APPL_DTL_TBL();
        public SESSION_B_EMPL_DTL_TBL SESSION_B { get; set; } = new SESSION_B_EMPL_DTL_TBL();
        public SESSION_C_QUAL_DTL_TBL SESSION_C { get; set; } = new SESSION_C_QUAL_DTL_TBL();
        public SESSION_D_PAST_EMPL_DTL_TBL SESSION_D { get; set; } = new SESSION_D_PAST_EMPL_DTL_TBL();
        public SESSION_E_DOC_DTL_TBL SESSION_E { get; set; } = new SESSION_E_DOC_DTL_TBL();

    }
}
