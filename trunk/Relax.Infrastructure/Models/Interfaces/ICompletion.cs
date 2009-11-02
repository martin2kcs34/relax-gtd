﻿using System;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be completed.
    /// </summary>
    public interface ICompletion
    {
        DateTime CompletedDate { get; }
    }
}