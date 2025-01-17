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
    partial class FormReport
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
            this.buttonCopy = new System.Windows.Forms.Button();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.buttonChart = new System.Windows.Forms.Button();
            this.labelChartType = new System.Windows.Forms.Label();
            this.comboBoxChartType = new System.Windows.Forms.ComboBox();
            this.labelStream = new System.Windows.Forms.Label();
            this.comboBoxStream = new System.Windows.Forms.ComboBox();
            this.labelAngle = new System.Windows.Forms.Label();
            this.comboBoxAngle = new System.Windows.Forms.ComboBox();
            this.labelPlaylist = new System.Windows.Forms.Label();
            this.comboBoxPlaylist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCopy.Location = new System.Drawing.Point(332, 527);
            this.buttonCopy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(142, 27);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "Copy to Clipboard";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // textBoxReport
            // 
            this.textBoxReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReport.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxReport.Location = new System.Drawing.Point(14, 59);
            this.textBoxReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxReport.MaxLength = 0;
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReport.Size = new System.Drawing.Size(779, 461);
            this.textBoxReport.TabIndex = 5;
            this.textBoxReport.WordWrap = false;
            this.textBoxReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxReport_KeyDown);
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(527, 25);
            this.buttonChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(142, 27);
            this.buttonChart.TabIndex = 4;
            this.buttonChart.Text = "Generate Chart...";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(310, 9);
            this.labelChartType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(66, 15);
            this.labelChartType.TabIndex = 47;
            this.labelChartType.Text = "Chart Type:";
            // 
            // comboBoxChartType
            // 
            this.comboBoxChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartType.FormattingEnabled = true;
            this.comboBoxChartType.Items.AddRange(new object[] {
            "Video Bitrate: 1-Second Window",
            "Video Bitrate: 5-Second Window",
            "Video Bitrate: 10-Second Window",
            "Video Frame Size (Min / Max)",
            "Video Frame Type Counts",
            "Video Frame Type Sizes"});
            this.comboBoxChartType.Location = new System.Drawing.Point(310, 28);
            this.comboBoxChartType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxChartType.Name = "comboBoxChartType";
            this.comboBoxChartType.Size = new System.Drawing.Size(209, 23);
            this.comboBoxChartType.TabIndex = 3;
            // 
            // labelStream
            // 
            this.labelStream.AutoSize = true;
            this.labelStream.Location = new System.Drawing.Point(136, 9);
            this.labelStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStream.Name = "labelStream";
            this.labelStream.Size = new System.Drawing.Size(47, 15);
            this.labelStream.TabIndex = 45;
            this.labelStream.Text = "Stream:";
            // 
            // comboBoxStream
            // 
            this.comboBoxStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStream.FormattingEnabled = true;
            this.comboBoxStream.Location = new System.Drawing.Point(136, 28);
            this.comboBoxStream.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxStream.Name = "comboBoxStream";
            this.comboBoxStream.Size = new System.Drawing.Size(115, 23);
            this.comboBoxStream.TabIndex = 1;
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(259, 9);
            this.labelAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(41, 15);
            this.labelAngle.TabIndex = 43;
            this.labelAngle.Text = "Angle:";
            // 
            // comboBoxAngle
            // 
            this.comboBoxAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAngle.FormattingEnabled = true;
            this.comboBoxAngle.Location = new System.Drawing.Point(259, 28);
            this.comboBoxAngle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxAngle.Name = "comboBoxAngle";
            this.comboBoxAngle.Size = new System.Drawing.Size(44, 23);
            this.comboBoxAngle.TabIndex = 2;
            // 
            // labelPlaylist
            // 
            this.labelPlaylist.AutoSize = true;
            this.labelPlaylist.Location = new System.Drawing.Point(14, 9);
            this.labelPlaylist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlaylist.Name = "labelPlaylist";
            this.labelPlaylist.Size = new System.Drawing.Size(47, 15);
            this.labelPlaylist.TabIndex = 41;
            this.labelPlaylist.Text = "Playlist:";
            // 
            // comboBoxPlaylist
            // 
            this.comboBoxPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaylist.FormattingEnabled = true;
            this.comboBoxPlaylist.Location = new System.Drawing.Point(14, 28);
            this.comboBoxPlaylist.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxPlaylist.Name = "comboBoxPlaylist";
            this.comboBoxPlaylist.Size = new System.Drawing.Size(115, 23);
            this.comboBoxPlaylist.TabIndex = 0;
            this.comboBoxPlaylist.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaylist_SelectedIndexChanged);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 568);
            this.Controls.Add(this.buttonChart);
            this.Controls.Add(this.labelChartType);
            this.Controls.Add(this.comboBoxChartType);
            this.Controls.Add(this.labelStream);
            this.Controls.Add(this.comboBoxStream);
            this.Controls.Add(this.labelAngle);
            this.Controls.Add(this.comboBoxAngle);
            this.Controls.Add(this.labelPlaylist);
            this.Controls.Add(this.comboBoxPlaylist);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxReport);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormReport";
            this.Text = "BDInfo Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReport_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.Button buttonChart;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox comboBoxChartType;
        private System.Windows.Forms.Label labelStream;
        private System.Windows.Forms.ComboBox comboBoxStream;
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.ComboBox comboBoxAngle;
        private System.Windows.Forms.Label labelPlaylist;
        private System.Windows.Forms.ComboBox comboBoxPlaylist;

    }
}