#pragma checksum "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\Main\GetDestination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "beb2bddc0dbb6c5f2e2a0ae190e408381d661aa5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_GetDestination), @"mvc.1.0.view", @"/Views/Main/GetDestination.cshtml")]
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
#line 1 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\_ViewImports.cshtml"
using Assignment9;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\_ViewImports.cshtml"
using Assignment9.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\Main\GetDestination.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"beb2bddc0dbb6c5f2e2a0ae190e408381d661aa5", @"/Views/Main/GetDestination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86bddc6c449716a90c3bc8a8a19443c8da3c5286", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_GetDestination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\Main\GetDestination.cshtml"
  
    var data = ViewData["data"] as string;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb2bddc0dbb6c5f2e2a0ae190e408381d661aa53820", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <title>All Destinations</title>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script>
        $(document).ready(function(){
            $(""#button"").click(function () {
                $.get(""/Main/GetAllDestinations"",
                    function(data,status) {
                        $(""#maindiv"").html(data);

                        $("".delete-button"").click(function (event) {
                            if (confirm('Are you sure you want to delete?')) {
                                $.post(""/Main/DeleteDestination"", { destId: event.target.id }, function () {
                                    alert(""Deleted successfully"");

                                    $(""#button"").trigger(""click"");
                                });
                            }
                        })

                        $("".update-button"").click(function () {
                       ");
                WriteLiteral(@"     console.log(""click"");
                            $.get(""/Main/UpdateDestination"", { destId: event.target.id }, function () {
                                document.location.href = '/Update';
                            });
                        })
                });
            });
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb2bddc0dbb6c5f2e2a0ae190e408381d661aa56200", async() => {
                WriteLiteral("\r\n\r\n    <h2>Welcome ");
#nullable restore
#line 43 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\Main\GetDestination.cshtml"
           Write(Context.Session.GetString("username"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <input id=\"button\" type=\"button\" value=\"Get all destinations\" />\r\n    <a href=\"/Add/\">Add Destination</a>\r\n    ");
#nullable restore
#line 46 "C:\Users\georg\Desktop\Work\University\Web\Web-Programming-Year2\Assignment9\Views\Main\GetDestination.cshtml"
Write(data);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <p>Destinations List:</p>\r\n    <div id=\"maindiv\"></div>\r\n    <br />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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