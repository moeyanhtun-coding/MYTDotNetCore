using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp3.Database;
using MYTDotNetCore.MvcApp3.Models;

namespace MYTDotNetCore.MvcApp3.Controllers
{
    public class SignUpController : Controller
    {
        private readonly AppDbContext _context;

        public SignUpController(AppDbContext context)
        {
            _context = context;
        }

        [ActionName("Index")]
        public IActionResult SignUpIndex()
        {
            return View("SignUpIndex");
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> SignUpIndex(UserModel reqModel)
        {
            await _context.Users.AddAsync(
                new TblUser
                {
                    UserID = Guid.NewGuid().ToString(),
                    UserName = reqModel.UserName,
                    Password = reqModel.Password,
                }
            );
            await _context.SaveChangesAsync();
            return Redirect("/login");
        }
    }
}
