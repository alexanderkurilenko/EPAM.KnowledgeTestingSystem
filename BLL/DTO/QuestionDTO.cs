﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int TestId { get; set; }
        public TestDTO Test { get; set; }
    }
}
