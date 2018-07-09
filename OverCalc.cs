/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10/30/2011
 * Time: 1:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*
 * Class to calculate the GDNT, GWMT and the overstemming index
 * from the regrouped files
 * Rob Hooper
 * 07/01/2004
 */
 


// *** set package
//package Evaluation;

using System;
using System.IO;
using System.Text;
using System.Collections;
using JavaConvert.Data;
using System.Windows.Forms;
//using MyLogger;

namespace WordListAnalyser2
{
 	
public class OverCalc
{
	//static string  sifile, wifile, snifile, wnifile;//File
	static StreamReader stronginput, weakinput, strongnumberinput, weaknumberinput;//BufferedReader 
	static porterData	pd_stronginput, pd_weakinput, pd_strongnumberinput, pd_weaknumberinput;
	static ArrayList stemgroup = new ArrayList();// Vector stemgroup = new Vector();
	static ArrayList numbergroup = new ArrayList();//Vector numbergroup = new Vector();
	static int[] stemnumbergroup;
	static string currentline = "";
	static string nextline = "";
	static int samplesize = 0;
	static double 	strongGDNT, strongGWMT, strongGAMT, strongOIG, strongOIL, strongDI,
					weakGDNT, weakGWMT, weakGAMT, weakOIG, weakOIL , weakDI;
					
	public static int numStrongOILZero = 0;
	public static int numStrongOILNonZero = 0;

	// Constructor methods 
	public OverCalc(string si, string wi, string sni, string wni, int ss)
	{
	try {
		stronginput = new StreamReader(new FileStream(si, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)); //BufferedReader(new FileReader(new File(si)));
		weakinput = new StreamReader (new FileStream(wi, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));//BufferedReader(new FileReader(new File(wi)));
		strongnumberinput = new StreamReader(new FileStream(sni, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));//BufferedReader(new FileReader(new File(sni)));
		weaknumberinput = new StreamReader(new FileStream(wni, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));//BufferedReader(new FileReader(new File(wni)));
		
		
		samplesize = ss;
		strongGDNT = 0;strongGWMT = 0;strongGAMT = 0;strongOIG = 0;strongOIL = 0;strongDI = 0;
		weakGDNT = 0;  weakGWMT = 0;  weakGAMT = 0;  weakOIG = 0;  weakOIL = 0;  weakDI = 0;
		
		System.Diagnostics.Debug.WriteLine("OverCalc 60: si=" + si + "\n wi=" + wi + "\n sni=" + sni + "\n wni=" + wni + "\n ss=" + ss);
	} catch (Exception ex ) {
		
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "OverCalc");
	}
		
	} //end of constructor
	
	public OverCalc(porterData si ,porterData wi, porterData sni, porterData wni, int ss)
	{
		pd_stronginput = si;
		pd_weakinput = wi;
		pd_strongnumberinput = sni;
		pd_weaknumberinput = wni;
		
		si.resetCursor();
		wi.resetCursor();
		sni.resetCursor();
		wni.resetCursor();
		
		samplesize = ss;
		
		strongGDNT = 0;strongGWMT = 0;strongGAMT = 0;strongOIG = 0;strongOIL = 0;strongDI = 0;
		weakGDNT = 0;  weakGWMT = 0;  weakGAMT = 0;  weakOIG = 0;  weakOIL = 0;  weakDI = 0;
		
	} //end of constructor
	
	public OverCalc(){}	//end of null constructor

	// Method to retrieve the next stem group from the strong input file 
	public static void getNextStrongStemGroup()
	{
	try {
		
		string[] splitcl;
		string[] splitnl;
		string currentstem;
		string nextstem;
		//int count = 0; //not used?
		
		//obtain and split nextline
		stemgroup.Clear();
		stemgroup.Add(currentline);
	
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentstem = splitcl[1];
		nextstem = splitnl[1];
		
	
		while(currentstem.Equals(nextstem))
		{
			stemgroup.Add(nextline);//was AddElement
			currentline = nextline;
			nextline = stronginput.ReadLine();
			
			if(nextline == null) 
			{
				//stronginput.
				//MessageBox.Show("Overcalc(99): nextLine was null?");
				break;
			}
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				
				currentstem = splitcl[1];
				
				
				nextstem = splitnl[1];
					
						
			}
		}
	
		sortStemGroup();
			
			
	} catch (Exception ex) {
		
		MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextStrongStemGroup");
	}
		
	} //end of method "getNextStrongStemGroup"
	
	public static void pd_getNextStrongStemGroup()
	{
	try {
		
		string[] splitcl;
		string[] splitnl;
		string currentstem;
		string nextstem;
		//int count = 0; //not used?
		
		//obtain and split nextline
		stemgroup.Clear();
		stemgroup.Add(currentline);
		
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentstem = splitcl[1];
		nextstem = splitnl[1];
		
		//add elements matching stem

		while(currentstem.Equals(nextstem))
		{
			stemgroup.Add(nextline);//was AddElement
			currentline = nextline;
			nextline = pd_stronginput.readLine();
		
			if(nextline == null) 
			{
				//stronginput.
				//MessageBox.Show("Overcalc(99): nextLine was null?");
				break;
			}
			else
			{
				
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				
				currentstem = splitcl[1];
				
				
				nextstem = splitnl[1];
					
				
			
			}
		}
		
		//end of while 'currentstem.equals ...'
		
		sortStemGroup();
			
			
	} catch (Exception ex) {
		
		MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextStrongStemGroup");
	}
		
	} //end of method "getNextStrongStemGroup"

	
	
	
	//Method to retrieve the next stem group from the weak input file   *****
	public static void getNextWeakStemGroup() 	{
	try {
		
		string[] splitcl, splitnl;
		string currentstem, nextstem;
		//obtain and split nextline
		stemgroup.Clear();
		stemgroup.Add(currentline);
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentstem = splitcl[1];
		nextstem = splitnl[1];
		//add elements to group while equal to stem
		while(currentstem.Equals(nextstem))
		{
			stemgroup.Add(nextline);
			currentline = nextline;
			nextline = weakinput.ReadLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentstem = splitcl[1];
				nextstem = splitnl[1];
			}
		} //end of while 'currentstem.equals ...'		
		sortStemGroup();
			
	} catch (Exception ex) {
		
		MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextWeakStemGroup");
	}
		
	} //end of method "getNextWeakStemGroup"
	
	public static void pd_getNextWeakStemGroup() 	{
	try {
		
		string[] splitcl, splitnl;
		string currentstem, nextstem;
		//obtain and split nextline
		stemgroup.Clear();
		stemgroup.Add(currentline);
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentstem = splitcl[1];
		nextstem = splitnl[1];
		//add elements to group while equal to stem
		while(currentstem.Equals(nextstem))
		{
			stemgroup.Add(nextline);
			currentline = nextline;
			nextline = pd_weakinput.readLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentstem = splitcl[1];
				nextstem = splitnl[1];
			}
		} //end of while 'currentstem.equals ...'		
		sortStemGroup();
			
	} catch (Exception ex) {
		
		MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextWeakStemGroup");
	}
		
	} //end of method "getNextWeakStemGroup"

	//Method to retrieve the next number group from the weak input file   *****
	public static void getNextWeakNumberGroup() 
	{
		try {
			
		string[] splitcl, splitnl;
		int currentno, nextno;
		//clear group and split next line
		numbergroup.Clear();
		numbergroup.Add(currentline);
		splitcl = currentline.Split(' ');//was ("\\s")
		splitnl = nextline.Split(' ');
		currentno = Convert.ToInt32(splitcl[0]);
		nextno = Convert.ToInt32(splitnl[0]);
		//whilst group numbers match add element
		while(currentno == nextno)
		{
			numbergroup.Add(nextline);
			currentline = nextline;
			nextline = weaknumberinput.ReadLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentno = Convert.ToInt32(splitcl[0]);//Integer.ParseInt(splitcl[0]);
				nextno = Convert.ToInt32(splitnl[0]); 
			}
		} // end of while 'currentno == nextno'
			
			
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextWeakNumberGroup");
		}
			
	} //end of method 'getNextWeakNumberGroup'
	
	public static void pd_getNextWeakNumberGroup() 
	{
		try {
			
		string[] splitcl, splitnl;
		int currentno, nextno;
		//clear group and split next line
		numbergroup.Clear();
		numbergroup.Add(currentline);
		splitcl = currentline.Split(' ');//was ("\\s")
		splitnl = nextline.Split(' ');
		currentno = Convert.ToInt32(splitcl[0]);
		nextno = Convert.ToInt32(splitnl[0]);
		//whilst group numbers match add element
		while(currentno == nextno)
		{
			numbergroup.Add(nextline);
			currentline = nextline;
			nextline = pd_weaknumberinput.readLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentno = Convert.ToInt32(splitcl[0]);//Integer.ParseInt(splitcl[0]);
				nextno = Convert.ToInt32(splitnl[0]); 
			}
		} // end of while 'currentno == nextno'
			
			
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextWeakNumberGroup");
		}
			
	} //end of method 'getNextWeakNumberGroup'

	//Method to retrieve the next number group from the strong input file   *****
	public static void getNextStrongNumberGroup() 
	{
	try {
		
		string[] splitcl, splitnl;
		int currentno, nextno;
		//clear current group and split next line
		numbergroup.Clear();
		numbergroup.Add(currentline);
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentno = Convert.ToInt32(splitcl[0]);
		nextno = Convert.ToInt32(splitnl[0]); //was 0
		//while group numbers match, add element
		while(currentno == nextno)
		{
			numbergroup.Add(nextline);
			currentline = nextline;
			
			nextline = strongnumberinput.ReadLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentno = Convert.ToInt32(splitcl[0]);
				nextno = Convert.ToInt32(splitnl[0]); // was 0
			}
		} //end of while 'currentno == nextno'		
			
			
			
			
	} catch (Exception ex) {
		
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextStrongNumberGroup");
	}
		
	} //end of method 'getNextStrongNumberGroup'
	
	public static void pd_getNextStrongNumberGroup() 
	{
	try {
		
		string[] splitcl, splitnl;
		int currentno, nextno;
		//clear current group and split next line
		numbergroup.Clear();
		numbergroup.Add(currentline);
		splitcl = currentline.Split(' ');
		splitnl = nextline.Split(' ');
		currentno = Convert.ToInt32(splitcl[0]);
		nextno = Convert.ToInt32(splitnl[0]); //was 0
		//while group numbers match, add element
		while(currentno == nextno)
		{
			numbergroup.Add(nextline);
			currentline = nextline;
			
			nextline = pd_strongnumberinput.readLine();
			if(nextline == null) break;
			else
			{
				splitcl = currentline.Split(' ');
				splitnl = nextline.Split(' ');
				currentno = Convert.ToInt32(splitcl[0]);
				nextno = Convert.ToInt32(splitnl[0]); // was 0
			}
		} //end of while 'currentno == nextno'		
			
			
			
			
	} catch (Exception ex) {
		
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getNextStrongNumberGroup");
	}
		
	} //end of method 'getNextStrongNumberGroup'

	//Method to take a stem group and sort it with bubble sort   *****
	public static void sortStemGroup() 
	{
	try {
		
		string str1, str2;
		StringTokenizer st1, st2;
		int no1;
		int no2; //was set to 0
		//set loop variables
		bool change = true;
		int stemgroupsize = stemgroup.Count;
		
		//while changes are still being made sort group
		while(change)
		{
			//reset change boolean
			change = false;
			
			//check adjacent pairs and swap if necessary
			for(int x = 0; x+1 < stemgroupsize; x++)
			{
				str1 = (string)stemgroup[x];//.ElementAt(x);
				str2 = (string)stemgroup[x+1];//.ElementAt(x+1);
			
				st1 = new StringTokenizer(str1);
				st2 = new StringTokenizer(str2);
				
				no1 = Convert.ToInt32(st1.NextToken);
				no2 = Convert.ToInt32(st2.NextToken);//Added 9 July 2013
				if(no1 > no2)
				{
					// HACK Tom 03/11/2015 Replacing
					// .Insert with a replace operation as Java was replacing not adding
					
					stemgroup[x+1] = str1;
					stemgroup[x]  = str2;
					
					//stemgroup.Insert(x+1,str1);//.setElementAt(str1, x+1);
					//stemgroup.Insert(x, str2);//setElementAt(str2, x);
					change = true;
				}
			}
		} //end of while 'change'	
			
			//MessageBox.Show("sort complete", "sortStemGroup");
			
	} catch (Exception ex ) {
		
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "sortStemGroup");
	}
		
	} //end of method 'sortStemGroup'

	//Method to retrieve the next number group from a sorted stem group   *****
	public static void getStemNumberGroup() //getNextStemNumberGroup' ??
	{
		try {
		//method variables
		string str1;
		StringTokenizer st1;
		//set variables
		int stemgrouplength = stemgroup.Count;
		stemnumbergroup	= new int[stemgrouplength];
		//retrieve the assigned number for stem group
		for(int i = 0; i < stemgrouplength; i++) //25 June 2013 i was initially 0
		{
			str1 = (string)stemgroup[i];//.ElementAt(i);
			st1 = new StringTokenizer(str1);
			stemnumbergroup[i] = Convert.ToInt32(st1.NextToken);
			//MessageBox.Show("StemNumberGroup = " + 	stemnumbergroup[i].ToString());
		}
			
			
		} catch (Exception ex ) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "getStemNumberGroup");
		}
		
				
	} //end of method 'getNextStemNumberGroup'

	//Method to calculate the 'wrongly-merged total' for a stem group
	public static double WMT() 
	{
		
		try {
			
		double wmt = 0;
		int no1, no2;
		int Ns = stemgroup.Count;
		int nsi = 1;
		//obtain number group and perform calculations
		getStemNumberGroup();	
		
		for(int i = 0; i < Ns-1; i++)
		{
			no1 = stemnumbergroup[i];
			no2 = stemnumbergroup[i+1];
			if(no1 == no2){
				nsi++;
				//MessageBox.Show("nsi = " + nsi.ToString(), "WMT() - no1 = no2");
			} else
			{
				wmt = (double)(wmt + (double)(0.5*nsi*(Ns-nsi)));
				//MessageBox.Show("wmt in loop = " + wmt.ToString(), "WMT()");
				nsi = 1;
			}
		}		
			//MessageBox.Show("WMT 348, nsi = " + nsi + " , Ns = " + Ns + " , wmt = " + wmt);
			wmt = (double)(wmt + (double)(0.5*nsi*(Ns-nsi)));	

			//MessageBox.Show("wmt = " + wmt.ToString(), "WMT()");
			//MessageBox.Show("WMT 352, wmt = " + wmt);
				return wmt;
			
			
			
		} catch (Exception ex ) {
			
			
				MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "WMT");
				
				return 0;
				
		}
			
			
	} //end of method 'WMT'

	//Method to calculate the "desired non-merge total" for a number group   *****
	public static double DNT()
	{
		try {
					
		//set variables and calculate
		double dnt = 0;
		int Ng = numbergroup.Count;
		dnt = (double)(Ng * (samplesize - Ng));
		dnt = (double)0.5 * dnt;
		return dnt;
			
			
		} catch (Exception ex ) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "DNT()");
			return 0;
		}
	
	} //end of method 'DNT'

	//Method to calculate the "actual merge total" for a stem group 
	public static double AMT()
	{
		try {
			
		//set variables and calculate
		double amt = 0.00;
		int Ns = stemgroup.Count;
		
		//MessageBox.Show("Ns = " + Ns, "AMT()");
		
		amt = (double)((0.5) * Ns);
		amt = (double)(amt * (Ns - 1));
		
		//MessageBox.Show("amt = " + amt, "AMT()");
		
		return amt;
			
		
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "AMT");
			return 0;
		}
	
	} //end of method 'AMT'

	//Method to calculate the indices for strong values
	public static void strongCalc() 
	{
		try {
			
			//read lines from buffers
		currentline = stronginput.ReadLine();
		nextline = stronginput.ReadLine();
		
		//calculate stemgroup based metrics
		// 21/10/2015.. counting loop iterations for debug purposes
		int tomsCount = 0;
		while(nextline != null)
		{
			//MessageBox.Show("OverCalc 430, currentline :" + currentline);
			getNextStrongStemGroup();
			strongGAMT = (double)strongGAMT + AMT();
			strongGWMT = (double)strongGWMT + WMT();
			currentline = nextline;
			nextline = stronginput.ReadLine();
			tomsCount++;
		} //end of while 'nextline != null'
		
		// Tom 21/10/2015 messagebox to say we exited this
		//MessageBox.Show("Overcalc exited first while-loop in strongCalc (439) \n \n tomsCount = " + tomsCount);
		
		//calculate numbergroup based metrics
		currentline = strongnumberinput.ReadLine();
		//MessageBox.Show("currentline = " + currentline, "strongCalc");
		nextline = strongnumberinput.ReadLine();
		while(nextline != null)
		{
			
			getNextStrongNumberGroup();
			strongGDNT = (double)strongGDNT + DNT();
			currentline = nextline;
			nextline = strongnumberinput.ReadLine();
		} //end of while 'nextline != null'
		//MessageBox.Show("OverCalc 452, lastLine :" + currentline);
		//MessageBox.Show("OverCalc exited second while-loop in strongCalc (453)");
		//calculate combined metrics
		
		// HACK Tom 21/10/2015 - There is a warning from the compiler on the commented out comparison logic
		// about the numbers having different precisions
		// using a workaround by comparing with .equals and .000000000000 
		//if(strongGDNT == 0.0) strongOIG = 0.0;#
		
		
		
		//MessageBox.Show("strong GDNT" + strongGDNT);
		//MessageBox.Show("strong GWMT" + strongGWMT);
		
		//MessageBox.Show("strong GAMT" + strongGAMT);
		
		
		if (strongGDNT.Equals(0.0000000000000)) strongOIG = 0.0;
		else strongOIG = strongGWMT / strongGDNT;
		
		//if(strongGAMT == 0.0) strongOIL = 0.0;
		if (strongGAMT.Equals(0.0000000000000)) {strongOIL = 0.0; numStrongOILZero++;}
		else {strongOIL = (double)strongGWMT / strongGAMT; numStrongOILNonZero++;
			System.Diagnostics.Debug.WriteLine("OverCalc 498: strongOIL:" + strongOIL);}
		strongDI = (double)1 - strongOIL;
			
			
			
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "strongCalc");
		}
		
		
	} // end of method 'strongCalc'
	
	public static void pd_strongCalc() 
	{
		try {
			
			//read lines from buffers
		currentline = pd_stronginput.readLine();
		nextline = pd_stronginput.readLine();
		
		//calculate stemgroup based metrics
		// 21/10/2015.. counting loop iterations for debug purposes
		int tomsCount = 0;
		while(nextline != null)
		{
			//MessageBox.Show("OverCalc 430, currentline :" + currentline);
			pd_getNextStrongStemGroup();
			strongGAMT = (double)strongGAMT + AMT();
			strongGWMT = (double)strongGWMT + WMT();
			currentline = nextline;
			nextline = pd_stronginput.readLine();
			tomsCount++;
		} //end of while 'nextline != null'
		
		// Tom 21/10/2015 messagebox to say we exited this
		//MessageBox.Show("Overcalc exited first while-loop in strongCalc (439) \n \n tomsCount = " + tomsCount);
		
		//calculate numbergroup based metrics
		currentline = pd_strongnumberinput.readLine();
		//MessageBox.Show("currentline = " + currentline, "strongCalc");
		nextline = pd_strongnumberinput.readLine();
		while(nextline != null)
		{
			
			pd_getNextStrongNumberGroup();
			strongGDNT = (double)strongGDNT + DNT();
			currentline = nextline;
			nextline = pd_strongnumberinput.readLine();
		} //end of while 'nextline != null'
		//MessageBox.Show("OverCalc 452, lastLine :" + currentline);
		//MessageBox.Show("OverCalc exited second while-loop in strongCalc (453)");
		//calculate combined metrics
		
		// HACK Tom 21/10/2015 - There is a warning from the compiler on the commented out comparison logic
		// about the numbers having different precisions
		// using a workaround by comparing with .equals and .000000000000 
		//if(strongGDNT == 0.0) strongOIG = 0.0;#
		
		
		
		//MessageBox.Show("strong GDNT" + strongGDNT);
		//MessageBox.Show("strong GWMT" + strongGWMT);
		
		//MessageBox.Show("strong GAMT" + strongGAMT);
		
		
		if (strongGDNT.Equals(0.0000000000000)) strongOIG = 0.0;
		else strongOIG = strongGWMT / strongGDNT;
		
		//if(strongGAMT == 0.0) strongOIL = 0.0;
		if (strongGAMT.Equals(0.0000000000000)) {strongOIL = 0.0; numStrongOILZero++;}
		else {strongOIL = (double)strongGWMT / strongGAMT; numStrongOILNonZero++;
			System.Diagnostics.Debug.WriteLine("OverCalc 498: strongOIL:" + strongOIL);}
		strongDI = (double)1 - strongOIL;
			
			
			
			
		} catch (Exception ex) {
			
			MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "strongCalc");
		}
		
		
	} // end of method 'strongCalc'

	//Method to calculate the indices for weak values
	public static void weakCalc() 
	{
		//read lines from buffers
		currentline = weakinput.ReadLine();
		nextline = weakinput.ReadLine();
		
		//calculate stemgroup based metrics
		while(nextline != null)
		{
			getNextWeakStemGroup();
			weakGAMT = weakGAMT + AMT();
			weakGWMT = weakGWMT + WMT();
			currentline = nextline;
			nextline = weakinput.ReadLine();
		} //end of while 'nextline != null'
		
		//calculate numbergroup based metrics
		currentline = weaknumberinput.ReadLine();
		nextline = weaknumberinput.ReadLine();
		while(nextline != null && currentline != null)
		{
			getNextWeakNumberGroup();
			weakGDNT = weakGDNT + DNT();
			currentline = nextline;
			nextline = weaknumberinput.ReadLine();
		} // *** end of while 'nextline != null'
		
		// *** calculate combined metrics
		if(weakGDNT == 0.0) weakOIG = 0.0;
		else weakOIG = weakGWMT / weakGDNT;
		
		if(weakGAMT == 0.0) weakOIL = 0.0;
		else weakOIL = weakGWMT / weakGAMT;
		weakDI = 1 - weakOIL;
		
	} // end of method 'weakCalc'
	
	public static void pd_weakCalc() 
	{
		//read lines from buffers
		currentline = pd_weakinput.readLine();
		nextline = pd_weakinput.readLine();
		
		//calculate stemgroup based metrics
		while(nextline != null)
		{
			pd_getNextWeakStemGroup();
			weakGAMT = weakGAMT + AMT();
			weakGWMT = weakGWMT + WMT();
			currentline = nextline;
			nextline = pd_weakinput.readLine();
		} //end of while 'nextline != null'
		
		//calculate numbergroup based metrics
		currentline = pd_weaknumberinput.readLine();
		nextline = pd_weaknumberinput.readLine();
		while(nextline != null && currentline != null)
		{
			pd_getNextWeakNumberGroup();
			weakGDNT = weakGDNT + DNT();
			currentline = nextline;
			nextline = pd_weaknumberinput.readLine();
		} // *** end of while 'nextline != null'
		
		// *** calculate combined metrics
		if(weakGDNT == 0.0) weakOIG = 0.0;
		else weakOIG = weakGWMT / weakGDNT;
		
		if(weakGAMT == 0.0) weakOIL = 0.0;
		else weakOIL = weakGWMT / weakGAMT;
		weakDI = 1 - weakOIL;
		
	} // end of method 'weakCalc'

	//Method to call both calulation methods
	public static void calculateResults() 	{
		strongCalc();
		weakCalc();
		stronginput.Close();
		weakinput.Close();
		strongnumberinput.Close();
		weaknumberinput.Close();
	} //end of method 'calculateResults'
	
	public static void pd_calculateResults() {
		
		pd_strongCalc();
		pd_weakCalc();
	}

	//Methods to return indices
	public double getStrongGDNT(){return strongGDNT;}
	public double getStrongGWMT(){return strongGWMT;}
	public double getStrongGAMT(){return strongGAMT;}
	public double getStrongOIG(){return strongOIG;}
	public double getStrongOIL(){return strongOIL;}
	public double getStrongDI(){return strongDI;}
	public double getWeakGDNT(){return weakGDNT;}
	public double getWeakGWMT(){return weakGWMT;}
	public double getWeakGAMT(){return weakGAMT;}
	public double getWeakOIG(){return weakOIG;}
	public double getWeakOIL(){return weakOIL;}
	public double getWeakDI(){return weakDI;}
} // *** end of class 'OverCalc'

 }