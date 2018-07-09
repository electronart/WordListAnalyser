/*
 * Created by SharpDevelop.
 * User: User
 * Date: 05/06/2012
 * Time: 19:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace WordListAnalyser2
{
	/// <summary>
	/// Description of ClassListViewExtensions.
	/// 
	/// From:
	/// http://stackoverflow.com/questions/254129/how-to-i-display-a-sort-arrow-in-the-header-of-a-list-view-column-using-c
	/// you can call the extension method like such:

///myListView.SetSortIcon(0, SortOrder.Ascending);
///It works by using P/Invoke to:
///Get the handle to the header control for a list view using the LVM_GETHEADER message.
///Get the information about a header column using the HDM_GETITEM message.
///It then modifies the fmt to set / clear the HDF_SORTDOWN and HDF_SORTUP flags on the returned HDITEM structure.
///Finally it re-sets the information usintg the HDM_SETITEM message.
///
	/// </summary>
	//public static class ClassListViewExtensions
	//{
		//public ClassListViewExtensions()
		//{
		//}
	
			
//extension method to set the sort arrow to a particular column:
	
[EditorBrowsable(EditorBrowsableState.Never)] 
public static class ListViewExtensions 
{ 
    [StructLayout(LayoutKind.Sequential)] 
    public struct HDITEM 
    { 
        public Mask mask; 
        public int cxy; 
        [MarshalAs(UnmanagedType.LPTStr)] public string pszText; 
        public IntPtr hbm; 
        public int cchTextMax; 
        public Format fmt; 
        public IntPtr lParam; 
        // _WIN32_IE >= 0x0300  
        public int iImage; 
        public int iOrder; 
        // _WIN32_IE >= 0x0500 
        public uint type; 
        public IntPtr pvFilter; 
        // _WIN32_WINNT >= 0x0600 
        public uint state; 
 
        [Flags] 
        public enum Mask 
        { 
            Format = 0x4,       // HDI_FORMAT 
        }; 
 
        [Flags] 
        public enum Format 
        { 
            SortDown = 0x200,   // HDF_SORTDOWN 
            SortUp = 0x400,     // HDF_SORTUP 
        }; 
    }; 
 
    public const int LVM_FIRST = 0x1000; 
    public const int LVM_GETHEADER = LVM_FIRST + 31; 
 
    public const int HDM_FIRST = 0x1200; 
    public const int HDM_GETITEM = HDM_FIRST + 11; 
    public const int HDM_SETITEM = HDM_FIRST + 12; 
 
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] 
    public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam); 
 
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] 
    public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam); 
 
    public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order) 
    { 
        IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero); 
        for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++) 
        { 
            var columnPtr = new IntPtr(columnNumber); 
            var item = new HDITEM 
                { 
                    mask = HDITEM.Mask.Format 
                }; 
 
            if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero) 
            { 
                throw new Win32Exception(); 
            } 
 
            if (order != SortOrder.None && columnNumber == columnIndex) 
            { 
                switch (order) 
                { 
                    case SortOrder.Ascending: 
                        item.fmt &= ~HDITEM.Format.SortDown; 
                        item.fmt |= HDITEM.Format.SortUp; 
                        break; 
                    case SortOrder.Descending: 
                        item.fmt &= ~HDITEM.Format.SortUp; 
                        item.fmt |= HDITEM.Format.SortDown; 
                        break; 
                } 
            } 
            else 
            { 
                item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp; 
            } 
 
            if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero) 
            { 
                throw new Win32Exception(); 
            } 
        } 
    } 
} 

		
	}