using ClassLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string fileName;
        WriteLogFile objOfFile = new WriteLogFile();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GetFilePath(object sender, RoutedEventArgs e)
        {
            string msg = (String.Format("{0}                     {1}                      {2}", "Debug", "", "Getting the excel file path to impliment the data of that file"));
            objOfFile.WriteLog(msg);
            OpenFileDialog abc = new OpenFileDialog();
            abc.Title = "test file";
            abc.Filter = "";
            abc.InitialDirectory = "";
            if (abc.ShowDialog() == true)
            {
                fileName = abc.FileName;
                FileNameData.Text = fileName;
                
            }

        }

        //private void GetValue(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    string msg1 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getCellValue)", "Getting the cell value by passing the row and column number as a parameter"));
        //    objOfFile.WriteLog(msg1);
        //    int row = Convert.ToInt32(rowData.Text);
        //    int column = Convert.ToInt32(columnData.Text);
        //    FetchExcelData obj = new FetchExcelData(fileName);
        //    string value = obj.getCellValue(row, column);

        //    showValue.Text = value;
        //    string msg2 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getCellValue)", "Getting the cell value by passing the row and column number as a parameter is done"));
        //    objOfFile.WriteLog(msg2);

        //}

        //private void GetRowCount(object sender, RoutedEventArgs e)
        //{
        //    string msg1 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getRowCount)", "Getting the row count"));
        //    objOfFile.WriteLog(msg1);
        //    FetchExcelData obj = new FetchExcelData(fileName);
        //    MessageBox.Show("Total Rows Are = ",obj.getRowCount().ToString());
        //    string msg2 = (String.Format("{0}                     {1}                      {2}",  "Debug", "The Class Name (FetchExcelData) and the method name (getRowCount)", "Getting row count is done"));
        //    objOfFile.WriteLog(msg2);
        //}

        //private void GetColumnCount(object sender, RoutedEventArgs e)
        //{


        //    string msg1 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getColumnCount)", "Getting The Total Column count"));
        //    objOfFile.WriteLog(msg1);
        //    FetchExcelData obj = new FetchExcelData(fileName);
        //    MessageBox.Show("Total Columns Are = ",obj.getColumnCount().ToString());
        //    string msg2 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getColumnCount)", "Getting The Column Count is done"));
        //    objOfFile.WriteLog(msg2);
        //}

        //private void GetRowValue(object sender, RoutedEventArgs e)
        //{
        //    string msg1 = (String.Format("{0}                     {1}                      {2}", "The Class Name (FetchExcelData) and the method name (getRowValue)", "Getting the whole data of given row and storing it in a list of string"));
        //    objOfFile.WriteLog(msg1);
        //    FetchExcelData obj = new FetchExcelData(fileName);

        //    List<string> lst = obj.getRowValue(3);

        //    foreach (string str in lst)
        //    {
        //        listBox.Items.Add(str);
        //    }
        //    MessageBox.Show("Successfully Fetch Row Data");
        //    string msg2 = (String.Format("{0}                      {1}                     {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getRowValue)", "Getting the whole data of given row and storing it in a list of string is done"));
        //    objOfFile.WriteLog(msg2);

        //}
        //private void GetColumnValue(object sender, RoutedEventArgs e)
        //{
        //    string msg1 = (String.Format("{0}                      {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getRowValue)", "Getting the whole data of given column and storing it in a list of string"));
        //    objOfFile.WriteLog(msg1);
        //    FetchExcelData obj = new FetchExcelData(fileName);

        //    List<string> lst = obj.getColumnValue(3);

        //    foreach (string str in lst)
        //    {
        //        listBox.Items.Add(str);
        //    }
        //    MessageBox.Show("Successfully Fetch Column Data");
        //    string msg2 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchExcelData) and the method name (getColumnValue)", "Getting the whole data of given column and storing it in a list of string is done"));
        //    objOfFile.WriteLog(msg2);

        //}


        private void Read_Config()
        {
        //    string msg1 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchConfigData) and the method name (FetchSections_Data) with the parameter of ATS_SubSystemDataBase file path and the name of the config file that should be in exe location", "Getting the Sections name from the config and getting the data from ATS_Subsystem_DataBase file"));
        //    objOfFile.WriteLog(msg1);
            FetchConfigData obj1 = new FetchConfigData();
            string configFileName = "ClassLibrarySettings";
         //   string atsSubsystemDataBase_File_Path = "C:\\Users\\485781\\Documents\\Visual Studio 2015\\Projects\\ATS_SubSystem_Database_v1.7.0.xml";
            Dictionary<string, Dictionary<string, string>> lst = obj1.FetchSections_Data(configFileName);
       //     string msg2 = (String.Format("{0}                     {1}                      {2}", "Debug", "The Class Name (FetchConfigData) and the method name (FetchSections_Data) with the parameter of ATS_SubSystemDataBase file path and the name of the config file that should be in exe location", "Getting the Sections name from the config and getting the data from ATS_Subsystem_DataBase file is done and storing the data into the dictionary"));
       //     objOfFile.WriteLog(msg2);
        }


        //private void createXML(object sender, RoutedEventArgs e)
        //{
        //    CreateXmlFile obj = new CreateXmlFile();
        //    obj.Create(fileName);
        //    MessageBox.Show("xml file created successfully");
        //}


        private void CreateTimetable(object sender, RoutedEventArgs e)
        {
            Read_Config();
            
            MessageBox.Show("Prease Wait For Sometime!", "Processing Window", MessageBoxButton.OK, MessageBoxImage.Information);

            CreateXmlUsingMission_TDG obj = new CreateXmlUsingMission_TDG();
            obj.Create(fileName);
            MessageBox.Show("File Created Successfully","Message Window",MessageBoxButton.OK,MessageBoxImage.Asterisk);
        }

 
    }
}
