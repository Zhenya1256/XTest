using Hurricane.XTest.Core.Abstract;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Abstract.Processors;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities;
using Hurricane.XTest.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Hurricane.Views.UserControls.Coding
{
    /// <summary>
    /// Логика взаимодействия для VarshamovaView.xaml
    /// </summary>
    public partial class VarshamovaView : UserControl
    {
        private readonly IGenerateProcess _generateProcess;
        private readonly ICollection<IQuestionEntity> _questionEntities;
        private IQuestionEntity _currentQuestionEntity;
        private int number = 1;
        private readonly IAnswerCheker _answerCheker;
        private Grid _grid;
        private List<TextBox> _textAnswer;

        public VarshamovaView(Grid grid)
        {
            InitializeComponent();
            _grid = grid;
            _textAnswer = new List<TextBox>();
            StaertTest.Click += StaertTest_Click;
            _generateProcess = new GenerateProcess();
            _answerCheker = new AnswerCheker();
            _questionEntities = _generateProcess.GetQuestions(QuestionType.Varshamova).Data;
            _currentQuestionEntity = _questionEntities.FirstOrDefault(p => p.StateType == StateType.Default);
            DescriptionText.Text = _currentQuestionEntity?.Description;
            Number.Text = number.ToString();
            Correct.Text = $"{_questionEntities.Count(p => p.StateType == StateType.Corect)}/{_questionEntities.Count}";
        }

        private void StaertTest_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in _textAnswer)
            {
                sb.Append(s.Text);
            }
            StateType stateType = _answerCheker.CheckQuestion(new TestAnswerEntity()
            {
                AllCount = _questionEntities.Count,
                Answer = new BaseValue()
                {
                    Value = sb.ToString()
                },
                CurrentCount = number,
                NameTest = QuestionType.Ellieas.ToString(),
                QuestionEntity = _currentQuestionEntity
            }).Data;
            _currentQuestionEntity = _questionEntities
                .FirstOrDefault(p => p.StateType == StateType.Default);

            if (_currentQuestionEntity != null)
            {
                DescriptionText.Text = _currentQuestionEntity?.Description;

                number++;
                Number.Text = number.ToString();
                Correct.Text = $"{_questionEntities.Count(p => p.StateType == StateType.Corect)}/{_questionEntities.Count}";
            }
            else
            {
                _grid.Children.Clear();
                _grid.Children.Add(new ResultView(_grid, this, QuestionType.Ellieas.ToString()));
            }
        }
    }
}
