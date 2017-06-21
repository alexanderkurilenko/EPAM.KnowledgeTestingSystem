﻿using BLL.DTO;
using BLL.Mapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class QuestionService:IQuestionService
    {
        private readonly IUnitOfWork _uow;

        public QuestionService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void CreateQuestion(QuestionDTO question)
        {
            _uow.Questions.Create(question.ToQuestionEntity());
            _uow.Save();
        }

        public void DeleteQuestion(int id)
        {
            _uow.Questions.Delete(id);
            _uow.Save();
        }

        public void DeleteQuestion(QuestionDTO question)
        {
            _uow.Questions.Delete(question.ToQuestionEntity());
            _uow.Save();
        }

        public IEnumerable<QuestionDTO> GetAllQuestions()
        {
            return _uow.Questions.GetAll().Select(question => question.ToQuestionDto());
        }

        public QuestionDTO GetQuestion(int id)
        {
            var question = _uow.Questions.Get(id);
            if (ReferenceEquals(question, null))
                return null;
            return question.ToQuestionDto();
        }

        public void UpdateQuestion(QuestionDTO question)
        {
            _uow.Questions.Update(question.ToQuestionEntity());
            _uow.Save();
        }
    }
}
