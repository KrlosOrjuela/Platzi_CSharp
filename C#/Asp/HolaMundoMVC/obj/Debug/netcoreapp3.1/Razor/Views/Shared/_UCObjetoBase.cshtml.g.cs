#pragma checksum "D:\GitHub\C#\Asp\HolaMundoMVC\Views\Shared\_UCObjetoBase.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cee54ab309b34bf54d1e8c4fa1facdf69e3c0c15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UCObjetoBase), @"mvc.1.0.view", @"/Views/Shared/_UCObjetoBase.cshtml")]
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
#line 1 "D:\GitHub\C#\Asp\HolaMundoMVC\Views\_ViewImports.cshtml"
using HolaMundoMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\C#\Asp\HolaMundoMVC\Views\_ViewImports.cshtml"
using HolaMundoMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\C#\Asp\HolaMundoMVC\Views\Shared\_UCObjetoBase.cshtml"
using HolaMundoMVC.Models.ModelosProyectoEscuela.ObjetosBaseEInterfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cee54ab309b34bf54d1e8c4fa1facdf69e3c0c15", @"/Views/Shared/_UCObjetoBase.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd844b5729bef53cbee2b226a2f3054d035bc852", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UCObjetoBase : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<p>\n   <strong>Nombre: </strong> ");
#nullable restore
#line 6 "D:\GitHub\C#\Asp\HolaMundoMVC\Views\Shared\_UCObjetoBase.cshtml"
                        Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n   <br>\n   <strong>Id: </strong> ");
#nullable restore
#line 8 "D:\GitHub\C#\Asp\HolaMundoMVC\Views\Shared\_UCObjetoBase.cshtml"
                    Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>");
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
