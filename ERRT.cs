/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10/30/2011
 * Time: 12:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;// for MessageBox

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of ERRT.
	/// </summary>
	public class ERRT
	{
		
		double[] weakUIarray;
		//ArrayList weakUIarray;
		double[] weakOILarray;
		double[] strongUIarray;
		double[] strongOILarray;
		double Xe, Ye;
		double X1, Y1;
		double Xr, Yr;
		double Xi, Yi;
		double weakERRTL, strongERRTL;
		double weakSWL, strongSWL;
		
		//Contructor methods
		public ERRT(double[] wUI, double[] wOIL, double[] sUI, double[] sOIL)
		{
			//set arrays
			weakUIarray = wUI;
			weakOILarray = wOIL;
			strongUIarray = sUI;
			strongOILarray = sOIL;
			
			// tom 26/10/2015 debugging - array i was testing with was 7 in length
			
			
			for (int i = 0 ; i < 7 ; i++)
			{
				System.Diagnostics.Debug.WriteLine("ERRT (ERRT.cs 45) ["+i+"] wUI="+wUI[i]+" wOIL="+wOIL[i]+" sUI="+sUI[i]+" sOIL="+sOIL[i]);
			}
			
			//reset calculation variables
			Xe = 0;
			Ye = 0;
			X1 = 0;
			Y1 = 0;
			Xr = 0;
			Yr = 0;
			Xi = 0;
			Yi = 0;
			weakERRTL = 0;
			weakSWL = 0;
			strongERRTL = 0;
			strongSWL = 0;
		}//end of constructor
		
		public ERRT()
		{
		}//end of null constructor
		
		public void weakTruncationPoints(){
			int i = 0;
			double tx, ty;
			double gradXeYe;
			double gradtxty;
			bool valueset = false;
			
			Xe = weakUIarray[i];
			Ye = weakOILarray[i];
			//calculate gradient
			gradXeYe = (double) (Ye/Xe);
			//loop to find left and right truncation points
			
			// HACK: Tom 14/10/2015 - Valueset never becomes true, not sure if it should do
			// I've made sure index out of bounds exception can't occur by checking the value of i
			while(!valueset)// && i < weakUIarray.Length)
			{
			 i++;
			//get temp values
			tx = weakUIarray[i];
			ty = weakOILarray[i];
			gradtxty = (double) (ty/tx);
			
			System.Diagnostics.Debug.WriteLine("weakTruncationPoints (ERRT.cs 84): tx " + tx + ", ty " + ty + ", gradtxty" + gradtxty + ", gradXeYe " + gradXeYe);
			
			if (gradtxty < gradXeYe){
				X1 = tx;
				Y1 = ty;
				Xr = weakUIarray[i-1];
				Yr = weakOILarray[i-1];
				valueset = true;
				//System.Diagnostics.Debug.WriteLine("weakTruncationPoints (ERRT.cs 92): X1 = " + X1 + ", Y1 = " + Y1 + ", Xr= " + Xr + ", Yr=" + Yr);
				
			}
			// HACK: i++ was moved to bottom of while loop rather than top
			//i++;
				
			}
			
			
			
		}
		
		public void strongTruncationPoints(){
			//try {
			double tx, ty;
			double gradXeYe;
			double gradtxty;
			bool valueset = false;
			int i = 0;
			Xe = strongUIarray[i];
			Ye = strongOILarray[i];
			//calculate gradient
			gradXeYe = (double) (Ye/Xe);
			
			System.Diagnostics.Debug.WriteLine("strongTruncationPoints (ERRT.cs 122) Xe =" + Xe + ", Ye=" + Ye);
			System.Diagnostics.Debug.WriteLine("strongTruncationPoints (ERRT.cs 123) gradXeYe =" + gradXeYe);
			// loop to find left and right truncation points
			// HACK: Tom 14/10/2015 - Valueset never becomes true, not sure if it should do
			// I've made sure index out of bounds exception can't occur by checking the value of i
			while(!valueset) // && i < weakUIarray.Length)
			{
			i++;
			//get temp values
			tx = strongUIarray[i];
			ty = strongOILarray[i];
			gradtxty = (double) (ty/tx);
			if (gradtxty < gradXeYe){
				X1 = tx;
				Y1 = ty;
				Xr = strongUIarray[i-1];
				Yr = strongOILarray[i-1];
				valueset = true;
				
			}
			// HACK: i++ was moved to bottom of while loop rather than top
			//i++;
			}	
				
				
			//}
//			catch (Exception ex) 
//			{
//				MessageBox.Show(ex.Message + "\n \n" + ex.StackTrace, "ERRT.StongTruncationPoints Exception");
//			}
			
	
			
			
		}
		
		public void weakCalculate(){
			
			double m1, m2, c;
			double evallength, interlength;
			//gradient of truncation line
			m1 = (double) ((Y1 - Yr)/(X1 - Xr));
			//equation of truncation line
			c = (double) (Y1 - (m1 * X1));
			//gradient of evaluation line
			m2 = (double) (Ye/Xe);
			//intersection of points
			Xi = (double) (c/(m2 - m1));
			Yi = (double) (m2 * Xi);
//			//calculate length of eval and intersection lines
//			evallength = Math.Sqrt((Xe * Xe)+(Ye * Ye));
//			interlength = Math.Sqrt(Xi * Xi) + (Yi * Yi);
//			//calculate ERRT and SW values
//			weakERRTL =  (evallength/interlength);
//			weakSWL = m2;
			decimal eval_formulaResult = Convert.ToDecimal((Xe * Xe)+(Ye * Ye));
			decimal inter_formulaResult = Convert.ToDecimal((Xi * Xi) + (Yi * Yi));
			
			decimal sqrt_evalLength = (decimal)Math.Sqrt((Xe * Xe)+(Ye * Ye));
			for (int i = 0; i < 10; ++i)
			{
				sqrt_evalLength = 0.5m* (sqrt_evalLength +  eval_formulaResult / sqrt_evalLength);
			}
			
			evallength = Convert.ToDouble(sqrt_evalLength);
			
			decimal sqrt_interlength = (decimal)Math.Sqrt((Xi * Xi) + (Yi * Yi));
			for (int i = 0; i < 10; ++i)
			{
				sqrt_interlength = 0.5m * (sqrt_interlength + inter_formulaResult / sqrt_interlength);
			}
			interlength = Convert.ToDouble(sqrt_interlength);
			
			weakERRTL =  (evallength/interlength);
			weakSWL = m2;
			
			
			System.Diagnostics.Debug.WriteLine("ERRT weakCalculate 162 - weakERRTL=" + weakERRTL + ", weakSWL=" + weakSWL );
			
		}  
		
		public void strongCalculate(){
			
			double m1, m2, c;
			double evallength, interlength;
			//gradient of truncation line
			m1 = ((Y1 - Yr)/(X1 - Xr));
			//equation of truncation line
			c =  (double)(Y1 - (m1 * X1));
			//gradient of evaluation line
			m2 = (double) (Ye/Xe);
			//intersection of points
			Xi =  (double) (c/(m2 - m1));
			Yi = (double) (m2 * Xi);
			//calculate length of eval and intersection lines

			// HACK Tom 04/11/2015 - trying to fix ERRT precision issues
			// suspecting sqrt function as a source of larger error
			// newtons algorithm see answer at 
			// http://stackoverflow.com/questions/8113651/c-sharp-high-precision-calculations
			decimal eval_formulaResult = Convert.ToDecimal((Xe * Xe)+(Ye * Ye));
			decimal inter_formulaResult = Convert.ToDecimal((Xi * Xi) + (Yi * Yi));
			
			decimal sqrt_evalLength = (decimal)Math.Sqrt((Xe * Xe)+(Ye * Ye));
			for (int i = 0; i < 10; ++i)
			{
				sqrt_evalLength = 0.5m* (sqrt_evalLength +  eval_formulaResult / sqrt_evalLength);
			}
			
			//evallength = Math.Sqrt((Xe * Xe)+(Ye * Ye));
			evallength = Convert.ToDouble(sqrt_evalLength);
			
			decimal sqrt_interlength = (decimal)Math.Sqrt((Xi * Xi) + (Yi * Yi));
			for (int i = 0; i < 10; ++i)
			{
				sqrt_interlength = 0.5m * (sqrt_interlength + inter_formulaResult / sqrt_interlength);
			}
			
			//interlength = Math.Sqrt((Xi * Xi) + (Yi * Yi));
			interlength = Convert.ToDouble(sqrt_interlength);
			//calculate ERRT and SW values
//			MessageBox.Show("ERRT TEMP DIALOG_1; \n \n evallength = " + evallength
//			                + "\n \n interlength = "+ interlength);
//			MessageBox.Show("ERRT TEMP DIALOG_2; \n \n Xi= " + Xi
//			                + "\n \n Yi = "+ Yi);
//			MessageBox.Show("ERRT TEMP DIALOG_3; \n \n c= " + c
//			                + "\n \n m2 = "+ m2
//			                + "\n \n m1 = " + m1);
//			MessageBox.Show("ERRT TEMP DIALOG_4; \n \n Y1= " + Y1
//			                + "\n \n m1 = "+ m1
//			                + "\n \n X1 = " + X1);
//			MessageBox.Show("ERRT TEMP DIALOG_5; \n \n Yr= " + Yr
//			                + "\n \n Xr= " + Xr);
			strongERRTL = (double) (evallength/interlength);
			strongSWL = m2;
			
			System.Diagnostics.Debug.WriteLine("ERRT strongCalculate 187 - strongERRTL=" + strongERRTL + ", strongSWL=" + strongSWL );
				
		}
		
		public void CalculateResults(){
			System.Diagnostics.Debug.WriteLine("CalculateResults(ERRT.cs 215): weakOILarrayLength: " + weakOILarray.Length +" weakUIarrayLength" + weakUIarray.Length);
			System.Diagnostics.Debug.WriteLine("CalculateResults(ERRT.cs 216): strongOILarrayLength: " + strongOILarray.Length +" strongUIarrayLength" + strongUIarray.Length);
			
			weakTruncationPoints();
			weakCalculate();
			strongTruncationPoints();
			strongCalculate();
		}
		
		public double getWeakERRTL(){
			return weakERRTL;
		}
		
		public double getWeakSWL(){
			return weakSWL;
		}
		
		public double getStrongERRTL(){
			return strongERRTL;
		}
		
		public double getStrongSWL(){
			return strongSWL;
		}
	}
}
