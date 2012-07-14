﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouristGuide.Helpers
{
    public static class CustomHelpers
    {
        public static string Image(this HtmlHelper helper, string src, string altText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, 
            object routeValues, string imagePath, string alt, string aClass = "")
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            //imgBuilder.MergeAttribute("onMouseOver", "this.src='"+url.Content(imagePath.Insert(imagePath.Length-4,"_"))+"'");
            //imgBuilder.MergeAttribute("onMouseOut", "this.src='" + url.Content(imagePath) + "'");
            if(aClass.CompareTo("")!=0)
                imgBuilder.MergeAttribute("class", aClass);
            imgBuilder.MergeAttribute("alt", alt);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}