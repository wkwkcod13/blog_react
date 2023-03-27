using Microsoft.AspNetCore.Mvc;
using blog_api.Service.Interface;
using blog_api.Service;

namespace blog_api.Controllers
{
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetList()
        {
            try
            {
                var list = _calendarService.GetList();
                return new JsonResult(list);
            }
            catch (Exception ex)
            {

            }
            return new JsonResult(null);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetDetail(string id)
        {
            return new JsonResult(new { id });
        }
    }
}
