#pragma checksum "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80471f414213a5fb26e3f3ebab969feeb86bc08d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_Report12), @"mvc.1.0.view", @"/Views/Reports/Report12.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80471f414213a5fb26e3f3ebab969feeb86bc08d", @"/Views/Reports/Report12.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc3e2d055f51c7015617562fd7534dbca520dc3", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_Report12 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RopayDvd.Models.Loan>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
  
    ViewData["Title"] = "Report 12";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 7 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
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
                Address
            </th>
            <th>
                Issued Date
            </th>
            <th>
                Dvd Title
            </th>
            <th>
                Loan Age (Day)
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 29 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
            Write(item.MemberNumberNavigation.MemberFirstName+ " "+item.MemberNumberNavigation.MemberLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
           Write(item.MemberNumberNavigation.MemberAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
           Write(item.DateOut.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>            \r\n            <td>                \r\n                ");
#nullable restore
#line 41 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
           Write(item.CopyNumberNavigation.DvdNumberNavigation.DvdTite);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
           Write(DateTime.Today.Subtract(item.DateOut).TotalDays);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 47 "C:\Users\97798\Desktop\RopayDvd\RopayDvd\Views\Reports\Report12.cshtml"
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
