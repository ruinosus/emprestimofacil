namespace SiteMVCTelerik.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.UI;
    using Telerik.Web.Mvc.Extensions;
    using Telerik.Web.Mvc.Infrastructure;
    using Telerik.Web.Mvc.UI;
#if MVC1 || MVC2
    using IHtmlString = System.String;
#else
    using IHtmlString = System.Web.IHtmlString;
    using Telerik.Web.Mvc;
#endif

    public static class HtmlHelpersExtensions
    {
        private static IDictionary<string, int> controllerToProductIdMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "grid", 718 },
                { "menu", 719 },
                { "panelbar", 720 },
                { "tabstrip", 721 }
            };

        public static ExampleConfigurator Configurator(this HtmlHelper html, string title)
        {
            return new ExampleConfigurator(html)
                        .Title(title);
        }
        
        public static string ExampleTitle(this HtmlHelper html)
        {
            XmlSiteMap sitemap = (XmlSiteMap)html.ViewData["telerik.mvc.examples"];
            string controller = (string)html.ViewContext.RouteData.Values["controller"];
            string action = (string)html.ViewContext.RouteData.Values["action"];

            SiteMapNode exampleSiteMapNode = sitemap.RootNode.ChildNodes
                .SelectRecursive(node => node.ChildNodes)
                .FirstOrDefault(node => controller.Equals(node.ControllerName, StringComparison.OrdinalIgnoreCase) &&
                    action.Equals(node.ActionName, StringComparison.OrdinalIgnoreCase));

            if (exampleSiteMapNode != null)
            {
                return exampleSiteMapNode.Title;
            }

            return string.Empty;
        }

        public static IHtmlString ProductMetaTag(this HtmlHelper html)
        {
            string controller = (string)html.ViewContext.RouteData.Values["controller"];

            if (!controllerToProductIdMap.ContainsKey(controller))
            {
                return string.Empty.Raw();
            }

            return String.Format("<meta name=\"ProductId\" content=\"{0}\" />", controllerToProductIdMap[controller]).Raw();
        }


        //public static IHtmlString CheckBox(this HtmlHelper html, string id, bool isChecked, string labelText)
        //{
        //    return (html.CheckBox(id, isChecked) + new HtmlTag("label").Attribute("for", id).Html(labelText).ToString()).Raw();
        //}

        public static string GetCurrentTheme(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.Request.QueryString["theme"] ?? "vista";
        }

        //public static IHtmlString WaveValidatorLink(this HtmlHelper html)
        //{
        //    var link = new HtmlTag("a")
        //        .Attributes(new
        //        {
        //            href = String.Format("http://wave.webaim.org/report?url={0}", System.Web.HttpUtility.UrlEncode(html.ViewContext.HttpContext.Request.Url.AbsoluteUri)),
        //            id = "wave-validate",
        //            @class = "t-button t-button-icontext"
        //        });

        //    new HtmlTag("span").AddClass("t-icon wave-logo").AppendTo(link);

        //    new LiteralNode("Validate with WAVE").AppendTo(link);

        //    return link.ToString().Raw();
        //}

        public static string SwitchToRazorLink(this HtmlHelper html)
        {
#if MVC3
            var link = html.ActionLink("Switch to Razor view engine",
                (string)html.ViewContext.RouteData.Values["action"],
                new { area = "razor", controller = (string)html.ViewContext.RouteData.Values["controller"] },
                new { @class = "t-button" });

            return link.ToString();
#else
            return "";
#endif
        }
    }

    public class ExampleConfigurator : IDisposable
    {
        public const string CssClass = "configurator";

        private HtmlTextWriter writer;
        private HtmlHelper htmlHelper;
        private string title;
        private MvcForm form;

        public ExampleConfigurator(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
            this.writer = new HtmlTextWriter(htmlHelper.ViewContext.Writer);
        }

        public ExampleConfigurator Title(string title)
        {
            this.title = title;

            return this;
        }

        public ExampleConfigurator Begin()
        {
            this.writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            this.writer.RenderBeginTag(HtmlTextWriterTag.Div);

            this.writer.AddAttribute(HtmlTextWriterAttribute.Class, "legend");
            this.writer.RenderBeginTag(HtmlTextWriterTag.H3);
            this.writer.Write(this.title);
            this.writer.RenderEndTag();

            return this;
        }

        public ExampleConfigurator End()
        {
            this.writer.RenderEndTag(); // fieldset

            if (this.form != null)
            {
                this.form.EndForm();
            }

            return this;
        }

        public void Dispose()
        {
            this.End();
        }

        public ExampleConfigurator PostTo(string action, string controller)
        {
            string theme = this.htmlHelper.ViewContext.HttpContext.Request.Params["theme"] ?? "vista";

            this.form = this.htmlHelper.BeginForm(action, controller, new { theme = theme });

            return this;
        }
    }
}