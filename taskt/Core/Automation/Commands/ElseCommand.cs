﻿using System;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("If Commands")]
    [Attributes.ClassAttributes.Description("This command declares the seperation between the actions based on the 'true' or 'false' condition.")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to signify the exit point of your if scenario")]
    [Attributes.ClassAttributes.ImplementationDescription("TBD")]
    public class ElseCommand : ScriptCommand
    {
        public ElseCommand()
        {
            this.DefaultPause = 0;
            this.CommandName = "ElseCommand";
            this.SelectionName = "Else";
            this.CommandEnabled = true;
        }

        public override string GetDisplayValue()
        {
            return "Else";
        }
    }
}