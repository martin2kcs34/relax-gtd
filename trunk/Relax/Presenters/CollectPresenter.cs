﻿using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (ICollectPresenter))]
    public class CollectPresenter : MultiPresenter, ICollectPresenter
    {
        public CollectPresenter(IInputPresenter inputPresenter, IInboxActionsPresenter inboxPresenter)
        {
            Input = inputPresenter;
            InboxActions = inboxPresenter;
        }

        public IInboxActionsPresenter InboxActions { get; private set; }
        public IInputPresenter Input { get; private set; }
    }
}