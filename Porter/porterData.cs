/*
 * Created by SharpDevelop.
 * User: Tom
 * Date: 04/11/2015
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace WordListAnalyser2
{
	/// <summary>
	/// Toms class added 04/11/2015 - Purpose is to simulate a porter stemmer file,
	/// allowing read line/write line
	/// </summary>
	public class porterData
	{
		private List<string> data;
		/// <summary>
		/// The line the caret is on
		/// </summary>
		private int			 lineNum;
		/// <summary>
		/// The column of the caret
		/// </summary>
		private int			 caretPosition;
		public  string		 fileName;
		
		public porterData(string FileName)
		{
			data = new List<string>();
			fileName = FileName;
			lineNum = 0;
			caretPosition = 0;
		}
		
		/// <summary>
		/// Simulates Reading a line from this porterData 'file'
		/// </summary>
		/// <returns> string on "line" or null if no more data </returns>
		public string readLine()
		{
			if (lineNum < data.Count)
			{
				string line = data[lineNum];
				lineNum++;
				return line;
			}
			
			return null;
		}
		
		/// <summary>
		/// Simulates reading in a byte of data from FileInputStream (advances caret)
		/// </summary>
		/// <returns>the next byte of data, or -1 if the end of the file is reached.</returns>
		public int read()
		{
			while (lineNum < data.Count)
			{
				
				if (lineNum < data.Count)
				{
					// still within the boundaries of the file
					byte[] bytes = getBytes(data[lineNum]);
					if (caretPosition < bytes.Length)
					{
						int pos = caretPosition;
						caretPosition++; // advance caret, don't advance line
						return bytes[pos];
					}
					else
					{
						// reached end of line, go to next line
						caretPosition = 0;
						lineNum ++;
					}
					
				}
				else
				{
					// lineNum is greater than amount of lines, no more data
					return -1;
				}
			}
			return -1;
		}
		
		/// <summary>
		/// Simulates writing a line to this porterData 'file'
		/// If the string contains a /n newline will be written as two lines
		/// </summary>
		public void writeLine(string lineData)
		{
			// see steve's answer at
			// http://stackoverflow.com/questions/21514387/split-strings-into-many-strings-by-newline
			string[] lines = lineData.Split(new String[]{"\n", "\r\n"},
			                                StringSplitOptions.RemoveEmptyEntries);
			
			foreach(string line in lines)
			{
				data.Add(line);
			}
		}
		
		/// <summary>
		/// Simulates putting the cursor back to the start of the 'file'
		/// </summary>
		public void resetCursor()
		{
			lineNum = 0;
			caretPosition = 0;
		}
		
		/// <summary>
		/// Tom 04/11/2015 I needed a way to convert strings to bytes to simulate read() function of FileInputStream
		/// Using;
		/// http://stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
		/// </summary>
		static byte[] getBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
		
		/// <summary>
		/// Takes path of initial input file, writes that file to memory for operating quickly on
		/// </summary>
		/// <param name="path"> path of file</param>
		/// <returns></returns>
		public static porterData fileToMemory(string path)
		{
			DirectoryInfo info = new DirectoryInfo(path);
			string fileName = info.Name;
			
			porterData newdata = new porterData(fileName);
			
			StreamReader fileReader = new StreamReader(path);
			string line;
			
			// read in file line by line and write to memory array
			while( (line = fileReader.ReadLine()) != null)
			{
				newdata.writeLine(line);
			}
			
			return newdata;
				
		}
	}
}
