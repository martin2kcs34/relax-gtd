﻿using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Shell
    {
        private readonly AutomationElement _element;

        public Shell(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public Workspace Workspace
        {
            get { return new Workspace(_element.FindChildById("Workspace")); }
        }
    }
}