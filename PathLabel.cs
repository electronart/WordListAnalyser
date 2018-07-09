/*
 * Created by SharpDevelop.
 * User: User
 * Date: 05/09/2011
 * Time: 23:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace StemmingTester
{
	/// <summary>
	/// Label component that puts ellipsis in the string if the path text is too long
	/// IMPORTANT Do not set Appearance Flatstyle to System (set it to Standard)
	/// otherwise it appears to break on paths with a space in.
	/// </summary>
			
public class PathLabel : Label {
  [Browsable(false)]
  public override bool AutoSize {
    get { return base.AutoSize; }
    set { base.AutoSize = false; }
  }
  protected override void OnPaint(PaintEventArgs e) {
    TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.PathEllipsis;
    TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, flags);
  }
}
}