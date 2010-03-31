using System;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProjectsPresenter))]
    public class ProjectSelector : SingleItemSelector<IAction, IActionTreeNodePresenter>, IProjectsPresenter
    {
        public ProjectSelector(IProjectsFilter projectsFilter,
                               Func<IAction, IActionTreeNodePresenter> actionPresenterFactory,
                               AllowNullSelectionPolicy selectionPolicy)
            : base(projectsFilter.Actions, actionPresenterFactory, selectionPolicy)
        {
        }
    }
}