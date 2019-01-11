using Hurricane.XTest.Core.Const.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurricane.XTest.Core.Const
{
    static class CacheCodeName 
    {
        public static Dictionary<QuestionType, String> map = new Dictionary<QuestionType, string>()
        {
            {QuestionType.Abramson, "Код Абрамсона"}
        }; 
    }
}
