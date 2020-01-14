using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managegment.Controllers;
using Managegment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/Courses")]
    public class CoursesController : Controller
    {

        private readonly CMSContext db;
        private Helper help;
        public CoursesController(CMSContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetCoursesBySuperPackageId")]
        public IActionResult GetCoursesBySuperPackageId(int pageNo, int pageSize, int SuperPackageId)
        {
            try
            {
                IQueryable<Courses> CoursesQuery;
                CoursesQuery = from p in db.Courses
                                where p.Status == 1 && p.SuperPackageId == SuperPackageId
                               select p;

                var CoursesCount = (from p in CoursesQuery
                                     select p).Count();

                var CoursesList = (from p in CoursesQuery
                                    orderby p.CreatedOn descending
                                    select new
                                    {
                                        Name = p.Name,
                                        Description = p.Description,
                                        CourseId = p.CourseId,
                                        Color = p.Color,
                                        Discount = p.Discount,
                                        PriceCompany = p.PriceCompany,
                                        PricePersonal = p.PricePersonal,
                                        Status = p.Status,
                                        SuperPackageId = p.SuperPackageId,
                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Courses = CoursesList, count = CoursesCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetCoursesByPackageId")]
        public IActionResult GetCoursesByPackageId(int pageNo, int pageSize, int PackageId)
        {
            try
            {
                IQueryable<Courses> CoursesQuery;
                CoursesQuery = from p in db.Courses
                               where p.Status == 1 && p.PackageId == PackageId
                               select p;

                var CoursesCount = (from p in CoursesQuery
                                    select p).Count();

                var CoursesList = (from p in CoursesQuery
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       Name = p.Name,
                                       Description = p.Description,
                                       CourseId = p.CourseId,
                                       Color = p.Color,
                                       Discount = p.Discount,
                                       PriceCompany = p.PriceCompany,
                                       PricePersonal = p.PricePersonal,
                                       Status = p.Status,
                                       SuperPackageId = p.SuperPackageId,
                                       PackageId=p.PackageId,
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Courses = CoursesList, count = CoursesCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        //[HttpGet("GetCoursesBySuperPackageIdOrPackageId")]
        //public IActionResult GetCoursesBySuperPackageIdOrPackageId(int pageNo, int pageSize, int SuperPackageId,int PackageId)
        //{
        //    try
        //    {
        //        IQueryable<Courses> CoursesQuery;
        //        if (SuperPackageId==0 && PackageId == 0)
        //        {                  
        //            CoursesQuery = from p in db.Courses
        //                           where p.Status == 1 && p.Package.Status==0 
        //                           select p;
        //        }
        //        else
        //        {
        //            CoursesQuery = from p in db.Courses
        //                           where p.Status == 1 && p.SuperPackageId == SuperPackageId
        //                           select p;

        //        }


        //        var CoursesCount = (from p in CoursesQuery
        //                            select p).Count();

        //        var CoursesList = (from p in CoursesQuery
        //                           orderby p.CreatedOn descending
        //                           select new
        //                           {
        //                               Name = p.Name,
        //                               Description = p.Description,
        //                               CourseId = p.CourseId,
        //                               Color = p.Color,
        //                               Discount = p.Discount,
        //                               PriceCompany = p.PriceCompany,
        //                               PricePersonal = p.PricePersonal,
        //                               Status = p.Status,
        //                               SuperPackageId = p.SuperPackageId,
        //                           }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

        //        return Ok(new { Courses = CoursesList, count = CoursesCount });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, "خطــأ في عملية الإتصـال بالخادم الرجاء المحاولة لاحقا");
        //    }
        //}



        [HttpPost("{CourseId}/delete")]
        public IActionResult DeleteCourse(long CourseId)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Course = (from p in db.Courses
                               where p.CourseId == CourseId
                               && (p.Status == 1)
                               select p).SingleOrDefault();

                if (Course == null)
                {
                    return NotFound("خــطأ : المستخدم غير موجود");
                }

                Course.Status = 9;
                Course.UpdatedBy = userId;
                Course.UpdatedOn = DateTime.Now;
                db.SaveChanges();
                return Ok("Course Deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult AddCourse([FromBody] Courses Course)
        {
            try
            {
                if (Course == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                Course.CreatedBy = userId;
                Course.CreatedOn = DateTime.Now;
                Course.Status = 1;
                db.Courses.Add(Course);
                db.SaveChanges();

                return Ok("لقد قمت بتسـجيل بيانات الــدورة بنــجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("Edit")]
        public IActionResult EditCourse([FromBody] Courses Course)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Courses = (from p in db.Courses
                                     where p.CourseId == Course.CourseId
                                     && (p.Status == 1)
                                     select p).SingleOrDefault();

                if (Courses == null)
                {
                    return BadRequest("خطأ بيانات الدورة غير موجودة");
                }

                Courses.Color = Course.Color;
                Courses.Description = Course.Description;
                Courses.Discount = Course.Discount;
                Courses.PricePersonal = Course.PricePersonal;
                Courses.PriceCompany = Course.PriceCompany;
                Courses.Name = Course.Name;
                Courses.Status = 1;
                Courses.UpdatedBy = userId;
                Courses.UpdatedOn = DateTime.Now;
                db.SaveChanges();
                return Ok("تم تعديل بينات الدورة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }




    }
}
