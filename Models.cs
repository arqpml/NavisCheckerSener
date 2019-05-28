using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisCheckerSener
{
    class Models : INotifyPropertyChanged
    {
        public ObservableCollection<string> Information { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        Document oDoc = Autodesk.Navisworks.Api.Application.ActiveDocument;
        public Models()
        {
            Information = new ObservableCollection<string>();
            Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Changed += OnSelectionChanged;
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += OnDocumentChanged;
        }

        private void OnDocumentChanged(object sender, EventArgs e)
        {
            oDoc = Autodesk.Navisworks.Api.Application.ActiveDocument;
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            
            Update();
        }

        public void Update()
        {
           
            if (oDoc.CurrentSelection.SelectedItems.Count > 0)
            {
                Information.Clear();                
                StringBuilder sb = new StringBuilder();                
                ModelItemCollection oSelectedItems = oDoc.CurrentSelection.SelectedItems;
                foreach (ModelItem modelItem in oSelectedItems)
                {

                    DataProperty Mark = modelItem.PropertyCategories.FindPropertyByDisplayName("Element",
                                                                                                       "Mark");

                    if (Mark != null)
                    {
                        sb.AppendLine("Mark: ");
                        try
                        {
                            sb.Append(Mark.Value.ToDisplayString());
                        }
                        catch (Exception)
                        {
                            sb.Append("erro");                            
                        }                        
                    }
                    DataProperty Volume = modelItem.PropertyCategories.FindPropertyByDisplayName("Element",
                                                                                   "Volume");
                    if (Volume != null)
                    {
                        sb.AppendLine("Volume: ");
                        try
                        {
                            sb.Append(Volume.Value.ToString());
                        }
                        catch (Exception)
                        {
                            sb.Append("erro volume");
                        }
                    }


                    Information.Add(sb.ToString());                    
                    
                }
                OnPropertyChanged("Information");
            }
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
