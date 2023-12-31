﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProjectFileViewer
{
    public class ViewModels : INotifyPropertyChanged
    {
        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                selectedItem = value;
                OnPropertyChanged(nameof(selectedItem));
            }
        }

        private string folderPath;
        public string FolderPath
        {
            get { return folderPath; }
            set
            {
                folderPath = value;
                OnPropertyChanged("FolderPath");
            }
        }
        private ObservableCollection<string> fileList;
        public ObservableCollection<string> FileList
        {
            get { return fileList; }
            set
            {
                if (fileList != value)
                {
                    fileList = value;
                    OnPropertyChanged(nameof(FileList));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OpenFileDialog() 
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.IsFolderPicker = true;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FolderPath = openFileDialog.FileName;
                string[] files = Directory.GetFiles(FolderPath);

                FileList = new ObservableCollection<string>();

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    FileList.Add($"{fileInfo.Name}");
                }
            }
        }
        
        public void SecondOpenFile()
        {
            OpenFileDialog();
            
        }

        public void OpenFile() 
        {
            SecondWindow secondWindow = new SecondWindow();
            string[] files = Directory.GetFiles(FolderPath);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                secondWindow.NameLabel.Content = $"{fileInfo.Name}";
                secondWindow.SizeLabel.Content =  $"{fileInfo.Length.ToString()} byte";
                secondWindow.CreateLabel.Content = $"{fileInfo.CreationTime}";
            }
            secondWindow.Show();
        }
    }


}
