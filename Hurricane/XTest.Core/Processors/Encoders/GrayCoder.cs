using System;
using System.Text;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;

namespace Hurricane.XTest.Core.Processors.Encoders
{
    public class GrayCoder :IEncoder
    {
        private  const int codeSize = 32;

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

        public GrayCoder(CodeType codeType)
        {
            CodeType = codeType;
        }

        private IQuestionEntity Encoder()
        {

            IQuestionEntity questionEntity = new QuestionEntity();
            questionEntity.QuestionType = QuestionType.Gray;
            questionEntity.CodeType = CodeType;

            questionEntity.Description = "Закодируйте сообщение";

            // StringBuilder matrix = new StringBuilder();
            StringBuilder answer = new StringBuilder();

            int[] matrix = new int[codeSize];
            for (int j = 0; j < codeSize; j++)
            {
                int randNumber = _random.Next(0, 2);

                matrix[j] = randNumber;
                answer.Append(matrix[j]);

               
            }

            questionEntity.Question = new BaseValue()
            {
                Value = answer.ToString()
            };
            answer.Clear();
            this.gray(codeSize, ref matrix, 0);
            for(int i =0; i < matrix.Length;i++)
            {
                answer.Append(matrix[i]);
            }
            questionEntity.Answer = new BaseValue()
            { Value = answer.ToString() };

           

            return questionEntity;
        }
        private IQuestionEntity Decoder()
        {
            throw new Exception();
        }
        //n -- требуемая длина кода,
        //m -- указатель на массив, способный хранить
        // все коды Грея, длиной до n
        // (должен быть выделен до вызова функции)
        //depth -- параметр рекурсии

        private int gray(int n, ref int[] m, int depth)
        {
            int i, t = (1 << (depth - 1));

            if (depth == 0)
                m[0] = 0;

            else
            {
                //массив хранит десятичные записи двоичных слов
                for (i = 0; i < t; i++)
                    m[t + i] = m[t - i - 1] + (1 << (depth - 1));
            }
            if (depth != n)
                gray(n, ref m, depth + 1);

            return 0;
        }

        
    }

    
}
