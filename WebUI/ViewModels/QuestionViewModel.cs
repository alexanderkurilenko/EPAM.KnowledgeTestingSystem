using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Question's text")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Text { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
        public int? SelectedAnswer { get; set; }
        public int TestId { get; set; }
    }
}