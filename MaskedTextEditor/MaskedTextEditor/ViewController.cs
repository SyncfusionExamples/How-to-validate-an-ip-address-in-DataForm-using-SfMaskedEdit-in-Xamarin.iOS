using System;
using Syncfusion.iOS.DataForm;
using Syncfusion.iOS.MaskedEdit;
using Syncfusion.iOS.DataForm.Editors;
using UIKit;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;

namespace MaskedTextEditor
{
    public partial class ViewController : UIViewController
    {
        SfDataForm dataForm;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            dataForm = new SfDataForm();
            dataForm.DataObject = new ExpenseInfo();
            dataForm.RegisterEditor("CustomMaskEditors", new CustomMaskEditor(dataForm));
            dataForm.RegisterEditor("Balance", "CustomMaskEditors");
            dataForm.BackgroundColor = UIColor.White;
            this.View = dataForm;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


    public class CustomMaskEditor : DataFormEditor<SfMaskedEdit>
    {
        public CustomMaskEditor(SfDataForm dataForm) : base(dataForm)
        {
        }

        protected override SfMaskedEdit OnCreateEditorView()
        {
            return new SfMaskedEdit();
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, SfMaskedEdit view)
        {
            view.Mask = @"000\.000\.000\.000";
            view.Value = (string)this.DataForm.ItemManager.GetValue(dataFormItem);
        }
        protected override void OnWireEvents(SfMaskedEdit view)
        {
            view.ValueChanged += View_ValueChanged;
        }

        void View_ValueChanged(object sender, ValueChangedEventArgs eventArgs)
        {
            OnValidateValue(sender as SfMaskedEdit);
            OnCommitValue(sender as SfMaskedEdit);
        }

        protected override void OnUnWireEvents(SfMaskedEdit view)
        {
            view.ValueChanged -= View_ValueChanged;
        }
        protected override bool OnValidateValue(SfMaskedEdit view)
        {
            return this.DataForm.Validate("Balance");
        }
        protected override void OnCommitValue(SfMaskedEdit view)
        {
            var dataFormItemView = view.Superview as DataFormItemView;
            DataForm.ItemManager.SetValue(dataFormItemView.DataFormItem, view.Value);
        }
    }

    public class ExpenseInfo : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private string _ItemName = "Education";
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }

        private string balance = "100";
        public string Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                RaisePropertyChanged("Balance");
            }
        }
   
        [Display(AutoGenerateField = false)]
        public bool HasErrors
        {
            get
            {
                return false;
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            var list = new List<string>();
            if (!propertyName.Equals("Balance"))
                return list;
            else
            {
                // Here, you can validate Mask Editor. 
            }
            return list;
        }

    }
}
