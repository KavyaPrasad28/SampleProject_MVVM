using SampleProject_MVVM.Commands;
using SampleProject_MVVM.Model;
using SampleProject_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject_MVVM.ViewModels
{
    public class DICOM_ViewModel
    {
        public static MainWindow getObject;
        public static PasswordView GetPassword { get; set; }
        public DICOM_Model DICOM { get; set; }
        public List<DICOM_Model> Nodes { get; set; }
        public MyCommands AddNewCommand { get; set; }
        public MyCommands UnlockCommand { get; set; }
        public MyCommands CloseCommand { get; set; }
        public MyCommands CancelCommand { get; set; }
        public DICOM_ViewModel()
        {
            DICOM = new DICOM_Model();
            Nodes = new List<DICOM_Model>();
            DICOM.Name = "23";
            DICOM.Status = "Error";
            //DICOM.Password = "1234";
            Nodes.Add(DICOM);
            AddNewCommand = new MyCommands(OnAddNew, CanAddNew);
            UnlockCommand = new MyCommands(OnUnlock, CanUnlock);
            CloseCommand = new MyCommands(OnClose, CanClose);
            CancelCommand = new MyCommands(OnCancel, CanCancel);
            
        }

        private bool CanCancel()
        {
            return true;
        }

        private void OnCancel()
        {
            GetPassword.Close();
        }

        private bool CanClose()
        {
            return true;
        }

        private void OnClose()
        {
            getObject.Close();
        }

        private bool CanAddNew()
        {
            return true;
        }
        private void OnAddNew()
        {
            PasswordView passwordView = new PasswordView();
            passwordView.Show();
            GetPassword = passwordView;
        }
        private bool CanUnlock()
        {
            return true;
        }
        private void OnUnlock()
        {
            if (DICOM.Password == "1234")
            {
                OnClose();
            }
        }
    }
}
