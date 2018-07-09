/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/05/2012
 * Time: 15:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WordListAnalyser2
{
	partial class FormOpenFiles
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonBrowseFile2 = new System.Windows.Forms.Button();
			this.buttonBrowseFile1 = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelA = new System.Windows.Forms.Label();
			this.labelB = new System.Windows.Forms.Label();
			this.pathLabelA = new StemmingTester.PathLabel();
			this.pathLabelB = new StemmingTester.PathLabel();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// buttonBrowseFile2
			// 
			this.buttonBrowseFile2.Location = new System.Drawing.Point(277, 52);
			this.buttonBrowseFile2.Name = "buttonBrowseFile2";
			this.buttonBrowseFile2.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowseFile2.TabIndex = 3;
			this.buttonBrowseFile2.Text = "Browse...";
			this.buttonBrowseFile2.UseVisualStyleBackColor = true;
			this.buttonBrowseFile2.Click += new System.EventHandler(this.ButtonBrowseFile2Click);
			// 
			// buttonBrowseFile1
			// 
			this.buttonBrowseFile1.Location = new System.Drawing.Point(277, 20);
			this.buttonBrowseFile1.Name = "buttonBrowseFile1";
			this.buttonBrowseFile1.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowseFile1.TabIndex = 4;
			this.buttonBrowseFile1.Text = "Browse...";
			this.buttonBrowseFile1.UseVisualStyleBackColor = true;
			this.buttonBrowseFile1.Click += new System.EventHandler(this.ButtonBrowseFile1Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(145, 142);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(277, 142);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// labelA
			// 
			this.labelA.Location = new System.Drawing.Point(12, 25);
			this.labelA.Name = "labelA";
			this.labelA.Size = new System.Drawing.Size(15, 14);
			this.labelA.TabIndex = 7;
			this.labelA.Text = "A";
			// 
			// labelB
			// 
			this.labelB.Location = new System.Drawing.Point(12, 55);
			this.labelB.Name = "labelB";
			this.labelB.Size = new System.Drawing.Size(16, 20);
			this.labelB.TabIndex = 8;
			this.labelB.Text = "B";
			// 
			// pathLabelA
			// 
			this.pathLabelA.BackColor = System.Drawing.SystemColors.Window;
			this.pathLabelA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pathLabelA.Location = new System.Drawing.Point(33, 21);
			this.pathLabelA.Name = "pathLabelA";
			this.pathLabelA.Size = new System.Drawing.Size(234, 20);
			this.pathLabelA.TabIndex = 9;
			this.pathLabelA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.pathLabelA.Click += new System.EventHandler(this.PathLabelAClick);
			// 
			// pathLabelB
			// 
			this.pathLabelB.BackColor = System.Drawing.SystemColors.Window;
			this.pathLabelB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pathLabelB.Location = new System.Drawing.Point(33, 55);
			this.pathLabelB.Name = "pathLabelB";
			this.pathLabelB.Size = new System.Drawing.Size(234, 20);
			this.pathLabelB.TabIndex = 10;
			this.pathLabelB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// FormOpenFiles
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(364, 189);
			this.Controls.Add(this.pathLabelB);
			this.Controls.Add(this.pathLabelA);
			this.Controls.Add(this.labelB);
			this.Controls.Add(this.labelA);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonBrowseFile1);
			this.Controls.Add(this.buttonBrowseFile2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOpenFiles";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open the two files to compare";
			this.Load += new System.EventHandler(this.FormOpenFilesLoad);
			this.ResumeLayout(false);

		}
		private StemmingTester.PathLabel pathLabelB;
		private StemmingTester.PathLabel pathLabelA;
		private System.Windows.Forms.Label labelB;
		private System.Windows.Forms.Label labelA;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonBrowseFile1;
		private System.Windows.Forms.Button buttonBrowseFile2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}
