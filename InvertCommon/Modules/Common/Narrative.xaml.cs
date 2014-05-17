using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;

namespace Invert911.InvertCommon.Modules
{
    /// <summary>
    /// Interaction logic for Narrative.xaml
    /// </summary>
    public partial class Narrative : UserControl
    {
        //==========================================================================================================
        // http://blogs.msdn.com/b/llobo/archive/2007/01/24/printing-richtextbox-content-find-the-idle-printer.aspx
        //==========================================================================================================
        
        private DataSet mDataSet;
        private bool mIsSummaryNarrative;
        //DataView dv;

        public Narrative()
        {
            InitializeComponent();
            mainRTB.LostFocus += new RoutedEventHandler(mainRTB_LostFocus);
        }

        void mainRTB_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        public void DataBind(DataSet lDataSet, bool IsSummaryNarrative)
        {
            mDataSet = lDataSet;
            mIsSummaryNarrative = IsSummaryNarrative;
            LoadData();
        }

        public void LoadData()
        {
            string Narr;
            string NarrFormat;

            if (mIsSummaryNarrative)
            {
                Narr = mDataSet.Tables["i9Narrative"].Rows[0]["SummaryNarrative"].ToString();
                NarrFormat = mDataSet.Tables["i9Narrative"].Rows[0]["SummaryNarrativeFormat"].ToString();
            }
            else
            {
                Narr = mDataSet.Tables["i9Narrative"].Rows[0]["Narrative"].ToString();
                NarrFormat = mDataSet.Tables["i9Narrative"].Rows[0]["NarrativeFormat"].ToString();
            }

            if (String.IsNullOrEmpty(NarrFormat.Trim()) == false)
            {
                // convert string to stream
                byte[] byteArray = Encoding.ASCII.GetBytes(NarrFormat);
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    TextRange range = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
            }
        }

        public void SaveData()
        {
            TextRange sourceDocument = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
            string rtf = "";

            using (MemoryStream stream = new MemoryStream())
            {
                sourceDocument.Save(stream, DataFormats.Rtf);
                stream.Seek(0, SeekOrigin.Begin);

                using (StreamReader reader = new StreamReader(stream))
                {
                    rtf = reader.ReadToEnd();
                }
            }

            if (mIsSummaryNarrative)
            {
                mDataSet.Tables["i9Narrative"].Rows[0]["SummaryNarrative"] = sourceDocument.Text;
                mDataSet.Tables["i9Narrative"].Rows[0]["SummaryNarrativeFormat"] = rtf;
            }
            else
            {
                mDataSet.Tables["i9Narrative"].Rows[0]["Narrative"] = sourceDocument.Text;
                mDataSet.Tables["i9Narrative"].Rows[0]["NarrativeFormat"] = rtf;
            }
        }

        private void FontHeightComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (FontHeightComboBox.SelectedItem == null)
                return;

            ComboBoxItem cbi = (ComboBoxItem)FontHeightComboBox.SelectedItem;
            string fontHeight = (string)cbi.Content;
            if (fontHeight != null)
            {
                mainRTB.Selection.ApplyPropertyValue(System.Windows.Controls.RichTextBox.FontSizeProperty, fontHeight);
                mainRTB.Focus();
            }
        }
    }
}
