﻿using System.Threading.Tasks;
using Acme.HeroShop.Controllers;
using Acme.HeroShop.Heroes;
using Acme.HeroShop.Web.Public.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.HeroShop.Web.Public.Controllers
{
    public class HomeController : HeroShopControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHeroAppService _heroAppService;

        public HomeController(
            IHostingEnvironment hostingEnvironment, 
            IHeroAppService heroAppService)
        {
            _hostingEnvironment = hostingEnvironment;
            _heroAppService = heroAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // for production, enable server side renderring
            var applicationBasePath = _hostingEnvironment.ContentRootPath;
            var requestFeature = Request.HttpContext.Features.Get<IHttpRequestFeature>();
            var unencodedPathAndQuery = requestFeature.RawTarget;
            var unencodedAbsoluteUrl = $"{Request.Scheme}://{Request.Host}{unencodedPathAndQuery}";

            // ** TransferData concept **
            // Here we can pass any Custom Data we want !

            TransferData transferData = new TransferData
            {
                request = AbstractHttpContextRequestInfo(Request),
                thisCameFromDotNET = new
                {
                    heroCompanies = _heroAppService.GetHeroCompanies(),
                    heroes = _heroAppService.GetHeroes(null)
                }
            };

            var nodeService = Request.HttpContext.RequestServices.GetRequiredService<INodeServices>(); // nodeServices
                                                                                                       //Prerender now needs CancellationToken
            System.Threading.CancellationTokenSource cancelSource = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationToken cancelToken = cancelSource.Token;

            // Prerender / Serialize application (with Universal)
            var prerenderResult = await Prerenderer.RenderToString(
                "/",
                nodeService,
                //Request.HttpContext.RequestServices.GetRequiredService<INodeServices>(), // nodeServices
                cancelToken,
                new JavaScriptModuleExport(applicationBasePath + "/HeroApp/dist-server/main.bundle"),
                unencodedAbsoluteUrl,
                unencodedPathAndQuery,
                transferData, // Our simplified Request object & any other CustommData you want to send!
                30000,
                Request.PathBase.ToString()
            );

            ViewData["SpaHtml"] = prerenderResult.Html; // our <app> from Angular
            ViewData["Title"] = prerenderResult.Globals["title"]; // set our <title> from Angular
            ViewData["Styles"] = prerenderResult.Globals["styles"]; // put styles in the correct place
            ViewData["Meta"] = prerenderResult.Globals["meta"]; // set our <meta> SEO tags
            ViewData["Links"] = prerenderResult.Globals["links"]; // set our <link rel="canonical"> etc SEO tags
            ViewData["TransferData"] = prerenderResult.Globals["transferData"]; // our transfer data set to window.TRANSFER_CACHE = {};

            return View();
        }

        private SimplifiedRequest AbstractHttpContextRequestInfo(HttpRequest request)
        {
            return new SimplifiedRequest
            {
                cookies = request.Cookies,
                headers = request.Headers,
                host = request.Host
            };
        }
    }
}