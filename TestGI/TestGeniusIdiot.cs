using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGI
{
    class TestGeniusIdiot
    {
        Random rnd = new Random();
        List<Question> listQuestion = new List<Question>();
        int indexQuestion = -1;
        int countRightAnswer = 0;
        string[] diagnose = { "идиот", "кретин", "дурак", "норма", "талант", "гений" };
        int[] orderQuestions = { 2, 3, 1, 0, 4 };

        public TestGeniusIdiot(bool fromFile=true)
        {
            if (fromFile)
                LoadFromFile();
            else
                LoadStandart();
            orderQuestions = shuffle();
        }

        void LoadStandart()
        {
            Question question1 = new Question("2 + 2 * 2", 6);
            listQuestion.Add(question1);

            Question question2 = new Question("Бревно нужно разделить на 10 частей, сколько сделать распислов?", 9);
            listQuestion.Add(question2);

            listQuestion.Add(new Question("На двух руках 10 пальцев, сколько пальцев на 5 руках?", 25));
            listQuestion.Add(new Question("Укол делаю каждые полчаса, сколько нужно минут на 3 укола?", 60));
            listQuestion.Add(new Question("5 свечей горелоа, три погасло. Сколько свечей осталось?", 3));
        }

        void LoadFromFile()
        {
            listQuestion.Clear();
            StreamReader sr = new StreamReader("data/question.data");
            while (!sr.EndOfStream)
            { 
                string[] line = sr.ReadLine().Split('|');
                Question question = new Question(line[0], Convert.ToInt32(line[1]));
                listQuestion.Add(question);
            }
        }

        public string NextQuestion()
        {

            if (indexQuestion < listQuestion.Count)
            {
                indexQuestion++;
                return listQuestion[orderQuestions[indexQuestion]].ToString();
            }
            else
                return listQuestion[orderQuestions[listQuestion.Count - 1]].ToString();
        }

        public int NumberQuestion()
        {
            return indexQuestion + 1;
        }

        public bool EndOfTest()
        {
            return indexQuestion == listQuestion.Count - 1;
        }

        public void CheckAnswer(int userAnswer)
        {
            if (listQuestion[orderQuestions[indexQuestion]].CheckAnswer(userAnswer))
                countRightAnswer++;
        }

        public string Diagnose()
        {
            if (countRightAnswer == listQuestion.Count)
                return diagnose[diagnose.Length - 1];
            if (countRightAnswer == 0)
                return diagnose[0];
            return diagnose[(diagnose.Length - 1) * countRightAnswer / listQuestion.Count];
        }

        int[] shuffle()
        {
            int n = listQuestion.Count;
            int[] temp = new int[n];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = i;
            }
            for (int i = 0; i < 10; i++)
            {
                int ind1 = rnd.Next(0, n);
                int ind2 = rnd.Next(0, n);
                int t = temp[ind1];
                temp[ind1] = temp[ind2];
                temp[ind2] = t;
            }
            return temp;
        }
    }
}
