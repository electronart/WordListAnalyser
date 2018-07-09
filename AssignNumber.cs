/*
 * Created by SharpDevelop.
 * User: User
 * Date: 01/11/2011
 * Time: 14:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*
 *	Class that takes a stemmed input file and assigns sequential numbers
 *	to all distinct groups of stems and produces two output files, one where
 *	weak barriers are treated as strong and one where they are ignored.
 *	Rob Hooper
 *	05/01/2004
 */


using System;
using System.IO;
using System.Windows.Forms;//for messageBox

namespace WordListAnalyser2
{

//class begins
public class AssignNumber
{
	//instance variables
	static int stronggroupno, weakgroupno;
	static int samplesize = 0;
	static string infile;// File infile;
	static StreamReader stronginput, weakinput;//BufferedReader stronginput, weakinput;
	static string strongbarrier = "====";
	static string weakbarrier = "----";
	
	public static porterData pdinfile;
	
	//constructor methods
	
	public AssignNumber(string s)//s = stemmedFileName
	{
		//MessageBox.Show("s = " + s);
		infile = s;//stemmedFile
		stronggroupno = 0;
		weakgroupno = 0;
		samplesize = 0;
	} //end of constructor
	
	public AssignNumber(porterData pd)//s = stemmedFileName
	{
		//MessageBox.Show("s = " + s);
		pdinfile = pd;
		pdinfile.resetCursor();
		stronggroupno = 0;
		weakgroupno = 0;
		samplesize = 0;
	} //end of constructor
	
	public AssignNumber(){}	//end of null constructor

	//Method to number the input file ignoring weak barriers
	public static void weakAssignNumber(string s)//s = output filename
	{
		try {
			pdinfile.resetCursor();
		//MessageBox.Show("infile = "+ infile, "AssignNumber.weakAssignNumber");	
		string weakinline = "";
		string weakoutline = "";
		//initialize reading and writing buffers
		FileStream fsinfile = new FileStream(infile, FileMode.Open,FileAccess.ReadWrite);
		weakinput = new StreamReader(fsinfile);
		
		FileStream weakoutfile = new FileStream(s, FileMode.OpenOrCreate,FileAccess.ReadWrite);
		StreamWriter weakprintout = new StreamWriter(weakoutfile);
		
		weakinline = weakinput.ReadLine();
		//traverse file until null line read in
		while(weakinline != null)
		{
			//increment group number only for strong barriers
			if(weakinline.Contains(strongbarrier)) weakgroupno++;
			else if(!(weakinline.Contains(weakbarrier)))
			{
				//create and write output string
				weakoutline = weakgroupno + " " + weakinline;
				weakprintout.WriteLine(weakoutline);
				weakprintout.Flush();
			}
			//read in next line
			weakinline = weakinput.ReadLine();
		} // *** end of while 'weakinline != null'
		// *** close buffers
		weakinput.Close();
		weakprintout.Close();
		weakoutfile.Close();
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message, "AssignNumber.weakAssignNumber");
		}
		
		
	} //end of method 'weakAssignNumber'
	
	public static porterData pD_weakAssignNumber(string s)//s = output filename
	{
		
		pdinfile.resetCursor();
		//MessageBox.Show("infile = "+ infile, "AssignNumber.weakAssignNumber");	
		string weakinline = "";
		string weakoutline = "";
		//initialize reading and writing buffers
//		FileStream fsinfile = new FileStream(infile, FileMode.Open,FileAccess.ReadWrite);
//		weakinput = new StreamReader(fsinfile);
		
		porterData pDataOut = new porterData(s);
		
//		FileStream weakoutfile = new FileStream(s, FileMode.OpenOrCreate,FileAccess.ReadWrite);
//		StreamWriter weakprintout = new StreamWriter(weakoutfile);
		
		weakinline = pdinfile.readLine();
		//traverse file until null line read in
		while(weakinline != null)
		{
			//increment group number only for strong barriers
			if(weakinline.Contains(strongbarrier)) weakgroupno++;
			else if(!(weakinline.Contains(weakbarrier)))
			{
				//create and write output string
				weakoutline = weakgroupno + " " + weakinline;
				pDataOut.writeLine(weakoutline);
			}
			//read in next line
			weakinline = pdinfile.readLine();
		} // *** end of while 'weakinline != null'
		// *** close buffers
//		weakinput.Close();
//		weakprintout.Close();
//		weakoutfile.Close();
		return pDataOut;
			
		
		
	} //end of method 'weakAssignNumber'

	//Method to number the input file treating weak barriers as strong
	public static void strongAssignNumber(string s)//s = output file name
	{
		try {
		string stronginline = "";
		string strongoutline = "";
		//initialize reading and writing buffers
		stronginput = new StreamReader(infile);
		FileStream strongoutfile = new FileStream(s, FileMode.OpenOrCreate,FileAccess.ReadWrite);
		StreamWriter strongprintout = new StreamWriter(strongoutfile);
		stronginline = stronginput.ReadLine();
		//traverse file until null line read in
		while(stronginline != null)
		{
			//increment group number for strong & weak barriers
			if(stronginline.Contains(strongbarrier) || stronginline.Contains(weakbarrier)) stronggroupno++;
			else
			{
				//create and write output string
				strongoutline = stronggroupno + " " + stronginline;
				strongprintout.WriteLine(strongoutline);
				strongprintout.Flush();
				//count number of words in file
				samplesize++;
			}
			//read in next line
			stronginline = stronginput.ReadLine();
		} //end of while 'stronginline != null'
		//close buffers used
		stronginput.Close();
		strongprintout.Close();
		strongoutfile.Close();
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message, "AssignNumber.strongAssignNumber");
		}
		
	}	// end of method 'strongAssignNumber'
	
	public static porterData pD_strongAssignNumber(string s)//s = output file name
	{
		pdinfile.resetCursor();
		string stronginline = "";
		string strongoutline = "";
		//initialize reading and writing buffers
//		stronginput = new StreamReader(infile);
//		FileStream strongoutfile = new FileStream(s, FileMode.OpenOrCreate,FileAccess.ReadWrite);
//		StreamWriter strongprintout = new StreamWriter(strongoutfile);
//		stronginline = stronginput.ReadLine();
		stronginline = pdinfile.readLine();
		
		porterData strongoutfile = new porterData(s);
		//traverse file until null line read in
		while(stronginline != null)
		{
			//increment group number for strong & weak barriers
			if(stronginline.Contains(strongbarrier) || stronginline.Contains(weakbarrier)) stronggroupno++;
			else
			{
				//create and write output string
				strongoutline = stronggroupno + " " + stronginline;
				strongoutfile.writeLine(strongoutline);
				//count number of words in file
				samplesize++;
			}
			//read in next line
			stronginline = pdinfile.readLine();
		} //end of while 'stronginline != null'
		//close buffers used
//		stronginput.Close();
//		strongprintout.Close();
//		strongoutfile.Close();
		return strongoutfile;
			
		
	}	// end of method 'strongAssignNumber'

	// *****   Method to return the samplesize 

	public static  int getSampleSize(){	return samplesize; }
} // *** end of class 'AssignNumber'
}