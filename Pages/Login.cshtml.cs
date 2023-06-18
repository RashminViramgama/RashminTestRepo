using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCDPNextGenPOCs.Enum;
using UCDPNextGenPOCs.Model;
using UCDPNextGenPOCs.Validator;

namespace UCDPNextGenPOCs.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public ErrorCodes objEnumErrorCodes { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public Login _objLogin { get; set; }
        public LoginValidator _objLoginValidator { get; set; }

        public LoginModel(LoginValidator objLoginValidator, Login objLogin)
        {
            _objLoginValidator = objLoginValidator;
            _objLogin = objLogin;   
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var validationResult = _objLoginValidator.Validate(_objLogin);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    ErrorMessage = error.ErrorMessage;
                    ErrorCode = error.ErrorCode;
                    break;
                }
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}