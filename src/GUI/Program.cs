using System;
using System.IO;
using System.Windows.Forms;

namespace DoomWriter.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(!File.Exists(TextRendererBase.DefaultFontPath))
            {
                MessageBox.Show(
                    "Primary font file not found!" + Environment.NewLine +
                    $"A file called '{Path.GetFileName(TextRendererBase.DefaultFontPath)}' should be located in the same directory as the application." + Environment.NewLine + Environment.NewLine +
                    "If you cannot find the file, try downloading Doom Writer again. If the problem persists, please contact the author.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error
                );

                Application.Exit();
                return;
            }

            var mainForm = new MainForm();

            try
            {
                mainForm.Initialize();
            }
            catch(Exception ex)
            {
                if(ex is DoomWriterException && ex.InnerException != null)
                {
                    MessageBox.Show(
                        $"{ex.Message}:" + Environment.NewLine + Environment.NewLine + ex.InnerException.ToString(),
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Failed to initialize the application:" + Environment.NewLine + Environment.NewLine + ex.ToString(),
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }

                Application.Exit();
                return;
            }

            Application.Run(mainForm);
        }
    }
}