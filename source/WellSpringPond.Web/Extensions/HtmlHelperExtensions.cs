namespace WellSpringPond.Web.Extensions
{
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string url, string alt, string cssClasses)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass(cssClasses);
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alt);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}