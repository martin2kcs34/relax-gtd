using System;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionsPresenter))]
    public class ActionsPresenter : ListPresenter<IAction, IActionPresenter>, IActionsPresenter
    {
        public ActionsPresenter(IWorkspace workspace,
                                Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(new ActionsFilterBase(workspace, x => true).Actions, actionPresenterFactory)
        {
        }
    }
}