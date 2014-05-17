using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

using Invert911.InvertCommon;
using Invert911.InvertCommon.Utilities;

namespace Invert911.Citation
{
    internal class Citations : CollectionBase
    {
        public delegate void RecievedMessageHandler();

        public Citations()
        {

        }

        public Citation this[int index]
        {
            get
            {
                return (Citation)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public void Add(Citation newCitation)
        {
            this.List.Add(newCitation);
        }

        public void Remove(Citation newCitation)
        {

        }

        public bool UploadCitation(string key)
        {
			return true;
        }

        public Citation GetCitation(string key)
        {
            foreach (Citation c in this.List)
            {
                if (c.Key.ToLower() == key.ToLower())
                {
                    return c;
                }
            }
            return null;
        }

        public Citation GetCitationByCitNumber(string CitNumber)
        {
            foreach (Citation c in this.List)
            {
                if (c.CitationNumber.ToLower() == CitNumber.ToLower())
                {
                    return c;
                }
            }
            return null;
        }

        public void Refresh()
        {
            try
            {
                this.List.Clear();
            }
            catch { }

            try
            {

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}