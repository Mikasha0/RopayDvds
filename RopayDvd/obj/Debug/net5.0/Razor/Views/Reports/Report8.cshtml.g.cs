#pragma checksum "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19fa5d6f9627ef7b140f3d4b71901b99d91456c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_Report8), @"mvc.1.0.view", @"/Views/Reports/Report8.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19fa5d6f9627ef7b140f3d4b71901b99d91456c2", @"/Views/Reports/Report8.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc3e2d055f51c7015617562fd7534dbca520dc3", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_Report8 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RopayDvd.Models.Member>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
  
    ViewData["Title"] = "Alphabetic List of Members";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 7 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Member Name
            </th>
            <th>
                Member Category
            </th>
            <th>
                Loan Count
            </th>            
            <th>Remarks</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 24 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
               Write(item.MemberFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;");
#nullable restore
#line 28 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
                                           Write(item.MemberLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
               Write(item.MembershipCategoryNumberNavigation.MembershipCategoryDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
               Write(item.Loans.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 37 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
                     if (item.Loans.Count > item.MembershipCategoryNumberNavigation.MembershipCategoryTotalLoans)
                    { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-danger\">Too many DVDs</span>\r\n");
#nullable restore
#line 40 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report8.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RopayDvd.Models.Member>> Html { get; private set; }
    }
}
#pragma warning restore 1591
