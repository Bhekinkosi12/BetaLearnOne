using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BetaLearnOne.ViewModels
{
    public class CalculatorVIewModel : BaseViewModel
    {
        public Command One { get; }
        public Command Two { get; }
        public Command Three { get; }
        public Command Four { get; }
        public Command Five { get; }
        public Command Six { get; }
        public Command Seven { get; }
        public Command Eight { get; }
        public Command Nine { get; }
        public Command Dot { get; }
        public Command Equal { get; }
        public Command Clear { get; }
        public Command Plus { get; }
        public Command Minus { get; }
        public Command Divide { get; }
        public Command Multiply { get; }

        



        string wordEquation;
        string lastOperator;
        string operators = "";
        string current = "0";

        string number;
        string answer;
        double refAnswer = 0;
        string newNumberS;
        double newNumberD;


        public string Answer
        {
            get => answer;
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {

                    SetProperty(ref answer, value);
                    OnPropertyChanged(nameof(Answer));

                }
                else
                {
                    SetProperty(ref answer, "");
                    OnPropertyChanged(nameof(Answer));
                }

            }
        }


        public string Number
        {
            get => number;
            set
            {
                SetProperty(ref number, value);
                OnPropertyChanged(nameof(Number));

            }
        }

        void OnOne()
        {
            string one = "1";
            if(operators != ".")
            {
            Answer = InputHandle(one, operators, current);
            current = Answer;

            }
            else
            {
                current = current + one;
            }



            wordEquation = wordEquation + one;
            Number = wordEquation;
            newNumberS = newNumberS + one;


        }
        void OnTwo()
        {
            string one = "2";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }



            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnThree()
        {
            string one = "3";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnFour()
        {
            string one = "4";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnFive()
        {
            string one = "5";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnSix()
        {
            string one = "6";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnSeven()
        {
            string one = "7";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnEight()
        {
            string one = "8";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnNine()
        {
            string one = "8";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnZero()
        {
            string one = "0";
            if (operators != ".")
            {
                Answer = InputHandle(one, operators, current);
                current = Answer;

            }
            else
            {
                current = current + one;
            }

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;
        }
        void OnDot()
        {
            string one = ".";
            operators = one;

                Answer = InputHandle("0", operators, current);
                current = Answer;

           

            wordEquation = wordEquation + one;
            newNumberS = newNumberS + one;
            Number = wordEquation;

        }


        void OnClear()
        {
            string one = "";
            wordEquation = one;
            Number = wordEquation;
            refAnswer = 0;
            Answer = "";


        }

        private string InputHandle(string input,string oper,string currentNum)
        {
           
            string output;
            if(oper != "")
            {
              
                    double num = double.Parse(input);
                    double currentnum = double.Parse(currentNum);
                

                    if (oper == "/")
                    {
                        output = $"{currentnum / num}";
                        return output;

                    }
                    else if (oper == "*")
                    {
                        output = $"{currentnum * num}";
                    return output;

                      }
                    else if (oper == "+")
                    {
                        output = $"{currentnum + num}";
                    return output;

                   }
                    else  
                    {
                        output = $"{currentnum - num}";
                     return output;

                      }
                   



                




            }
            else
            {
                return input;
            }




        }
        
       

      async  void OnDivide()
        {
            
            if (string.IsNullOrEmpty(wordEquation) != true)
            {

                if(double.TryParse(newNumberS, out double a ) == true)
                {
                    refAnswer = refAnswer / double.Parse(newNumberS);
                    newNumberS = "";

                    string one = "/";
                    lastOperator = one;
                    wordEquation = wordEquation + one;
                    Number = wordEquation;


                }
                else
                {

                    await Shell.Current.DisplayAlert("Error", "Syntex Error", "OK");
                }
                    

              



            }
            else
            {
                return;

            }


            operators = "/";

           

        }
       async void OnMultiply()
        {

            operators = "*";
            if (string.IsNullOrEmpty(wordEquation) != true)
            {

                if (double.TryParse(newNumberS, out double a) == true)
                {
                    refAnswer = refAnswer * double.Parse(newNumberS);
                    newNumberS = "";

                    string one = "X";
                    lastOperator = one;
                    wordEquation = wordEquation + one;
                    Number = wordEquation;


                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Syntex Error", "OK");
                }






            }
            else
            {
                return;

            }


        }
       async void OnAdd()
        {
            operators = "+";
            if (string.IsNullOrEmpty(wordEquation) != true)
            {

                if (double.TryParse(newNumberS, out double a) == true)
                {
                    refAnswer = refAnswer + double.Parse(newNumberS);
                    newNumberS = "";

                    string one = "+";
                    lastOperator = one;
                    wordEquation = wordEquation + one;
                    Number = wordEquation;


                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Syntex Error", "OK");
                }






            }
            else
            {
                return;

            }


        }
      async  void OnSubtract()
        {
            operators = "-";

            if (string.IsNullOrEmpty(wordEquation) != true)
            {

                if (double.TryParse(newNumberS, out double a) == true)
                {
                    refAnswer = refAnswer - double.Parse(newNumberS);
                    newNumberS = "";

                    string one = "-";
                    lastOperator = one;
                    wordEquation = wordEquation + one;
                    Number = wordEquation;


                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Syntex Error", "OK");
                }






            }
            else
            {
                return;

            }


        }

        async void OnEqual()
        {
            double equalNum;

            if(lastOperator == "+")
            {
                refAnswer = refAnswer + double.Parse(newNumberS);

            }
            else if(lastOperator == "-")
            {

                refAnswer = refAnswer - double.Parse(newNumberS);
            }
            else if (lastOperator == "/")
            {

                refAnswer = refAnswer / double.Parse(newNumberS);
            }
            else 
            {

                refAnswer = refAnswer * double.Parse(newNumberS);
            }

            Answer = refAnswer.ToString();
            refAnswer = 0;

        }


        






        public CalculatorVIewModel()
        {
            One = new Command(OnOne);
            Two = new Command(OnTwo);
            Three = new Command(OnThree);
            Four = new Command(OnFour);
            Five = new Command(OnFive);
            Six = new Command(OnSix);
            Seven = new Command(OnSeven);
            Eight = new Command(OnEight);
            Nine = new Command(OnNine);
            Dot = new Command(OnDot);
            Clear = new Command(OnClear);
            Plus = new Command(OnAdd);
            Minus = new Command(OnSubtract);
            Divide = new Command(OnDivide);
            Multiply = new Command(OnMultiply);
            Equal = new Command(OnEqual);


        }





      



    }
}
