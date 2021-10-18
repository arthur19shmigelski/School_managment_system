using AutoMapper;
using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.BLL.Services.Course;
using School.BLL.Services.Topic;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly ICourseService _courseService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TopicsController(IMapper mapper,
                                ITopicService topicService,
                                ILogger<TopicsController> logger, ICourseService courseService)
        {
            _mapper = mapper;
            _logger = logger;
            _courseService = courseService;
            _topicService = topicService;
        }

        public async Task<IActionResult> Index(QueryOptions options)
        {
            try
            {
                var topics = await _topicService.GetByPages(options);

                return View(topics);
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
                var topicModel = id.HasValue ?
                    _mapper.Map<TopicModel>(await _topicService.GetById(id.Value)) :
                    new TopicModel();

                return View(topicModel);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TopicModel topicModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var topic = _mapper.Map<Topic>(topicModel);
                    if (topic.Id == 0)
                        await _topicService.Create(topic);
                    else
                        await _topicService.Update(topic);

                    return RedirectToAction(nameof(Index));
                }

                return View(topicModel);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var topic = _mapper.Map<Topic>(await _topicService.GetById(id));
                await _topicService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var topic = _mapper.Map<Topic>(await _topicService.GetById(id));

                var value = await _courseService.GetAll();
                var newValue = value.Where(x => x.Id == id).Select(x => x);

                if (newValue.Count() > 0)
                {
                    return View("ConfrimDelete", topic);
                }
                else
                    return RedirectToAction(nameof(Delete));
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }
    }
}