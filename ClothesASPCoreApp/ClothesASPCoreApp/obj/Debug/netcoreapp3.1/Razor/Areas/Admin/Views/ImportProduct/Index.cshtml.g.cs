#pragma checksum "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "055a82da2df972c744e85066faf7f0d4f9086cb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ImportProduct_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ImportProduct/Index.cshtml")]
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
#line 1 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"055a82da2df972c744e85066faf7f0d4f9086cb2", @"/Areas/Admin/Views/ImportProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77aaaab402b3e9002ed597d545527b8af303f92e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ImportProduct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClothesASPCoreApp.Models.ImportProductDetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<br />\n<br />\n\n<div class=\"row\">\n    <div class=\"col-6\">\n        <h2 class=\"text-info\">Danh sách thông tin nhập hàng</h2>\n    </div>\n    <div class=\"col-6 text-right\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "055a82da2df972c744e85066faf7f0d4f9086cb24578", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp;Nhập hàng mới");
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
            WriteLiteral("\n    </div>\n</div>\n\n<br />\n<div>\n    <table class=\"table table-striped border\">\n        <tr class=\"table-info\">\n            <th>\n                ");
#nullable restore
#line 24 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.DateImport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                Tên sản phẩm\n            </th>\n            <th>\n                ");
#nullable restore
#line 30 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.AmountProduct));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n\n");
#nullable restore
#line 35 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 39 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
               Write(Html.DisplayFor(m => item.DateImport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 42 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
               Write(Html.DisplayFor(m => item.Products.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 45 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
               Write(Html.DisplayFor(m => item.AmountProduct));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td></td>\n            </tr>\n");
#nullable restore
#line 49 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master (1)\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\ImportProduct\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClothesASPCoreApp.Models.ImportProductDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
