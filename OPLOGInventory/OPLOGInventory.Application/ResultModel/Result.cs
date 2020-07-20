using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.ResultModel
{
    public class Result : IResult
    {
        protected Result() { }

        public bool IsError { get; protected set; }

        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }

        public static IResult Error()
        {
            return new Result { IsError = true, IsSuccess = false };
        }

        public static IResult Error(string message)
        {
            return new Result { IsError = true, IsSuccess = false, Message = message };
        }

        public static IResult Success()
        {
            return new Result { IsError = false, IsSuccess = true };
        }

        public static IResult Success(string message)
        {
            return new Result { IsError = false, IsSuccess = true, Message = message };
        }
    }
}
