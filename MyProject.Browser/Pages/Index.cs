﻿using DotNetForHtml5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using MyProject.Browser.Interop;
using System.Threading.Tasks;
using System;

namespace MyProject.Browser.Pages
{
    [Route("/")]
    public class Index : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!await JSRuntime.InvokeAsync<bool>("getOSFilesLoadedPromise"))
            {
                throw new InvalidOperationException("Failed to initialize OpenSilver. Check your browser's console for error details.");
            }

            Cshtml5Initializer.Initialize(new UnmarshalledJavaScriptExecutionHandler(JSRuntime));
            Program.RunApplication();
        }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }
    }
}