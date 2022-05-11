using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace SoftwareHouseManagement.Helpers
{
    public static class ActiveMenuExtension
    {
        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, string actions, string cssClass = "active-menu")
        {
            string currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;

            IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');

            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                cssClass : String.Empty;
        }

        private static readonly HtmlContentBuilder _emptyBuilder = new HtmlContentBuilder();
        public static string Titleize(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).ToSentenceCase();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }

        public static string TimeStampConverter(this TimeSpan ts)
        {
            return string.Format($"{(int)ts.TotalHours}:{ts:mm}");
        }

        public static IHtmlContent BuildBreadcrumbNavigation(this IHtmlHelper helper)
        {
            if //(helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                (helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return _emptyBuilder;
            }

            string controllerName = helper.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();

            var breadcrumb = new HtmlContentBuilder()
                .AppendHtml("<ol class='breadcrumb'><li>")
                .AppendHtml(helper.ActionLink("Home", "Index", "Home"))
                .AppendHtml("</li><li>")
                .AppendHtml(helper.ActionLink(controllerName.Titleize(),
                    "Index", controllerName))
                .AppendHtml("</li>");


            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.AppendHtml("<li>")
                    .AppendHtml(helper.ActionLink(actionName.Titleize(), actionName, controllerName))
                    .AppendHtml("</li>");
            }

            return breadcrumb.AppendHtml("</ol>");
            
        }
    }
}
