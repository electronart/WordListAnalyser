/*
 * Created by SharpDevelop.
 * User: tom
 * Date: 04/11/2015
 * Time: 12:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WordListAnalyser2.Porter
{
	/// <summary>
	/// Port of PorterOutput.java by Tom 04/11/2015
	/// </summary>
	public class PorterOutput
	{
		string stem, origword;
		string[] steps;
		
		public PorterOutput(String s, String o, String[] st)
		{
			stem = s;
			origword = o;
			steps = st;
		}
		
		public PorterOutput()
		{
			stem = "";
 			origword = "";
 			steps = new String[6]; 
 			for(int i = 0; i < 6; i++){steps[i] = "";}
		}
		
		public String toString()
		{
			String temp = "";
	 		int length = 0;
	 		// *** output the stem
			temp += stem;
			temp += " ";
			// *** output the original word
			temp += origword;
			temp += " ";
			// *** output each step in turn
			for(int k = 0; k < 6; k++)
			{
				temp = temp + steps[k];
				length = steps[k].Length;
				if(length > 0){temp += " ";}
			}
	 		return temp;
		}
		
		public String getStem(){return stem;}
		public String getOrigWord(){return origword;}
		public String[] getSteps(){return steps;}
		public void setStem(String s){stem = s;}
		public void setOrigWord(String o){origword = o;}
		public void setStep(int i, String st){steps[i] = st;}
	}
}
