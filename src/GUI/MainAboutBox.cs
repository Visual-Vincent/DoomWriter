﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DoomWriter.GUI
{
    partial class MainAboutBox : Form
    {
        private readonly struct ThirdPartyItem
        {
            public string LicenseName { get; }
            public string Link { get; }

            public ThirdPartyItem(string link, string licenseName)
            {
                Link = link;
                LicenseName = licenseName;
            }
        }

        private static readonly Dictionary<string, ThirdPartyItem> thirdPartyLicenses = new Dictionary<string, ThirdPartyItem>() {
            { "ImageSharp",           new ThirdPartyItem("https://github.com/SixLabors/ImageSharp", "ImageSharp.txt") },
            { "ImageSharp (notices)", new ThirdPartyItem("https://github.com/SixLabors/ImageSharp", "ImageSharp-THIRD-PARTY-NOTICES.txt") }
        };

        public MainAboutBox()
        {
            InitializeComponent();

#pragma warning disable IDE0003 // Remove 'this'

            this.Text = $"About {Application.ProductName}";
            this.ProductNameLabel.Text = Application.ProductName;
            this.VersionLabel.Text = $"Version {Application.ProductVersion}";
            this.CopyrightLabel.Text = Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault()?.Copyright ?? "";
            this.CompanyNameLabel.Text = Application.CompanyName;

            foreach(var kvp in thirdPartyLicenses)
            {
                ThirdPartyListBox.Items.Add(kvp.Key);
            }

            ThirdPartyListBox.SelectedIndex = 0;

#pragma warning restore IDE0003
        }

        private void ThirdPartyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThirdPartyLinkLabel.Visible = ThirdPartyListBox.SelectedIndex >= 0;

            if(ThirdPartyListBox.SelectedIndex < 0)
            {
                ThirdPartyTextBox.Text = "Please select an item from the list.";
                return;
            }

            if(!thirdPartyLicenses.TryGetValue(ThirdPartyListBox.SelectedItem?.ToString(), out var item))
                return;

            using(var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(MainAboutBox).Namespace}.Licenses.{item.LicenseName}"))
            using(var streamReader = new StreamReader(resourceStream))
            {
                ThirdPartyTextBox.Text = streamReader.ReadToEnd();
            }

            ThirdPartyLinkLabel.Text = item.Link;
        }

        private void ThirdPartyLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(ThirdPartyListBox.SelectedIndex < 0)
                return;

            Process.Start(ThirdPartyLinkLabel.Text);
        }
    }
}
