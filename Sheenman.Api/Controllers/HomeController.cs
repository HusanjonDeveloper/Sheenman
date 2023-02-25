//======================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//======================

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Sheenman.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello");
       
    }
}
