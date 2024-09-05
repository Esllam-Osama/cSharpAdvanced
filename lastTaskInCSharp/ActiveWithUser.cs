using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lastTaskInCSharp
{
  sealed class ActiveWithUser
  {
    static public List<Instructor> Instructors = new List<Instructor>();
    static public void ShowTitle(string text)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("==============================");
      Console.WriteLine($"{text}");
      Console.WriteLine("==============================");
      Console.ForegroundColor = ConsoleColor.DarkYellow;

    }
    static public void ShowDateAndTime()
    {
      //Date And Time Now
      ShowTitle("=    " + DateTime.Now + "   =");
    }
    static public string GetUserName()
    {
      //This Func Return UserName
      // i will make username = undefind because if user cant Enter his name
      string userName = string.Empty;
      ShowTitle("Enter Your Name:");
      Console.Write("Enter Your Name: ");
      try
      {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        userName = Console.ReadLine();
        if (string.IsNullOrEmpty(userName))
        {
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("We Will Handle Your Name");
          userName = "undefined";
        }
      }
      catch (Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(ex.Message + "We Will handle that error");
        Console.ForegroundColor = ConsoleColor.White;
      }
      finally
      {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Hello Mr,{userName} *_*");
      }
      return userName;
    }
    static public string GetStatus()
    {

      string status = string.Empty;
      do
      {

        ShowTitle("Choose Your Status:");
        Console.Write("Enter You Are a [student or instructor]: ");
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          status = Console.ReadLine();
          status = status.ToLower();
        }
        catch (Exception ex)
        {
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine(ex.Message);
        }
        // the user must be Enter his status
        if (status == "student" || status == "instructor")
        {
          break;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("Wrong input Just choice You Are A [student or instructor]");
        }
      } while (true);
      return status;
    }
    static public void ChekHimInstractourOrStudent(string state, string name)
    {
      if (state == "instructor")
      {
        CreateInstructor(name);
        SaveInstructorAndQuestions(name);
      }
      else if (state == "student")
      {
        bool getInstructor = ShowAllInstructors();
        if (getInstructor == true)
        {
          Instructor instructor = GetInstructorForStudent();
          List<string> allRightAnswers = instructor.StartExam();
        }
      }
    }
    static public bool ShowAllInstructors()
    {
      if (Instructors.Count > 0)
      {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        ShowTitle("We Have This Instructors");
        Console.Write("instructors => [");
        foreach (Instructor i in Instructors)
        {
          Console.Write($" {i.Name}=>Questions[{i.Exams.Count}] ");
        }
        Console.WriteLine("]");
        return true;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("So Sorry We Havent Any Instructor Now..!");
        return false;
      }
    }
    static public Instructor GetInstructorForStudent()
    {
      Instructor instructor;
      string instructorName = "";

      do
      {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Enter You Instructor Name=>");
        try
        {
          instructorName = Console.ReadLine();
        }
        catch (Exception ex)
        { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message); }
        instructorName.ToLower();
        instructor = Instructors.Find(e => e.Name == instructorName);
        if (instructor != null)
        {
          break;
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("Sorry Cant Find This Instructor..!");
        }
      } while (true);
      return instructor;
    }
    static public void CreateInstructor(string name)
    {
      Instructor instructor = new Instructor(name);
      Instructors.Add(instructor);
    }
    static public int ChooseCounter()
    {
      int counter = 0;
      do
      {
        ShowTitle("Choose How Many questions:");
        Console.Write("How many questions do you want?: ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        try
        {
          counter = int.Parse(Console.ReadLine());
          if (counter != 0) { break; }
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + "Choose Number pls"); }
      } while (true);
      return counter;
    }

    static public int ChooseExame()
    {
      int choose = 0;
      do
      {
        ShowTitle("Choose the type of Question:");
        Console.WriteLine("1:True Or False Question");
        Console.WriteLine("2:Chose one Question");
        Console.WriteLine("3:Multiple Choice Question");
        Console.Write("Enter As A Number=>");
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          choose = int.Parse(Console.ReadLine());
          if (choose == 1 || choose == 2 || choose == 3) break;
          else { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Just Choose Chice [1,2,3]"); }
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + "Choose choice [1,2,3]"); }
      } while (true);
      return choose;
    }
    static public string GetQuestion()
    {
      string question = "";
      do
      {
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.Write("Your Question: ");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          question = Console.ReadLine();
          if (question != "")
          {
            return question;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You Must Enter Any Value");
          }
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message); }
      } while (true);
    }
    static public string GetRightAnswerTrueOrFalse()
    {
      string rightAnswer = "";
      do
      {
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.Write("Right Answer: ");
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          rightAnswer = Console.ReadLine();
          rightAnswer = rightAnswer.ToLower();
          if (rightAnswer == "true" || rightAnswer == "false")
          {
            return rightAnswer;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You Must Choice [true or false]");
          }
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message); }
      } while (true);
    }
    static public List<string> GetAnswers()
    {
      int questionCount = 0;
      do
      {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("How Many Answers You Want  Without Right Answer.? As A Number=>");
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          questionCount = int.Parse(Console.ReadLine());
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + " you must be Enter number"); }
        if (questionCount != 0) { break; }
      } while (true);
      ShowTitle("Enter Your Answers..");
      List<string> answers = new List<string>();
      string answer = "";
      for (int i = 0; i < questionCount; i++)
      {
        do
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.Write($"Enter Answer Number {i + 1}=>");
          try
          {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            answer = (Console.ReadLine());
          }
          catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + " you must be Enter Any Value"); }
          if (answer != "") { break; }
        } while (true);
        answers.Add(answer);
      }
      return answers;
    }
    static public string GetRightAnswerForChoseOneQuestion()
    {
      string answer = "";
      do
      {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Enter Right Answer=>");
        try
        {
          Console.ForegroundColor = ConsoleColor.DarkBlue;
          answer = (Console.ReadLine());
        }
        catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + " you must be Enter Any Value"); }
        if (answer != "") { break; }
      } while (true);
      return answer;
    }
    static public void SaveInstructorAndQuestions(string name)
    {
      int counter = ChooseCounter();
      for (int i = 0; i < counter; i++)
      {
        int typeOfQuetstion = ChooseExame();
        string question = GetQuestion();
        Instructor ins = Instructors.Find(e => e.Name == name);
        if (typeOfQuetstion == 1)
        {
          string rightAnswer = GetRightAnswerTrueOrFalse();
          List<string> ra = new List<string>() { rightAnswer };
          ins.CreateTrueOrFalseQ(question, ra);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($"Question {question}\nRight Answer:{rightAnswer}=>Added Succsefully..!");
        }
        else if (typeOfQuetstion == 2)
        {
          string rightAnswer = GetRightAnswerForChoseOneQuestion();
          List<string> ra = new List<string>() { rightAnswer };
          List<string> answers = GetAnswers();
          answers.Add(rightAnswer);
          ins.CreateChoseOne(question, ra, answers);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($"Question {question}\nRight Answer:{ra[0]}=>Added Succsefully..!");
        }
        else if (typeOfQuetstion == 3)
        {
          int count = 0;
          List<string> ra = new List<string>();
          do
          {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter How Many Right Answers=> ");
            try
            {
              Console.ForegroundColor = ConsoleColor.DarkBlue;
              count = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + " you must Enter As a number"); }
            if (count != 0)
            {
              break;
            }
          } while (true);
          List<string> answers = new List<string>();
          for (int c = 0; c < count; c++)
          {
            string rightAnswer = GetRightAnswerForChoseOneQuestion();
            ra.Add(rightAnswer);
            answers.Add(rightAnswer);
          }
          answers.AddRange(GetAnswers());
          ins.CreateChoseOne(question, ra, answers);
          Console.ForegroundColor = ConsoleColor.Green;
          string right = String.Join(",", ra);
          Console.WriteLine($"Question {question}\nRight Answer:{right} =>Added Succsefully..!");
        }
      }
    }
    static public void EndPoint()
    {
      ShowDateAndTime();
      char closeProgrm = ' ';
      do
      {
        string name = GetUserName();
        string status = GetStatus();
        ChekHimInstractourOrStudent(status, name);
        do
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.Write("You Want Try Agin..?[y / n]=>");
          try
          {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            closeProgrm = Console.ReadLine()[0];
          }
          catch (Exception ex) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(ex.Message + " you must Choice [y / n]"); }
          if (closeProgrm == 'y' || closeProgrm == 'n')
          {
            break;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("you must Choice [y / n]");
          }
        } while (true);
        if (closeProgrm == 'n')
        {
          ShowTitle("Good Bye *_*");
          break;
        }
      } while (true);
    }
  }
}

