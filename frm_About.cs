/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10/22/2011
 * Time: 3:33 PM
 * 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
namespace WordListAnalyser2
{	
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


/// <summary>
/// Description of About.
/// </summary>
public partial class About : Form
{
public About()
{
//
// The InitializeComponent() call is required for Windows Forms designer support.
//
InitializeComponent();
//
// TODO: Add constructor code after the InitializeComponent() call.
//
             string strVersionMaj = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
             string strVersionMin = Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
             string strVersionBuild = Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
              string strVersionRev = Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
             this.lblVersion.Text = string.Format("{0}{1:##}.{2:##} ({3:####}.{4:####})", "Version ", strVersionMaj,strVersionMin,strVersionBuild, strVersionRev);
			
		}
		
        //Close About dialog
		void BtnOK_Click(object sender, EventArgs e)
		{
		this.Close();
		}
		
	
		
		//Link to website
		void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
		System.Diagnostics.Process.Start("http://www.electronart.co.uk");     
		}
	}
}
