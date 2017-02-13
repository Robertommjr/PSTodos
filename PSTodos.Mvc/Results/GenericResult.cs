﻿namespace PSTodos.Mvc.Results
{
    public class GenericResult
    {
        public string[] Errors { get; set; }
        public bool Success { get; set; }
    }

    public class GenericResult<TResult> : GenericResult
    {
        public TResult Result { get; set; }
    }
}