using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Navisworks.Api.Plugins;

namespace NavisCheckerSener
{
    [Plugin("NavisCheckerSener.WPFDockPaneAddin", "PML_Sener",
   DisplayName = "Element Checker",
   ToolTip = "Criado por Pablo Marinho Lopes")]
    class WPFDockPaneAddin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            #region loadPlugin
            if (Autodesk.Navisworks.Api.Application.IsAutomated)
            {
                throw new InvalidOperationException("Invalid when running using Automation");
            }

            //Find the plugin
            PluginRecord pr = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("NavisCheckerSener.WPFDocPanePlugin.PML_Sener");

            if (pr != null && pr is DockPanePluginRecord && pr.IsEnabled)
            {
                //checks if it needs loading
                if (pr.LoadedPlugin == null)
                {
                    pr.LoadPlugin();
                }

                DockPanePlugin dpp = pr.LoadedPlugin as DockPanePlugin;
                if (dpp != null)
                {
                    //switch the Visible flag
                    dpp.Visible = !dpp.Visible;
                }
               
            }
            #endregion


            return 0;
        }
    }
}
