using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelWorkbook
{
    public partial class MyRibbon
    {
        ActionsPaneControl1 actionsPane1 = new ActionsPaneControl1();
        ActionsPaneControl2 actionsPane2 = new ActionsPaneControl2();
        private void MyRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisWorkbook.ActionsPane.Controls.Add(actionsPane1);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(actionsPane2);
            actionsPane1.Hide();
            actionsPane2.Hide();
            Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = false;

            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                this.button1_Click);
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                this.button2_Click);
            this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                this.toggleButton1_Click);
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                this.button3_Click);
        }
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = true;
            actionsPane2.Hide();
            actionsPane1.Show();
            toggleButton1.Checked = false;
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = true;
            actionsPane1.Hide();
            actionsPane2.Show();
            toggleButton1.Checked = false;

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            if (toggleButton1.Checked == true)
            {
                Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = false;
            }
            else
            {
                Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = true;
            }

        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            //Globals.ThisWorkbook.Application.AddIns

        }
    }
}
