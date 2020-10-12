#pragma checksum "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b32c9ef0d43a4c0a87c8b1eb8da86fa14518ef97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyPurchases_Index), @"mvc.1.0.view", @"/Views/MyPurchases/Index.cshtml")]
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
#line 1 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\_ViewImports.cshtml"
using ASP_CA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\_ViewImports.cshtml"
using ASP_CA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b32c9ef0d43a4c0a87c8b1eb8da86fa14518ef97", @"/Views/MyPurchases/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d825ddfae2e4b12677f93dc72841e21ac655b13", @"/Views/_ViewImports.cshtml")]
    public class Views_MyPurchases_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
  
    var myPurchases = (List<MyPurchase>)ViewData["MyPurchases"];
    var summariseMyPurchases = (List<SummariseMyPurchase>)ViewData["SummariseMyPurchases"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
 if (ViewData["MyPurchases"] == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>Empty</div>\r\n");
#nullable restore
#line 12 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
         foreach (var summariseMyPurchase in summariseMyPurchases)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>Name: ");
#nullable restore
#line 20 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                  Write(summariseMyPurchase.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div>Purchased on: ");
#nullable restore
#line 21 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                          Write(summariseMyPurchase.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div>Amount ");
#nullable restore
#line 22 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                   Write(summariseMyPurchase.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            WriteLiteral("            <select>\r\n");
#nullable restore
#line 25 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                 foreach (var myPurchase in myPurchases)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                     if (myPurchase.ProductName == summariseMyPurchase.ProductName && myPurchase.TimeStamp == summariseMyPurchase.Timestamp)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b32c9ef0d43a4c0a87c8b1eb8da86fa14518ef975900", async() => {
#nullable restore
#line 29 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                           Write(myPurchase.ActivationCode);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 30 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n");
#nullable restore
#line 33 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 37 "C:\Users\e0641583\Documents\GitHub\asp.net-core-CA\ASP_CA\ASP_CA\Views\MyPurchases\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591