using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeView
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion

        #region Constructor
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetLogicalDrives().Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion
        private RelayCommand delete;
        /// <summary>
        /// 登录事件
        /// </summary>
        public RelayCommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(C);
                }
                return delete;
            }
        }
        public void C()
        {
            
            if (DirectoryItemViewModel.name.FullPath != null)
            {
                MessageBox.Show(DirectoryItemViewModel.name.FullPath);
            }
            else
            {
                MessageBox.Show("Please choose one file");
            }
        }
        
    }
}
