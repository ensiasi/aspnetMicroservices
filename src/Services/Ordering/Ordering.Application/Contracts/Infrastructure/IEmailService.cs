// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool>  SendEmailAsync(Email email);
    }
}
