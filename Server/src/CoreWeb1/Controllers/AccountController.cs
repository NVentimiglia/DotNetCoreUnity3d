using CoreWeb1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb1.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET api/Account
        /// <summary>
        /// Get Account, Token Test Method
        /// </summary>
        [HttpGet]
        [Authorize]
        public AccountModel Get()
        {
            return new AccountModel();
        }

        // POST api/Account
        /// <summary>
        /// SignUp, and SignIn
        /// </summary>
        [HttpPost]
        public AuthModel Post(AccountModel model)
        {
            return new AuthModel();
        }

        //TODO Password Reset / Support
        //TODO Update Account w/ Verification
        //TODO Facebook and other OAUTH2 providers
    }
}
