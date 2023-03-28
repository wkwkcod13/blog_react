using Microsoft.AspNetCore.Mvc;
using blog_api.Service.Interface;
using blog_api.Service;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using blog_api.Models;

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
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetList()
        {
            try
            {
                List<ICalendarEvent> list = _calendarService.GetList();
                return new JsonResult(list);
            }
            catch (Exception ex)
            {

            }
            return new JsonResult(null);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetDetail(string id)
        {
            return new JsonResult(new { id });
        }
    }
}
