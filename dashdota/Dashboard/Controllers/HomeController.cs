﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using SteamWebAPI2.Interfaces;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ApplicationUserManager manager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();

            // Create an empty View Model.
            var viewModel = new DashboardViewModel();

            // Return empty View Model immediately if not logged in. 
            if (!User.Identity.IsAuthenticated)
            {
                return View(viewModel);
            }

            // We are logged in. Get User's external login information.
            var logins = await manager.GetLoginsAsync(User.Identity.GetUserId());

            foreach (var login in logins)
            {
                // Look for the specific login from Steam provider.
                if (login.LoginProvider == "Steam")
                {
                    // Steam Id is the segment with index 3 from Uri.
                    var steamId = new Uri(login.ProviderKey).Segments[3];

                    // Populate the view model with steam Id.
                    viewModel.SteamId = steamId;

                    // TODO: Should really create a "dev" or "admin" user role in ASP.NET user database
                    // and check if the user is assigned to said role. Perhaps someday when I'm not the only
                    // person working on this...
                    viewModel.DeveloperView = (steamId == "76561197983364518" ? true : false);

                    long steamIdL;
                    if (long.TryParse(steamId, out steamIdL))
                    {
                        // Map to the ISteamUser endpoint.
                        var steamInterface = new SteamUser(ConfigurationManager.AppSettings["SteamApiKey"]);

                        // Steam API call to get the player summary.
                        var playerSummary = await steamInterface.GetPlayerSummaryAsync(steamIdL);

                        // Stick the relevant info into the ViewBag for now.
                        // TODO: Prefer to use strongly typed views (models) instead of ViewBags.
                        ViewBag.NickName = playerSummary.Nickname;
                        ViewBag.ProfileUrl = playerSummary.ProfileUrl;
                        ViewBag.AvatarUrl = playerSummary.AvatarMediumUrl;
                    }
                }
            }

            return View(viewModel);
        }
    }
}