﻿using System;
using System.Xml.Serialization;

namespace taskt.Core.Automation.Commands
{





    [Serializable]
    [Attributes.ClassAttributes.Group("Text File Commands")]
    [Attributes.ClassAttributes.Description("This command writes specified data to a text file")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to write data to text files.")]
    [Attributes.ClassAttributes.ImplementationDescription("This command implements '' to achieve automation.")]
    public class WriteTextFileCommand : ScriptCommand
    {
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please indicate the path to the file")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [Attributes.PropertyAttributes.InputSpecification("Enter or Select the path to the text file.")]
        [Attributes.PropertyAttributes.SampleUsage("C:\\temp\\myfile.txt or [vTextFilePath]")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_FilePath { get; set; }

        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please indicate the text to be written")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [Attributes.PropertyAttributes.InputSpecification("Indicate the text should be written to files.")]
        [Attributes.PropertyAttributes.SampleUsage("**[vText]** or **Hello World!**")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_TextToWrite { get; set; }

        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please select overwrite option")]
        [Attributes.PropertyAttributes.PropertyUISelectionOption("Append")]
        [Attributes.PropertyAttributes.PropertyUISelectionOption("Overwrite")]
        [Attributes.PropertyAttributes.InputSpecification("Indicate whether this command should append the text to or overwrite all existing text in the file")]
        [Attributes.PropertyAttributes.SampleUsage("Select from **Append** or **Overwrite**")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_Overwrite { get; set; }
        public WriteTextFileCommand()
        {
            this.CommandName = "WriteTextFileCommand";
            this.SelectionName = "Write To File";
            this.CommandEnabled = true;
        }

        public override void RunCommand(object sender)
        {
            //convert variables
            var filePath = v_FilePath.ConvertToUserVariable(sender);
            var outputText = v_TextToWrite.ConvertToUserVariable(sender);

            //append or overwrite as necessary
            if (v_Overwrite == "Append")
            {
                System.IO.File.AppendAllText(filePath, outputText);
            }
            else
            {
                System.IO.File.WriteAllText(filePath, outputText);
            }

        }

        public override string GetDisplayValue()
        {
            return base.GetDisplayValue() + " [" + v_Overwrite + " to '" + v_FilePath + "']";
        }
    }
}