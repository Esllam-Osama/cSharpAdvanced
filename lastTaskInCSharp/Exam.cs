using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastTaskInCSharp
{
  abstract class Exam
  {

    public string Question { get; set; }
    public List<string> Answers { get; set; }
    public List<string> RightAnswer { get; set; }
    public Exam(string question, List<string> rightAnswer)
    {
      Question = question;
      RightAnswer = rightAnswer;
      Answers = new List<string>();
    }
  }
}
