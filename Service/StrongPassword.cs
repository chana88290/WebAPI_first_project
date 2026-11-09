using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Service
{
    public class StrongPassword
    {
        public int GetStrongPassword(string password)
        {
            var Result = Zxcvbn.Core.EvaluatePassword(password);
            return Result.Score;
        }
    }
}
