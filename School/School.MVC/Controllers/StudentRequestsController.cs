using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Course;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.Core.Models;
using School.Core.Models.Enum;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class StudentRequestsController : Controller
    {
        private readonly IStudentRequestService _requestService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IStudentGroupService _studentGroupService;

        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentRequestsController(IMapper mapper,
            IStudentService studentService,
            ICourseService courseService,
            IStudentRequestService requestService,
            UserManager<IdentityUser> userManager,
            IStudentGroupService studentGroupService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
            _userManager = userManager;
            _studentGroupService = studentGroupService;
        }
        public async Task<Student> GetCurrentStudentBySystemUser()
        {
            IdentityUser currentSystemUser = await _userManager.GetUserAsync(User);

            var getAllStudents = await _studentService.GetAll();

            Student getCurrentStudentBySystemUserId = getAllStudents.FirstOrDefault(student => student.UserId == currentSystemUser.Id);
            return getCurrentStudentBySystemUserId;
        }

        #region Вывод списка заявок (для каждого пользователя своя логика)
        public async Task<IActionResult> Index(bool? includeClosed, QueryOptions options)
        {
            try
            {
                if (User.IsInRole("student"))
                {
                    var allRequests = includeClosed == true ? await _requestService.GetAll() : await _requestService.GetAllOpen();

                    IdentityUser currentSystemUser = await _userManager.GetUserAsync(User);

                    var getAllStudents = await _studentService.GetAll();

                    Student getCurrentStudentBySystemUserId = getAllStudents.FirstOrDefault(student => student.UserId == currentSystemUser.Id);

                    var selectRequestsCurrentStudent = allRequests.Where(studentReq => studentReq.StudentId == getCurrentStudentBySystemUserId.Id);
                    return View(_mapper.Map<IEnumerable<StudentRequestModel>>(selectRequestsCurrentStudent));
                }
                else if (User.IsInRole("manager"))
                {
                    //Дописать - взять манагера, посмотреть всех его учеников и посмотреть все их заявки
                    return RedirectToAction(nameof(Error));
                }

                else if (User.IsInRole("admin"))
                {
                    var requests = includeClosed == true ? await _requestService.GetAll() : await _requestService.GetAllOpen();

                    return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
                }

                else
                {
                    return RedirectToAction(nameof(Error));
                }

            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion


        #region Принять заявку
        [HttpGet]

        public async Task<IActionResult> AcceptRequest(int? id)
        {
            //StudentRequest request = null;
            //StudentRequestModel model = null;
            //if (id.HasValue)
            //{
            //    request = await _requestService.GetById(id.Value);
            //    model = _mapper.Map<StudentRequestModel>(request);
            //    model.StudentName = request.Student.FullName;
            //}
            //else
            //{
            //    model = new StudentRequestModel() { Created = DateTime.Today };
            //}
            var model = id.HasValue ? _mapper.Map<StudentRequestModel>(await _requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };
            var allGroups = (await _studentGroupService.GetAll());
            var filteredGroups = allGroups.Where(g => g.Status == GroupStatus.NotStarted && g.CourseId == model.CourseId);

            ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(filteredGroups);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptRequest(StudentRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var student = await _studentService.GetById(model.StudentId);
                student.GroupId = model.GroupId;
                await _studentService.Update(student);

                var request = _mapper.Map<StudentRequest>(model);
                request.Status = School.Core.Models.Enum.RequestStatus.Closed;
                await _requestService.Update(request);

                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion
        #region Изменить заявку
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var model = id.HasValue ? _mapper.Map<StudentRequestModel>(await _requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };

                var allCourses = await _courseService.GetAll();
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(allCourses.OrderBy(c => c.Title));

                var allStudents = await _studentService.GetAll();
                ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(allStudents.OrderBy(s => s.LastName));

                return View(model);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentRequestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var student = await GetCurrentStudentBySystemUser();
                model.StudentId = student.Id;

                var request = _mapper.Map<StudentRequest>(model);
                if (model.Id > 0)
                    await _requestService.Update(request);
                else
                    await _requestService.Create(request);
                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion
        #region Удалить заявку
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _requestService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        #endregion
        #region Exception-view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}