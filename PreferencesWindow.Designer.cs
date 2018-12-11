/*
 * Created by SharpDevelop.
 * User: User
 * Date: 20/01/2016
 * Time: 16:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WordListAnalyser2
{
	partial class PreferencesWindow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox buttonIncludingFileBug;
		private System.Windows.Forms.RadioButton radioButtonNormal;
		private System.Windows.Forms.RadioButton radioButtonHooper;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonApply;
		
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonIncludingFileBug = new System.Windows.Forms.CheckBox();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonHooper = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonIncludingFileBug);
            this.groupBox1.Controls.Add(this.radioButtonNormal);
            this.groupBox1.Controls.Add(this.radioButtonHooper);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ERRT Mode";
            // 
            // buttonIncludingFileBug
            // 
            this.buttonIncludingFileBug.Enabled = false;
            this.buttonIncludingFileBug.Location = new System.Drawing.Point(24, 79);
            this.buttonIncludingFileBug.Name = "buttonIncludingFileBug";
            this.buttonIncludingFileBug.Size = new System.Drawing.Size(167, 24);
            this.buttonIncludingFileBug.TabIndex = 2;
            this.buttonIncludingFileBug.Text = "Emulate File Buffer Bug";
            this.buttonIncludingFileBug.UseVisualStyleBackColor = true;
            this.buttonIncludingFileBug.CheckedChanged += new System.EventHandler(this.ButtonIncludingFileBugCheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.Location = new System.Drawing.Point(6, 19);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(185, 24);
            this.radioButtonNormal.TabIndex = 1;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "&Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.RadioButtonNormalCheckedChanged);
            // 
            // radioButtonHooper
            // 
            this.radioButtonHooper.Location = new System.Drawing.Point(6, 49);
            this.radioButtonHooper.Name = "radioButtonHooper";
            this.radioButtonHooper.Size = new System.Drawing.Size(185, 24);
            this.radioButtonHooper.TabIndex = 0;
            this.radioButtonHooper.TabStop = true;
            this.radioButtonHooper.Text = "&Lancs bug";
            this.radioButtonHooper.UseVisualStyleBackColor = true;
            this.radioButtonHooper.CheckedChanged += new System.EventHandler(this.RadioButtonHooperCheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(144, 135);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(63, 135);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // PreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 171);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
