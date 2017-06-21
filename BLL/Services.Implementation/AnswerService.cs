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
    public class AnswerService:IAnswerService
    {
        private readonly IUnitOfWork _uow;

        public AnswerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateAnswer(AnswerDTO answer)
        {
            _uow.Answers.Create(answer.ToAnswerEntity());
            _uow.Save();
        }

        public void DeleteAnswer(int id)
        {
            _uow.Answers.Delete(id);
            _uow.Save();
        }

        public void DeleteAnswer(AnswerDTO answer)
        {
            _uow.Answers.Delete(answer.ToAnswerEntity());
            _uow.Save();
        }

        public IEnumerable<AnswerDTO> GetAllAnswers()
        {
            return _uow.Answers.GetAll().Select(answer => answer.ToAnswerDto());
        }

        public AnswerDTO GetAnswer(int id)
        {
            var answer = _uow.Answers.Get(id);
            if (ReferenceEquals(answer, null))
                return null;
            return answer.ToAnswerDto();
        }

        public void UpdateAnswer(AnswerDTO answer)
        {
            _uow.Answers.Update(answer.ToAnswerEntity());
            _uow.Save();
        }
    }
}
