#pragma checksum "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d0426c3e65c4de834fb0a091e5016c1998f291e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/Index.cshtml")]
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
#line 1 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d0426c3e65c4de834fb0a091e5016c1998f291e", @"/Areas/Admin/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98a5a40f201b5766cc8c8bd6b1b6d206553db2b0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClothesASPCoreApp.Models.Products>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 4 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<br />\n<br />\n\n<div class=\"row\">\n    <div class=\"col-6\">\n        <h2 class=\"text-info\"> Product List</h2>\n    </div>\n    <div class=\"col-6 text-right\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0426c3e65c4de834fb0a091e5016c1998f291e5064", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp; New Product ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n</div>\n\n\n<br />\n<br />\n\n<div>\n    <table class=\"table table-striped border\">\n        <tr class=\"table-info\">\n            <th>\n                ");
#nullable restore
#line 27 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 30 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Vendors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 33 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Update));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 36 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 39 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 42 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Categories));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 45 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.SpecialTags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n            <th></th>\n        </tr>\n\n");
#nullable restore
#line 51 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 55 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <th>\n                    ");
#nullable restore
#line 58 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(Html.DisplayFor(m => item.Vendors.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </th>\n                <th>\n                    ");
#nullable restore
#line 61 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(Html.DisplayFor(m => item.Update));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </th>\n                <td>\n                    ");
#nullable restore
#line 64 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(String.Format("{0:c}", item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 67 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(Html.DisplayFor(m => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 70 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
               Write(Html.DisplayFor(m => item.Categories.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n");
#nullable restore
#line 73 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
                     if (!item.SpecialTags.Name.Equals("--None--"))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SpecialTags.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
                                                                    
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\n                <td>\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0d0426c3e65c4de834fb0a091e5016c1998f291e13315", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 79 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 82 "D:\Học chính thức\Năm 3\HK 2\Thương mại điện tử\Đồ án\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Products\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClothesASPCoreApp.Models.Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591
