﻿using System;
using System.Xml.Serialization;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Data Commands")]
    [Attributes.ClassAttributes.Description("This command allows you to retrieve the length of a string or variable.")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to find the length of a string or variable")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    public class GetWordLengthCommand : ScriptCommand
    {
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Supply the value or variable requiring the word count (ex. {vSomeVariable})")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [Attributes.PropertyAttributes.InputSpecification("Select or provide a variable or text value")]
        [Attributes.PropertyAttributes.SampleUsage("**Hello** or **vSomeVariable**")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_InputValue { get; set; }


        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please select the variable to receive the length")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [Attributes.PropertyAttributes.InputSpecification("Select or provide a variable from the variable list")]
        [Attributes.PropertyAttributes.SampleUsage("**vSomeVariable**")]
        [Attributes.PropertyAttributes.Remarks("If you have enabled the setting **Create Missing Variables at Runtime** then you are not required to pre-define your variables, however, it is highly recommended.")]
        public string v_applyToVariableName { get; set; }

        public GetWordLengthCommand()
        {
            this.CommandName = "GetLengthCommand";
            this.SelectionName = "Get Word Length";
            this.CommandEnabled = true;

        }

        public override void RunCommand(object sender)
        {
            //get engine
            var engine = (Core.Automation.Engine.AutomationEngineInstance)sender;

            //get input value
            var stringRequiringLength = v_InputValue.ConvertToUserVariable(sender);

            //count number of words
            var stringLength = stringRequiringLength.Length;

            //store word count into variable
            stringLength.ToString().StoreInUserVariable(sender, v_applyToVariableName);

        }



        public override string GetDisplayValue()
        {
            return base.GetDisplayValue() + " [Apply Result to: '" + v_applyToVariableName + "']";
        }
    }
}