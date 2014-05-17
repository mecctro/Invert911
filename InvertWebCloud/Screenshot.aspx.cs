using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace Invert911_WebSite
{
    public partial class Screenshot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);

            //if (DisplayLargeImagesCheckBox.Checked)
            //    Image1.Width = new Unit(); //null; //new Unit("100%");
            //else
            //    Image1.Width = new Unit("900px");

            //if (!Page.IsPostBack)
            //{
            //    ListImages();
            //}


            xmlGeneratedContent.InnerHtml = ListImagesLinks();

        }

        //protected void btndel_Click(object sender, EventArgs e)
        //{
            
        //    foreach (ListItem li in ListBox1.Items)
        //    {
        //        if (li.Selected)
        //        {
        //           // File.Delete(Server.MapPath(Dir + li.Text));
        //        }
        //    }
        //    //lblerror.Text = "Selected files deleted successfully.";
        //}

        //protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            

        //   int cnt = ListBox1.Items.Count; // count the items in listbox
        //    for (int i = 0; i <= cnt - 1; i++)
        //    {
        //        if (ListBox1.Items[i].Selected == true)
        //        {
        //            // Will display the selected image
        //            string imagename = ListBox1.Items[i].Text;
        //            imagename = "Invert911_" + imagename.Replace(" ", "_") + ".png";
        //            string ssurl = "~/Screenshots/" + imagename;
        //            Image1.ImageUrl = ssurl;
        //        }
        //    }
        //}

        public string ListImagesLinks()
        {
            string Results = "";
            DirectoryInfo dir = new DirectoryInfo(MapPath("~/Screenshots/"));
            FileInfo[] fileArray = dir.GetFiles();
            ArrayList list = new ArrayList();

            foreach (FileInfo file2 in fileArray)
            {
                if (file2.Extension == ".png" || file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif")
                {
                    string imageName = file2.Name.Replace("Invert911_", "");
                    imageName = imageName.Replace(".png", "");
                    imageName = imageName.Replace("_", " ");

                    string imageURL = "/Screenshots/" + file2.Name;

                    Results += @"<li> <a href='" + imageURL + "'>" + imageName + "</a>  </li> ";
                }
            }

            return Results;
        }

        //private void ListImages()
        //{
        //    DirectoryInfo dir = new DirectoryInfo(MapPath("~/Screenshots/"));
        //    FileInfo[] fileArray = dir.GetFiles();
        //    ArrayList list = new ArrayList();

        //    foreach (FileInfo file2 in fileArray)
        //    {
        //        if (file2.Extension == ".png" ||  file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif")
        //        {
        //            string imagename = file2.Name.Replace("Invert911_", "");
        //            imagename = imagename.Replace(".png", "");
        //            imagename = imagename.Replace("_", " ");
        //            list.Add(imagename);
        //        }
        //    }
        //    ListBox1.Items.Clear();
        //    ListBox1.DataSource = list;
        //    ListBox1.DataBind();
        //}
    }
}