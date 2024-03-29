﻿namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// A context in which certain actions can be completed.
    /// </summary>
    public interface IGtdContext : IItem
    {
        string Description { get; set; }
    }
}