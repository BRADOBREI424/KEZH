using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace KEZH.WindowFolder.WinInfo
{
    /// <summary>
    /// Логика взаимодействия для WinInfo.xaml
    /// </summary>
    public partial class WinInfo : Window
    {
        public WinInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Hidden;
            btnCloseV2.Visibility = Visibility.Visible;
        }

       
        private void btnCloseV2_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Visible;
            btnCloseV2.Visibility = Visibility.Hidden;
        }

        

        private void BtnTechSupport_Click(object sender, RoutedEventArgs e)
        {
            WinTechSupport winTechSupport = new WinTechSupport();
            winTechSupport.ShowDialog();         
        }

        private void BtnInfoProgam_Click(object sender, RoutedEventArgs e)
        {
            WinInfoProgram winInfoProgram = new WinInfoProgram();
            winInfoProgram.ShowDialog();           
        }

        private void BtnUserGuide_Click(object sender, RoutedEventArgs e)
        {
            //Process.Start(@"C:\Users\totmyanina.COLLEGE\Desktop\KEZH\KEZH\ResourceFolder\KEZHUserGuide.docx");
            //string originalfilename = System.IO.Path.GetFullPath();
            //Process.Start(@"\\tk34\306\KEZHUserGuide.docx");

            //var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //var file = Path.Combine(directory, "KEZHUserGuide.docx");
            //Process.Start(file);

            Process wordProcess = new Process();
            wordProcess.StartInfo.FileName = "\\KEZHUserGuide.docx";
            wordProcess.StartInfo.UseShellExecute = true;
            wordProcess.Start();

            //Word.Application wordApp = new Word.Application();
            //Word.Document wordDoc = new Word.Document();
            //wordApp.Visible = true;
            //Object docPath = (AppDomain.CurrentDomain + "\\KEZHUserGuide.docx");
            //wordDoc = wordApp.Documents.Add(ref docPath);

            //System.Diagnostics.Process myProcess = new Process();
            //myProcess.StartInfo.FileName = "c:\\KEZHUserGuide.docx";
            //myProcess.StartInfo.Verb = "Open";
            //myProcess.StartInfo.CreateNoWindow = false;
            //myProcess.Start();

        }
    }
}
