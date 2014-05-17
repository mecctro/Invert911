using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Data;
using System.ComponentModel;

namespace Invert911.InvertCommon.Modules.Common.DynamicEntry
{
    public class RulesValidation : ValidationRule
    {
        public string module { get; set; }
        public string table { get; set; }
        public string column { get; set; }
        public ICollectionView data { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) 
        { 
            if (value != null) 
            { 
                string input = value as string;
                DataRowView drv = data.CurrentItem as DataRowView;

                //drv.DataView.Table.TableName
                //string Key = drv["Key"].ToString();
                //System.Windows.MessageBox.Show("Key: " + Key);
                string ErrorMessage = "";
                if (ValidationManager.IsValid(input, module, drv, table, column, ref ErrorMessage))
                {
                    return new ValidationResult(true, ErrorMessage); 
                }
                else
                {
                    return new ValidationResult(false, ErrorMessage); 
                }

                //if (input.Length <= 0)
                //    return new ValidationResult(false, "Validation error. Field input required.");
                //else if (input != "w") //drv[column].ToString().Trim().ToLower() != "w" )
                //    return new ValidationResult(false, "Validation error. Field input not equal to the code."); 
                //else
                //    return new ValidationResult(true, null); 
            } 

            return new ValidationResult(false, "Validation error. Field input required."); 
        }
    }
}
