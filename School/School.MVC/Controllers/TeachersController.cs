using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Teacher;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        public TeachersController(ITeacherService teacherService, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index(QueryOptions options)
        {
            try
            {
                var teachers = await _teacherService.GetByPages(options);
                return View(teachers);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var modelTeacher = id.HasValue
            ? _mapper.Map<TeacherModel>(await _teacherService.GetById(id.Value))
            : new TeacherModel();
                return View(_mapper.Map<TeacherModel>(modelTeacher));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherModel teacherModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var teacher = _mapper.Map<Teacher>(teacherModel);
                    if (teacherModel.Id > 0)
                        await _teacherService.Update(teacher);
                    else
                        await _teacherService.Create(teacher);

                    return RedirectToAction("Index");
                }
                return View(teacherModel);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(TeacherModel teacherModel)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(teacherModel);
                await _teacherService.Delete(teacher.Id);

                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var path = "/Files/" + uploadedFile.FileName;

                // save file to file system
                await using var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);

                await uploadedFile.CopyToAsync(fileStream);

                //save file to DB (Person)
                await using var memoryStream = new MemoryStream();

                await uploadedFile.CopyToAsync(memoryStream);

                var content = memoryStream.ToArray();

                await _teacherService.SavePhoto(id, content);
            }

            return RedirectToAction(nameof(Edit), new {Id = id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}