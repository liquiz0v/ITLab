#pragma checksum "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3018edcfc490e5f32368073de984cece3f3a972"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Landing_ShortNews), @"mvc.1.0.view", @"/Views/Landing/ShortNews.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\github repos\ITLab\ITLab\ITLab\Views\_ViewImports.cshtml"
using ITLab;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github repos\ITLab\ITLab\ITLab\Views\_ViewImports.cshtml"
using ITLab.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3018edcfc490e5f32368073de984cece3f3a972", @"/Views/Landing/ShortNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48213bc9fc207f7285f08093caaa831df5f94cdf", @"/Views/_ViewImports.cshtml")]
    public class Views_Landing_ShortNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ITLab.Client_Objects.ShortNews>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FullNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!--news template-->\r\n\r\n");
#nullable restore
#line 6 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"slider-news news_block\">\r\n\r\n        <div class=\"news-date\">\r\n            <span>");
#nullable restore
#line 11 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
             Write(item.TimeDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"slider-news-header\"");
            BeginWriteAttribute("style", " style=\"", 279, "\"", 327, 4);
            WriteAttributeValue("", 287, "background-image:", 287, 17, true);
            WriteAttributeValue(" ", 304, "url(\'", 305, 6, true);
#nullable restore
#line 13 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
WriteAttributeValue("", 310, item.HeadPhoto, 310, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 325, "\')", 325, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n        <div class=\"news-body\">\r\n            <span>«");
#nullable restore
#line 15 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <p><span>");
#nullable restore
#line 16 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
                Write(item.CommentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> комментариев / <span>");
#nullable restore
#line 16 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
                                                                Write(item.ViewsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> просмотров</p>\r\n            <p>\r\n                ");
#nullable restore
#line 18 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
           Write(item.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3018edcfc490e5f32368073de984cece3f3a9725734", async() => {
                WriteLiteral("\r\n            <div class=\"news-button\">\r\n                <button>Подробнее</button> <!--ПОФИКСИТЬ-->\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 27 "D:\github repos\ITLab\ITLab\ITLab\Views\Landing\ShortNews.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!--end news template-->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ITLab.Client_Objects.ShortNews>> Html { get; private set; }
    }
}
#pragma warning restore 1591
