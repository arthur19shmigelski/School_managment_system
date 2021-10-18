using Moq;
using NUnit.Framework;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.Core.Models;
using School.Core.Models.Enum;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Tests
{
    public class StudentGroupServiceTests
    {
        private Mock<IStudentService> studentService;
        private Mock<IStudentRequestService> requestService;
        private Mock<IRepository<Group>> repository;

        private StudentGroupService underTest;
        [SetUp]
        public void Setup()
        {
            studentService = new Mock<IStudentService>();
            requestService = new Mock<IStudentRequestService>();
            repository = new Mock<IRepository<Group>>();

            underTest = new StudentGroupService(repository.Object,
                requestService.Object, studentService.Object);
        }

        [Test]
        public void Create_RequestsByCourse_ShouldBeCloses()
        {
            var testCourseId = 1;
            var testGroupId = 1;

            Student student = new();
            var group = new Group {Id = testGroupId, CourseId = testCourseId };

            var requests = GenerateRequests(testCourseId, student);

            requestService
                .Setup(x => x.GetOpenRequestsByCourse(It.IsAny<int>()))
                .Returns(Task.FromResult<IEnumerable<StudentRequest>>(requests));


            //act
            underTest.Create(group);

            //assert
            Assert.IsTrue(requests.Where(r => r.CourseId == testCourseId).All(r => r.Status == RequestStatus.Closed));
        }

        [Test]
        public void Create_Students_ShouldBeAssignedToGroup()
        {
            var testCourseId = 1;
            var testGroupId = 1;

            var student = new Student() { GroupId = null };
            var group = new Group { Id = testGroupId, CourseId = testCourseId };
            List<StudentRequest> requests = GenerateRequests(testCourseId, student);

            requestService
                .Setup(x => x.GetOpenRequestsByCourse(It.IsAny<int>()))
                .Returns(Task.FromResult<IEnumerable<StudentRequest>>(requests));


            //act
            underTest.Create(group);

            //assert
            Assert.AreEqual(testGroupId, student.GroupId);
        }

        private static List<StudentRequest> GenerateRequests(int courseId, Student student)
        {
            return new List<StudentRequest>()
            {
                new StudentRequest {Status = RequestStatus.Open, CourseId = courseId, Student = student},
                new StudentRequest {Status = RequestStatus.Open, CourseId = courseId, Student = student}
            };
        }
    }
}
