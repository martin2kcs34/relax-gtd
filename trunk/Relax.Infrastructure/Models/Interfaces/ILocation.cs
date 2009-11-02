﻿using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Groups the contexts that are relevant in a particular location.
    /// </summary>
    public interface ILocation : IItem
    {
        ObservableCollection<IContext> Contexts { get; set; }
    }
}