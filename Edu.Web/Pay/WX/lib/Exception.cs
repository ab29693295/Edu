﻿using System;
using System.Collections.Generic;
using System.Web;

namespace Edu.Web.Pay
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}