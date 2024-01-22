using DirectFerriesTest.Interfaces;
using DirectFerriesTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DirectFerriesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserProcessor UserProcessor { get; set; }
        private IValidation Validator { get; set; }
        public HomeController(ILogger<HomeController> logger , 
            IUserProcessor userProcessor,
            IValidation validator)
        {
            Validator = validator;
            UserProcessor = userProcessor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/ProcessUser")]
        public IActionResult ProcessUser([FromForm] UserInfo userInfo)
        {
            List<string> messages;
            bool valid;

            (messages, valid) = Validator.ValidUserInfo(userInfo);

            if (!valid)
                messages.ForEach(a => ModelState.AddModelError(Guid.NewGuid().ToString(), a)); 

            if (ModelState.IsValid)
            {
                    UserResults userResults = UserProcessor.GetUserResults(userInfo);
                    return RedirectToAction("Result",userResults);
            }
            else
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage).ToArray();
                return View("Index");
            }
            
        }

        public IActionResult Result(UserResults userResults)
        {
            return View(userResults);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
