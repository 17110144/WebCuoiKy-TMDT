#pragma checksum "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb118ca94ec24fb0fdeba68bbce1085c53040159"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Orders_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Orders/Index.cshtml")]
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
#line 1 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using ClothesASPCoreApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb118ca94ec24fb0fdeba68bbce1085c53040159", @"/Areas/Admin/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98a5a40f201b5766cc8c8bd6b1b6d206553db2b0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClothesASPCoreApp.Models.ViewModel.OrdersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb118ca94ec24fb0fdeba68bbce1085c530401594524", async() => {
                WriteLiteral("\r\n    <br /><br />\r\n    <h2 class=\"text-info\">Orders List</h2>\r\n    <br />\r\n\r\n    <div style=\"height:150px; background-color:aliceblue\" class=\"container\">\r\n");
                WriteLiteral("        <div class=\"col-12\">\r\n            <div class=\"row\" style=\"padding-top:10px;\">\r\n                <div class=\"col-2\">\r\n                    Customer Name\r\n                </div>\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 19 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-2\">\r\n                    Email\r\n                </div>\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 28 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>

            </div>
            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-2"">
                    Phone Number
                </div>
                <div class=""col-3"">
                    ");
#nullable restore
#line 37 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.Editor("searchPhone", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-2\">\r\n                    Order Date\r\n                </div>\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.Editor("searchDate", new { htmlAttributes = new { @class = "form-control", @id = "datepicker" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>

            </div>
            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-2"">
                </div>
                <div class=""col-3"">
                </div>
                <div class=""col-2"">
                </div>
                <div class=""col-2"">
                </div>
                <div class=""col-3"">
                    <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-primary form-control"">
                        <i class=""fas fa-search""></i> Search
                    </button>
                </div>

            </div>
        </div>
    </div>

    <br /><br />

    <div>
        <table class=""table table-striped border"">
            <tr class=""table-info"">
                <th>
                    ");
#nullable restore
#line 75 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 78 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().OrderDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 81 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 84 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerPhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 87 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 90 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Orders.FirstOrDefault().isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n");
#nullable restore
#line 96 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
             foreach (var item in Model.Orders)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.OrderDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerPhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 113 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
                   Write(Html.DisplayFor(m => item.isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb118ca94ec24fb0fdeba68bbce1085c5304015913860", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 119 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
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
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 122 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n    <div");
                BeginWriteAttribute("page-model", " page-model=\"", 4337, "\"", 4367, 1);
#nullable restore
#line 126 "C:\Users\vohoa\Downloads\WebCuoiKy-TMDT-master\WebCuoiKy-TMDT-master\ClothesASPCoreApp\ClothesASPCoreApp\Areas\Admin\Views\Orders\Index.cshtml"
WriteAttributeValue("", 4350, Model.PagingInfo, 4350, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" page-action=\"Index\" page-classes-enabled=\"true\"\r\n         page-class=\"btn border\" page-class-normal=\"btn btn-default active\"\r\n         page-class-selected=\"btn btn-primary active\" class=\"btn-group m-1\">\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n        $(function () {\r\n            $(\"#datepicker\").datepicker({\r\n                minDate: +1, maxDate: \"+3M\"\r\n            });\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClothesASPCoreApp.Models.ViewModel.OrdersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
