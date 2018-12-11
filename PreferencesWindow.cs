/*
 * Created by SharpDevelop.
 * User: User
 * Date: 20/01/2016
 * Time: 16:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of PreferencesWindow.
	/// </summary>
	public partial class PreferencesWindow : Form
	{
		int mode = 0;
		int m_normal = 1;
		int m_hoo = -1;
		
		bool buffbug = false;

        public int ERRTMode { get { return mode; } }


        public PreferencesWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			if (MainForm.stemming_mode == MainForm.MODE_DTS) radioButtonNormal.Checked = true;
			else											 radioButtonHooper.Checked = true;
			
			if (radioButtonHooper.Checked == false)
			{
				buttonIncludingFileBug.Enabled = false;
			}
			
			buttonApply.Enabled = false;
		}
		void RadioButtonNormalCheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonNormal.Checked == true)
			{
				mode = m_normal;
				Properties.Settings1.Default.useDTSAlgorithm = m_normal.ToString();
			}
			buttonApply.Enabled = true;
		}
		void RadioButtonHooperCheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonHooper.Checked == true)
			{
				mode = m_hoo;
				Properties.Settings1.Default.useDTSAlgorithm = m_hoo.ToString();
				//buttonIncludingFileBug.Enabled = true;
			}
			buttonApply.Enabled = true;
	
		}
		void ButtonIncludingFileBugCheckedChanged(object sender, EventArgs e)
		{
			if (buttonIncludingFileBug.Checked == true) buffbug = true;
			else										buffbug = false;
			buttonApply.Enabled = true;
	
		}
		void ButtonApplyClick(object sender, EventArgs e)
		{
			MainForm.stemming_mode = mode;
			MainForm.use_buffer_bug = buffbug;
			Properties.Settings1.Default.Save();
            Properties.Settings1.Default.Reload();
            
            this.Close();
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
