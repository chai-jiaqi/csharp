﻿using System;

namespace basic.Common
{
    internal class TryCatchDemoClass
    {
        public void WillNotThrowException()
        {
            // This method throws nothing :-D
        }

        public void WillThrowFormatException()
        {
            throw new FormatException();
        }
    }
}