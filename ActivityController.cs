using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ActivityController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Json(DAL.Activity.Instance.GetCount());
        }
        [HttpGet("verifyCount")]
        public ActionResult GetVerifyCount()
        {
            return Json(DAL.Activity.Instance.GetVerifyCount());
        }
        [HttpGet("recommend")]
        public ActionResult GetRecommend()  //获取推荐活动
        {
            var result = DAL.Activity.Instance.GetRecommend();
            if (result != null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("记录数为0"));
        }
    }
}
