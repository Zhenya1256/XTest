﻿using System;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;

namespace Hurricane.XTest.Core.Processors.Encoders
{
    public class PrimaryNonDualOnes : IEncoder
    {
        private JsonParser<QuestionEntity> _jsonParser;

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

        public PrimaryNonDualOnes(CodeType codeType)
        {
            _jsonParser = new JsonParser<QuestionEntity>();
            CodeType = codeType;
        }

        private IQuestionEntity Encoder()
        {
            return _jsonParser.GetIQuestionEntity(1, 11, "PrimaryNonDualOnes");
        }
        private IQuestionEntity Decoder()
        {
            return _jsonParser.GetIQuestionEntity(11, 21, "PrimaryNonDualOnes");
        }
    }
}
