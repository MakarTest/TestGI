using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGI
{
    public class Question
    {
        string textQuestion;
        int rightAnswer;

        public Question(string text, int answer) 
        { 
            textQuestion = text;
            rightAnswer = answer;
        }

        public override string ToString()
        { return textQuestion; }

        public bool CheckAnswer(int userAnswer)
        {
            return rightAnswer == userAnswer;
        }
    }
}
