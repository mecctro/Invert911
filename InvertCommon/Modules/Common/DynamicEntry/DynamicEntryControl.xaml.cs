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
using System.ComponentModel;
using System.IO;

using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.ClientData;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.StandardGui;

namespace Invert911.InvertCommon.Modules.Common.DynamicEntry
{
    /// <summary>
    /// Interaction logic for DynamicEntryControl.xaml
    /// </summary>
    public partial class DynamicEntryControl : UserControl
    {
        private DataView mDataView;
        //private DataSet mDataSet;

        private DataTable mTableSchema;
        
        private ICollectionView mCollectionView;
        
        private Brush BrushDefault;
        private string mTableName;
        private string mModuleSection;



//<TabControl>
//            <TabItem Header="Horizonatal">
//                <DockPanel Name="HorizonatalDP">
//                    <!--<StackPanel DockPanel.Dock="Top" Name="StackPanelss" Orientation="Horizontal" Margin="3" VerticalAlignment="Top">
//                        <Button Height="25"  Width="75" Click="FirstButton_Click" >First</Button>
//                        <Button Height="25" Width="75" Click="PreviousButton_Click">Previous</Button>
//                        <Button Height="25" Width="75" Click="ForwardButton_Click" >Forward</Button>
//                        <Button Height="25" Width="75" Click="LastButton_Click" >Last</Button>
//                    </StackPanel>-->
//                    <WrapPanel Name="MainWrapPanel">

//                    </WrapPanel>
//                </DockPanel>
//            </TabItem>
//            <TabItem Header="Stack Pannel">
//                <DockPanel Name="StackPannelDP">
//                    <!--<StackPanel DockPanel.Dock="Top" Name="StackPanel1" Orientation="Horizontal" Margin="3" VerticalAlignment="Top">
//                        <Button Height="25" Name="FirstButton" Width="75" Click="FirstButton_Click" >First</Button>
//                        <Button Height="25" Name="PreviousButton" Width="75" Click="PreviousButton_Click">Previous</Button>
//                        <Button Height="25" Name="ForwardButton" Width="75" Click="ForwardButton_Click" >Forward</Button>
//                        <Button Height="25" Name="LastButton" Width="75" Click="LastButton_Click" >Last</Button>
//                    </StackPanel>-->
//                    <Grid Name="Grid1">
//                        <Grid.ColumnDefinitions>
//                            <ColumnDefinition Width="Auto"/>
//                            <ColumnDefinition Width="200*"/>
//                        </Grid.ColumnDefinitions>
//                        <StackPanel Name="StackLabels" Margin="3" Grid.Column="0">

//                        </StackPanel>
//                        <StackPanel Grid.Column="1" Name="StackFields" Margin="3">

//                        </StackPanel>
//                    </Grid>
//                </DockPanel>
//            </TabItem>
//            <!--<TabItem Header="Setup">
//                <DockPanel Name="SetupDP">
//                    <StackPanel DockPanel.Dock="Top" Name="SetUpStackPanel" Orientation="Horizontal" Margin="3" VerticalAlignment="Top">
//                        <Label Height="28" Name="Label1"  HorizontalContentAlignment="Right" FontWeight="Bold">ID</Label>
//                        <TextBox Height="25" Name="txtSearch" Width="120" TextChanged="TextBox_TextChanged" LostFocus="TextBox_LostFocus">1</TextBox>
//                        <Button Height="25" Name="btnFind" Width="75" >Find</Button>
//                        <Button Height="25" Name="btnSave" Width="75">Save</Button>
//                    </StackPanel>
//                    <WrapPanel Name="SetupWrapPanel">

//                    </WrapPanel>
//                </DockPanel>
//            </TabItem>-->
//        </TabControl>

                        

        public DynamicEntryControl()
        {
            InitializeComponent();
        }
  
        public void DataBind(DataView lDataView, string ModuleSection, string TableName)
        {
            this.mTableName = TableName;
            this.mModuleSection = ModuleSection;
            this.mDataView = lDataView;     //this.mDataSet.Tables[this.mTableName].DefaultView;

            this.DataContext = mDataView;
            this.mCollectionView = CollectionViewSource.GetDefaultView(mDataView);
        

            if (MainWrapPanel.Children.Count <= 0)
            {
                
                GetSchema();
                //BuildStackUI();
                BuildHorizontalUI();
            }
        }

        private void GetSchema()
        {
            //string sql = File.ReadAllText("GetTableSchema.sql");
            //sql = sql.Replace("@table", this.mModuleSection);
            string sql = "SELECT * FROM i9DynamicEntryConfig WHERE ModuleSection = '" + this.mModuleSection + "' ORDER BY DisplayOrder";
            this.mTableSchema = new ClientDataAccess().GetDataTable(sql, "i9DynamicEntryConfig");
        }

        private void BuildHorizontalUI()
        {
            try
            {
                //Clear Old Controls
                foreach (Control c in MainWrapPanel.Children)
                {
                    MainWrapPanel.Children.Remove(c);
                }

                //TODO:  Need to sort the mTableSchema table

                //Clear new Controls
                foreach (DataRow dr in mTableSchema.Rows)
                {

                    if (dr["Enabled"].ToString() != "0")
                    {
                        string ColumnName = dr["ColumnName"].ToString();
                        string LabelText = dr["LabelText"].ToString();
                        Label l = new Label()
                        {
                            Height = 28,
                            Name = ColumnName + "Label",
                            HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left,
                            Content = LabelText
                        };

                        
                        //tb.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
                        //tb.LostFocus += new RoutedEventHandler(TextBox_LostFocus);
                        //AddRules(tb);

                        RulesValidation myRulesValidation = new RulesValidation();
                        myRulesValidation.module = this.mModuleSection;
                        myRulesValidation.table = this.mTableName;
                        myRulesValidation.column = ColumnName;
                        myRulesValidation.data = mCollectionView;

                        Binding bindMyColumn = new Binding();
                        bindMyColumn.Path = new PropertyPath(ColumnName);
                        bindMyColumn.ValidationRules.Clear();
                        bindMyColumn.ValidationRules.Add(myRulesValidation);
                        bindMyColumn.ValidatesOnDataErrors = true;

                        StackPanel sp = new StackPanel();
                        sp.Children.Add(l);

                        //UIElement InputObject;
                        switch (dr["CtrlTypeName"].ToString())
                        {
                            case "i9TextBox":
                                i9TextBox i9tb = new i9TextBox()
                                {
                                    Height = 28,
                                    Name = ColumnName + "TextBox",
                                    TextAlignment = System.Windows.TextAlignment.Left,
                                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right,
                                };

                                i9tb.IsReadOnly = false;
                                if (dr["IsReadOnly"].ToString() != "0")
                                {
                                    i9tb.IsReadOnly = true;
                                }

                                if (dr["MaxLength"] is DBNull)
                                {
                                    //Do Nothing
                                    Console.WriteLine("MaxLength is db null");
                                }
                                else
                                {
                                    i9tb.MaxLength = System.Convert.ToInt32(dr["MaxLength"].ToString());
                                }

                                i9tb.SetBinding(TextBox.TextProperty, bindMyColumn);
                                sp.Children.Add(i9tb);
                                break;


                            case "i9ComboBox":
                                i9ComboBox i9cb = new i9ComboBox()
                                {
                                    Height = 28,
                                    Name = ColumnName + "ComboBox",
                                    //TextAlignment = System.Windows.TextAlignment.Left,
                                    //HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right,
                                };



                                i9cb.IsReadOnly = false;
                                if (dr["IsReadOnly"].ToString() != "0")
                                {
                                    i9cb.IsReadOnly = true;
                                }

                                if (dr["MaxLength"] is DBNull)
                                {
                                    //Do Nothing
                                    Console.WriteLine("MaxLength is db null");
                                }
                                else
                                {
                                    i9cb.MaxLength = System.Convert.ToInt32(dr["MaxLength"].ToString());
                                }

                                if (dr["CodeSetName"] != DBNull.Value)
                                    i9cb.i9BindCodeSetName = dr["CodeSetName"].ToString();


                                i9cb.DisplayMemberPath = "Code"; 
                                i9cb.SelectedValuePath="Code";
                                i9cb.SelectedValue = ColumnName;

                                i9cb.SetComboBoxEvents();

                                i9cb.SetBinding(ComboBox.TextProperty, bindMyColumn);
                                //i9cb.SetBinding(ComboBox.SelectedItemProperty, bindMyColumn);
                                
                                sp.Children.Add(i9cb);
                                break;

                            default:
                                TextBox tb = new TextBox()
                                {
                                    Height = 28,
                                    Name = ColumnName + "TextBox",
                                    TextAlignment = System.Windows.TextAlignment.Left,
                                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right,
                                };
                                tb.SetBinding(TextBox.TextProperty, bindMyColumn);
                                sp.Children.Add(tb);
                                break;
                        }
                        
                        //bindMyColumn.Source = mDataView;
                        sp.Margin = new Thickness(0, 5, 5, 0);
                        MainWrapPanel.Children.Add(sp);
                    }
                    else
                    {
                        LogManager.Instance.LogMessage("Disabled ColumnName " + dr["ColumnName"].ToString());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                LogManager.Instance.LogMessage("DynamicEntryControl", "BuildHorizontalUI", "Error FileNotFoundException", ex);
            }
        }


        //private void CodeSetNameComboBox_DropDownOpened(object sender, EventArgs e)
        //{
        //    i9ComboBox i9cb = (i9ComboBox)sender;

        //    if (!String.IsNullOrEmpty(i9cb.i9BindCodeSetName) && i9cb.Items.Count <= 0)
        //    {
        //        ClientDataAccess cda = new ClientDataAccess();
        //        DataTable dt = cda.GetDataTable("SELECT Code, CodeText FROM i9Code WHERE Enabled <> 0 AND CodeSetName = " + DataAccessUtilities.GetDBStr(i9cb.i9BindCodeSetName) + " Order By CodeText ", "i9Code");
        //        i9ComboBox.PopulateCombobox(i9cb, dt, "i9Code");
        //    }
        //}

        //private void BuildStackUI()
        //{
        //    try
        //    {
        //        foreach (DataRow dr in mTableSchema.Tables[this.mTableName].Rows)
        //        {
        //            string ColumnName = dr["ColumnName"].ToString();
        //            Label l = new Label() 
        //            {
        //                Height=28,
        //                Name=ColumnName + "Label",
        //                HorizontalContentAlignment= System.Windows.HorizontalAlignment.Right,
        //                Content = ColumnName
        //            };

        //            TextBox tb = new TextBox() 
        //            {
        //                Height=28,
        //                Name=ColumnName + "TextBox",
        //                TextAlignment = System.Windows.TextAlignment.Left,
        //                HorizontalContentAlignment= System.Windows.HorizontalAlignment.Right,
        //            };

        //            //tb.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
        //            //tb.LostFocus += new RoutedEventHandler(TextBox_LostFocus);
        //            //AddRules(tb);

        //            RulesValidation myRulesValidation = new RulesValidation();
        //            myRulesValidation.module = "TestModule";
        //            myRulesValidation.table = this.mTableName;
        //            myRulesValidation.column = ColumnName;
        //            myRulesValidation.data = mCollectionView;

        //            Binding bindMyColumn = new Binding();
        //            bindMyColumn.Path = new PropertyPath(ColumnName);
        //            bindMyColumn.ValidationRules.Clear();
        //            bindMyColumn.ValidationRules.Add(myRulesValidation);
        //            bindMyColumn.ValidatesOnDataErrors = true;
        //            tb.SetBinding(TextBox.TextProperty, bindMyColumn);
        //            //bindMyColumn.Source = mDataView;

        //            StackLabels.Children.Add(l);
        //            StackFields.Children.Add(tb);
        //        }
        //    }
        //    catch (FileNotFoundException ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        private void AddRules(TextBox tb)
        {
            if (tb.Name.ToLower() == "phonetypecodetextbox")
            {
                DynamicRules mDynRules = new DynamicRules();
                DynamicRule dr = new DynamicRule() { RuleEquals = "W" };
                mDynRules.Add(dr);

                tb.Tag = mDynRules;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateRule(e.OriginalSource);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateRule(e.OriginalSource);
        }

        private void ValidateRule(object OriginalSource)
        {
  
            if (OriginalSource is TextBox)
            {
                TextBox tb = OriginalSource as TextBox;
                if (tb.Tag != null)
                {
                    DynamicRules dr = tb.Tag as DynamicRules;
                    if (dr != null)
                    {
                        foreach (DynamicRule r in dr)
                        {
                            if (r.RuleEquals.ToLower() != tb.Text.Trim().ToLower())
                            {
                                if(BrushDefault == null)
                                    BrushDefault = tb.BorderBrush;

                                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                                
                                return;
                            }
                        }
                    }
                }
                //tb.BorderBrush = System.Windows.Media.LinearGradientBrush.;
                if (BrushDefault != null)
                    tb.BorderBrush = BrushDefault;
            }
        }

        //private void ForwardButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (mCollectionView.MoveCurrentToNext() == false)
        //        mCollectionView.MoveCurrentToLast();
        //}

        //private void PreviousButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (mCollectionView.MoveCurrentToPrevious() == false)
        //        mCollectionView.MoveCurrentToFirst();
        //}

        //private void FirstButton_Click(object sender, RoutedEventArgs e)
        //{
        //    mCollectionView.MoveCurrentToFirst();
        //}

        //private void LastButton_Click(object sender, RoutedEventArgs e)
        //{
        //    mCollectionView.MoveCurrentToLast();
        //}

    }
}
