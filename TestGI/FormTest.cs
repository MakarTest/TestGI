using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{
    public partial class FormTest : Form
    {

        TestGeniusIdiot test;

        public FormTest()
        {
            InitializeComponent();
            startTest();
        }

        void startTest()
        {
            test = new TestGeniusIdiot();

            labelQuestion.Text = test.NextQuestion();
            labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
        }

        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                int userAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
                test.CheckAnswer(userAnswer);

                if (test.EndOfTest())
                {
                    MessageBox.Show(test.Diagnose());
                    buttonNewStart.Visible = true;
                }
                else
                { 
                    labelQuestion.Text = test.NextQuestion();
                    labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("В ответе может быть только число");
            }
        }

        private void buttonNewStart_Click(object sender, EventArgs e)
        {
            startTest();
        }
    }
}
