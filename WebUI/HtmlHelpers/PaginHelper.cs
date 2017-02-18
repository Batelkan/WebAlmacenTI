using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using System.Text;

namespace WebUI.HtmlHelpers
{
    public static class PaginHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PaginacionInfo paginInfo, Func<int, string> paginaURL)
        {
            StringBuilder result = new StringBuilder();
            for(int i= 1; i< paginInfo.TotalPaginas;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href",paginaURL(i));
                tag.InnerHtml = i.ToString();
                if(i== paginInfo.PaginaActual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
           
            return MvcHtmlString.Create(result.ToString());
        }


    }
}