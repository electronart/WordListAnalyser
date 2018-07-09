/*
 * Created by SharpDevelop.
 * User: User
 * Date: 31/10/2011
 * Time: 02:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/* Based on Java program below published by Lancs University
 *	Class to take a numbered file after it has been stemmed and sort
 *	it into pseudo groups where identical stems are adjacent
 *	Rob Hooper
 *	02/11/2003
 */


using System;
using System.IO;
using System.Collections;
using System.Text;
using JavaConvert.Data;
using System.Windows.Forms;//for MessageBox
using System.Globalization;

namespace WordListAnalyser2
{
	
public class Regroup
{
	//instance variables
	ArrayList output;//was Vector in Java
	string infile;//was File in Java
	porterData pd_infile;
	
	// *****   Constructor methods   *****

	public Regroup(string s)
	{
		output = new ArrayList();
	
		infile = s;//new FileStream(s, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
	}	// *** end of constructor
	
	/// <summary>
	/// Tom 04/11/2015 using simulated file rather than actual file
	/// </summary>
	public Regroup(porterData input)
	{
		output = new ArrayList();
		
		pd_infile = input;
		pd_infile.resetCursor();
	}
	
	public Regroup(){} // *** end of null constructor

	//Method to regroup the numbered file
	public void regroupfile(string s) //input should be the numbered-wordListFileName file
	{
		try {
		string inputstring = "";
		string test = "";
		string outputstring = "";
		string str1, str2;
		StringTokenizer st1, st2;// was Tokenizer
		bool added = false;
		int x = 0;
		int outputlength = 0;
		
		//MessageBox.Show("s = " + s, "regroupfile(s)"); //s should be weakRegrouped_stemmedfilename
		
		//initialise input/output buffers
		FileStream outfile = new FileStream(s, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
		StreamWriter swOut = new StreamWriter(outfile);
		FileStream fsi = new FileStream(infile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		StreamReader datain = new StreamReader(fsi);
		
		//add first element to the output
		inputstring = datain.ReadLine();
		output.Add(inputstring);
		
		
		//19 June 2012 added below to filter out comment lines
		// 21/10/2015 Can't see a filter??? Tom
		
        inputstring = datain.ReadLine();
        while (inputstring != null)
        {
			//initialise variables
			st1 = new StringTokenizer(inputstring);
			str1 = st1.NextToken;
			str1 = st1.NextToken;
			//reset loop variables					
			added = false;
			outputlength = output.Count;
			x = outputlength;
			while(x > 0)
			{
				test = (string)output[(x - 1)];
				st2 = new StringTokenizer(test);
				str2 = st2.NextToken;
				str2 = st2.NextToken;
				// HACK Tom 21/10/2015 - Changed from CompareTo to Compare to remove cultural awareness
				// see Remarks @ https://msdn.microsoft.com/en-us/library/system.string.compareto%28v=vs.110%29.aspx
				
				//CultureInfo mInfo 
				if(String.Compare(str1, str2, StringComparison.Ordinal) < 0) x--;
				else
				{
					output.Insert(x, inputstring);
					added = true;
					x = 0;
				}
			} // end of while 'x > 0'
			if(!added) output.Insert(0, inputstring);
			inputstring = datain.ReadLine();
			//inputstring = inputstring.TrimEnd();
			
		} // end of while 'inputstring != null'
		outputlength = output.Count;//was .size
		
		// *** output sorted array into file
		for(int i = 0; i < outputlength ; i++)
		{
			outputstring = (string)output[i];//was .ElementAt
			//outputstring = outputstring.TrimEnd(); removed blank space between the 2 groups
			swOut.WriteLine(outputstring);
			swOut.Flush();
		} // *** end of for
		// *** close buffers
		datain.Close();
          	
        fsi.Close(); //added 5 July 2013  	
		swOut.Close();
		outfile.Close(); //was DeleteOnExit();
	
	
		} catch (Exception ex) {
			
			MessageBox.Show(ex.ToString() + "\n \n" + ex.StackTrace, "Regroup.regroupfile(s)");
			throw;
		}
		
		
	} // *** end of method 'regroupfile'
	
	public porterData pd_regroupfile(string name) //input should be the numbered-wordListFileName file
	{
		
		pd_infile.resetCursor();
		string inputstring = "";
		string test = "";
		string outputstring = "";
		string str1, str2;
		StringTokenizer st1, st2;// was Tokenizer
		bool added = false;
		int x = 0;
		int outputlength = 0;
		
		porterData numberedData = new porterData(name);
		
		//MessageBox.Show("s = " + s, "regroupfile(s)"); //s should be weakRegrouped_stemmedfilename
		
		//add first element to the output
		inputstring = pd_infile.readLine();
		//System.Diagnostics.Debug.WriteLine("inputString" + inputstring);
		output.Add(inputstring);
		
		
		//19 June 2012 added below to filter out comment lines
		// 21/10/2015 Can't see a filter??? Tom
		
        inputstring = pd_infile.readLine();
        while (inputstring != null)
        {
			//initialise variables
			st1 = new StringTokenizer(inputstring);
			str1 = st1.NextToken;
			str1 = st1.NextToken;
			//reset loop variables					
			added = false;
			outputlength = output.Count;
			x = outputlength;
			while(x > 0)
			{
				test = (string)output[(x - 1)];
				st2 = new StringTokenizer(test);
				str2 = st2.NextToken;
				str2 = st2.NextToken;
				// HACK Tom 21/10/2015 - Changed from CompareTo to Compare to remove cultural awareness
				// see Remarks @ https://msdn.microsoft.com/en-us/library/system.string.compareto%28v=vs.110%29.aspx
				
				//CultureInfo mInfo 
				if(String.Compare(str1, str2, StringComparison.Ordinal) < 0) x--;
				else
				{
					output.Insert(x, inputstring);
					added = true;
					x = 0;
				}
			} // end of while 'x > 0'
			if(!added) output.Insert(0, inputstring);
			inputstring = pd_infile.readLine();
			//inputstring = inputstring.TrimEnd();
			
		} // end of while 'inputstring != null'
		outputlength = output.Count;//was .size
		
		// *** output sorted array into file
		for(int i = 0; i < outputlength ; i++)
		{
	
			outputstring = (string)output[i];//was .ElementAt
			//outputstring = outputstring.TrimEnd(); removed blank space between the 2 groups
			//System.Diagnostics.Debug.WriteLine("outputstring" + outputstring);
			numberedData.writeLine(outputstring);

//			swOut.WriteLine(outputstring);
//			swOut.Flush();
		} // *** end of for
		// *** close buffers
//		datain.Close();
//          	
//        fsi.Close(); //added 5 July 2013  	
//		swOut.Close();
//		outfile.Close(); //was DeleteOnExit();
	
		return numberedData;
		
		
	}
}// *** end of class 'Regroup'
}