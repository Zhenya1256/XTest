using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;

namespace Hurricane.XTest.Core.Processors.Encoders
{
    public class VarshamovaCoder : IEncoder
    {
        public static Random _random = new Random();
        private JsonParser<QuestionEntity> _jsonParser;

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

        public VarshamovaCoder(CodeType codeType)
        {
            CodeType = codeType;
        }

        private IQuestionEntity Encoder()
        {
			IQuestionEntity questionEntity = new QuestionEntity();
			questionEntity.QuestionType = QuestionType.Varshamova;
			questionEntity.CodeType = CodeType;

			questionEntity.Description = "Закодируйте число:";

			// StringBuilder matrix = new StringBuilder();
			StringBuilder answer = new StringBuilder();
			int[,] Gmatr = GMatrix();
			int[,] Hmatr = HMatrix();

			int[] matrix = new int[6];
			for (int j = 0; j < 6; j++)
			{
				int randNumber = _random.Next(0, 2);

				matrix[j] = randNumber;
				answer.Append(matrix[j]);
			}
			answer.Append(Gmatr);
			answer.Append(Hmatr);

			questionEntity.Question = new BaseValue()
			{
				//Нужно вывести комбинацию которую необходимо закодировать и две матрицы G и H
				Value = answer.ToString()
			};
			answer.Clear();

			string result = DoResult(string.Join("", matrix));
			answer.Append(result);

			questionEntity.Answer = new BaseValue()
			{ Value = answer.ToString() };
			return questionEntity;
		}

		//Для Варшамова нет декодирования
        private IQuestionEntity Decoder()
        {
            return _jsonParser.GetIQuestionEntity(11, 21, "VarshamovaCoder");
        }

		/// <summary>
		/// Кодирует число по матрицам G и H
		/// </summary>
		/// <param name="number">число которое необходимо закодировать</param>
		/// <returns></returns>
		public static string DoResult(string number)
		{
			List<int> nums = new List<int>();
			var chars = number.ToCharArray();
			for (int i = 0; i < chars.Length; i++)
			{
				if (chars[i] == '1')
				{
					nums.Add(i);
				}
			}
			int[,] hmatr = HMatrix();
			int resStolb = 0;
			List<int> listNum = new List<int>(3);
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					foreach (int item in nums)
					{
						resStolb += hmatr[item, j];
					}
					listNum.Add(resStolb % 2);
					resStolb = 0;
				}
			}
			string resH = listNum[0].ToString() + listNum[1].ToString() + listNum[2].ToString() + listNum[3].ToString();
			string finalResult = number + resH;
			return finalResult;
		}

		/// <summary>
		/// Создает матрицу G
		/// </summary>
		/// <returns></returns>
		public static int[,] GMatrix()
		{
			int[,] p = new int[6, 6];
			Random ran = new Random();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					p[i, j] = 0;
				}
			}
			p[0, 0] = 1;
			p[1, 1] = 1;
			p[2, 2] = 1;
			p[3, 3] = 1;
			p[4, 4] = 1;
			p[5, 5] = 1;
			return p;
		}
		/// <summary>
		/// Создает матрицу H
		/// </summary>
		/// <returns></returns>
		public static int[,] HMatrix()
		{
			int[,] p = new int[6, 4];
			Random ran = new Random();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					p[i, j] = 0;
				}
			}
			p[0, 2] = 1;
			p[0, 3] = 1;
			p[1, 1] = 1;
			p[1, 3] = 1;
			p[2, 0] = 1;
			p[2, 3] = 1;
			p[3, 1] = 1;
			p[3, 2] = 1;
			p[4, 0] = 1;
			p[4, 2] = 1;
			p[5, 0] = 1;
			p[5, 1] = 1;
			return p;
		}
	}
}
