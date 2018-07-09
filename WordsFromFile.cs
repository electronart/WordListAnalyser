/*
 * Created by SharpDevelop.
 * User: User
 * Date: 9/28/2011
 * Time: 12:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of GetWordsFromFile.
	/// </summary>
	/// 
	public class GetWordsFromFile
	{
	
		   
		public GetWordsFromFile()
		{
			
		}
		
		//return it as an int
		public static int ActualWordCount;//was WordCount

		//return barrierCount
		public static int barrierCount;
		
		public static int IntWordCount
		{
		get { return ActualWordCount; }//changed from WordCount
		set { IntWordCount = value; }
		}
		
		public static int IntBarrierCount
		{
		get { return barrierCount; }
		set { IntBarrierCount = value; }
		}
	public static void ReadFile(string fileName)
		//public static string[] ReadFileToArray(string fileName)
		{
					  
			//int STRONGbarrierCount = 0;
			//int WEAKbarrierCount = 0;
			
			barrierCount = 0;
			string[] wordListArray = new string[1000];
			//if (debug)
		    //	{
			//	MessageBox.Show("debug");
		     //	MyLogger.MyLog.WriteToLog(false,true,"start reading file:",fileName,"");
		     //	} 
			
			if (File.Exists( fileName ))
	        {
	           //check file size
            	long fileSize = new FileInfo(fileName).Length;
            	//if (fileSize < 404800) 	//if file size less than 400kB (409600)
            	if (fileSize < 819200) 	//if file size less than 800kB 
               	{
		     	try
             		{
		       		StringBuilder sb = new StringBuilder();
               		string wordList = string.Empty;
               	 	using (StreamReader sr = new StreamReader(fileName))
                	{
                	string testLine;           	 
            		while ((testLine = sr.ReadLine()) != null)
                	{
               			if (testLine.Contains("//") == true) //see if it's reached the comment line
               			{
               			break;
               			}
               			else //count barriers and append all word+barriers to StringBuilder
               			{
               				if (testLine.Contains("==== end ====")){
               				   //do nothing ;                               	
               				}else {
               						if ((testLine.Contains("====")||(testLine.Contains("----")))){
               						
               					/*	if (testLine.Contains("====")){
               						     	 STRONGbarrierCount++ ; 
               						     }
               							
               						
               						
               						if (testLine.Contains("----")){
               						         WEAKbarrierCount++ ;    
               						          	
               						          }*/
               						
               						
               				    barrierCount++ ;                               	
               				}
               				}
               				
               			
               			//this will append any line of words or numbers
               			//would be better to be able to remove phrases etc
               			if (!(testLine == "")){
               				sb.AppendLine( testLine + "\r\n");	
               			}
               			
               		
				    	}
               		} //while it's not reached the end of the file
                	}//	end using
		   
               	wordList = sb.ToString();
		     
               	//MessageBox.Show(STRONGbarrierCount.ToString() + " " + WEAKbarrierCount.ToString());
		                
                //trim whitespace
                //wordList = Regex.Replace( wordList, @" ", "" );
                //Added 4 June 2012 to remove space at start and end only.
                //regex method was converting phrases to a single word.
                //word lists should now be cleaned to remove phrases.
                wordList.Trim();
		  	   
               	//put words in array
               	wordListArray = wordList.Split(new string[] { "\r\n", "\n"  }, StringSplitOptions.RemoveEmptyEntries);
               	
               	
               	ActualWordCount = wordListArray.Length - barrierCount;
               	string sActualWordCount = Convert.ToString(ActualWordCount);
               	//MessageBox.Show(sActualWordCount);
               //	WordLengthCount(wordListArray);
               //	return barrierCount;               	
               //	return wordListArray;
		    }
		     catch (Exception ex)
			{
                  MessageBox.Show(ex.Message,"The list of words file could not be read", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                  wordListArray[0] = "=NONE=";
                 // return wordListArray;
		     }
            }
              	else MessageBox.Show("File is too big", "800 kB file size maximum",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              	wordListArray[0] = "=BIG=";
              	//return wordListArray;
              	 
              	{
              	
            }//end file size check
            	  	 
           }//end if file exists
          	 //return wordListArray;

            	  
           
		}
		
		
		public static  string GetWordFromArray(string[] wordListArray, int x )
		{
		   	    
		    try {
		    	 		     	
            //do a word count (includes barriers ==== & ----)
            int WordCount = wordListArray.Length;//int places a limit on max number of words as 
					
                
            
            if (WordCount == 0) 
					{
					MessageBox.Show("Load a list of words file!", "No  words found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				
		     	//output the next word in the list including barriers
				int n = x-1;
		     	if (WordCount > n)
					{
					return wordListArray[n];
					}
				else 
					{
					return "==== end ====";
					}
           		
   
			//return "end";// stemmingRulesArray[x-1];	
		    } catch (Exception ex) {
		    	
		    	MessageBox.Show(ex.Message,"GetWordsFromFile",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		    	return "end";
		    }
          
                 
        }//end method
         
		//11 Aug 2013 changed so that it return average word length - ignoring barriers
		//public static double WordLengthCount(string[] wordListArray)
		public static void WordLengthCount(string[] wordListArray)
		{
			try {
					int one = 0, two = 0, three = 0, four = 0, five = 0, six = 0, seven = 0,
			eight = 0, nine = 0, ten = 0, eleven = 0, twelve = 0, thirteen = 0,
			forteen = 0, fifteen = 0, sixteen = 0, seventeen = 0, eighteen = 0,
			nineteen = 0, twenty = 0, twentyone = 0, twentytwo = 0, twentythree = 0,	
			twentyfour=0, twentyfive=0, twentysix=0, twentyseven = 0, twentyeight=0, twentynine=0,
			thirty=0, thirtyone=0, thirtytwo=0, thirtytwoplus = 0;
			
			foreach (string temp in wordListArray) 
			{
				int value = temp.Length; 
				
				if (value > 32) {
					value = 50;
				}
				
				switch (value)
				{
	    		case 1:
				one++;
				break;
	    		case 2:
				two++;
				break;
				case 3:
				three++;
				break;
	    		case 4:
				four++;
				break;
				case 5:
			 	five++;
				break;
	    		case 6:
				six++;
				break;
				case 7:
				seven++;
				break;
	    		case 8:
				eight++;
				break;
				case 9:
				nine++;
				break;
	    		case 10:
				ten++;
				break;
				case 11:
				eleven++;
				break;
	    		case 12:
				twelve++;
				break;
				case 13:
				thirteen++;
				break;
				case 14:
				forteen++;
				break;
	    		case 15:
				fifteen++;
				break;
				case 16:
				sixteen++;
				break;
				case 17:
				seventeen++;
				break;
				case 18:
				eighteen++;
				break;
	    		case 19:
				nineteen++;
				break;
				case 20:
				twenty++;
				break;
				case 21:
				twentyone++;
				break;
				case 22:
				twentytwo++;
				break;
				case 23:
				twentythree++;
				break;
				case 24:
				twentyfour++;
				break;
				case 25:
				twentyfive++;
				break;
				case 26:
				twentysix++;
				break;
				case 27:
				twentyseven++;
				break;
				case 28:
				twentyeight++;
				break;
				case 29:
				twentynine++;
				break;
				case 30:
				thirty++;
				break;
				case 31:
				thirtyone++;
				break;
				//break;
				case 32:
				thirtytwo++;
				break;
				case 50:
				thirtytwoplus++;
				break;
				
				
				}

			}
			
					
			int[] array1 = { one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, forteen, fifteen ,sixteen , seventeen, eighteen, nineteen, twenty, twentyone, twentytwo, twentythree,
			twentyfour, twentyfive, twentysix, twentyseven, twentyeight, twentynine, thirty, thirtyone, thirtytwo, thirtytwoplus };
			
			
			int sum1 = array1.Sum();
			
			//26 March 2012 upgraded project from .NET 2 to .NET 3.5
			//to use LINQ to easily get average word length and longest word as below
  			var strings = wordListArray; 
 			double averageLength = strings.Average(s => s.Length); 
  			string longest = strings.OrderByDescending( s => s.Length ).First();
			int lengthLong = longest.Length;
			
			
			//temporary display in messagebox
			//aim will be to output as a string that can be
			//written to log or some other file and viewed later
			MessageBox.Show("Length" + "\t" + "Count" + "\n" +
			                "1\t" + one + "\n" +
			                "2\t" + two +"\n" +
			  				 "3\t" + three +"\n" +
			  				  "4\t" + four +"\n" +
			  				   "5\t" + five +"\n" +
			  				 "6\t" + six +"\n" +
			  				  "7\t" + seven +"\n" +
			  				   "8\t" + eight +"\n" +
			  				 "9\t" + nine +"\n" +
			  				  "10\t" + ten +"\n" +
			  				  "11\t" + eleven +"\n" +
			  				   "12\t" + twelve +"\n" +
			  				 "13\t" + thirteen +"\n" +
			  				  "14\t" + forteen +"\n" +
			  				  "15\t" + fifteen +"\n" +
			  				  "16\t" + sixteen +"\n" +
			  				   "17\t" + seventeen +"\n" +
			  				 "18\t" + eighteen +"\n" +
			  				 "19\t" + nineteen + "\n" +
			 				"20\t" + twenty + "\n" + 
			 				 "21\t" + twentyone + "\n" +
			 	 			 "22\t" + twentytwo + "\n" +
			 	 			 "23\t" + twentythree + "\n" +
			 	  			"24\t" + twentyfour + "\n" +
			 	    		"25\t" + twentyfive + "\n" +
			 	 			 "26\t" + twentysix + "\n" +
			 	  			 "27\t" + twentyseven + "\n" +
			 	    		 "28\t" + twentyeight + "\n" +
			 	  			"29\t" + twentynine + "\n" +
			 	   			 "30\t" + thirty + "\n" +
			 	  			"31\t" + thirtyone + "\n" +
			 	    		"32\t" + thirtytwo + "\n" +
			 	    		"Over 32\t" + thirtytwoplus + "\n\n" +
			 	"Total (Incl. barriers) = " + sum1 + "\n" +
			 	"Barriers = " + barrierCount + "\n\n" +
			"Longest = " + longest + " (" + lengthLong + ")"  + "\n" +
			"Average Length = " + String.Format("{0:0.####}", averageLength) + "\n", "Word List analysis");
			
			//added 11 Aug 2013
			//return 	 averageLength;
				
			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message, "WordLengthCount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		
		}
		 
		//public static void ReadFileToArray(string fileName)
		public static string[] ReadFileToArray(string fileName)
		{
			
			string[] wordListArray = new string[1000];
		try
             		{
			barrierCount = 0;
			
			 string wordList = string.Empty;
			
           
           StringBuilder sb = new StringBuilder();
			
			if (File.Exists( fileName ))
	        {
	           //check file size
            	long fileSize = new FileInfo(fileName).Length;
            	//if (fileSize < 404800) 	//if file size less than 400kB (409600)
            	if (fileSize < 819200) 	//if file size less than 800kB 
               	{
		     
		       		
          			using (StreamReader datain = new StreamReader(fileName))
                	{
                	string testLine;           	 
            		while ((testLine = datain.ReadLine()) != null)
                	{
               		
               			//MessageBox.Show("testLine = " + testLine, "WordsFromFile");
               			
               			if ((!(testLine == "")) && (testLine.Contains("//") == false)) {
               				//sb.AppendLine( testLine + "\r\n");
               				sb.AppendLine( testLine ); // 25 June removed \r\n
               			}
               			
               		
               			//}
               		} //while it's not reached the end of the file
                	//}//	end using
		
		        wordList = sb.ToString();
		        wordList.Trim();
		       // MessageBox.Show(wordList, "ReadFileToArray");
		        
		        //put words in array
               wordListArray = wordList.Split(new string[] { "\r\n", "\n"  }, StringSplitOptions.RemoveEmptyEntries);
		        
		        
          			}
		        }  	else {
            		MessageBox.Show("File is too big", "800 kB file size maximum",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            		wordListArray[0] = "=BIG=";
                	return wordListArray;
            	}
		  	   
               	//put words in array
               //	wordListArray = wordList.Split(new string[] { "\r\n", "\n"  }, StringSplitOptions.RemoveEmptyEntries);
           
            	//}
			} else { 
				MessageBox.Show("The list of words file could not be read","ReadFileToArray", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                  wordListArray[0] = "=NONE=";
                  return wordListArray;
			}
			
			     return wordListArray;
			
			
             
            	
			}
            	
		     catch (Exception ex)
			{
                 MessageBox.Show(ex.Message, "ReadFileToArray", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return wordListArray;
		     } //	else 
		     
	          	  
           
		}
		
	}//end class
}//end namespace
