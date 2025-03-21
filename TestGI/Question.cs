using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGI
{
    class Question
    {
        string textQuestion;
        public int rightAnswer;

        public Question(string text, int answer) 
        { 
            textQuestion = text;
            rightAnswer = answer;
        }

        public string ToString()
        { return textQuestion; }

    }
}
