using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastTaskInCSharp
{
  internal class ChooseOneQuestion:Exam
  {
    public ChooseOneQuestion(string q,List<string> rightAnswer,List<string> answers):base(q,rightAnswer) {
    Answers= answers;
    }
    //لو هنعوز نضيف حاجه قدام
  }
}
