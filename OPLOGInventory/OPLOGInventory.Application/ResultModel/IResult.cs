using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.ResultModel
{
    public interface IResult
    {
        bool IsError { get; }

        bool IsSuccess { get; }

        string Message { get; }
    }
}
