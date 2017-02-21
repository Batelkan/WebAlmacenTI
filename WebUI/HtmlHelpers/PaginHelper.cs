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
          
            //TagBuilder tagBtnAntes = new TagBuilder("a");
            //tagBtnAntes.MergeAttribute("href", paginaURL(1));
            //tagBtnAntes.InnerHtml = "1";

            //for (int i= 1; i< paginInfo.TotalPaginas;i++)
            //{
            //    TagBuilder tag = new TagBuilder("a");
            //    tag.MergeAttribute("href",paginaURL(i));
            //    tag.InnerHtml = i.ToString();
            //    if(i== paginInfo.PaginaActual)
            //    {
            //        tag.AddCssClass("selected");
            //        tag.AddCssClass("btn-primary");
            //    }

            //    tag.AddCssClass("btn btn-default");
            //    result.Append(tag.ToString());
            //}

            const int maxPages =6;

            if (paginInfo.TotalPaginas <= maxPages)
            {
              result.Append( CreadorLinks(1, paginInfo.TotalPaginas, paginaURL, null,paginInfo.PaginaActual));
                return MvcHtmlString.Create(result.ToString());
            }

            int pagesAfter = paginInfo.TotalPaginas - paginInfo.PaginaActual; // Number of pages after current
            int pagesBefore = paginInfo.PaginaActual - 1; // Number of pages before current


            if (pagesAfter <= 4)
            {
              result.Append(  CreadorLinks(1, 1, paginaURL, null, paginInfo.PaginaActual)); // Show 1st page

                 int pageSubset = paginInfo.TotalPaginas - maxPages - 1 > 1 ? paginInfo.TotalPaginas - maxPages - 1 : 2;
              result.Append(  CreadorLinks(pageSubset, pageSubset, paginaURL,"...", paginInfo.PaginaActual)); // Show page subset (...)

             result.Append( CreadorLinks(paginInfo.TotalPaginas - maxPages + 3, paginInfo.TotalPaginas, paginaURL, null, paginInfo.PaginaActual)); // Show last pages
                return MvcHtmlString.Create(result.ToString());
            }

            if (pagesBefore <= 4)
            {
                result.Append( CreadorLinks(1, maxPages - 2, paginaURL, null, paginInfo.PaginaActual)); // Show 1st pages
                int pageSubset = maxPages + 2 < paginInfo.TotalPaginas ? maxPages + 2 : paginInfo.TotalPaginas - 1;
               result.Append(CreadorLinks(pageSubset, pageSubset,paginaURL,"...", paginInfo.PaginaActual)); // Show page subset (...)
               result.Append(CreadorLinks(paginInfo.TotalPaginas, paginInfo.TotalPaginas,paginaURL ,null, paginInfo.PaginaActual)); // Show last page
                return MvcHtmlString.Create(result.ToString());
            }


            if (pagesAfter > 4)
            {
                result.Append(CreadorLinks(1, 1, paginaURL, null, paginInfo.PaginaActual)); // Show 1st pages

                 int pageSubset1 = paginInfo.PaginaActual - 7 > 1 ? paginInfo.PaginaActual - 7 : 2;
                int pageSubset2 = paginInfo.PaginaActual + 7 < paginInfo.TotalPaginas ? paginInfo.PaginaActual + 7 : paginInfo.TotalPaginas - 1;

                result.Append(CreadorLinks(pageSubset1, pageSubset1,paginaURL,pageSubset1 == paginInfo.PaginaActual - 4 ? null : "...", paginInfo.PaginaActual)); // Show 1st page subset (...)


                result.Append(CreadorLinks(paginInfo.PaginaActual - 3, paginInfo.PaginaActual + 3,paginaURL,null, paginInfo.PaginaActual)); // Show middle pages

                // Show 2nd page subset (...)
                // only show ... if page is contigous to the previous one.
                result.Append(CreadorLinks(pageSubset2, pageSubset2, paginaURL,pageSubset2 == paginInfo.PaginaActual + 4 ? null : "...", paginInfo.PaginaActual));
                result.Append(CreadorLinks(paginInfo.TotalPaginas, paginInfo.TotalPaginas, paginaURL,null, paginInfo.PaginaActual));// Show last page
                return MvcHtmlString.Create(result.ToString());
            }

            return MvcHtmlString.Create(result.ToString());

        }

      public static string CreadorLinks(int inicio,int final, Func<int, string> contenido,string icono,int paginaAct)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = inicio; i <= final; i++)
            {

                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", contenido(i));
                if(icono != null)
                {
                    tag.InnerHtml = icono;
                }
               else
                {
                    tag.InnerHtml = i.ToString();
                }
                if (i == paginaAct)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag.ToString());

            }

            return resultado.ToString();
        }
    }
}