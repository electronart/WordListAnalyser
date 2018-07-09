/*
 * Created by SharpDevelop.
 * User: User
 * Date: 15/10/2011
 * Time: 01:15
 * 
/*	Based on Java file by Rob Hooper
 *	File to implement method to perform  Truncation
 *	on an inputfile and return the new file
 *	Rob Hooper
 *	05/02/2004
 */
 
 using System;
 using System.IO;
 using System.Collections;
 using System.Reflection;
 using System.Windows;
 using System.Windows.Forms;

 namespace WordListAnalyser2
 {

	
//class begins
public class Truncator
{
	// *** instance variables
	//static Reader datain;
	public  static StreamReader dataIn;
	public  static  porterData  pd_dataIn;
	private static string strongbarrier = "====";
	private static string weakbarrier = "----";

	// *****   Contructor methods   *****

	public Truncator(string i) //string is FileName
	{
		FileStream fs0 = new FileStream(i,FileMode.Open,FileAccess.ReadWrite);
		dataIn = new StreamReader(fs0);
		
	} // *** end of constructor
	
	public Truncator(porterData givenData) // sortedFile
	{
		pd_dataIn = givenData;
		pd_dataIn.resetCursor();
	}
	
	public Truncator()
	{
	}
	// *** end of null constuctor

	//input x is max length of word
	//input string o is output file name & path
	public static void truncate(string o, int x) 	
	{
		//method variables, 
		string inline, outline;
		int inlinelength;
		
	try {

		//create new output file and overwrite old files
		FileStream outfile = new FileStream(o, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
		StreamWriter dataout = new StreamWriter(outfile);
		
		//string fileName2 = System.Windows.Forms.Application.StartupPath + "\\GroupedWordList.txt";// + dataIn;
		//FileStream fs2 = new FileStream(dataIn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		//StreamReader datain = new StreamReader(fs2);
		//read in first line
		inline = dataIn.ReadLine();
		//traverse file until a null line read in
		while(inline != null)
		{
			//find length of input string
			inlinelength = inline.Length;
			//if comment line is reached stop
			if (inline.Contains("//"))break;
			//when barrier read-in and write to outfile unchanged
			if(inline.Contains(strongbarrier) || inline.Contains(weakbarrier)) outline = inline;
			//only truncate word that are long enough
			else if(inlinelength > x) outline = inline.Substring(0, ((x)));
			else outline = inline;
			
			//output truncated word
			dataout.WriteLine(outline);
			dataout.Flush();
			
			//read in next line
			inline = dataIn.ReadLine();			
		} // *** end of while	
		// *** close buffers used
		dataout.Close();
		outfile.Dispose();	
		
		dataIn.Close();
		//fs0.Dispose();
			
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "Truncator",  MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		
		
	} // *** end of method 'truncate'
	
	public static porterData pd_truncate(string o_name, int x) 	
	{
		//method variables, 
		string inline, outline;
		int inlinelength;
	

		//create new output file and overwrite old files
//		FileStream outfile = new FileStream(o, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
//		StreamWriter dataout = new StreamWriter(outfile);
		
		porterData dataout = new porterData(o_name);
		
		//string fileName2 = System.Windows.Forms.Application.StartupPath + "\\GroupedWordList.txt";// + dataIn;
		//FileStream fs2 = new FileStream(dataIn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		//StreamReader datain = new StreamReader(fs2);
		//read in first line
		inline = pd_dataIn.readLine();
		//traverse file until a null line read in
		while(inline != null)
		{
			//find length of input string
			inlinelength = inline.Length;
			//if comment line is reached stop
			if (inline.Contains("//"))break;
			//when barrier read-in and write to outfile unchanged
			if(inline.Contains(strongbarrier) || inline.Contains(weakbarrier)) outline = inline;
			//only truncate word that are long enough
			else if(inlinelength > x) outline = inline.Substring(0, ((x)));
			else outline = inline;
			
			//output truncated word
			dataout.writeLine(outline);
			//dataout.Flush();
			
			//read in next line
			inline = pd_dataIn.readLine();			
		} // *** end of while	
		// *** close buffers used
		return dataout;
		//fs0.Dispose();
			
			
		
		
	}
} // *** end of class 'Truncator'
}