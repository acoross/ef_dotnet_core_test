using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFForCore.Contexts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFForCore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly UserContext context;
        public UserController(UserContext context)
        {
            this.context = context;
        }
               
        // POST api/values
        [HttpPost]
        public JsonResult Create([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { msg = "invalid request" });
            }

            try
            {
                context.Database.EnsureCreated();

                context.tb_user.Add(user);
                context.SaveChanges();
                return new JsonResult(new { msg = "success" });
            }
            catch (Exception ex)
            {
                string ex_msg = ex.Message;
                //if (ex.InnerException != null)
                //{
                //    ex_msg = ex.InnerException.Message;
                //}

                return new JsonResult(new { msg = "db failed", ex_msg = ex_msg });
            }
        }

        [HttpPost("AddItems")]
        public JsonResult AddItems([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { msg = "invalid request" });
            }

            try
            {
                context.Database.EnsureCreated();

                //context.tb_user.Update(user);
                context.tb_item.AddRange(user.items);
                context.SaveChanges();
                return new JsonResult(new { msg = "success" });
            }
            catch (Exception ex)
            {
                string ex_msg = ex.Message;
                //if (ex.InnerException != null)
                //{
                //    ex_msg = ex.InnerException.Message;
                //}

                return new JsonResult(new { msg = "db failed", ex_msg = ex_msg });
            }
        }

        [HttpPost("UpdateItems")]
        public JsonResult UpdateItems([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { msg = "invalid request" });
            }

            try
            {
                context.Database.EnsureCreated();

                //context.tb_user.Update(user);
                context.tb_item.UpdateRange(user.items);
                context.SaveChanges();
                return new JsonResult(new { msg = "success" });
            }
            catch (Exception ex)
            {
                string ex_msg = ex.Message;
                //if (ex.InnerException != null)
                //{
                //    ex_msg = ex.InnerException.Message;
                //}

                return new JsonResult(new { msg = "db failed", ex_msg = ex_msg });
            }
        }
    }
}
