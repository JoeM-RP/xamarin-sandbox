using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Output
{
	public class Result<T>
	{
		public ResultType Type { get; set; }
		public IEnumerable<string> Errors { get; set; }
		public T Data { get; set; }

		public Result(T data)
		{
			Data = data;
			Type = ResultType.Ok;
			Errors = new List<string>();
		}

		public Result(ResultType type, IEnumerable<string> errors)
		{
			Type = type;
			Errors = errors;
		}

		public Result(ResultType type, string error)
		{
			Type = type;
			Errors = new List<string> { error };
		}
	}
}
