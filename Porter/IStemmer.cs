/*
 * Created by SharpDevelop.
 * User: Tom
 * Date: 04/11/2015
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WordListAnalyser2.Porter
{
	/// <summary>
	/// Port of Stemmer.java interface Tom 04/11/2015
	/// </summary>
	public interface IStemmer
	{
		void initialize();
		
		porterData stemFile(porterData inFile, string outfilename);
		
		
	}
}
