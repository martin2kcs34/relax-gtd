using System.Windows.Input;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using Relax.Commands;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    /// <summary>
    /// Presents the UI allowing the action being processed to be marked as done.
    /// </summary>
    [PerRequest("Do Now", typeof (IActionProcessorPresenter))]
    public class DoNowPresenter : Screen, IActionProcessorPresenter
    {
        public DoNowPresenter(DoNowCommand applyCommand)
        {
            ApplyCommand = applyCommand;
        }

        #region IActionProcessorPresenter Members

        public ICommand ApplyCommand { get; private set; }

        public override string DisplayName
        {
            get { return "Now"; }
            set { }
        }

        #endregion
    }
}