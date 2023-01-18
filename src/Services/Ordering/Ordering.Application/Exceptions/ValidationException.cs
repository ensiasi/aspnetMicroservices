// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            :base("one or more error validation has occured")
        {
            Errors= new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures
                   .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                   .ToDictionary(f => f.Key, f=> f.ToArray());
        }
        public Dictionary<string, string[]> Errors { get;}
    }
}
