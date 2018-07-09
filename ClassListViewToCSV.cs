/*
 * Created by SharpDevelop.
 * User: User
 * Date: 21/05/2012
 * Time: 00:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of ListViewToCSV.
	/// </summary>
	public class ClassListViewToCSV 
{ 
    //public static void ListViewToCSV(ListView listView, string filePath, bool includeHidden) 
   // { 
        //make header string 
       // StringBuilder result = new StringBuilder(); 
       // WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text.ToLower());
 
       // ListViewItem.ListViewSubItem listItem = new ListViewItem.ListViewSubItem();
        //export data rows 
      // foreach (var listItem in listView.Items) 
       //    WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.[i].Text); 
 
       // File.WriteAllText(filePath, result.ToString()); 
    //} 
 
   // private static void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue) 
   // { 
    //    bool isFirstTime = true; 
    //    for (int i = 0; i < itemsCount; i++) 
    //    { 
     //       if (!isColumnNeeded(i)) 
      //          continue; 
 
     //       if (!isFirstTime) 
      //          result.Append(","); 
       //     isFirstTime = false; 
 
       //     result.Append(String.Format("\"{0}\"", columnValue(i))); 
       // } 
       // result.AppendLine(); 
    
       public static void ListViewToCSV(ListView listView, StreamWriter sw) 
       {       
          	if (listView.Items.Count > 0) {
       		string separator = Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator; // Can be different - UK use ',' but for Germany is ';' 
       		string valueFormat = "\"{0}\"" + separator; // we will replace {0} with the value using string.Format later             
       		StringBuilder sb = new StringBuilder();              
       		// section title             
       		//sw.WriteLine(title);
       		// column names             
       		foreach (ColumnHeader ch in listView.Columns) {                  
       			sb.Append(string.Format(valueFormat, ch.Text));             
       		}             sw.WriteLine(sb.ToString());             
       		// the actual data             
       		foreach (ListViewItem lvi in listView.Items) {                    
       			sb = new StringBuilder();                   
       			foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems) { 
       				sb.Append(string.Format(valueFormat, listViewSubItem.Text));  
       			}                    sw.WriteLine(sb.ToString());   
       		}              // and an empty line for prettinness   
       		sw.WriteLine();      
       	}
       
    } 
} 

			
			
}
