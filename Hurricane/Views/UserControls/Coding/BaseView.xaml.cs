using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Const.Enums;
using Hurricane.XTest.Core.Entities.History;
using Hurricane.XTest.Core.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hurricane.Views.UserControls.Coding
{
    /// <summary>
    /// Логика взаимодействия для BaseView.xaml
    /// </summary>
    public partial class BaseView : UserControl
    {
        private Grid _currentGrid;
        private QuestionType _questionType;

        public BaseView(string name,Grid currentGrid)
        {
            InitializeComponent();
            NameTest.Text = name;
            QuestionType questionType = EnR();

            if(questionType== QuestionType.Deffoult)
            {
                questionType = RuR();

               if (questionType== QuestionType.Deffoult)
                {
                    questionType = UaR();
                }
            }
            var temp = MainHistoryEntity.CodingHistorys?.FirstOrDefault(p => p.NameTest ==
                questionType.ToString());
            DateTest.Text += temp?.TestHistorys?.Last()?.CreateTiem.Date;
            BestMark.Text+= temp?.TestHistorys?.Max(p=>p.Mark)??0;
            Try.Text +=    temp?
              .TestHistorys?.Count()??0;
            _currentGrid = currentGrid;
            StaertTest.Click += StaertTest_Click;
        }

        private QuestionType EnR()
        {
            QuestionType questionType = QuestionType.Deffoult;
            if (NameTest.Text.ToLower().Equals("Abramson".ToLower()))
            {
                questionType = QuestionType.Abramson;
              //  _currentGrid.Children.Add(new AbramsoneView(_currentGrid, "Abramson"));
            }
            else if (NameTest.Text.ToLower().Equals("BCH".ToLower()))
            {
                questionType = QuestionType.BCH;
              //  _currentGrid.Children.Add(new BCHView(_currentGrid, "BCH"));
            }
            else if (NameTest.Text.ToLower().Equals("Haphmana".ToLower()))
            {
                questionType = QuestionType.Haphmana;
             //   _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Ellieas".ToLower()))
            {
                questionType = QuestionType.Ellieas;
               // _currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("DDC".ToLower()))
            {
                questionType = QuestionType.DDC;
                //_currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Berger".ToLower()))
            {
                questionType = QuestionType.Berger;
                //_currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Recyrent".ToLower()))
            {
                questionType = QuestionType.Recyrent;
              //  _currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("SystematicHemming".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
                //_currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("CycleHemming".ToLower()))
            {

                questionType = QuestionType.CycleHemming;
           //     _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Faira".ToLower()))
            {
                questionType = QuestionType.Faira;
             //   _currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("PrimaryNonDualOnes".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
               /// _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ModuleCodeQ".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
                //_currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("EasyReturn".ToLower()))
            {
                questionType = QuestionType.EasyReturn;
              // _currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Gray".ToLower()))
            {
                questionType = QuestionType.Gray;
              //  _currentGrid.Children.Add(new GrayView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Iterative".ToLower()))
            {
                questionType = QuestionType.Iterative;
                //_currentGrid.Children.Add(new IterativeCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("RidaMallera".ToLower()))
            {
                questionType = QuestionType.RidaMallera;
                //_currentGrid.Children.Add(new RidaMalleraView(_currentGrid));
            }

            return questionType;
        }
        private QuestionType RuR()
        {
            QuestionType questionType = QuestionType.Deffoult;

            if (NameTest.Text.ToLower().Equals("Абрамсона".ToLower()))
            {
                questionType = QuestionType.Abramson;
          //      _currentGrid.Children.Add(new AbramsoneView(_currentGrid, "Abramson"));
            }
            else if (NameTest.Text.ToLower().Equals("БЧХ".ToLower()))
            {
                questionType = QuestionType.BCH;
            //    _currentGrid.Children.Add(new BCHView(_currentGrid, "BCH"));
            }
            else if (NameTest.Text.ToLower().Equals("Хаффмена".ToLower()))
            {
                questionType = QuestionType.Haphmana;
             //   _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Эллайеса".ToLower()))
            {
                questionType = QuestionType.Ellieas;
              //  _currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ДДК".ToLower()))
            {
                questionType = QuestionType.DDC;
                //_currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Бергера".ToLower()))
            {
                questionType = QuestionType.Berger;
              //  _currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рекуретный".ToLower()))
            {
                questionType = QuestionType.Recyrent;
                //_currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Систематические коды".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
                //_currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Циклические коды".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
              //  _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Файра".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
             //   _currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Первично недвоичные коды".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
               // _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код с проверкой по модулю q".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
              //  _currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код с простым повторением".ToLower()))
            {
                questionType = QuestionType.EasyReturn;
                //_currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Грея".ToLower()))
            {
                questionType = QuestionType.Gray;
             
            }
            else if (NameTest.Text.ToLower().Equals("Итеративный код".ToLower()))
            {
                questionType = QuestionType.Iterative;
               // _currentGrid.Children.Add(new IterativeCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рида Маллера".ToLower()))
            {
                questionType = QuestionType.RidaMallera;
            }

            return questionType;
        }
        private QuestionType UaR()
        {
            QuestionType questionType = QuestionType.Deffoult;

            if (NameTest.Text.ToLower().Equals("Абрамсона".ToLower()))
            {
                questionType = QuestionType.Abramson;
              //  _currentGrid.Children.Add(new AbramsoneView(_currentGrid, "Abramson"));
            }
            else if (NameTest.Text.ToLower().Equals("БЧХ".ToLower()))
            {
                questionType = QuestionType.BCH;
                //_currentGrid.Children.Add(new BCHView(_currentGrid, "BCH"));
            }
            else if (NameTest.Text.ToLower().Equals("Хаффмена".ToLower()))
            {
                questionType = QuestionType.Haphmana;
              //  _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Елайса".ToLower()))
            {
                questionType = QuestionType.Ellieas;
                //_currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ДДК".ToLower()))
            {
                questionType = QuestionType.DDC;
                //_currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Бергера".ToLower()))
            {
                questionType = QuestionType.Berger;
                //_currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рекурентний код".ToLower()))
            {
                questionType = QuestionType.Recyrent;
             //   _currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Систематичний код".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
             //   _currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Циклічний код".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
               // _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Файра".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
                //_currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Первичні недвоїчні".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
              //  _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Перевірка по модулю q".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
              //  _currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код з простим повторенням".ToLower()))
            {
                questionType = QuestionType.EasyReturn;
             //   _currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Грея".ToLower()))
            {
                questionType = QuestionType.Gray;
                
            }
            else if (NameTest.Text.ToLower().Equals("Ітеративний код".ToLower()))
            {
                questionType = QuestionType.Iterative;
            }
            else if (NameTest.Text.ToLower().Equals("Ріда Маллєра".ToLower()))
            {
                questionType = QuestionType.RidaMallera;
            }

            return questionType;
        }

        private QuestionType En()
        {
            QuestionType questionType = QuestionType.Deffoult;
            if (NameTest.Text.ToLower().Equals("Abramson".ToLower()))
            {
                questionType = QuestionType.Abramson;
                _currentGrid.Children.Add(new AbramsoneView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("BCH".ToLower()))
            {
                questionType = QuestionType.BCH;
                _currentGrid.Children.Add(new BCHView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Haphmana".ToLower()))
            {
                questionType = QuestionType.Haphmana;
                _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Ellieas".ToLower()))
            {
                questionType = QuestionType.Ellieas;
                _currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("DDC".ToLower()))
            {
                questionType = QuestionType.DDC;
                _currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Berger".ToLower()))
            {
                questionType = QuestionType.Berger;
                _currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Recyrent".ToLower()))
            {
                questionType = QuestionType.Recyrent;
                _currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("SystematicHemming".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
                _currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("CycleHemming".ToLower()))
            {

                questionType = QuestionType.CycleHemming;
                _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Faira".ToLower()))
            {
                questionType = QuestionType.Faira;
                _currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("PrimaryNonDualOnes".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
                _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ModuleCodeQ".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
                _currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("EasyReturn".ToLower()))
            {
                questionType = QuestionType.EasyReturn;
                _currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Gray".ToLower()))
            {
                questionType = QuestionType.Gray;
                _currentGrid.Children.Add(new GrayView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Iterative".ToLower()))
            {
                questionType = QuestionType.Iterative;
                _currentGrid.Children.Add(new IterativeCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("RidaMallera".ToLower()))
            {
                questionType = QuestionType.RidaMallera;
                _currentGrid.Children.Add(new RidaMalleraView(_currentGrid));
            }

            return questionType;
        }
        private QuestionType Ru()
        {
            QuestionType questionType = QuestionType.Deffoult;

            if (NameTest.Text.ToLower().Equals("Абрамсона".ToLower()))
            {
                questionType = QuestionType.Abramson;
                _currentGrid.Children.Add(new AbramsoneView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("БЧХ".ToLower()))
            {
                questionType = QuestionType.BCH;
                _currentGrid.Children.Add(new BCHView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Хаффмена".ToLower()))
            {
                questionType = QuestionType.Haphmana;
                _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Эллайеса".ToLower()))
            {
                questionType = QuestionType.Ellieas;
                _currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ДДК".ToLower()))
            {
                questionType = QuestionType.DDC;
                _currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Бергера".ToLower()))
            {
                questionType = QuestionType.Berger;
                _currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рекуретный".ToLower()))
            {
                questionType = QuestionType.Recyrent;
                _currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Систематические коды".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
                _currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Циклические коды".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
                _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Файра".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
                _currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Первично недвоичные коды".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
                _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код с проверкой по модулю q".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
                _currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код с простым повторением".ToLower()))
            { 
                questionType = QuestionType.EasyReturn;
                _currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Грея".ToLower()))
            {
                _currentGrid.Children.Add(new GrayView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Итеративный код".ToLower()))
            {
                _currentGrid.Children.Add(new IterativeCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рида Маллера".ToLower()))
            {
                _currentGrid.Children.Add(new RidaMalleraView(_currentGrid));
            }

            return questionType;
        }
        private QuestionType Ua()
        {
            QuestionType questionType = QuestionType.Deffoult;

            if (NameTest.Text.ToLower().Equals("Абрамсона".ToLower()))
            {
                questionType = QuestionType.Abramson;
                _currentGrid.Children.Add(new AbramsoneView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("БЧХ".ToLower()))
            {
                questionType = QuestionType.BCH;
                _currentGrid.Children.Add(new BCHView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Хаффмена".ToLower()))
            {
                questionType = QuestionType.Haphmana;
                _currentGrid.Children.Add(new HaphmanaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Елайса".ToLower()))
            {
                questionType = QuestionType.Ellieas;
                _currentGrid.Children.Add(new EllieasCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("ДДК".ToLower()))
            {
                questionType = QuestionType.DDC;
                _currentGrid.Children.Add(new DDCView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Бергера".ToLower()))
            {
                questionType = QuestionType.Berger;
                _currentGrid.Children.Add(new BergerView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Рекурентний код".ToLower()))
            {
                questionType = QuestionType.Recyrent;
                _currentGrid.Children.Add(new RecyrentView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Систематичний код".ToLower()))
            {
                questionType = QuestionType.SystematicHemming;
                _currentGrid.Children.Add(new SystematicHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Циклічний код".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
                _currentGrid.Children.Add(new CycleHemmingView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Файра".ToLower()))
            {
                questionType = QuestionType.CycleHemming;
                _currentGrid.Children.Add(new FairaView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Первичні недвоїчні".ToLower()))
            {
                questionType = QuestionType.PrimaryNonDualOnes;
                _currentGrid.Children.Add(new PrimaryNonDualOnesView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Перевірка по модулю q".ToLower()))
            {
                questionType = QuestionType.ModuleCodeQ;
                _currentGrid.Children.Add(new ModuleCodeQView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Код з простим повторенням".ToLower()))
            {
                questionType = QuestionType.EasyReturn;
                _currentGrid.Children.Add(new EasyReturnView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Грея".ToLower()))
            {
                _currentGrid.Children.Add(new GrayView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Ітеративний код".ToLower()))
            {
                _currentGrid.Children.Add(new IterativeCoderView(_currentGrid));
            }
            else if (NameTest.Text.ToLower().Equals("Ріда Маллєра".ToLower()))
            {
                _currentGrid.Children.Add(new RidaMalleraView(_currentGrid));
            }

            return questionType;
        }

        private void StaertTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentGrid.Children.Clear();
                JsonParser<IQuestionEntity>.SaveList.Clear();
                En();
                Ru();
                Ua();
            }
            catch(Exception ex)
            {
            }

        }

    
    }
}
