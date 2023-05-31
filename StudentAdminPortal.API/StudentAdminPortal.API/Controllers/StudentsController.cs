using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            //return Ok(studentRepository.GetStudents());
            var students = await studentRepository.GetStudentsAsync();
            return Ok(mapper.Map<List<Student>>(students));
            //var studentDomainModel = new List<Student>();

            //foreach(var student in students)
            //{
            //    studentDomainModel.Add(new Student()
            //    {
            //        Id = student.Id,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        DatOfBirth = student.DatOfBirth,
            //        Email = student.Email,
            //        ProfileImageUrl = student.ProfileImageUrl,
            //        GenderId = student.GenderId,
            //        Address = new Address
            //        {
            //            Id= student.Address.Id,
            //            PhysicalAddress = student.Address.PhysicalAddress,
            //            PostalAddress = student.Address.PostalAddress
            //        },
            //        Gender = new Gender
            //        {
            //            Id = student.Gender.Id,
            //            Description = student.Gender.Description
            //        }

            //    });
            //}

            //return Ok(studentDomainModel);
        }

        [HttpGet]
        [Route("[controller]/{studentId:Guid}")]
        public async Task<IActionResult> GetStudetAsync([FromRoute] Guid studentId)
        {
        var student = await studentRepository.GetStudentAsync(studentId);
        if(student == null)
        {
            return NotFound();
        }
        else
        {
                return Ok(mapper.Map<Student>(student));
        }
        }
    }
}
