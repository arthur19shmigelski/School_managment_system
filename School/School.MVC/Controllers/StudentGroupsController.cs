using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Course;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Teacher;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class StudentGroupsController : Controller
    {
        private readonly IStudentGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IStudentRequestService _requestService;
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService groupService,
           ITeacherService teacherService,
           ICourseService courseService,
           IStudentRequestService requestService,
           IMapper mapper)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _courseService = courseService;
            _requestService = requestService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(QueryOptions options)
        {
            try
            {
                var groups = await _groupService.GetByPages(options);
                return View(groups);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id, int? courseId)
        {
            StudentGroupModel model;
            if (id.HasValue)
            {
                var group = await _groupService.GetById(id.Value);
                model = _mapper.Map<StudentGroupModel>(group);
                model.Students = _mapper.Map<IEnumerable<StudentModel>>(group.Students);
            }
            else
            {
                model = new StudentGroupModel
                {
                    StartDate = DateTime.Today
                };
            }

            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(await _teacherService.GetAll());
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(await _courseService.GetAll());
            ViewBag.IsAdmin = HttpContext.User.IsInRole("admin");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(StudentGroupModel groupModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(groupModel);

                var group = _mapper.Map<Group>(groupModel);
                if (groupModel.Id > 0)
                    await _groupService.Update(group);
                else
                    await _groupService.Create(group);

                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}