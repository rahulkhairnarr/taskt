﻿using System;
using System.Xml.Serialization;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Excel Commands")]
    [Attributes.ClassAttributes.Description("This command allows you to delete a specified cell in Excel")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to delete a specific cell from the current sheet.")]
    [Attributes.ClassAttributes.ImplementationDescription("This command implements Excel Interop to achieve automation.")]
    public class ExcelDeleteCellCommand : ScriptCommand
    {
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Please Enter the instance name")]
        [Attributes.PropertyAttributes.InputSpecification("Enter the unique instance name that was specified in the **Create Excel** command")]
        [Attributes.PropertyAttributes.SampleUsage("**myInstance** or **seleniumInstance**")]
        [Attributes.PropertyAttributes.Remarks("Failure to enter the correct instance name or failure to first call **Create Excel** command will cause an error")]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        public string v_InstanceName { get; set; }
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyUIHelper(Attributes.PropertyAttributes.PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [Attributes.PropertyAttributes.PropertyDescription("Indicate the range to delete ex. A1 or A1:C1")]
        [Attributes.PropertyAttributes.InputSpecification("Enter the actual location of the cell.")]
        [Attributes.PropertyAttributes.SampleUsage("A1, B10, [vAddress]")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_Range { get; set; }
        [XmlAttribute]
        [Attributes.PropertyAttributes.PropertyDescription("Should the cells below shift upward after deletion?")]
        [Attributes.PropertyAttributes.PropertyUISelectionOption("Yes")]
        [Attributes.PropertyAttributes.PropertyUISelectionOption("No")]
        [Attributes.PropertyAttributes.InputSpecification("Indicate whether the row below will be shifted up to replace the old row.")]
        [Attributes.PropertyAttributes.SampleUsage("Select 'Yes' or 'No'")]
        [Attributes.PropertyAttributes.Remarks("")]
        public string v_ShiftUp { get; set; }
        public ExcelDeleteCellCommand()
        {
            this.CommandName = "ExcelDeleteCellCommand";
            this.SelectionName = "Delete Cell";
            this.CommandEnabled = true;
        }
        public override void RunCommand(object sender)
        {
            var engine = (Core.Automation.Engine.AutomationEngineInstance)sender;
            var vInstance = v_InstanceName.ConvertToUserVariable(engine);
            var excelObject = engine.GetAppInstance(vInstance);

           

                Microsoft.Office.Interop.Excel.Application excelInstance = (Microsoft.Office.Interop.Excel.Application)excelObject;
                Microsoft.Office.Interop.Excel.Worksheet workSheet = excelInstance.ActiveSheet;

                string range = v_Range.ConvertToUserVariable(sender);
                var cells = workSheet.Range[range, Type.Missing];


                if (v_ShiftUp == "Yes")
                {
                    cells.Delete();
                }
                else
                {
                    cells.Clear();
                }



          
        }
        public override string GetDisplayValue()
        {
            return base.GetDisplayValue() + " [Range: " + v_Range + ", Instance Name: '" + v_InstanceName + "']";
        }
    }
}