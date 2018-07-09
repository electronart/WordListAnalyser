/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/05/2012
 * Time: 15:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of FormOpenFiles.
	/// </summary>
	public partial class FormOpenFiles : Form
	{
		
		static  string _FilePathA;
		
		public string FilePathA
		{
		get { return _FilePathA; }
		set { _FilePathA = value; }
		}
		
		static  string _FilePathB;
		
		public string FilePathB
		{
		get { return _FilePathB; }
		set { _FilePathB = value; }
		}


		public FormOpenFiles()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonBrowseFile1Click(object sender, EventArgs e)
		{
						
		OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt"; 
            dlg.Title = "Open the files to compare file";
            dlg.CheckFileExists = true;
       
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
            	
            this.pathLabelA.Text	= dlg.FileName;
            _FilePathA  = dlg.FileName;
            //this.pathLabelA.Text = _FilePathA;
            if ((pathLabelA.Text.Length >0) && (pathLabelB.Text.Length >0)){
            this.buttonOK.Enabled = true;
            } else    this.buttonOK.Enabled = false;
            	try
            	{
          
                //Save the file and path to the app.config file
               //WordListAnalyser2.Properties.Settings1.Default.FilePathA = _FilePathA;
            	//WordListAnalyser2.Properties.Settings1.Default.Save();
            	}
            	catch (Exception ex)
            	{
            	 MessageBox.Show(ex.Message, "FormOpenFiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
            	}
            	      	
            }
		}
		
		void ButtonBrowseFile2Click(object sender, EventArgs e)
		{
					
			OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt"; 
            dlg.Title = "Open the files to compare file";
            dlg.CheckFileExists = true;
       
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
            	
            this.pathLabelB.Text	= dlg.FileName;
            _FilePathB  = dlg.FileName;
            //this.pathLabelB.Text = _FilePathB;
            if ((pathLabelA.Text.Length >0) && (pathLabelB.Text.Length >0)){
            this.buttonOK.Enabled = true;
            } else    this.buttonOK.Enabled = false;
            	try
            	{
          
                 //Save the file and path to the app.config file
               //WordListAnalyser2.Properties.Settings1.Default.FilePathB = _FilePathB;
               //WordListAnalyser2.Properties.Settings1.Default.Save();
            	}
            	catch (Exception ex)
            	{
            	 MessageBox.Show(ex.Message, "FormOpenFiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);	
            	}
            	      	
			
			}
			
		}
		
		void ButtonCancelClick(object sender, EventArgs e)
		{
			// TODO
		}
		
		void FormOpenFilesLoad(object sender, EventArgs e)
		{
			try {
		
				
				this.buttonOK.Enabled = false;
			/*	textBoxFile1.Text =  WordListAnalyser2.Properties.Settings1.Default.FilePathA;
			 	textBoxFile1.TextAlign = HorizontalAlignment.Left;
			
			 	textBoxFile2.Text =  WordListAnalyser2.Properties.Settings1.Default.FilePathB;
				textBoxFile2.TextAlign = HorizontalAlignment.Left;
				textBoxFile2.Select();
				textBoxFile1.Select();*/
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message, "FormOpenFilesLoad");
			}
			   
			
		}
		
		void PathLabelAClick(object sender, EventArgs e)
		{
			
		}
		void ButtonOKClick(object sender, EventArgs e)
		{
	
		}
	}
}
