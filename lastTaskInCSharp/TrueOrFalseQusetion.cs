using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lastTaskInCSharp
{
  internal class TrueOrFalseQusetion : Exam
  {
    public TrueOrFalseQusetion(string question, List<string> rightAnswer)
      : base(question, rightAnswer) {
    Answers=new List<string> {"true" , "false"};
    }
  }
  //لو هنعوز نضيف حاجه قدام
}
