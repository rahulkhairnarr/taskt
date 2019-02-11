﻿using System;
using System.Xml.Serialization;

namespace taskt.Core.Automation.Commands
{

    [Serializable]
    [Attributes.ClassAttributes.Group("Web Browser Commands")]
    [Attributes.ClassAttributes.Description("This command allows you to navigate forward a Selenium web browser session.")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to simulate a forward click in the web browser session.")]
    [Attributes.ClassAttributes.ImplementationDescription("This command implements Selenium to achieve automation.")]
    public class SeleniumBrowserNavigateForwardCommand : ScriptCommand
    {
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please Enter the instance name")]
        [Attributes.PropertyAttributes.InputSpecification("Enter the unique instance name that was specified in the **Create Browser** command")]
        [Attributes.PropertyAttributes.SampleUsage("**myInstance** or **seleniumInstance**")]
        [Attributes.PropertyAttributes.Remarks("Failure to enter the correct instance name or failure to first call **Create Browser** command will cause an error")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        public string v_InstanceName { get; set; }

        public SeleniumBrowserNavigateForwardCommand()
        {
            this.CommandName = "WebBrowserNavigateCommand";
            this.SelectionName = "Navigate Forward";
            this.v_InstanceName = "default";
            this.CommandEnabled = true;
        }

        public override void RunCommand(object sender)
        {
            var engine = (Core.Automation.Engine.AutomationEngineInstance)sender;

            var vInstance = v_InstanceName.ConvertToUserVariable(engine);

            var browserObject = engine.GetAppInstance(vInstance);


            var seleniumInstance = (OpenQA.Selenium.Chrome.ChromeDriver)browserObject;
            seleniumInstance.Navigate().Forward();

        }

        public override string GetDisplayValue()
        {
            return base.GetDisplayValue() + " [Instance Name: '" + v_InstanceName + "']";
        }
    }
}