﻿//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

namespace BDInfoGUI
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxFilterLoopingPlaylists = new System.Windows.Forms.CheckBox();
            this.checkBoxAutosaveReport = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxGenerateStreamDiagnostics = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepStreamOrder = new System.Windows.Forms.CheckBox();
            this.checkBoxGenerateTextSummary = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterShortPlaylists = new System.Windows.Forms.CheckBox();
            this.textBoxFilterShortPlaylistsValue = new System.Windows.Forms.TextBox();
            this.labelPlaylistLength = new System.Windows.Forms.Label();
            this.checkBoxUseImagePrefix = new System.Windows.Forms.CheckBox();
            this.textBoxUseImagePrefixValue = new System.Windows.Forms.TextBox();
            this.checkBoxEnableSSIF = new System.Windows.Forms.CheckBox();
            this.checkBoxExtendedStreamDiagnostics = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplayChapterCount = new System.Windows.Forms.CheckBox();
            this.checkBoxSizeFormatHR = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxFilterLoopingPlaylists
            // 
            this.checkBoxFilterLoopingPlaylists.AutoSize = true;
            this.checkBoxFilterLoopingPlaylists.Checked = true;
            this.checkBoxFilterLoopingPlaylists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterLoopingPlaylists.Location = new System.Drawing.Point(14, 177);
            this.checkBoxFilterLoopingPlaylists.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxFilterLoopingPlaylists.Name = "checkBoxFilterLoopingPlaylists";
            this.checkBoxFilterLoopingPlaylists.Size = new System.Drawing.Size(199, 19);
            this.checkBoxFilterLoopingPlaylists.TabIndex = 3;
            this.checkBoxFilterLoopingPlaylists.Text = "Filter playlists that contain loops.";
            this.checkBoxFilterLoopingPlaylists.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutosaveReport
            // 
            this.checkBoxAutosaveReport.AutoSize = true;
            this.checkBoxAutosaveReport.Location = new System.Drawing.Point(14, 123);
            this.checkBoxAutosaveReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxAutosaveReport.Name = "checkBoxAutosaveReport";
            this.checkBoxAutosaveReport.Size = new System.Drawing.Size(226, 19);
            this.checkBoxAutosaveReport.TabIndex = 2;
            this.checkBoxAutosaveReport.Text = "Auto-save report on scan completion.";
            this.checkBoxAutosaveReport.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(147, 314);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 27);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(52, 314);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 27);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxGenerateStreamDiagnostics
            // 
            this.checkBoxGenerateStreamDiagnostics.AutoSize = true;
            this.checkBoxGenerateStreamDiagnostics.Checked = true;
            this.checkBoxGenerateStreamDiagnostics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGenerateStreamDiagnostics.Location = new System.Drawing.Point(14, 44);
            this.checkBoxGenerateStreamDiagnostics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxGenerateStreamDiagnostics.Name = "checkBoxGenerateStreamDiagnostics";
            this.checkBoxGenerateStreamDiagnostics.Size = new System.Drawing.Size(218, 19);
            this.checkBoxGenerateStreamDiagnostics.TabIndex = 0;
            this.checkBoxGenerateStreamDiagnostics.Text = "Include stream diagnostics in report.";
            this.checkBoxGenerateStreamDiagnostics.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeepStreamOrder
            // 
            this.checkBoxKeepStreamOrder.AutoSize = true;
            this.checkBoxKeepStreamOrder.Location = new System.Drawing.Point(14, 150);
            this.checkBoxKeepStreamOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxKeepStreamOrder.Name = "checkBoxKeepStreamOrder";
            this.checkBoxKeepStreamOrder.Size = new System.Drawing.Size(185, 19);
            this.checkBoxKeepStreamOrder.TabIndex = 4;
            this.checkBoxKeepStreamOrder.Text = "Keep original stream ordering.";
            this.checkBoxKeepStreamOrder.UseVisualStyleBackColor = true;
            // 
            // checkBoxGenerateTextSummary
            // 
            this.checkBoxGenerateTextSummary.AutoSize = true;
            this.checkBoxGenerateTextSummary.Checked = true;
            this.checkBoxGenerateTextSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGenerateTextSummary.Location = new System.Drawing.Point(14, 97);
            this.checkBoxGenerateTextSummary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxGenerateTextSummary.Name = "checkBoxGenerateTextSummary";
            this.checkBoxGenerateTextSummary.Size = new System.Drawing.Size(224, 19);
            this.checkBoxGenerateTextSummary.TabIndex = 1;
            this.checkBoxGenerateTextSummary.Text = "Include quick text summary in report.";
            this.checkBoxGenerateTextSummary.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterShortPlaylists
            // 
            this.checkBoxFilterShortPlaylists.AutoSize = true;
            this.checkBoxFilterShortPlaylists.Checked = true;
            this.checkBoxFilterShortPlaylists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterShortPlaylists.Location = new System.Drawing.Point(14, 203);
            this.checkBoxFilterShortPlaylists.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxFilterShortPlaylists.Name = "checkBoxFilterShortPlaylists";
            this.checkBoxFilterShortPlaylists.Size = new System.Drawing.Size(174, 19);
            this.checkBoxFilterShortPlaylists.TabIndex = 7;
            this.checkBoxFilterShortPlaylists.Text = "Filter playlists with length < ";
            this.checkBoxFilterShortPlaylists.UseVisualStyleBackColor = true;
            // 
            // textBoxFilterShortPlaylistsValue
            // 
            this.textBoxFilterShortPlaylistsValue.Location = new System.Drawing.Point(191, 201);
            this.textBoxFilterShortPlaylistsValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxFilterShortPlaylistsValue.MaxLength = 4;
            this.textBoxFilterShortPlaylistsValue.Name = "textBoxFilterShortPlaylistsValue";
            this.textBoxFilterShortPlaylistsValue.Size = new System.Drawing.Size(47, 23);
            this.textBoxFilterShortPlaylistsValue.TabIndex = 8;
            this.textBoxFilterShortPlaylistsValue.Text = "20";
            // 
            // labelPlaylistLength
            // 
            this.labelPlaylistLength.AutoSize = true;
            this.labelPlaylistLength.Location = new System.Drawing.Point(244, 205);
            this.labelPlaylistLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylistLength.Name = "labelPlaylistLength";
            this.labelPlaylistLength.Size = new System.Drawing.Size(24, 15);
            this.labelPlaylistLength.TabIndex = 9;
            this.labelPlaylistLength.Text = "sec";
            // 
            // checkBoxUseImagePrefix
            // 
            this.checkBoxUseImagePrefix.AutoSize = true;
            this.checkBoxUseImagePrefix.Location = new System.Drawing.Point(14, 230);
            this.checkBoxUseImagePrefix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxUseImagePrefix.Name = "checkBoxUseImagePrefix";
            this.checkBoxUseImagePrefix.Size = new System.Drawing.Size(114, 19);
            this.checkBoxUseImagePrefix.TabIndex = 10;
            this.checkBoxUseImagePrefix.Text = "Use image prefix";
            this.checkBoxUseImagePrefix.UseVisualStyleBackColor = true;
            // 
            // textBoxUseImagePrefixValue
            // 
            this.textBoxUseImagePrefixValue.Location = new System.Drawing.Point(138, 227);
            this.textBoxUseImagePrefixValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxUseImagePrefixValue.MaxLength = 4;
            this.textBoxUseImagePrefixValue.Name = "textBoxUseImagePrefixValue";
            this.textBoxUseImagePrefixValue.Size = new System.Drawing.Size(131, 23);
            this.textBoxUseImagePrefixValue.TabIndex = 11;
            this.textBoxUseImagePrefixValue.Text = "video-";
            // 
            // checkBoxEnableSSIF
            // 
            this.checkBoxEnableSSIF.AutoSize = true;
            this.checkBoxEnableSSIF.Location = new System.Drawing.Point(14, 256);
            this.checkBoxEnableSSIF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxEnableSSIF.Name = "checkBoxEnableSSIF";
            this.checkBoxEnableSSIF.Size = new System.Drawing.Size(139, 19);
            this.checkBoxEnableSSIF.TabIndex = 12;
            this.checkBoxEnableSSIF.Text = "Enable SSIF scanning.";
            this.checkBoxEnableSSIF.UseVisualStyleBackColor = true;
            // 
            // checkBoxExtendedStreamDiagnostics
            // 
            this.checkBoxExtendedStreamDiagnostics.AutoSize = true;
            this.checkBoxExtendedStreamDiagnostics.Location = new System.Drawing.Point(14, 70);
            this.checkBoxExtendedStreamDiagnostics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxExtendedStreamDiagnostics.Name = "checkBoxExtendedStreamDiagnostics";
            this.checkBoxExtendedStreamDiagnostics.Size = new System.Drawing.Size(212, 19);
            this.checkBoxExtendedStreamDiagnostics.TabIndex = 13;
            this.checkBoxExtendedStreamDiagnostics.Text = "Extended video stream diagnostics.";
            this.checkBoxExtendedStreamDiagnostics.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplayChapterCount
            // 
            this.checkBoxDisplayChapterCount.AutoSize = true;
            this.checkBoxDisplayChapterCount.Location = new System.Drawing.Point(14, 283);
            this.checkBoxDisplayChapterCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxDisplayChapterCount.Name = "checkBoxDisplayChapterCount";
            this.checkBoxDisplayChapterCount.Size = new System.Drawing.Size(221, 19);
            this.checkBoxDisplayChapterCount.TabIndex = 14;
            this.checkBoxDisplayChapterCount.Text = "Display chapter count in Playlist view";
            this.checkBoxDisplayChapterCount.UseVisualStyleBackColor = true;
            // 
            // checkBoxSizeFormatHR
            // 
            this.checkBoxSizeFormatHR.AutoSize = true;
            this.checkBoxSizeFormatHR.Checked = true;
            this.checkBoxSizeFormatHR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSizeFormatHR.Location = new System.Drawing.Point(14, 16);
            this.checkBoxSizeFormatHR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxSizeFormatHR.Name = "checkBoxSizeFormatHR";
            this.checkBoxSizeFormatHR.Size = new System.Drawing.Size(231, 19);
            this.checkBoxSizeFormatHR.TabIndex = 15;
            this.checkBoxSizeFormatHR.Text = "Stream sizes in human readable format";
            this.checkBoxSizeFormatHR.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 346);
            this.Controls.Add(this.checkBoxSizeFormatHR);
            this.Controls.Add(this.checkBoxDisplayChapterCount);
            this.Controls.Add(this.checkBoxExtendedStreamDiagnostics);
            this.Controls.Add(this.checkBoxEnableSSIF);
            this.Controls.Add(this.textBoxUseImagePrefixValue);
            this.Controls.Add(this.checkBoxUseImagePrefix);
            this.Controls.Add(this.labelPlaylistLength);
            this.Controls.Add(this.textBoxFilterShortPlaylistsValue);
            this.Controls.Add(this.checkBoxFilterShortPlaylists);
            this.Controls.Add(this.checkBoxGenerateTextSummary);
            this.Controls.Add(this.checkBoxKeepStreamOrder);
            this.Controls.Add(this.checkBoxFilterLoopingPlaylists);
            this.Controls.Add(this.checkBoxAutosaveReport);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxGenerateStreamDiagnostics);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BDInfo Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxFilterLoopingPlaylists;
        private System.Windows.Forms.CheckBox checkBoxAutosaveReport;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxGenerateStreamDiagnostics;
        private System.Windows.Forms.CheckBox checkBoxKeepStreamOrder;
        private System.Windows.Forms.CheckBox checkBoxGenerateTextSummary;
        private System.Windows.Forms.CheckBox checkBoxFilterShortPlaylists;
        private System.Windows.Forms.TextBox textBoxFilterShortPlaylistsValue;
        private System.Windows.Forms.Label labelPlaylistLength;
        private System.Windows.Forms.CheckBox checkBoxUseImagePrefix;
        private System.Windows.Forms.TextBox textBoxUseImagePrefixValue;
        private System.Windows.Forms.CheckBox checkBoxEnableSSIF;
        private System.Windows.Forms.CheckBox checkBoxExtendedStreamDiagnostics;
        private System.Windows.Forms.CheckBox checkBoxDisplayChapterCount;
        private System.Windows.Forms.CheckBox checkBoxSizeFormatHR;
    }
}