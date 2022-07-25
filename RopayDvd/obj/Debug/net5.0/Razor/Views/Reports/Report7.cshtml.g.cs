#pragma checksum "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9e28397b78e35296889b82cb003e1131a2b17e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_Report7), @"mvc.1.0.view", @"/Views/Reports/Report7.cshtml")]
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
#line 1 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\_ViewImports.cshtml"
using RopayDvd.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9e28397b78e35296889b82cb003e1131a2b17e4", @"/Views/Reports/Report7.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc3e2d055f51c7015617562fd7534dbca520dc3", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_Report7 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RopayDvd.Models.Loan>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReturnDVDCopy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Loans", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
  
    ViewData["Title"] = "Return Member Loans";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 7 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
           Write(Html.DisplayNameFor(model => model.MemberNumberNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
           Write(Html.DisplayNameFor(model => model.LoanTypeNumberNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
           Write(Html.DisplayNameFor(model => model.CopyNumberNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
           Write(Html.DisplayNameFor(model => model.DateOut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
           Write(Html.DisplayNameFor(model => model.DateDue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>Standard Charge</th>\r\n            <th>\r\n                Penalty Charge\r\n            </th>\r\n            <th>Total Charge</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
         foreach (var item in Model)
        {
            decimal penalty = 0, standard =item.CopyNumberNavigation.DvdNumberNavigation.StandardCharge * Convert.ToInt32(DateTime.Today.Subtract(item.DateOut).TotalDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(item.MemberNumberNavigation.MemberFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;");
#nullable restore
#line 40 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                                                                  Write(item.MemberNumberNavigation.MemberLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(Html.DisplayFor(modelItem => item.LoanTypeNumberNavigation.LoanTypeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(Html.DisplayFor(modelItem => item.CopyNumberNavigation.CopyNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateOut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateDue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>                    \r\n                    ");
#nullable restore
#line 55 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
               Write(standard);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    \r\n");
#nullable restore
#line 59 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                     if(item.DateDue<DateTime.Today)
                    {
                        penalty = item.CopyNumberNavigation.DvdNumberNavigation.PenaltyCharge * Convert.ToInt32(DateTime.Today.Subtract(item.DateDue).TotalDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 62 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                         Write(penalty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 63 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>-</span>\r\n");
#nullable restore
#line 67 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 70 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                Write(standard + penalty);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e28397b78e35296889b82cb003e1131a2b17e410142", async() => {
                WriteLiteral("Return DVD Copy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
                                                                           WriteLiteral(item.LoanNumber);

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
            WriteLiteral(" \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 76 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report7.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RopayDvd.Models.Loan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
