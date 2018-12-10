/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/05/2012
 * Time: 15:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics; //for elapsed time display
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection; //used to get Assembly namespace
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using WordListAnalyser2.Porter;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
		
		{
		
		// added 20 jan 2016 tom
		// for emulating hooper stemmer
		
		public static int 	stemming_mode 	= 1;
		public static int 	MODE_DTS		= 1;
		public static int 	MODE_HOOPER		= -1;
		public static bool  use_buffer_bug	= false;
		
				
		//added 27 Dec 2013
		private double[] weakUIarray 	= new double[7];
		private double[] weakOILarray 	= new double[7];
		private double[] strongUIarray 	= new double[7];
		private double[] strongOILarray = new double[7];
		
		
		
		//added 12 July 2013
	
		string strPath = Application.StartupPath;
		
		bool barrierA = false;
		bool barrierB = false;
		
		//Added 19 June 2013
			decimal w = 0;
			decimal s = 0;
		
		
		//Added 17 June 2013
		string FileApath = "";
		string FileA = "";
		
		
		//Added 17 June 2013
		string FileBpath = "";
		string FileB = "";
		
		
		string[] ListA = {""};
		string[] ListB = {""};
		
		int lengthA = 0;
		int lengthB = 0;
		
		int WordCountA = 0;
		int WordCountB = 0;
		
		double iSum = 0;
		double iSumR = 0;
		double iSumLenA = 0;
		double iSumLenB = 0;
		
			
		[DllImport("shell32.dll",CharSet = CharSet.Unicode)]
		static extern int SHGetFolderPath(IntPtr hwndOwner, Environment.SpecialFolder nFolder,
         IntPtr hToken, uint dwFlags, [Out] StringBuilder pszPath);

		//added 17 april 2012
		[DllImport("wininet.dll",CharSet = CharSet.Unicode)]//added Charset.Unicode 8/12/18
		private extern static bool InternetGetConnectedState(out int conn, int val);
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			string strVersionMaj = Assembly.GetExecutingAssembly().GetName() .Version.Major.ToString ();
            string strVersionMin = Assembly.GetExecutingAssembly().GetName() .Version.Minor.ToString ();
            string strVersionBuild = Assembly.GetExecutingAssembly().GetName() .Version.Build.ToString ();
			this.toolStripStatusLabelVersion.Text = string.Format("{0} {1:##}.{2:##} ({3:####})", "List Analyser", strVersionMaj, strVersionMin, strVersionBuild);
			//
			numericUpDownMin.Maximum = 32;
			numericUpDownMax.Maximum = 32;
			numericUpDownMin.Minimum = 0;
			numericUpDownMax.Minimum = 0;
			numericUpDownMin.Value = 0;
			numericUpDownMax.Value = 32;
			//labelMax.Text = "0";
			//labelMin.Text = "0";
			
			buttonCalculate.Enabled = false;
			buttonClear.Enabled = false;
			
			//added 12 July 2013
			StemmingErrorGroupBox.Enabled = false;
			
			//
			
			// tom 02/02/2016 persistent setting for algorithm
			Properties.Settings1.Default.Reload();
			int setting_stemmingMode = int.Parse(Properties.Settings1.Default.useDTSAlgorithm);
			if (setting_stemmingMode == 0 || setting_stemmingMode == 1)
			{
				stemming_mode = MODE_DTS;
			}
			else
			{
				stemming_mode = MODE_HOOPER;
			}
			//InitializeListView();
			
			
			
		}
		
		void InitializeListView()
		{
	
			labelDiffCount.Text = "Total = " ;
			//labelMeanMHD.Text = "Mean MHD = " ;  
			labelInverseMeanMHD.Text = "Inverse Mean MHD = " ;
			labelSSM.Text = "SSM* = " ;
			//labelAUnique.Text = "List A unique words = " ;
			//labelBUnique.Text = "List B unique words = " ;	
			//labelConflationClassSize.Text = "Mean Conflation Class size = " ;
			//labelCompressionFactor.Text = "Compression Factor = " ;
			labelMeanCharsRemoved.Text = "Mean Characters Removed = ";
			labelOIG.Text = "Over Stemming Index = ";
         	labelUI.Text = "Under Stemming Index = ";
         	labelSW.Text = "SW = ";
			labelMeanLengthA.Text = "List A Mean Word Length = ";
			labelMeanLengthB.Text = "List B Mean Word Length = ";
			
			//labelMeanLengthA.Enabled = false;
			//labelMeanLengthB.Enabled = false;
			
			
		listViewResults.View = View.Details;
		listViewResults.GridLines = true;  
		listViewResults.FullRowSelect = true; 

		ColumnHeader columnHeader1 = new ColumnHeader();
		ColumnHeader columnHeader2 = new ColumnHeader();
		ColumnHeader columnHeader3 = new ColumnHeader();
 		ColumnHeader columnHeader4 = new ColumnHeader();
 		ColumnHeader columnHeader5 = new ColumnHeader();
 		ColumnHeader columnHeader6 = new ColumnHeader();
 		ColumnHeader columnHeader7 = new ColumnHeader();
 		ColumnHeader columnHeader8 = new ColumnHeader();
  		
		columnHeader1.Text = "ID";
		columnHeader2.Text = "List A";
		columnHeader3.Text = "Length";
		columnHeader4.Text = "List B";
		columnHeader5.Text = "Length";
		columnHeader6.Text = "MHD";
		columnHeader7.Text = "Levenshtein Distance";
		columnHeader8.Text = "Relative MHD";
	
		//Application.RenderWithVisualStyles = vi;
 
		listViewResults.Columns.Add(columnHeader1);
		listViewResults.Columns.Add(columnHeader2);
		listViewResults.Columns.Add(columnHeader3);
		listViewResults.Columns.Add(columnHeader4);
		listViewResults.Columns.Add(columnHeader5);
		listViewResults.Columns.Add(columnHeader6);
		listViewResults.Columns.Add(columnHeader7);
		listViewResults.Columns.Add(columnHeader8);
			
		listViewResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		
		
		}
		
		
		
		void OpentoolStripMenuItemClick(object sender, EventArgs e)
		{
			openFiles();
			
		}
		
		private void openFiles(){
			try {
				
			FormOpenFiles ofd = new FormOpenFiles();
			
			//Added 1st Aug 2013
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				
			FileApath = ofd.FilePathA;
			FileBpath = ofd.FilePathB;
			
			//added 12 July 2013
			barrierA = false;
			barrierB = false;
		
			StemmingErrorGroupBox.Enabled = false;
			
			//FileApath = WordListAnalyser2.Properties.Settings1.Default.FilePathA;
			//FileBpath = WordListAnalyser2.Properties.Settings1.Default.FilePathB;
			 
			FileA = "";
			FileB = "";
			
			//moved 2 June 2013
			clearLabels();
			toolStripStatusLabelElapsedTime.Text = "";
			toolStripProgressBar1.Value = 0;
			
			
			if ((FileApath !="") && (FileBpath !=""))
			{
			//For File A	
			FileA = Path.GetFileName(FileApath);
			GetWordsFromFile.ReadFile(FileApath);
			int intBarrierCountA = GetWordsFromFile.IntBarrierCount;
			//TODO get average wordlength
			//double averageLength = GetWordsFromFile.WordLengthCount(FileApath);
			//string sAverageWordLength = String.Format("{0:0.####}", averageLength);
			//MessageBox.Show("Average Word Length = " + sAverageWordLength);
			
			//For File B
			FileB = Path.GetFileName(FileBpath);
			GetWordsFromFile.ReadFile(FileBpath);
			int intBarrierCountB = GetWordsFromFile.IntBarrierCount;
			
		
			ListA = GetWordsFromFile.ReadFileToArray(FileApath);
			
			
			ListB = GetWordsFromFile.ReadFileToArray(FileBpath);
			
			
						
			lengthA = ListA.Length -  intBarrierCountA;
			lengthB = ListB.Length -  intBarrierCountB;
		
			}
			
			//Convert string[] to List<> 
			List<string> listlA = new List<string>(ListA);
			List<string> listlB = new List<string>(ListB);
		

			//Using LINQ to count distinct words
			var distinctWordsA = new List<string>(listlA.Distinct()); 
			var distinctWordsB = new List<string>(listlB.Distinct()); 
			
			
			StringBuilder builderA = new StringBuilder();
			foreach (string wordA in distinctWordsA) 
			{
	  		  builderA.Append(wordA).Append("|");
			}
			string resultA = builderA.ToString(); 
			
			
			WordCountA = distinctWordsA.Count;
			
			if (resultA.Contains("====")) {
				WordCountA = WordCountA -1;
				barrierA = true;
			}
			if (resultA.Contains("----")) {
				WordCountA = WordCountA -1;
				barrierA = true;
			}
			if (resultA.Contains("//")) {
				WordCountA = WordCountA -1;
			}
			
			StringBuilder builderB = new StringBuilder();
			foreach (string wordB in distinctWordsB) 
			{
	  		  builderB.Append(wordB).Append("|"); 
			}
			string resultB = builderB.ToString(); 
			
			WordCountB = distinctWordsB.Count;
			
			if (resultB.Contains("====")) {
				WordCountB = WordCountB -1;
				barrierB = true;
			}
			if (resultB.Contains("----")) {
				WordCountB = WordCountB -1;
				barrierB = true;
			}
			if (resultB.Contains("//")) {
				WordCountB = WordCountB -1;
			}
			
					
			w = WordCountA;
			s = WordCountB;
			
			decimal dmwc = w/s;
			decimal truncatedMwc = decimal.Truncate((dmwc * 100m) / 100m);
  			
  			decimal dcf = ((w - s)/w);
			decimal truncatedCf = decimal.Truncate((dcf * 100m) / 100m);
  			
			labelConflationClassSize.Text = "Mean Conflation Class size = " + String.Format("{0:0.###}", dmwc);
			labelCompressionFactor.Text = "Compression Factor = " + String.Format("{0:0.###}", dcf); 
			
			
			
			labelFileAName.Text = "File A: " + FileA + " [" + lengthA.ToString() +"] [" + WordCountA.ToString() +"]";
		    labelFileBName.Text = "File B: " + FileB + " [" + lengthB.ToString() +"] [" + WordCountB.ToString() +"]";
		    
		    
		    //Added 6 Aug 2013
		    if(lengthA <= WordCountA){
		    	//do nothing
		    } else 
		    {
		    	DialogResult result = MessageBox.Show("Duplicate words in File A" + Environment.NewLine +  "List Duplicates?","WARNING",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		    	if(result == DialogResult.Yes){
		    		ListDuplicatesInList(ListA);
		    	}
		    
		    }
					
		
			if (lengthA == lengthB){
				buttonCalculate.Enabled = true;
			} else {
				buttonCalculate.Enabled = false;
			MessageBox.Show("File A and File B Word Count needs to be the same", "Word Counts not equal",MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
			//Clear ListView and calculated result labels
			//clearLabels();			
			listViewResults.Items.Clear();
			} 
							
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "openFiles");
				
			}
			
			
		}
		
		//Added 13 Aug 2013 
		private void RefreshListView()
		{
		listViewResults.BeginUpdate();
		listViewResults.Items.Clear();
		//AddItemsToListView();
		listViewResults.EndUpdate();
		}
		

		
		void ListResults(){
			//added timer for diagnostics 14 Aug 2013
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			
			
			try {
				
			string si = strPath + "\\StrongRegrouped" + FileA; //added 27 June 2013
			string wni = strPath + "\\WeakNumbered" + FileA;
			string sni = strPath + "\\StrongNumbered" + FileA;
			string wi = strPath + "\\WeakRegrouped" + FileA;
			
				
			// Convert string[] to List<> 
			List<string> listlA = new List<string>(ListA);
			List<string> listlB = new List<string>(ListB);
					
			//get unique words count
			var distinctWordsA = new List<string>(listlA.Distinct()); 
			var distinctWordsB = new List<string>(listlB.Distinct()); 
			
			
				
			decimal dmwc = w/s;
			//decimal truncatedMwc = decimal.Truncate((dmwc * 100m) / 100m);
  			
  			decimal dcf = ((w - s)/w);
			//decimal truncatedCf = decimal.Truncate((dcf * 100m) / 100m);
  			
			//labelConflationClassSize.Text = "Mean Conflation Class size = " + String.Format("{0:0.###}", dmwc);
			//labelCompressionFactor.Text = "Compression Factor = " + String.Format("{0:0.###}", dcf); 
			
			int editDistance = 0;
			int hammingDistance = 0;
			decimal relativeModifiedHammingDistance = 0;
				
			iSum = 0;
			iSumR = 0;
			double meanMHD =0;
			double meanRelMHD = 0;
			double SSMLancs = 0;
			double meanLengthA = 0;
			double meanLengthB = 0;
			iSumLenA = 0;
			iSumLenB = 0;
			int j = 1;
			int i = 0;
			int count = 1;
			double[] numbers = new double[4];
			
  			  	
			if (lengthA == lengthB){
		
					
					
					//added 13 Aug 2013
					listViewResults.BeginUpdate();
        			
				
					for (i = 0; i < ListA.Length; i++)
						{
						editDistance = LevenshteinDistance.Compute(ListA[i], ListB[i]);
						
					
				
						if ((editDistance >= numericUpDownMin.Value) && (editDistance <= numericUpDownMax.Value)){
							hammingDistance = ClassHammingDistanceSimple.ModifiedHammingDistance(ListA[i], ListB[i]);
							relativeModifiedHammingDistance = ClassHammingDistanceSimple.RelativeModifiedHammingDistance(ListA[i], ListB[i]);
											
									
							if ((ListA[i].Contains("====")) || (ListA[i].Contains("----")) || (ListA[i].Contains("//"))){
								 		//do nothing
								 		
								 	}else {
							
								count = j++; //loop once for each word in the array ListA = string[]

							 numbers =  AddItemsToListViewByRange(count, i, hammingDistance, relativeModifiedHammingDistance, editDistance);
								
											
									}
									
						}
				
				
				backgroundWorker1.ReportProgress(count-1);
				
			
				
			} //end of loop
			
						
	    	listViewResults.EndUpdate();
       
        	listViewResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
       						
				
				iSumLenA = numbers[0];
				iSumLenB = numbers[1];
				iSum = numbers[2];	//sum of MHD column (MHD)
				iSumR = numbers[3]; //sum of RelMHD column 
			
								
				meanLengthA = (double)iSumLenA/listViewResults.Items.Count;
				meanLengthB = (double)iSumLenB/listViewResults.Items.Count;
				meanMHD = (double)iSum/listViewResults.Items.Count;
				
				meanRelMHD = (double)(iSumR/listViewResults.Items.Count);
				
				
				//SSMLancs = (double)100 * (1 - (meanRelMHD/lengthA)); //TODO 13 AUG 2013	accuracy??
				SSMLancs = (double)100 * (1 - meanRelMHD); //FIXED 18 Aug 2013 but meanRelMHD not accurate
				
							
				
									
			  															
				labelMeanLengthA.Text = "List A Mean Word Length = " + String.Format("{0:0.###}", meanLengthA.ToString("N3"));//13 Aug 2013 added ToString("N3")
				labelMeanLengthB.Text = "List B Mean Word Length = " + String.Format("{0:0.###}", meanLengthB.ToString("N3"));//13 Aug 2013 added ToString("N3")
										
				int UniqueWordsA = distinctWordsA.Count - GetWordsFromFile.IntBarrierCount;
				int UniqueWordsB = distinctWordsB.Count - GetWordsFromFile.IntBarrierCount;
					
													
				labelMeanCharsRemoved.Text = "Mean Characters Removed = " + String.Format("{0:0.###}", (meanLengthA - meanLengthB).ToString("N3"));//13 Aug 2013 added ToString("N3")
										
									
				//Similarity metrics
				this.labelInverseMeanMHD.Text = "Inverse Mean MHD = " + String.Format("{0:0.###}", (1/meanMHD).ToString("N3"));//13 Aug 2013 add ToString("N3")
				this.labelSSM.Text = "SSM* = " +  String.Format("{0:0.###}", SSMLancs.ToString("N3")) + "%";//13 Aug 2013 added ToString("N3")
			
				//added 6 Aug 2013 to get % accurate to three decimal places
				int ItemsCount = listViewResults.Items.Count;
				double PercentageDiffs = (double)(100 * ItemsCount)/lengthA;
			
				labelDiffCount.Text = "Total = " + listViewResults.Items.Count + " from " + lengthA.ToString() + " [" + String.Format("{0:0.###}", PercentageDiffs.ToString("N3")) + "%]";
				toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 85; // 85% progress..
			
				

			//if both files have barriers then show OI and UI metrics
			if (barrierA && barrierB){
					StemmingErrorGroupBox.Enabled = true;
					
					
					porterData sortedData = porterData.fileToMemory(FileBpath);
			
					UnderCalc uc = new UnderCalc(sortedData);
					
					UnderCalc.pd_calculateResults();
					
					double strongUI = uc.getStrongUI();
					double weakUI	= uc.getWeakUI();
					
					labelUnderStemSOnly.Text = String.Format("{0:0.######}", weakUI.ToString("N6"));
					labelUnderStemSW.Text = String.Format("{0:0.######}", strongUI.ToString("N6"));
					
					toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 90; // 90% progress..
					this.Update(); // force update since ui thread is otherwise blocked
					
					
					AssignNumber assignNumber = new AssignNumber(sortedData);
					
					porterData weakNumberedData = AssignNumber.pD_weakAssignNumber("WeakNumbered");
					porterData strongNumberedData = AssignNumber.pD_strongAssignNumber("StrongNumbered");
					
					int samplesize = AssignNumber.getSampleSize();
					
					Regroup regroup = new Regroup(weakNumberedData);
					
					porterData weakRegroupedData = regroup.pd_regroupfile("WeakRegrouped");
					
					regroup = new Regroup(strongNumberedData);
					
					porterData strongRegroupedData = regroup.pd_regroupfile("StrongRegrouped");
					
					
					OverCalc oc = new OverCalc(strongRegroupedData,weakRegroupedData,strongNumberedData,weakNumberedData, samplesize);
					
					OverCalc.pd_calculateResults();
				 
					string str1 = new FileInfo(FileApath).Directory.FullName;
	       			string str2 = new FileInfo(FileApath).Name;
					
				
									
//					Regroup regroup = new Regroup(str1 + "/WeakNumbered" + str2);
//					regroup.regroupfile(str1 + "/WeakRegrouped" + str2);
//					
//					regroup = new Regroup(str1 + "/StrongNumbered" + str2);
//					regroup.regroupfile(str1 + "/StrongRegrouped" + str2);
//					
					
					toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 92; // 92% progress..
					this.Update(); // force update since ui thread is otherwise blocked
					
										
					toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 96; // 92% progress..
					this.Update(); // force update since ui thread is otherwise blocked
					
					// HACK MemoryBarrier Tom 21/10/2015 see http://stackoverflow.com/questions/5996267/c-sharp-enforcing-order-of-statement-execution
					// Just added on suspicion that the below code somehow was getting executed before calculateResults finishes
					System.Threading.Thread.MemoryBarrier();
					
					
					double strongOI =  oc.getStrongOIG();
					double SW = (double)strongOI/strongUI;
					
					double weakOIG = oc.getWeakOIG();
					
					
					string OverStemmingIndex = strongOI.ToString("N8");
									
					labelOverStemSWG.Text = String.Format("{0:0.########}",  OverStemmingIndex);
					labelOverStemSOnlyG.Text = String.Format("{0:0.########}", weakOIG);
					
					
					double strongOIL = oc.getStrongOIL();
					double weakOIL = oc.getWeakOIL();
					labelOverStemSOnlyL.Text = String.Format("{0:0.########}",  weakOIL);
					labelOverStenSWL.Text = String.Format("{0:0.########}",  strongOIL);
					
					
								
					
					//Added 22 DEC 2013 for ERRT Calc
					double[] weakUIarray = new double[7];
					double[] weakOILarray = new double[7];
					double[] strongUIarray= new double[7];
					double[] strongOILarray= new double[7];
				
					//Tom 14/10/2015 - Adding logic for ERRT Calculation
					//Used SwingInterface.java lines 743 - 795 
					//from Lancaster Univ program as reference
					
					weakUIarray[0] = uc.getWeakUI();
		       		weakOILarray[0] = oc.getWeakOIL();
		       		strongUIarray[0] = uc.getStrongUI();
		       		strongOILarray[0] = oc.getStrongOIL();
		       		
		       		
		       		toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 97; // 92% progress..
					this.Update(); // force update since ui thread is otherwise blocked
		       		//Java 743
		       		
		       		sortedData = porterData.fileToMemory(FileApath);
		       		
		       		for (i = 3 ; i < 9 ; i++)
		       		{
		       					       			
		       			Truncator truncator = new Truncator(sortedData);
		       			
		       				       			
	       			
		       			porterData truncatedData = Truncator.pd_truncate("truncated",i);
		       			uc = new UnderCalc(truncatedData);

		       			UnderCalc.pd_calculateResults();
		       			
//		       			AssignNumber asn = new AssignNumber(str1 + "truncated" + i + str2);
		       			AssignNumber asn = new AssignNumber(truncatedData);
		       			porterData weakNumberedTData = AssignNumber.pD_weakAssignNumber("WeakNumberedT");
//		       			AssignNumber.strongAssignNumber(str1 + "StrongNumberedT" + i + str2);
		       			porterData strongNumberedTData = AssignNumber.pD_strongAssignNumber("StrongNumberedT");
		       			samplesize = AssignNumber.getSampleSize();
		       			
//		       			regroup = new Regroup(str1 +  "WeakNumberedT" + i + str2);		       			
//		       			regroup.regroupfile(str1 + "WeakRegroupedT" + i + str2);
//		       			regroup = new Regroup(str1 + "StrongNumberedT" + i + str2);
//		       			regroup.regroupfile(str1 + "StrongRegroupedT" + i +str2);
		       			

		       			regroup = new Regroup(weakNumberedTData);
		       			porterData weakRegroupedTData = regroup.pd_regroupfile("WeakRegroupedT");       			
		       			regroup = new Regroup(strongNumberedTData);
		       			porterData strongRegroupedTData = regroup.pd_regroupfile("StrongRegroupedT");

		       			
//		       			oc = new OverCalc(str1 + "StrongRegroupedT" + i + str2,
//		       			                 str1 + "WeakRegroupedT" + i + str2,
//		       			                 str1 + "StrongNumberedT" + i + str2,
//		       			                str1 + "WeakNumberedT" + i + str2, samplesize);
		       			
		       			oc = new OverCalc(strongRegroupedTData,
		       				                         weakRegroupedTData,
		       				                        	strongNumberedTData,
		       				                        weakNumberedTData, samplesize);
		       			
		       			OverCalc.pd_calculateResults();
		       			
		       			weakUIarray[i-2] 	= uc.getWeakUI();
		       			weakOILarray[i-2] 	= oc.getWeakOIL();
			       		strongUIarray[i-2] 	= uc.getStrongUI();
			       		strongOILarray[i-2] = oc.getStrongOIL();
			       		
			       		toolStripProgressBar1.Value = (toolStripProgressBar1.Maximum/100) * 98; // 92% progress..
						this.Update(); // force update since ui thread is otherwise blocked
		       		}

		       		
		       		
		       		
					//Changed last Parameter of ERRT Constructor to match Line 800 SwingInterface.java of original Lancs program..
					//Although, parameter names do not seem to match to constructor (using weakOILarray in sOIL spot)
					
					ERRT errt;
					
					if (stemming_mode == MODE_DTS)
					{
						errt = new ERRT(weakUIarray ,weakOILarray, strongUIarray, strongOILarray);
					} else
					{
						errt = new ERRT(weakUIarray ,weakOILarray, strongUIarray, weakOILarray);
					}
					
					//double[] wUI, wOIL, sUI, sOIL
					// Tom 21/10/2015 - Changed last parameter from strongOILarray to weakOILarray to match Java 801
					//ERRT errt = new ERRT(weakUIarray ,weakOILarray, strongUIarray, weakOILarray);
					errt.CalculateResults();
					
					
					
					double derrt = errt.getStrongERRTL();
					//MessageBox.Show("derrt" + derrt);
					//labelERRT.Text = "ERRT = " + String.Format("{0:0.#######}", derrt.ToString("N6"));
					
					
					// Tom 26/10/2015 see SwingInterface.java line 814 & 
					// the answer @ http://stackoverflow.com/questions/2924242/replicating-javas-decimalformat-in-c-sharp
					
					string sws = "Test" + (errt.getWeakSWL()*100.00).ToString();
					sws = (errt.getWeakSWL()*100).ToString("N2");
					labelSWSOnly.Text = sws;
					
					
					string swlText = (errt.getStrongSWL()*100.00).ToString();
					swlText = (errt.getStrongSWL()*100).ToString("N2");
					labelSWSW.Text   =  swlText;
					
					string errtSOnlytext = (errt.getWeakERRTL()*100).ToString("N2");
					
					string errtText  = (errt.getStrongERRTL()*100.00).ToString("N2");
					labelERRTSW.Text = errtText ;
					labelERRTSOnly.Text = errtSOnlytext;
					
				      			
        			
        			System.Diagnostics.Debug.WriteLine("MainForm 821: UnderCalc.numDMTCalls= " + UnderCalc.numDMTCalls);
        			System.Diagnostics.Debug.WriteLine("MainForm 822: OverCalc numStrongOILZero =  " + OverCalc.numStrongOILZero +  ", numStrongOILNonZero = " + OverCalc.numStrongOILNonZero);
       			 	// tom 03/11/2015 writing out list of DMT(); results from underCalc to a file
       			 	string DMTData = UnderCalc.sb.ToString();
       			 	//System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\DMT_Test\\DMT_LA.txt");
       			 	//file.WriteLine(DMTData);
       			 	//file.Close();
       			 	
       			 	
       			 	
					
					
			} else StemmingErrorGroupBox.Enabled = false;
			
					
			//MessageBox.Show(j.ToString());
									
			} else MessageBox.Show("Lengths of Lists are not the same","ListResults");		
				
						
					
			} catch (Exception ex) {
				MessageBox.Show(ex.Message +"\n \n" +  ex.StackTrace, "ListResults");
				//throw;
			}
					TimeSpan ts = stopWatch.Elapsed;
					// Format and display the TimeSpan value. 
					string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
					toolStripStatusLabelElapsedTime.Text =  elapsedTime;
					stopWatch.Stop();
					
					toolStripProgressBar1.Value = toolStripProgressBar1.Maximum; // finished
						this.Update(); // force update since ui thread is otherwise blocked
			
       			 
    
			
		}
		
		
		void ButtonCalculateClick(object sender, System.EventArgs e)
		{
			
			buttonClear.Enabled = false;
			labelUI.Focus(); //move focus away to try to remove border???
			
			buttonCalculate.Enabled = false;
			//buttonCalculate.Visible = false;
			
			
			listViewResults.Items.Clear();//this works
			ClearCalculatedResults(); //TODO this is not working 
			toolStripStatusLabelElapsedTime.Text = "";//TODO this does not work 
			
					
			ListResults();
			
			buttonCalculate.Enabled = false;
			//buttonCalculate.Visible = true;
			//this.toolStripProgressBar1.Value = 0;
			buttonClear.Enabled = true;
			buttonCalculate.Enabled = true;
			
		}
			
			
		void CheckBoxAllCheckedChanged(object sender, EventArgs e)
		{
			//if (checkBoxAll.Checked){
			//	this.numericUpDownMin.Enabled = false;
			//	this.numericUpDownMax.Enabled = false;
			//	label1.Enabled = false;
				//groupBox1.Enabled = false;
			//} else{
				this.numericUpDownMin.Enabled = true;
				this.numericUpDownMax.Enabled = true;
				label1.Enabled = true;
				//groupBox1.Enabled = true;
		//	}
		// TODO: Implement CheckBoxAllCheckedChanged
		}
		
		void NumericUpDownMinValueChanged(object sender, EventArgs e)
		{
			numericUpDownMax.Minimum = numericUpDownMin.Value;
			
			try {
				
				
			//(labelMin.Text.ToString()) ;
			
			
			} catch (Exception) {
				
				throw;
			}
		
			
		}
		
		
		
		void NumericUpDownMaxValueChanged(object sender, EventArgs e)
		{
			//if (numericUpDownMax.Value < 0)numericUpDownMax.Value = Convert.ToDecimal(labelMin.Text) ;
			//groupBox1.Enabled = false;
			//if (Convert.ToDecimal(labelMin.Text) > numericUpDownMax.Value) labelMin.Text = numericUpDownMax.Value.ToString();
			//labelMax.Text = numericUpDownMax.Value.ToString();
			//int MaxCount = Convert.ToInt32(labelMax.Text);
			//if (Convert.ToDecimal(labelMax.Text) > numericUpDownMax.Value) labelMax.Text = (MaxCount--).ToString();
			
		}
		
		void NumericUpDownMaxMouseClick(object sender, MouseEventArgs e)
		{
			//numericUpDownMax.Minimum =0;
		
			//numericUpDownMin.Maximum = numericUpDownMax.Value;
		}
		
		
		
		void NumericUpDownMinMouseClick(object sender, MouseEventArgs e)
		{
			//numericUpDownMin.Maximum = 32;
		}
		
		
		
		
		void ListViewResultsColumnClick(object sender, ColumnClickEventArgs e)
		{
			
			SortColumn(e);
			
		}
		
		void SortColumn(ColumnClickEventArgs e){
			
			
			ListViewItemComparer sorter = listViewResults.ListViewItemSorter as ListViewItemComparer;
			
			if (sorter == null) {
				sorter = new ListViewItemComparer(e.Column);
				if ((e.Column == 0)||(e.Column == 2 )||(e.Column == 4 )||(e.Column == 5 )||(e.Column == 6 )){
					sorter.Numeric = true;
				} else 	sorter.Numeric = false;
				listViewResults.ListViewItemSorter = sorter;
				
			}
			else
			{
				sorter.Column = e.Column;
				
			}
			
			
			listViewResults.Sort();
			
			this.listViewResults.SetSortIcon(e.Column, SortOrder.Descending); 
			
		}
		
		
		
		
		
		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenSaveDialog();
		}
		
		void OpenSaveDialog(){
			
			string FileANoExt = Path.GetFileNameWithoutExtension(FileA);
			string FileBNoExt = Path.GetFileNameWithoutExtension(FileB);
			
			SaveFileDialog sd = new SaveFileDialog();
			sd.Title ="Save as CSV";
			sd.Filter = "CSV files (*.csv)|*.csv";
         	sd.DefaultExt = ".csv";
         	sd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         	sd.FileName = "List_" + FileBNoExt;
          	if (sd.ShowDialog() == DialogResult.OK){
				string fileName = sd.FileName;	
				 using (StreamWriter sw = new StreamWriter(fileName))
				 {
				 ClassListViewToCSV.ListViewToCSV(listViewResults, sw);
				 }
			}
		}
		
         	void clearLabels()
         	{
       
			labelDiffCount.Text = "Total = " ;
			labelInverseMeanMHD.Text = "Inverse Mean MHD = " ;
			labelSSM.Text = "SSM* = " ;
			labelConflationClassSize.Text = "Mean Conflation Class size = " ;
			labelCompressionFactor.Text = "Compression Factor = " ;
         	labelMeanCharsRemoved.Text = "Mean Characters Removed = ";
         	labelOIG.Text = "Over-Stemming Index = ";
         	labelUI.Text = "Under-Stemming Index = ";
         	labelSW.Text = "SW = ";
         	labelMeanLengthA.Text = "List A Mean Word Length = ";
			labelMeanLengthB.Text = "List B Mean Word Length = ";
			
			//labelMeanLengthA.Enabled = false;
			//labelMeanLengthB.Enabled = false;
							
			labelFileAName.Text = "File A: ";
		    labelFileBName.Text = "File B: ";
         		
         	}
		
		void SaveToolStripButtonClick(object sender, EventArgs e)
		{
			OpenSaveDialog();
		}
		
		void OpenToolStripButtonClick(object sender, EventArgs e)
		{
			
			openFiles();
			
		}
			
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
		
			//Added 11 June 2012
			//this.toolsToolStripMenuItem.Enabled = false;
			InitializeListView();
			//Added 5 June 2012
			this.listViewResults.SetSortIcon(0, SortOrder.Descending); 
		}
		
		int[] GetOccurancesOfWordInList(string [] listOfItems)
		{
			
		//assemble the word count of each word into an array
		StringBuilder sb = new StringBuilder();
		int[] WordCount = {0};
		var q = from x in listOfItems
        group x by x into g 
        let count = g.Count() 
       // orderby count descending 
        select new {Value = g.Key, Count = count}; 
		foreach (var x in q) 
		{ 
			WordCount.SetValue(x.Count, Convert.ToInt32(x));
		} 
		return WordCount;

		}
		
			
		
		//string [] listOfItems = ListB;
		void ListDuplicatesInList(string [] listOfItems)
			{
			
 		StringBuilder sb = new StringBuilder();
		var q = from x in listOfItems
        group x by x into g 
        let count = g.Count() 
        orderby count descending 
        select new {Value = g.Key, Count = count}; 
		foreach (var x in q) 
		{ 
			if((x.Value.Contains("===="))||(x.Value.Contains("----"))){
			   	//do nothing
			   } else {
						if (x.Count > 1)
						{
							sb.Append(x.Value + " [" + x.Count + "]\n");
						}
			   }
		} 
 		MessageBox.Show(sb.ToString(), "Duplicates");
 		}
		
	
		
		void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			ShowAbout();
		}
		
		void ShowAbout()
		{
			
			Form about = new About();
			about.ShowDialog();
						
			this.menuStripMain.Focus();
		}
		
		
		
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			ShowWebHelp();
		}
		
		
		void ShowWebHelp(){
		int Out;
			if (InternetGetConnectedState(out Out, 0) == true)
			{
			//July 2018 path was to WebHelp URL, changed to GitHub repo
			System.Diagnostics.Process.Start("https://github.com/electronart/WordListAnalyser/wiki");
			} else MessageBox.Show("Not Connected to Internet", "WebHelp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		
		
		
		void deleteFiles(string si, string wni, string sni, string wi)
			{
			if((File.Exists(si)) && (System.IO.File.Exists(wi)))
        			{
		              try
            			{
                		System.IO.File.Delete(si);
                		System.IO.File.Delete(wi);
            			}
            			catch (Exception ex)
            			{
               		 MessageBox.Show(ex.Message, "deleteFiles");
                		return;
            			}
            			
            		if((File.Exists(sni))&&(System.IO.File.Exists(wni)))
        			{
		              try
            			{
                		System.IO.File.Delete(sni);
                		System.IO.File.Delete(wni);
            			}
            			catch (Exception ex)
            			{
               		 MessageBox.Show(ex.Message, "deleteFiles");
                		return;
            			}

					}

				}
			}
		
		
	
		
		void HelpToolStripButtonClick(object sender, EventArgs e)
		{
			ShowWebHelp();
		}
		
	
		
		void ButtonClearClick(object sender, EventArgs e)
		{
			
			FileA = "";
			FileB = "";
			
			//Clear ListView and result labels
			clearLabels();			
			listViewResults.Items.Clear();
			buttonCalculate.Enabled = false;
			buttonClear.Enabled = false;
			toolStripStatusLabelElapsedTime.Text = "";
            ClearCalculatedResults();//not working - new strong/strong + weak labels added must be incorrect source

        }
		
		
		void ClearCalculatedResults(){
			
		  	labelMeanLengthA.Text = "List A Mean Word Length = ";
			labelMeanLengthB.Text = "List B Mean Word Length = ";
			labelMeanCharsRemoved.Text = "Mean Characters Removed = ";
			
			labelInverseMeanMHD.Text = "Inverse Mean MHD = " ;
			labelSSM.Text = "SSM* = " ;
			
			labelOIG.Text = "Over-Stemming Index =           ";
         	labelUI.Text = "Under-Stemming Index =          ";
         	labelSW.Text = "SW = ";
         	labelERRT.Text = "ERRT = ";
         }
		
		//NOT USED
		void AddItemsToListView(int count, int i , int hammingDistance, decimal relativeModifiedHammingDistance, int editDistance,  ListViewItem item){
			
			//this works OK approx 1.5 sec to complete commonwords_trunc7
			item.Text = count.ToString();
			item.SubItems.Add(ListA[i]);
			item.SubItems.Add(ListA[i].Trim().Length.ToString());
			item.SubItems.Add(ListB[i]);
			item.SubItems.Add(ListB[i].Trim().Length.ToString());							
   		item.SubItems.Add(hammingDistance.ToString());
   		item.SubItems.Add(editDistance.ToString());
   		item.SubItems.Add(relativeModifiedHammingDistance.ToString());
   		listViewResults.Items.Add(item);
			
			
		}
		
		private double[] AddItemsToListViewByRange(int count, int i , int hammingDistance, decimal relativeModifiedHammingDistance, int editDistance){
		
		List<ListViewItem> items = new List<ListViewItem>();
		items.Add(CreateListViewItem(ListA, ListB, count, i , hammingDistance, relativeModifiedHammingDistance, editDistance));
		listViewResults.Items.AddRange(items.ToArray());
			
		//iSumLenA += double.Parse(ListA[i].Trim().Length.ToString());// int to string to double conversion
		//iSumLenB += double.Parse(ListB[i].Trim().Length.ToString());// int to string to double conversion
		//iSum += double.Parse(hammingDistance.ToString());// int to string to double conversion
		//iSumR += double.Parse(relativeModifiedHammingDistance.ToString());//decimal to string to double conversion
		
				
		iSumLenA += (double)(ListA[i].Trim().Length);//int to double conversion
		iSumLenB += (double)(ListB[i].Trim().Length);//int to double conversion
		iSum += (double)(hammingDistance);// int to double conversion
		
		//MSDN This operation can produce round-off errors because a double-precision floating-point number has fewer significant digits than a Decimal.
		iSumR += (double)(relativeModifiedHammingDistance);//decimal to double conversion
		
		double[] numbers = new double[] {iSumLenA, iSumLenB, iSum, iSumR};
		return numbers;	
		
		}
		
		
		
		
		
		private static ListViewItem CreateListViewItem(string[] ListA, string[] ListB, int count, int i , int hammingDistance, decimal relativeModifiedHammingDistance, int editDistance)
		{
		ListViewItem item = new ListViewItem(
		new string[]
					{
				count.ToString(),
				ListA[i],
				ListA[i].Trim().Length.ToString(),
				ListB[i],
				ListB[i].Trim().Length.ToString(),
				hammingDistance.ToString(),
				editDistance.ToString(),	
				relativeModifiedHammingDistance.ToString()			
					});
			
			
				return item;
		}
		
		
		
		
		
	
		
		void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			 // Change the value of the ProgressBar to the BackgroundWorker progress.
	   	 // toolStripProgressBar1.Value = e.ProgressPercentage;
	   }
		
		void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
		{
		
			ListResults();
			 e.Result = 0;
		}

		void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Preferences Clicked from drop down
			PreferencesWindow pWin = new PreferencesWindow();
			pWin.ShowDialog();
		}
}
}