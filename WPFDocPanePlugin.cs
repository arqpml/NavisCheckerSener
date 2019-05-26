using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Autodesk.Navisworks.Api.Plugins;

namespace NavisCheckerSener
{
    [Plugin("NavisCheckerSener.WPFDocPanePlugin", "PML_Sener",
            DisplayName = "NavisModelCheker",
            ToolTip ="Criado por Pablo Marinho Lopes")]
    [DockPanePlugin(150,200, FixedSize =false)]
    public class WPFDocPanePlugin : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //create and ElementHost
            ElementHost eh = new ElementHost();

            //assign the control
            eh.AutoSize = true;
            eh.Child = new WPFElementPropertiesControl();

            eh.CreateControl();

            return eh;
        }

        public override void DestroyControlPane(System.Windows.Forms.Control pane) => pane.Dispose();

    }
}
