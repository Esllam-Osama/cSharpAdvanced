using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastTaskInCSharp
{
  internal class Instructor
  {

    public string Name { get; set; }
    public List<Exam> Exams { get; set; }
    public Instructor(string name)
    {
      Name = name;
      Exams = new List<Exam>();
    }
    public void CreateTrueOrFalseQ(string q, List<string> rightAnswer)
    {
      Exam question = new TrueOrFalseQusetion(q, rightAnswer);
      Exams.Add(question);
    }
    public void CreateChoseOne(string q, List<string> rightAnswer, List<string> answers)
    {
      Exam question = new ChooseOneQuestion(q, rightAnswer, answers);
      Exams.Add(question);
    }
    public List<string> StartExam()
    {
      List<string> allUserAnswers = new List<string>();
      string answer = "";
      string userAnswer = "";
      ActiveWithUser.ShowTitle("Start Exam");
      Random rand = new Random();
      Exams = Exams.OrderBy(x => rand.Next()).ToList();
      for (int i = 0; i < Exams.Count; i++)
      {
        ActiveWithUser.ShowTitle($"Question Number {i + 1}=>");
        Console.WriteLine($"{Exams[i].Question}");
        List<string> answers = Exams[i].Answers.OrderBy(x => rand.Next()).ToList();
        Console.Write($"Choices:=>[");
        for (int c = 0; c < answers.Count; c++)
        {
          Console.Write($" {c + 1}:{answers[c]} ");
        }
        Console.WriteLine("]");
        Console.WriteLine($"You must Enter {Exams[i].RightAnswer.Count} Answers");
        for (int c = 0; c < Exams[i].RightAnswer.Count; c++)
        {
          allUserAnswers.Clear();
          do
          {
            try
            {
              Console.ForegroundColor = ConsoleColor.DarkYellow;
              Console.Write($"Enter Answer Number{c + 1}=>");
              answer = Console.ReadLine();
            }
            catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + "Choose choice; "); }
            answer.ToLower();
            userAnswer = answers.Find(e => e == answer);
            if (userAnswer != null)
            {
              allUserAnswers.Add(userAnswer);
              break;
            }
            else
            {
              Console.ForegroundColor = ConsoleColor.DarkRed;
              Console.WriteLine("Choose from the options");
            }
          } while (true);
            foreach (string useranswer in allUserAnswers)
            {
              string uAnser = Exams[i].RightAnswer.Find(e => e == useranswer);
              if (uAnser != null)
              {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{useranswer} is Right Answer..!");
              }
              else
              {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{useranswer} is Wrong Answer");
              }
            }
        }
      }
      return allUserAnswers;
    }
  }
}
