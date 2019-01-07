using System;
using System.Collections.Generic;
using System.Linq;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;

namespace Hurricane.XTest.Core.Processors.Encoders
{
    public class DDC : IEncoder
    {

        public static Random _random = new Random();
        public static List<Task> tasks;

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

        public DDC(CodeType codeType)
        {
            CodeType = codeType;
            tasks = new List<Task>() {
            new Task { Id = 0, NumbToCoding = "437", Mask = "5-3-2-1" },
            new Task { Id = 1, NumbToCoding = "56485", Mask = "5-2-1-1" },
            new Task { Id = 2, NumbToCoding = "9389", Mask = "8-4-2-1" },
            new Task { Id = 3, NumbToCoding = "2237", Mask = "5-4-2-1" },
            new Task { Id = 4, NumbToCoding = "1614", Mask = "4-3-1-1" },
            new Task { Id = 5, NumbToCoding = "36", Mask = "6-3-2-1" },
            new Task { Id = 6, NumbToCoding = "4780", Mask = "4-3-2-1" },
            new Task { Id = 7, NumbToCoding = "47324", Mask = "8-4-2-1" },
            new Task { Id = 8, NumbToCoding = "639", Mask = "6-4-2-1" },
            new Task { Id = 9, NumbToCoding = "16710", Mask = "4-2-2-1" },
            new Task { Id = 10, NumbToCoding = "5865", Mask = "4-3-1-1" },
            new Task { Id = 11, NumbToCoding = "18", Mask = "5-3-1-1" },
            new Task { Id = 12, NumbToCoding = "62", Mask = "5-3-2-1" },
            new Task { Id = 13, NumbToCoding = "391", Mask = "3-3-2-1" },
            new Task { Id = 14, NumbToCoding = "63642", Mask = "5-3-2-1" },
            new Task { Id = 15, NumbToCoding = "566", Mask = "4-4-2-1" },
            new Task { Id = 16, NumbToCoding = "36", Mask = "7-4-2-1" },
            new Task { Id = 17, NumbToCoding = "686", Mask = "6-3-2-1" },
            new Task { Id = 18, NumbToCoding = "125", Mask = "6-4-2-1" },
            new Task { Id = 19, NumbToCoding = "9302", Mask = "4-3-2-1" }
        };
        }


        private IQuestionEntity Encoder()
        {
            IQuestionEntity questionEntity = new QuestionEntity();
            questionEntity.QuestionType = QuestionType.EasyReturn;
            questionEntity.CodeType = CodeType;

            Console.WriteLine("\n==================================\n");
            string numbToDecoding = GenerateNumbToDecoding();

            questionEntity.Description = "Число для декодирования: " + numbToDecoding;

            Task task = tasks.Find(item => item.Id == RandomizeFromList());
            string decodMask = task.Mask;
            Console.WriteLine("Число для декодирования: " + numbToDecoding);
            Console.WriteLine("Маска: " + decodMask);
            int[] maskNumbs = TransferMaskToArr(decodMask);

            string[] numbToDecodingParts = TransferResToParts(numbToDecoding, maskNumbs);

            string answer =  GetMyltipliedByMask(maskNumbs, numbToDecodingParts);

            questionEntity.Question = new BaseValue()
            {
                Value = string.Format("Маска: {1}", numbToDecoding, decodMask)
            };

            questionEntity.Answer = new BaseValue()
            {
                Value = answer.ToString()
            };

            return questionEntity;
        }

        private string GenerateNumbToDecoding()
        {
            Random random = new Random();
            string result = "";
            for (int i = 0; i < 16; i++)
            {
                result += random.Next(2);
            }
            return result;
        }

        private string GenerateBitValue()
        {
            Random random = new Random();
            return random.Next(1).ToString();
        }

        private string GetMyltipliedByMask(int[] maskNumbs, string[] parts)
        {
            string res = "";
            for (int i = 0; i < parts.Length; i++)
            {
                res += GetMyltipliedPartByMask(maskNumbs, parts[i]);
            }
            return res;
        }

        private string GetMyltipliedPartByMask(int[] maskNumbs, string part)
        {
            int res = 0;
            for (int i = 0; i < maskNumbs.Length; i++)
            {
                res += maskNumbs[i] * Convert.ToInt32("" + part[i]);
            }
            return res.ToString();
        }

        
        
        private IQuestionEntity Decoder()
        {
            Task task = tasks.Find(item => item.Id == RandomizeFromList());

            IQuestionEntity questionEntity = new QuestionEntity();
            questionEntity.QuestionType = QuestionType.EasyReturn;
            questionEntity.CodeType = CodeType;

            questionEntity.Description = "Закодировать число: " + task.NumbToCoding;

           

            Console.WriteLine("Закодировать число: " + task.NumbToCoding);
            Console.WriteLine("Маска: " + task.Mask);
            int[] maskNumbs = TransferMaskToArr(task.Mask);

            questionEntity.Answer = new BaseValue()
            {
                Value = GenerateResult(maskNumbs, task.NumbToCoding)
            };

            questionEntity.Question = new BaseValue()
            {
                Value = "Маска: " + task.Mask
            };

            return questionEntity;            
        }

        private int RandomizeFromList()
        {
            Random random = new Random();
            return random.Next(20);
        }

        private string GenerateResult(int[] maskNumbs, string numbToCoding)
        {
            string result = "";
            for (int i = 0; i < numbToCoding.Length; i++)
            {
                result += GenerateResForPart(maskNumbs, "" + numbToCoding[i]);
            }
            return result;
        }

        private string GenerateResForPart(int[] maskNumbs, string partOfNumbToCoding)
        {
            int answNumb = Convert.ToInt32(partOfNumbToCoding);
            string resut = "";
            foreach (int numb in maskNumbs)
            {
                if (answNumb / numb >= 1)
                {
                    answNumb -= numb;
                    resut += 1;
                }
                else
                {
                    resut += 0;
                }
            }
            return resut;
        }

        
        private string[] TransferResToParts(string res, int[] maskNumbs)
        {
            string[] resultArr = new string[maskNumbs.Length];
            string part = "";
            int partNumb = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (i % maskNumbs.Length != 0 || i == 0)
                {
                    part += res[i];
                    if (i == 15)
                    {
                        resultArr[partNumb] = part;
                    }
                    continue;
                }
                resultArr[partNumb] = part;
                part = "" + res[i];
                partNumb += 1;
            }
            return resultArr;
        }

        private int[] TransferMaskToArr(string mask)
        {
            return TransferToIntArr(mask.Split('-'));
        }

        private int[] TransferToIntArr(string[] arr)
        {
            return arr.Select(x => int.Parse(x)).ToArray();
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string NumbToCoding { get; set; }
        public string Mask { get; set; }
    }
}
