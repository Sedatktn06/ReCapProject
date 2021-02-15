using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Getter readonly'dir.Fakat constroctorda set edilebilir.
        public Result(bool success,string message):this(success) //Bu constructor çağrıldığında diğer constructorında çalışılması isteniyor.
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success 
        {
            get;
        }

        public string Message
        {
            get;
        }
    }
}
