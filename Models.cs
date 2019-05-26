using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisCheckerSener
{
    class Models : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Information { get; private set; }

        public PropertyCategory oPC_TypeMark { get; private set; }
        public PropertyCategory oPC_Volume { get; private set; }


        public Models()
        {
            //TODO: IMplement information about multiple selections
            Document oDoc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            if (oDoc.CurrentSelection.SelectedItems.Count>0)
            {
                ModelItem oSelectedItem = oDoc.CurrentSelection.SelectedItems[0];
                oPC_TypeMark = oSelectedItem.PropertyCategories.FindCategoryByDisplayName("Type Mark");
                oPC_Volume = oSelectedItem.PropertyCategories.FindCategoryByDisplayName("Volume");
                UpdateDisplay();
                
            }            
   
        }

        private void UpdateDisplay()
        {
            Information = "";
            StringBuilder sb = new StringBuilder(1000);
            sb.Append("TYPE MARK: ");
            sb.Append(oPC_TypeMark.ToString());
            sb.Append(Environment.NewLine);
            Information = sb.ToString();
            OnPropertyChanged("Information");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
