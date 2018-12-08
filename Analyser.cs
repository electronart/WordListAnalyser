/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/10/2011
 * Time: 02:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
//using MyReaderNS;
//using StemmingTester;

namespace WordListAnalyser2
{
    /// <summary>
    /// Based on code in SwingInterface.java in Program.zip
    /// from Lancs University R.Hood 2004.
    /// </summary>
    public class Analyser
	{
	 
	private double[] weakUIarray = new double[7];
	private double[] weakOILarray = new double[7];
	private double[] strongUIarray = new double[7];
	private double[] strongOILarray = new double[7];
	//private string[] currentfilesItems, currentgroupItems;//NOT USED ???
	private ArrayList groupinginput = new ArrayList();
	private ArrayList groupingoutput = new ArrayList();
	//private string logfilename, sortedfilename, currentword, nextwordstr; //Not Used ??
 	//private int noofpasses, samplesize;
	static int samplesize = 0;
	
		public static int SampleSize
		{
		get { return samplesize; }
		set { samplesize = value; }
		}

		
	//private UnderCalc undercalc;
	//private OverCalc overcalc;
	//private Regroup regroup;
	//private AssignNumber assignnumber;
	//private Truncator truncator;
	//private ERRT errt;
		
		
		
		public void analyser(string stemmedFileName, string wordList)
		{
					
		string startPath = Application.StartupPath;//currentdir.getText();
		string wordListFileName = Path.GetFileName(wordList) ;// selectedfile.getText();
		
	
   //==================== 4 =========================
   //perform understemming calculations on stemmedFile.txt
			
		//try {
			///UnderCalc uc = new UnderCalc(stemmedFileName);
		
			//UnderCalc.calculateResults();
			
			//UnderCalcLog(uc);
	
			//added 25 June 2013
    		//CreateFiles(startPath, wordListFileName, stemmedFileName);
   		//} catch (Exception e) {
			
		//MessageBox.Show("Error: " + e.Message, "4 - Error in understemming calculations");
		}	
			
	
			
		//update progress 
       		//this.listBox1.Items.Add("4 - Performing understemming calculations...");
       		
      //Added 25 June 2013
     public void analyser(){}	//end of null constructor
       	
 //================= end 4 ====================      
	  //====================== 5====================== 
    //number each stem to associate it with a group   
    public static void CreateFiles(string startPath, string wordListFilePathName, string stemmedFilePathName ){
    	
       string wordListFileName = Path.GetFileName(wordListFilePathName);
       string stemmedFileName = Path.GetFileName(stemmedFilePathName);
       
       AssignNumber assignnumber = new AssignNumber(stemmedFilePathName);
              	
       //weak barriers are ignored
      	try{ AssignNumber.weakAssignNumber(startPath + "\\WeakNumbered" + wordListFileName);//WeakNumbered" + str2 + ".txt");
       	}
     	catch(Exception e){ MessageBox.Show("Error: " + e, "5 - Error when performing weak numbering"); return;}
			
		//when weak barriers are treated as strong
      	try{ 	
			//MessageBox.Show("Calling strongAssignNumber", "Analyser - Step 5");
			AssignNumber.strongAssignNumber(startPath + "\\StrongNumbered" + wordListFileName);}
      	catch(Exception e){ MessageBox.Show("Error: " + e, "5 - Error when performing strong numbering"); return;}
       	
      	samplesize = AssignNumber.getSampleSize();
      	//==================== end 5 ==================
      	
      	//=================== 6 =======================
	
        //sort numbered file where weak barriers were ignored by stem
        Regroup rg = new Regroup(startPath + "\\WeakNumbered" + wordListFileName);
        try{ rg.regroupfile(startPath + "\\WeakRegrouped" + wordListFileName); }
        catch(Exception e){ MessageBox.Show("Error: " + e + "  " + startPath + "\\WeakNumbered" + wordListFileName, "6a - Error when sorting stemmed file  " ); return;}
		
        
		//sort numbered file where weak barriers are strong by stem
        Regroup rg2 = new Regroup(startPath + "\\StrongNumbered" + wordListFileName);
        try{ rg2.regroupfile(startPath + "\\StrongRegrouped" + wordListFileName); }
        catch(Exception e){ MessageBox.Show("Error: " + e, "6b - Error when sorting stemmed file"); return;}
       	//=================end 6 ===================	
 
 //=================== 7 ========================
 //perform overstemming calcs on newly sorted file
 
 try {
 	//MessageBox.Show("samplesize = " + samplesize, "Analyser-7");
 //	OverCalc oc = new OverCalc(startPath + "\\StrongRegrouped" + wordListFileName, startPath + "\\WeakRegrouped" + wordListFileName, startPath + "\\StrongNumbered" + wordListFileName, startPath + "\\WeakNumbered" + wordListFileName, samplesize);
 	//OverCalc.calculateResults();
 	
 //	double strongOI = oc.getStrongOIG();
 //	MessageBox.Show("Over Stemming Index = " + String.Format("{0:0.###}", strongOI.ToString("N3")));
	//MainForm.labelOI.Text = "Over Stemming Index = " + String.Format("{0:0.###}", strongOI.ToString("N3")); 
 	
 	
 	//OverCalcToLog(oc);
 } catch (Exception e) {
 	
 		MessageBox.Show("Error: " + e, "7 - Error in overstemming calculator");
 }
   //update progress
   //  this.listBox1.Items.Add("7 - Performing Overstemming Calculations...");
//try {
     	//OverCalc.calculateResults();
//} catch (Exception e) {
	
//	MessageBox.Show("Error: " + e, "7 - Error when  performing overstemming calculations");
//}

 
//=================== 8 =========================        
		//place stemming UI and OI(L) values into arrays for ERRT calculations
		 //update progress
   //  this.listBox1.Items.Add("8 - Place Stemming UI & OI(L) values into arrays for ERRT calcs...");
		
		ArrayList weakUIarray = new ArrayList();
		ArrayList weakOILarray = new ArrayList();
		ArrayList strongUIarray = new ArrayList();
		ArrayList strongOILarray = new ArrayList();
		//TODO Display both sets of UI, OI(G), and OI(L)
		
		
//================== end 8 ====================	
		
	//===================== 9 ===========================		
			//update progress
    	//	this.listBox1.Items.Add("9 - Performing Truncation...");
    		//================================ Version 1.0 no truncation for ERRT ==================
    		//24 June 2013 remove for loop this version - ends at line 328
			//for (int i=3; i<9; i++)
			//int i=3; 
			//{
				
			//try {
		//	Truncator truncator = new Truncator(wordList);
		//	} catch (Exception e) {
				
		//		MessageBox.Show("9 - Error: " + e, "Error creating truncation instance");
		//	}
    				
    	//	try {
    	//		Truncator.truncate(startPath + "\\truncated" + i + wordListFileName, i);
    	//	} catch (Exception e) {
    		//	
    		//	MessageBox.Show("9 - Error: " + e, "Error when truncating file");
    	//	}
   		
			
		 //==================end 9 ===================	
//======================10====================
//perform understemming calculations on stemmed file
		//UnderCalc undercalc = new UnderCalc(startPath + "\\truncated" + i + wordListFileName);
//} catch (Exception e) 
	
	//MessageBox.Show("Error: " + e, "10 - Error initialising understemming calculator");
	//return;
	//}
 	//update progress
   // this.listBox1.Items.Add("10 - Perform Understemming Calculations " + i);     
    //try {
    	//UnderCalc.calculateResults();
   // } catch (Exception e) {
    	
    	//MessageBox.Show("Error: " + e, "10 - Error performing understemming calculations: " + i);
    //return;
   // }
    	//List<Process> list = StemmingTester.Win32Processes.GetProcessesLockingFile("truncated3GroupedWordList.txt");
     	//	foreach (var element in list) {
     	//		Console.WriteLine(element);
     	
     	//	}
    //UnderCalcLog(undercalc);
//}//temp
			
		//======================11===================
		//number each stem to associate it with a word
		
			//17 June 2013
		//string wordListNameNoExt = Path.GetFileNameWithoutExtension(wordList);
		//wordList = Path.GetFileNameWithoutExtension(wordList);
		//24 June 2013 - renamed
		//wordList = Path.GetFileNameWithoutExtension(wordList);
		//wordList = wordListPath ;
		//+ "\\" + wordListNameNoExt;
		
		stemmedFileName = Path.GetFileName(stemmedFileName);
		//MessageBox.Show(wordListPath , "wordList part 11");
		//try {
			//assignnumber = new AssignNumber(startPath + "\\truncated" + i + wordListFileName);
			//assignnumber = new AssignNumber(startPath + "\\truncated" + i + wordList);
			//assignnumber = new AssignNumber(wordListPath + "\\truncated" + i + stemmedFileName);
			
		//} catch (Exception e) {
			
		//	MessageBox.Show("11 - Error: " + e, "Error creating new Regroup instance");
		//}
			//update progress
   //this.listBox1.Items.Add("11 - Numbering file...");     
		
   
   
   
		//when weak barriers are ignored
		//try {
		//	AssignNumber.weakAssignNumber(startPath + "\\WeakNumberedT" + i + stemmedFileName);
			//AssignNumber.weakAssignNumber(wordList + "\\WeakNumberedT" + i + stemmedFileName);
			
	//	} catch (Exception e ) {
			
			//MessageBox.Show("11 - Error: " + e, "Error performing weak Regroup");
		//}
		//weak barriers treated as strong
		//try {
			//MessageBox.Show("Calling strongAssignNumber", "frm_Analyser");
			//AssignNumber.strongAssignNumber(startPath + "\\StrongNumberedT" + i + stemmedFileName);
		//} catch (Exception e) {
			
		//	MessageBox.Show("11 - Error: " + e, "Error performing strong Regroup");
		//}
		
		samplesize = AssignNumber.getSampleSize();
		//===========end 11===================
		
		//=============12=======================
		//sort the numbered file where weak barriers were ignored by stem
		
	
		
		//Regroup regroup = new Regroup(startPath + "\\WeakNumberedT" + i + stemmedFileName);
		//update progress
    	//this.listBox1.Items.Add("12 - Sorting Files");  
   // try {
   //		regroup.regroupfile(startPath + "\\WeakRegroupedT" + i + stemmedFileName);
   // } catch (Exception e) {
 //   	
   	//MessageBox.Show("Error: " + e, "12a - Error when sorting stemmed file");
    //}
	//sort the numbered file where weak barriers are strong by stem
	//regroup = new Regroup(startPath + "\\StrongNumberedT" + i + stemmedFileName);
		//try {
		//regroup.regroupfile(startPath + "\\StrongRegroupedT" + i + stemmedFileName);
		//} catch (Exception e) {
			
			//MessageBox.Show("Error: " + e, "12b - Error when sorting stemmed file");
		//return;
	//}
	
		//============end 12==================
		
		
       	//17 June replace str1 str2 with wordList, stemmedFileName
			//==================13 =======================
				//perform over stemming calculations on the newly sorted file
    	   	//	OverCalc overcalc = new OverCalc(startPath + "\\StrongRegroupedT" + i + stemmedFileName, 
    	   		//	startPath + "\\WeakRegroupedT" + i + stemmedFileName, 
    	   		//	startPath + "\\StrongNumberedT" + i + stemmedFileName,
    	   		//	startPath + "\\WeakNumberedT" + i + stemmedFileName, samplesize);
       			//catch(Exception e){	MessageBox.Show("13 - Error: " + e, "Error when initialising overrstemming calculations"); return;
				
       			//update progress
       		//	this.listBox1.Items.Add("13 - Performing Overstemming Calculations " + i);
       			
       		//	try{ OverCalc.calculateResults(); }//TODO why overcalc no go
       		//	catch(Exception e){MessageBox.Show("13 - Error: " + e, "Error when performing overstemming calculations"); return;}
       		
       
       			
       			//==================== 14 =========================
       			//retrieve UI/OI values
       			try {
       			//weakUIarray[i-2] = undercalc.getWeakUI();
	       	//	weakOILarray[i-2] = overcalc.getWeakOIL();
	       		//strongUIarray[i-2] = undercalc.getStrongUI();
	       	//	strongOILarray[i-2] = overcalc.getStrongOIL();
       			
	       				
       				//update progress
    				//this.listBox1.Items.Add("14 - retrieve UI/OI values"); 
    	
       			} catch (Exception e) {
       				
       				MessageBox.Show("Error: " + e, "14 - Error when retrieving UI/OI values");
       			}
       			
		//}//end for
  //===============end 14=== and end for loop ========

					
//=============15 ==========================
		//perform ERRT calculations
		//has input of 4 arrays from block 14
		//try {
		
		//17 June 2013  TODO arrayList are input to ERRT but it expects double[]
		
		//ERRT errt = new ERRT(weakUIarray, weakOILarray, strongUIarray, strongOILarray);
		//} catch (Exception e) {
			
		//MessageBox.Show("Error: " + e, "Error when performing initialising ERRT calculator");
		//}
		
		//try //{
			//errt.CalculateResults();
		//} catch (Exception e) {
			
		//	MessageBox.Show("Error: " + e, "Error when performing ERRT calculations");
		//}
			
		//TODO Append ERRT results to display
		//DecimalFormat perCent = new de
		
			//ERRTToLog();
//==============end 15================


//now log results ======================
			


				
     	
   	//weakUIarray.Insert(0, uc.getWeakUI());
		//weakOILarray.Insert(0, oc.getWeakOIL());
		//strongUIarray.Insert(0, uc.getStrongUI());
		//strongOILarray.Insert(0, oc.getStrongOIL());
		
		}
 //======================16================================
//Log undercalc results
	private void UnderCalcLog(UnderCalc uc)
	{
	//UnderCalc uc = new UnderCalc();

			double wUI = uc.getWeakUI();
			double wGUMT = uc.getWeakGUMT();
			double wGDMT = uc.getWeakGDMT();
			double wCI = uc.getWeakCI();
			double sUI = uc.getStrongUI();
			double sGUMT = uc.getStrongGUMT();
			double sGDMT = uc.getStrongGDMT();
			double sCI = uc.getStrongCI();
			
			//MyLogger.MyLog.WriteToLog(false,false,"","\nUnderCalc Results for dtSearch Stemmer\n","");
			
			string strWUI = wUI.ToString("0.000");
			//MyLogger.MyLog.WriteToLog(false,false,"wUI= ",strWUI,"");
			
			string strWGUMT = wGUMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"wGUMT= ",strWGUMT,"");
			
			string strWGDMT = wGDMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"wGDMT= ",strWGDMT,"");
			
			string strWCI = wCI.ToString("0.000");
			//MyLogger.MyLog.WriteToLog(false,false,"wCI= ",strWCI,"");
			
			string strSUI = sUI.ToString("0.000");
			//MyLogger.MyLog.WriteToLog(false,false,"sUI= ",strSUI,"");
			
			string strSGUMT = sGUMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"sGUMT= ",strSGUMT,"");
			
			string strSGDMT = sGDMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"sGDMT= ",strSGDMT,"");
			
			string strSCI = sCI.ToString("0.000");
			//MyLogger.MyLog.WriteToLog(false,false,"sCI= ",strSCI,"");
				
	
		}
		
		
		
		//======================17========================
	//Log Overstemming results
	private void OverCalcToLog(OverCalc oc)
	{
				
			//oc = new OverCalc();
		//Over stemming metrics
			double strongGDNT = oc.getStrongGDNT();
			double strongGWMT = oc.getStrongGWMT();
			double strongGAMT = oc.getStrongGAMT();
			double strongOIG = oc.getStrongOIG();
			double strongOIL = oc.getStrongOIL();
			double strongDI = oc.getStrongDI();
			double weakGDNT = oc.getWeakGDNT();
			double weakGWMT = oc.getWeakGWMT();
			double weakGAMT = oc.getWeakGAMT();
			double weakOIG = oc.getWeakOIG();
			double weakOIL = oc.getWeakOIL();
			double weakDI = oc.getWeakDI();
		
			//MyLogger.MyLog.WriteToLog(false,false,"","\nOverCalc Results for dtSearch Stemmer\n","");
	//=================OverCalc==================		
			string strStrongGDNT = strongGDNT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"sGDNT= ",strStrongGDNT,"");
			
			string strStrongGWMT= strongGWMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"sGWMT= ",strStrongGWMT,"");
			
			string strStrongGAMT= strongGAMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"sGAMT= ",strStrongGAMT,"");
			
			string strStrongOIG = strongOIG.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"sOIG= ",strStrongOIG,"");
			
			string strStrongOIL = strongOIL.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"sOIL= ",strStrongOIL,"");
			
			string strStrongDI  = strongDI.ToString("0.00");
			//MyLogger.MyLog.WriteToLog(false,false,"sDI= ",strStrongDI ,"");
			
			//--------------------------------------
			string strWeakGDNT = weakGDNT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"wGDNT= ",strWeakGDNT,"");
			
			string strWeakGWMT  = weakGWMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"wGWMT = ",strWeakGWMT ,"");
			
			string strWeakGAMT  = weakGAMT.ToString("0");
			//MyLogger.MyLog.WriteToLog(false,false,"wGAMT= ",strWeakGAMT ,"");
	
			string strWeakOIG  = weakOIG.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"wOIG= ",strWeakOIG ,"");
			
			string strWeakOIL  = weakOIL.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"wOIL= ",strWeakOIL ,"");
			
			string strWeakDI = weakDI.ToString("0.00");
			//MyLogger.MyLog.WriteToLog(false,false,"wDI= ",strWeakDI ,"");
	
	
	}
	
//=================================18=========================	
/*	private void ERRTToLog()
	{
				
	try {
		//ERR metrics
			double weakERRTL = errt.getWeakERRTL();
			double weakSWL = errt.getWeakSWL();
			double strongERRTL = errt.getStrongERRTL();
			double strongSWL = errt.getStrongSWL();
	
		//MyLogger.MyLog.WriteToLog(false,false,"","\nERRT Results for dtSearch Stemmer\n","");
			
		//===========================ERRT===============
			string strWeakERRTL  = weakERRTL.ToString("0.00");
			//MyLogger.MyLog.WriteToLog(false,false,"wERRTL= ",strWeakERRTL ,"");
	
			string strWeakSWL  = weakSWL.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"wSWL= ",strWeakSWL ,"");
			
			string strStrongERRTL  = strongERRTL.ToString("0.00");
			//MyLogger.MyLog.WriteToLog(false,false,"sERRTL= ",strStrongERRTL ,"");
			
			string strStrongSWL = strongSWL.ToString("0.000000");
			//MyLogger.MyLog.WriteToLog(false,false,"sSWL= ",strStrongSWL ,"");
	} catch (Exception e) {
		
		MessageBox.Show(e.Message,"18 - Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
	}
	
	      }*/
                         

		      
		
		void Button1_Click(object sender, EventArgs e)
		{
			//MyReader child = new MyReader(true, true);
       		//if (logging){
       			//child.Message = "true";//enable ViewLog button

       		
       		//}else child.Message = "false"; //disable ViewLog button
        	
        	//child.ShowDialog();//open myReader dlg.
		}
		}	
            
	}
		
	

	
