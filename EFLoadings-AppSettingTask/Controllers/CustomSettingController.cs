using EFLoadings_AppSettingTask.CustomSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EFLoadings_AppSettingTask.Controllers
{
    public class CustomSettingController : Controller
    {
        private readonly IOptions<CustomAppSetting> options;

        public CustomSettingController(IOptions<CustomAppSetting> options)
        {
            this.options = options;
        }
        public IActionResult Index()
        {
            ViewBag.Message1 = options.Value.CustomSetting1;
            ViewBag.Message2 = options.Value.CustomSetting2;
            ViewBag.Message3 = options.Value.CustomSetting3;
            return View();
        }
    }
}
