/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/10/2011
 * Time: 21:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
using JavaConvert.Data;
using System.Text;
using System.Windows.Forms;
//using MyLogger;

namespace WordListAnalyser2
{
	// <summary>
	// Description of UnderCalc.
	// </summary>
		 
	// Class to calculate the conflation index and the understemming
 	// index from a stemmed file
 	//	Based on Java code by
 	// Rob Hooper
 	// 03/01/2004
	
	
	public class UnderCalc
	{
	//instance variables
	//static string analysefile;
	static string infile;	
	static StreamReader stronginput, weakinput ;
	static ArrayList wordgroup 		= new ArrayList(); //was Vector in Java
	static ArrayList tempwordgroup 	= new ArrayList();//was Vector in Java
	static string strongbarrier = "====";
	static string weakbarrier 	= "----";
	static double strongGDMT, strongGUMT, strongUI, strongCI, weakGDMT, weakGUMT,weakUI, weakCI;
	static porterData givenPData;
	
	
	public static StringBuilder sb = new StringBuilder(); // tom 03/11/2015 for debugging DMT();
	
	public static int numDMTCalls = 0;

	public UnderCalc(string s)//s = stemmedFile.txt file or truncated file
		{
		//MessageBox.Show(s, "UnderCalc");
		infile = s;
		//System.IO.StreamReader sr = System.IO.File.OpenText(infile) ;
		
		
		strongGDMT = 0.0;
		strongGUMT = 0.0;
		strongUI = 0.0;
		strongCI = 0.0;
		weakGDMT = 0.0;
		weakGUMT = 0.0;
		weakUI = 0.0;
		weakCI = 0.0;
		
		//calculateResults();
	
	
	}
	
	public UnderCalc(porterData data)
	{
		//MessageBox.Show(s, "UnderCalc");
		givenPData = data;
		//System.IO.StreamReader sr = System.IO.File.OpenText(infile) ;
		givenPData.resetCursor();
		
		strongGDMT = 0.0;
		strongGUMT = 0.0;
		strongUI = 0.0;
		strongCI = 0.0;
		weakGDMT = 0.0;
		weakGUMT = 0.0;
		weakUI = 0.0;
		weakCI = 0.0;
		
		//calculateResults();
	}
	
		//= new StreamReader(new FileStream(infile, FileMode.Open));//was BufferedReader in Java
		

	//public UnderCalc() 
	//{
		//try {
		//infile ="";	
		//using (FileStream fs = new FileStream(analysefile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) // Must be FileShare.ReadWrite, FileShare.Read doesn't work for some odd reason.
		//using (StreamReader sr = new StreamReader(fs)) 	
		
		//infile = sr.ReadToEnd();
		
			
		//} catch (Exception ex) {
		//MessageBox.Show	(ex.Message, "UnderCalc",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		//}
	
		
		
	//}
	// end of constructor
	

	
	//Method to sort the word group
	public static void sortWordGroup() 
	{
		
		string str1, str2;
		bool change = true;
		int wordgroupsize = wordgroup.Count;
		string sWordGroupSize = Convert.ToString(wordgroupsize);
		//MessageBox.Show("In sortWordGroup. Size= " + sWordGroupSize);
		// begin loop
		while(change)
		{
			change = false;
			for(int x = 0; x+1 < wordgroupsize; x++)
			{
				str1 = Convert.ToString(wordgroup[x]);
				str2 = Convert.ToString(wordgroup[x+1]);
				if(str1.CompareTo(str2) > 0)
				{
					//wordgroup.setElementAt(str1, x+1);
					//wordgroup.setElementAt(str2, x);
					// HACK Tom 03/11/2015 wordgroup.insert is adding whilst in java is replacing
					// instead I am setting these values manually and overwriting whatever was already there
					// as is done in java program
					//wordgroup.Insert(x+1, str1);//index, val
					wordgroup[x+1] = str1;
					//wordgroup.Insert(x, str2);
					wordgroup[x] = str2;
					change = true;
				}
			} // end of for		
		} // end of while 'change'
	} 
	// end of method 'sortWordGroup'

	//Method to read in the next group of words where weak barriers are ignored
	public static void getNextWeakWordGroup(string s) 
	{
		//string[] splitinline;
		string inLine;
		//int recode;
		// clear the wordgroup
		wordgroup.Clear();
		
		//set inline variable to passed parameter
		inLine = s;
		//MessageBox.Show(inLine,"inline, UnderCalc getNextWeakWordGroup");
		// check for error of two barriers in file
		if(inLine.Contains(strongbarrier)) inLine = weakinput.ReadLine();
		
		//loop through file until next barrier found
		while(!(inLine.Contains(strongbarrier)))
		{
			// if weak barrier found ignore and read in next line
			if(inLine.Contains(weakbarrier)) inLine = weakinput.ReadLine();
			// add next element to wordgroup
			wordgroup.Add(inLine);
			inLine = weakinput.ReadLine();
			// if end of file break from loop
			if(inLine == null) break;
		} // end of while
		
		sortWordGroup();
		
	} 
		
		
	public static void pd_getNextWeakWordGroup(string s) 
		{
			//string[] splitinline;
			string inLine;
			//int recode;
			// clear the wordgroup
			wordgroup.Clear();
			
			//set inline variable to passed parameter
			inLine = s;
			//MessageBox.Show(inLine,"inline, UnderCalc getNextWeakWordGroup");
			// check for error of two barriers in file
			if(inLine.Contains(strongbarrier)) inLine = givenPData.readLine();
			
			//loop through file until next barrier found
			while(!(inLine.Contains(strongbarrier)))
			{
				// if weak barrier found ignore and read in next line
				if(inLine.Contains(weakbarrier)) inLine = givenPData.readLine();
				// add next element to wordgroup
				wordgroup.Add(inLine);
				inLine = givenPData.readLine();
				// if end of file break from loop
				if(inLine == null) break;
			} // end of while
			
			sortWordGroup();
			
		} 
	// end of method 'getNextWeakWordGroup'

	//Method read in the next group of words where weak barriers are treated as strong
	public static void getNextStrongWordGroup(string w) 
	{
		//TODO remove debug
		//MessageBox.Show("entered method", "getNextStrongWordGroup");
		
		//string[] splitinline;
		string inline;// stem, origword, ending, recodestring, inline;
		//int recode;
		//clear wordgroup
		wordgroup.Clear();
		
		// set inline variable to passed parameter
		inline = w;
		
		//MyLog.WriteToLog(false,true,"getNextStrongWordGroup - value of w(inline)= ",w,"");
		
		// check for error of two barriers in file
		if(inline.Contains(strongbarrier) || inline.Contains(weakbarrier)) inline = stronginput.ReadLine();
		
		// loop through file until weak/strong barrier found
		while(!(inline.Contains(strongbarrier)) && !(inline.Contains(weakbarrier)))
		{
			// add next element to wordgroup
			wordgroup.Add(inline);
			
			//MyLog.WriteToLog(false,true,"getNextStrongWordGroup - in loop - next is readline from stream. Inline= ",inline,"");
			//StreamReader stronginputx = new StreamReader(analysefile);
			inline = stronginput.ReadLine();
			
			// if end of file break from loop
			if(inline == null) break;
		} // end of while
		
		sortWordGroup();
		
	} 
	
	public static void pd_getNextStrongWordGroup(string w) 
	{
				
		//string[] splitinline;
		string inline;// stem, origword, ending, recodestring, inline;
		//int recode;
		//clear wordgroup
		wordgroup.Clear();
		
		// set inline variable to passed parameter
		inline = w;
		
		//TODO remove debug		
		//MyLog.WriteToLog(false,true,"getNextStrongWordGroup - value of w(inline)= ",w,"");
		
		// check for error of two barriers in file
		if(inline.Contains(strongbarrier) || inline.Contains(weakbarrier)) inline = givenPData.readLine();
		
		// loop through file until weak/strong barrier found
		while(!(inline.Contains(strongbarrier)) && !(inline.Contains(weakbarrier)))
		{
			// add next element to wordgroup
			wordgroup.Add(inline);
			
			//MyLog.WriteToLog(false,true,"getNextStrongWordGroup - in loop - next is readline from stream. Inline= ",inline,"");
			//StreamReader stronginputx = new StreamReader(analysefile);
			inline = givenPData.readLine();
			
			// if end of file break from loop
			if(inline == null) break;
		} // end of while
		
		sortWordGroup();
		
	} 
	// end of method 'getNextStrongWordGroup'

	//Method to calculate the 'desired merge total' (DMT
	public static double DMT()
	{
		numDMTCalls++; // tom debugging 03/11/2015
		double dmt = 0;
		//retrieve the size of the wordgroup
		int dNg = wordgroup.Count;//was .size in Java
		//System.Diagnostics.Debug.WriteLine("DMT() 194 wordgroup.count =" + wordgroup.Count);
		
		//calculate the desired merge total using formula
		if(dNg != 0) dmt = (double)((0.5) * dNg) * (dNg - 1);
		
		//System.Diagnostics.Debug.WriteLine("UnderCalc DMT() 195: dNg= " + dNg + " , dmt=" + dmt);
		sb.Append("\n" + wordgroup.Count + " , " + dmt);
		return dmt;
	}
	// end of method 'DMT'

	// Method to calculate 'Unachieved Merge Total' (UMT) 
	public static double UMT()
	{
		double umt = 0;
		double tempumt;
		//retrieve wordgroup size
		int uNg = wordgroup.Count;
		string suNg = Convert.ToString(uNg);
		
		//TODO remove debug logging
		//MyLog.WriteToLog(false,true,"UMT - size of wordgroup - uNg = ",suNg,"");
		
		int stemgroupsize = 1;
		int[] nga = new int[uNg + 1];
		int nogroups = 0;
		int x = 0;
		int ng;
		string str1 = "";
		string str2 = "";
		string temp1, temp2;
		StringTokenizer st1, st2;
		
		//check for single word group and return zero
		if(uNg == 1) umt = 0;
		else
		{
			//loop through group to check for distinct stems from same concept group
			while(x+1 < uNg)
			{
				//retrieve next two elements from word group
				temp1 = Convert.ToString(wordgroup[x]); //was .ElementAt in Java
				temp2 = Convert.ToString(wordgroup[x+1]);// removed(string)
				//tokenize and retrieve stems from group elements
				st1 = new StringTokenizer(temp1);
				st2 = new StringTokenizer(temp2);
				str1 = st1.NextToken;
				str2 = st2.NextToken;
				
				//TODO remove debug
				//MyLog.WriteToLog(false,true,"UMT - str1 = ",str1,"");
				//MyLog.WriteToLog(false,true,"UMT - str2 = ",str2," (next check if str1 = str2)");
				
				//if stems equals increment stemgroup size counter
				if(str1.Equals(str2)){
					stemgroupsize++;
					//string sGroupSize = Convert.ToString(stemgroupsize);
				
				//TODO remove debug
				//MyLog.WriteToLog(false,true,"UMT Match, new stem group size= ",sGroupSize,"");
				}
			
				
				
				// if stems differ add stemgroup size to array and reset variables
				
				else
				{
					nga[nogroups] = stemgroupsize;
					stemgroupsize = 1;
					nogroups++;
					//string snoGroups = Convert.ToString(nogroups);
					
					//TODO remove debug
					//MyLog.WriteToLog(false,true,"UMT no match - new number of groups= ",snoGroups,"");
				}
				x++;
			} // end of while 'x+1 < uNg'
			
			// add last stemgroup size to array
			nga[nogroups] = stemgroupsize;
			
			// sum over all distinct stemgroups
			for(int i = 0; i <= nogroups; i++)
			{
				ng = nga[i];
				tempumt = (double)(ng * (uNg - ng));
				umt = umt + tempumt;
			} // end of for
		}
		// halve current undesired merge total
		umt = (double)0.5 * umt;
		return umt;
	} 
	// end of method 'UMT'

	//Method to calculate the indices for strong values
	public static void strongCalc()
	{
		 
		FileStream fs1 = new FileStream(infile, FileMode.Open);
		using (stronginput = new StreamReader(fs1))
		//using (System.IO.StreamReader stronginput = System.IO.File.OpenText(infile)) 
		{
		
		wordgroup.Clear();
		string snextline = "";
		
		//read in first line
		snextline = stronginput.ReadLine();
					
		// obtain rest of wordgroup after inline
		while((snextline != null) && (snextline.Contains ("//") == false))
		{
			getNextStrongWordGroup(snextline);
			strongGDMT = (double)strongGDMT + DMT();
			strongGUMT = (double)strongGUMT + UMT();
			snextline = stronginput.ReadLine();
			
		} // end of while 'snextline != null
		
		if(strongGDMT.Equals(0)) strongUI = 0.0;
		else strongUI = (double)strongGUMT/strongGDMT;
		strongCI = (double)(1 - strongUI);
		
		}
		//added 16 oct 11
		stronginput.Close(); //without this get an error at stage 4 - stemmedFile.txt in use.
	}
	
	public static void pd_strongCalc()
	{
		 
		//using (System.IO.StreamReader stronginput = System.IO.File.OpenText(infile)) 
		{
			givenPData.resetCursor();
		wordgroup.Clear();
		string snextline = "";
		
		//read in first line
		snextline = givenPData.readLine();
					
		// obtain rest of wordgroup after inline
		while((snextline != null) && (snextline.Contains ("//") == false))
		{
			pd_getNextStrongWordGroup(snextline);
			strongGDMT = (double)strongGDMT + DMT();
			strongGUMT = (double)strongGUMT + UMT();
			snextline = givenPData.readLine();
			
		} // end of while 'snextline != null
		
		if(strongGDMT.Equals(0)) strongUI = 0.0;
		else strongUI = (double)strongGUMT/strongGDMT;
		strongCI = (double)(1 - strongUI);
		
		}
		//added 16 oct 11
//		stronginput.Close(); //without this get an error at stage 4 - stemmedFile.txt in use.
	}
	// end of method "strongCalc"

	//Method to calculate the indices for weak values
	public static void weakCalc()
	{
	
		//initialise new buffer to read from input file
		
		FileStream fs1 = new FileStream(infile, FileMode.Open);
		// HACK Tom 28/10/2015 removed 'using' as weakinput seems to be globally used (however needs closing!)
//		using (weakinput = new StreamReader(fs1))
//		
//		{
		
		weakinput = new StreamReader(fs1);
		
		//read in first line from file
		string wnextline = weakinput.ReadLine();
		
		int numLines = 0;

		
		String lastLineNotNull = "unassigned";
		double weakGDMTBefore = weakGDMT;
		// loop through
		
		int numZeroDMT = 0;
		int numNonZeroDMT = 0;
		
		while((wnextline != null) && (wnextline.Contains ("//") == false))
		{
			numLines ++;
			getNextWeakWordGroup(wnextline);
			
			double mDMT = DMT();
			if (mDMT.Equals(0.0)) numZeroDMT++;
			else			 numNonZeroDMT++;
			
			
			weakGDMT = (double)weakGDMT + DMT();
			weakGUMT = (double)weakGUMT + UMT();
			wnextline = weakinput.ReadLine();

			if (wnextline != null)
			{
				lastLineNotNull = wnextline;
			}
		} //end of while 'wnextline != null)
		
		
		System.Diagnostics.Debug.WriteLine("UnderCalc.cs 373: weakGDMT = " + weakGDMT + ", weakGUMT =" + weakGUMT + ", numLines =" + numLines );
		System.Diagnostics.Debug.WriteLine("Undercalc.cs 374: numZeroDMT =" + numZeroDMT + ", numNonZeroDMT =" + numNonZeroDMT + " , weakGDMTBefore =" + weakGDMTBefore);
		weakinput.Close(); // closing this 28/10/2015 tom
		if(weakGDMT.Equals(0)) weakUI = 0;
		else weakUI = (double)weakGUMT/weakGDMT;
		weakCI = (double)(1 - weakUI);
		
		// }
	}// end of method "weakCalc"
	
	public static void pd_weakCalc()
	{
	
//		//initialise new buffer to read from input file
//		
//		FileStream fs1 = new FileStream(infile, FileMode.Open);
//		// HACK Tom 28/10/2015 removed 'using' as weakinput seems to be globally used (however needs closing!)
//		using (weakinput = new StreamReader(fs1))
//	
//	{
//		
//		weakinput = new StreamReader(fs1);
		
		//read in first line from file
		givenPData.resetCursor();
		
		string wnextline = givenPData.readLine();
		
		int numLines = 0;

		
		String lastLineNotNull = "unassigned";
		double weakGDMTBefore = weakGDMT;
		// loop through
		
		int numZeroDMT = 0;
		int numNonZeroDMT = 0;
		
		while((wnextline != null) && (wnextline.Contains ("//") == false))
		{
			numLines ++;
			pd_getNextWeakWordGroup(wnextline);
			
			double mDMT = DMT();
			if (mDMT.Equals(0.0)) numZeroDMT++;
			else			 numNonZeroDMT++;
			
			
			weakGDMT = (double)weakGDMT + DMT();
			weakGUMT = (double)weakGUMT + UMT();
			wnextline = givenPData.readLine();

			if (wnextline != null)
			{
				lastLineNotNull = wnextline;
			}
		} //end of while 'wnextline != null)
		
		
		System.Diagnostics.Debug.WriteLine("UnderCalc.cs 373: weakGDMT = " + weakGDMT + ", weakGUMT =" + weakGUMT + ", numLines =" + numLines );
		System.Diagnostics.Debug.WriteLine("Undercalc.cs 374: numZeroDMT =" + numZeroDMT + ", numNonZeroDMT =" + numNonZeroDMT + " , weakGDMTBefore =" + weakGDMTBefore);
//		weakinput.Close(); // closing this 28/10/2015 tom
		if(weakGDMT.Equals(0)) weakUI = 0;
		else weakUI = (double)weakGUMT/weakGDMT;
		weakCI = (double)(1 - weakUI);
		
		// }
	}// end of method "weakCalc"

	//Method call both calculation methods
	public static void calculateResults()
	{
		System.Diagnostics.Debug.WriteLine("UnderCalc.cs CalculateResults 366: infile:" + infile);
		
		//System.Diagnostics.Debug.WriteLine("calculateResults (UnderCalc.cs 366), strongCI=" + strongCI + " strongGDMT=" + strongGDMT + " strongGUMT=" + strongGUMT + " strongUI=" + strongUI);
		//System.Diagnostics.Debug.WriteLine("calculateResults (UnderCalc.cs 367), weakCI" + weakCI + " weakGDMT" + weakGDMT + " weakGUMT" + weakGUMT + " weakUI" +  weakUI);
		// calculate strong and weak indices
		strongCalc();
		weakCalc();
		
		//close buffers
		weakinput.Close();
		stronginput.Close();
		
	} 
	// end of method "calculateResults"
	
	public static void pd_calculateResults()
	{
		
		//System.Diagnostics.Debug.WriteLine("UnderCalc.cs CalculateResults 366: infile:" + infile);
		
		//System.Diagnostics.Debug.WriteLine("calculateResults (UnderCalc.cs 366), strongCI=" + strongCI + " strongGDMT=" + strongGDMT + " strongGUMT=" + strongGUMT + " strongUI=" + strongUI);
		//System.Diagnostics.Debug.WriteLine("calculateResults (UnderCalc.cs 367), weakCI" + weakCI + " weakGDMT" + weakGDMT + " weakGUMT" + weakGUMT + " weakUI" +  weakUI);
		// calculate strong and weak indices
		pd_strongCalc();
		pd_weakCalc();
		
		//close buffers
		//weakinput.Close();
		//stronginput.Close();
		
	}

	//Methods to return indices
	public double getStrongGDMT(){return strongGDMT;}
	public double getStrongGUMT(){return strongGUMT;}
	public double getStrongUI(){return strongUI;}
	public double getStrongCI(){return strongCI;}
	public double getWeakGDMT(){return weakGDMT;}
	public double getWeakGUMT(){return weakGUMT;}
	public double getWeakUI(){return weakUI;}
	public double getWeakCI(){return weakCI;}
} 
	// *** end of class "UnderCalc"
		
}

