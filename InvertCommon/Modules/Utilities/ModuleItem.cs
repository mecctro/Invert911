using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Modules
{
    public enum ModuleTypeEnum
    {
        Window,
        Form,
        Page,
        None
    }

    public class ModuleItem
    {
        public string i9ModuleID {get;set;}
        public string ModuleKey { get; set; }
        public string ClassName { get; set; }
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public string Section { get; set; }
        public bool PopupPage {get;set;}
        public bool DesktopEnabled {get;set;}
        public bool MobileEnabled {get;set;}
        public ModuleTypeEnum ModuleType {get;set;} 
        public object Instance = null;
        public bool IsDemoModule { get; set; }

        public ModuleItem()
        {
            this.PopupPage = false;
            this.DesktopEnabled = true;
            this.MobileEnabled = false;
            this.ModuleType = ModuleTypeEnum.Page;
            this.IsDemoModule = false;
        }

        public ModuleItem(string Key, ModuleTypeEnum lModuleType, string ClassName, string Name, string Section, bool PopupPage, bool DesktopEnabled, bool MobileEnabled, string FileName)
        {

            this.ModuleKey = Key;
            this.ModuleType = lModuleType;
            this.ClassName = ClassName;
            this.ModuleName = Name;
            this.Section = Section;
            this.PopupPage = PopupPage;
            this.DesktopEnabled = DesktopEnabled;
            this.MobileEnabled = MobileEnabled;
            this.FileName = FileName;
            this.IsDemoModule = false;
        }

        public ModuleItem(string Key, ModuleTypeEnum lModuleType, string ClassName, string Name, string Section, bool PopupPage, string FileName)
        {
           
            this.DesktopEnabled = true;
            this.MobileEnabled = false;
            this.ModuleType = ModuleTypeEnum.Page;

            this.ModuleKey = Key;
            this.ModuleType = lModuleType;
            this.ClassName = ClassName;
            this.FileName = FileName;
            this.ModuleName = Name;
            this.Section = Section;
            this.PopupPage = PopupPage;
            this.IsDemoModule = false;
        }

        public ModuleItem(string Key, ModuleTypeEnum lModuleType, string ClassName, string Name, string Section, string FileName)
        {
            this.DesktopEnabled = true;
            this.MobileEnabled = false;
            this.ModuleType = ModuleTypeEnum.Page;

            this.ModuleKey = Key;
            this.ModuleType = lModuleType;
            this.ClassName = ClassName;
            this.FileName = FileName;
            this.ModuleName = Name;
            this.Section = Section;
            this.PopupPage = true;
            this.IsDemoModule = false;
        }
    }
}
