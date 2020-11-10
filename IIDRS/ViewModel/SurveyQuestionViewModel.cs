using System.ComponentModel.DataAnnotations;


namespace IIDRS.ViewModel
{
    public class SurveyQuestionViewModel
    {
        //public string ID { get; set; }

        [Display(Name ="Category")]
        public string SURVEY_QUESTION_NAME { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "required")]
        public string SURVEY_QUESTION_DESC { get; set; }
    }
}