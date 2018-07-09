/*
 * Created by SharpDevelop.
 * User: User
 * Date: 20/05/2012
 * Time: 23:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Windows.Forms;

namespace WordListAnalyser2
{
	/// <summary>
	/// Description of ListViewItemComparer.
	/// </summary>
	public class ListViewItemComparer : IComparer
	{
			public int Column {get; set;}
			public bool Numeric {get; set;}
			
			public ListViewItemComparer (int columnindex)
			{
			Column = columnindex;
			}
			
			public int Compare(object x, object y){
			ListViewItem itemX = x as ListViewItem;
			ListViewItem itemY = y as ListViewItem;
			
			if (itemX == null && itemY == null)return 0;
			else if(itemX == null)return -1;
			else if(itemY == null)return 1;
			
			if (itemX == itemY)return 0;
			
			if (Numeric){
				decimal itemXVal, itemYVal;
				
				if (!Decimal.TryParse(itemX.SubItems[Column].Text, out itemXVal)){
					itemXVal = 0;
				}
				if (!Decimal.TryParse(itemY.SubItems[Column].Text, out itemYVal)){
					itemYVal = 0;
				}
				return Decimal.Compare(itemXVal,itemYVal);
				
			}else {
				
				string itemXText = itemX.SubItems[Column].Text;
				string itemYText = itemY.SubItems[Column].Text;
				
				return string.Compare(itemXText, itemYText);
			}
				
			}
	}
}
