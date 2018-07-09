/*
 * Created by SharpDevelop.
 * User: User
 * Date: 18/05/2012
 * Time: 02:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WordListAnalyser2
{
	/// <summary>
	///Computing the Difference Between Two Strings

///If the strings that are being compared always have the same length, one 
///simple possibility is to use the character-based Hamming distance, which is 
///just the number of positions in either string where characters differ.
///For example, if s = "car" and t = "bag", the Hamming distance between s and t is two.
///If your two strings have different lengths, you can use a modified Hamming distance 
///that adds the difference in size between the longer string and the shorter string. 
///For example if s = "car" and t = "cable", the modified Hamming distance is one 
///(for the 'r' vs. 'b') + 2 (for the 'l' and 'e') = 3. 
///Here is one way to implement the Hamming distance for same-size strings:
 

	/// </summary>
	public class ClassHammingDistanceSimple
	{
				
	public static int HammingDistance(string s, string t)
	{
  	if (s.Length != t.Length)
    throw new Exception("s and t must have same length in HammingDistance()");
  	int ct = 0;
  	for (int i = 0; i < s.Length; ++i)
    if (s[i] != t[i])
      ++ct;
  return ct;
	}
	
	//modified HammingDistance
	//measure string lengths first s.length t.length
	//find difference in length
	//truncate longest word to same length as shorter
	//do the hamming distance calculation
	//add the difference in length
	//RD(x,y) = MHD(x.y)/MD (x,y)
	//MD = maximum distance = length of longest word
	//
	public static int ModifiedHammingDistance(string s, string t)
	{
		int lenDiff = 0;
	
		//if the word lengths are different make them the same length
		if (s.Length > t.Length)
			{
				lenDiff = s.Length - t.Length;
				 s = s.Substring(0, t.Length);
			
			
		} else {
			lenDiff = t.Length - s.Length;
			t = t.Substring(0, s.Length);
			
		}
			
						
			if (s.Length != t.Length)
    		throw new Exception("s and t must have same length in HammingDistance()");	
			int ct = 0;
  				for (int i = 0; i < s.Length; ++i)
    			if (s[i] != t[i])
     			 ++ct;
  				return (ct + lenDiff); //add the difference in word length 
			
		
			}
			
		public static decimal RelativeModifiedHammingDistance(string s, string t)
		{
		double lenDiff = 0;
		double	 maxDist = 0;
		//if the word lengths are different make them the same length
		if (s.Length > t.Length)
			{
				maxDist = s.Length;
				lenDiff = s.Length - t.Length;
				 s = s.Substring(0, t.Length);
			
		} else {
			maxDist = t.Length;
			lenDiff = t.Length - s.Length;
			t = t.Substring(0, s.Length);
			
		}
			
						
			if (s.Length != t.Length)
    		throw new Exception("s and t must have same length in HammingDistance()");	
			double ct = 0;
  				for (int i = 0; i < s.Length; ++i)
    			if (s[i] != t[i])
     			 ++ct;
  				double r = (ct + lenDiff)/maxDist; //add the difference in word length and divide by length of longest word
  				decimal d = (decimal)r;
  				
  				//decimal truncated = decimal.Truncate(d * 100m) / 100m; //19 Aug 2013 adjusted to return truncated to 4 decimal places
  				//return truncated;
  				
  				//19 Aug 2013 changed from truncated to rounded value
  				decimal rounded = Math.Round(d, 4);
  				return rounded;
  				

		//

			}
		
	}
	
		
}
