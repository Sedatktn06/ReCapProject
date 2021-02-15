using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)//Base class'a mesaj gönderiyor.Ayrıca onun constructor'ı ile sonucuda gönderiyor.
        {

        }
        public SuccessResult():base(true)//Burada mesaj yollamak istemiyorum.Fakat base class'ın tek parametreli const'u bana lazım.Onu kullanıyorum.
        {

        }
    }
}
