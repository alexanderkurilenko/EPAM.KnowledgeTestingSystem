using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Answer's text")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Text { get; set; }

        [Display(Name = "Is it correct answer?")]
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}