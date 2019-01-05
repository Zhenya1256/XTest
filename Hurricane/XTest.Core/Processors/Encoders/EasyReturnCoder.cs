using System;
using System.Text;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;

namespace Hurricane.XTest.Core.Processors.Encoders
{
    public class EasyReturnCoder : IEncoder
    {

        public static Random _random = new Random();

        public IQuestionEntity QuestionEntity
        {
            get
            {
                return CodeType.Dencoding == CodeType ? Decoder() : Encoder();
            }
            set
            {
            }
        }
        public CodeType CodeType { get; set; }

        public EasyReturnCoder(CodeType codeType)
        {
            CodeType = codeType;
        }


        private IQuestionEntity Encoder()
        {
            IQuestionEntity questionEntity = new QuestionEntity();
            questionEntity.QuestionType = QuestionType.EasyReturn;
            questionEntity.CodeType = CodeType;

            questionEntity.Description = "Закодируйте сообщение";

            StringBuilder answer = new StringBuilder();
            StringBuilder questionValue = new StringBuilder();

            int countNumber = _random.Next(3, 9);

            for (int i = 0; i < countNumber; i++)
            {
                if (i == 0)
                {
                    questionValue.Append(_random.Next(1, 9));
                }
                else
                {
                    questionValue.Append(_random.Next(0, 9));
                }
            }

            answer.Append(questionValue); answer.Append(questionValue);

            questionEntity.Question = new BaseValue()
            {
                Value = questionValue.ToString()
            };

            questionEntity.Answer = new BaseValue()
            {
                Value = answer.ToString()
            };

            return questionEntity;
        }

        private IQuestionEntity Decoder()
        {
            IQuestionEntity questionEntity = new QuestionEntity();
            questionEntity.QuestionType = QuestionType.EasyReturn;
            questionEntity.CodeType = CodeType;

            questionEntity.Description = "Раскодируйте сообщение";

            StringBuilder answer = new StringBuilder();

            StringBuilder questionValue = new StringBuilder();

            int countNumber = _random.Next(3, 9);

            for (int i = 0; i < countNumber; i++)
            {
                if (i == 0 )
                {
                    answer.Append(_random.Next(1, 9));
                }
                else
                {
                    answer.Append(_random.Next(0, 9));
                }
               
            }

            questionValue.Append(answer); questionValue.Append(answer);

            questionEntity.Answer = new BaseValue()
            {
                Value = answer.ToString()
            };

            questionEntity.Question = new BaseValue()
            {
                Value = questionValue.ToString()
            };

            return questionEntity;
        }

    }
}