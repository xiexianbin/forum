using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class CreatePicture : db
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Random"] = random(4);
        this.CreatePic(Session["Random"].ToString());
    }
    public void  CreatePic(string code)
    {
        if (code == null || code == string.Empty)
            return;
        Bitmap imge = new Bitmap(code.Length * 11 + 1, 21);
        Graphics g = Graphics.FromImage(imge);
        try
        {
            Random random = new Random();
            g.Clear(Color.White);
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(imge.Width);
                int x2 = random.Next(imge.Width);
                int y1 = random.Next(imge.Height);
                int y2 = random.Next(imge.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, imge.Width, imge.Height), Color.BlueViolet, Color.Crimson, 1.2f, true);
            g.DrawString(code, font, brush, 2, 2);
            for (int i = 1; i < 80; i++)
            {
                int x = random.Next(imge.Width);
                int y = random.Next(imge.Height);
                imge.SetPixel(x, y, Color.FromArgb(random.Next()));

            }
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, imge.Width - 1, imge.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imge.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "龙龙/Gif";
            Response.BinaryWrite(ms.ToArray());

        }
        finally
        {
            g.Dispose();
            imge.Dispose();
        }
    }
}
