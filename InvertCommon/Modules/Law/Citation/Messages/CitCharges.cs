using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace LawRecords.Citation
{
    public class CitCharges : CollectionBase
    {
        public CitCharges()
        {
            //Refresh();
        }

        /// <summary>
        /// Strongly Typed Accessor 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CitCharge this[int index]
        {
            get
            {
                return (CitCharge)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public void Add(CitCharge newCitation)
        {
            this.List.Add(newCitation);
        }

        public void Remove(CitCharge newCitation)
        {
            this.List.Remove(newCitation);
        }

        public CitCharge GetCitCharge(string key)
        {
            foreach (CitCharge c in this.List)
            {
                if(c.Key == key)
                {
                    return c;
                }
            }
            return null;
        }

        //public void Refresh()
        //{
        //    this.List.Clear();

        //    //TODO:  Need some error handling

        //    foreach (string FileName in Directory.GetFiles(Globals.CitationsPath))
        //    {
        //        CitCharge c = new CitCharge(FileName);
        //        this.List.Add(c);
        //    }
        //}
    }
}
