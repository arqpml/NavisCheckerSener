using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

namespace NavisCheckerSener
{
    [PluginAttribute("Sener Element Checker",
          //Plugin name
          "ADSK",
                //character Developer ID or GUID
                ToolTip = "Select Element to Display Information",
                //The tooltip for the item in the ribbon
                DisplayName = "Sener Element Checker")]
    public class NavisModelCheker : AddInPlugin
    {
        
        public override int Execute(params string[] parameters)
        {
            MessageBox.Show("Teste");
            return 0;
        }
    }
}
