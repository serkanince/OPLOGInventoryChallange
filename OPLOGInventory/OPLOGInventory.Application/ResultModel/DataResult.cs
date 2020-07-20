using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.ResultModel
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        protected DataResult() { }

        public T Data { get; protected set; }

        public static new IDataResult<T> Error()
        {
            return new DataResult<T> { IsError = true, IsSuccess = false };
        }

        public static new IDataResult<T> Error(string message)
        {
            return new DataResult<T> { IsError = true, IsSuccess = false, Message = message };
        }

        public static new IDataResult<T> Success()
        {
            return new DataResult<T> { IsError = false, IsSuccess = true };
        }

        public static new IDataResult<T> Success(string message)
        {
            return new DataResult<T> { IsError = false, IsSuccess = true, Message = message };
        }

        public static IDataResult<T> Success(T data)
        {
            return new DataResult<T> { IsError = false, IsSuccess = true, Data = data };
        }

        public static IDataResult<T> Success(T data, string message)
        {
            return new DataResult<T> { IsError = false, IsSuccess = true, Data = data, Message = message };
        }
    }
}
