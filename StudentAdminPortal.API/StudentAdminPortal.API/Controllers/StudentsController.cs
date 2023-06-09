﻿using AutoMapper;
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
        [Route("[controller]/{studentId:Guid}"),ActionName("GetStudetAsync")]
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

        [HttpPut]
        [Route("[controller]/{studentId:Guid}")]
        public async Task<IActionResult> UpdatesStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentResult result)
        {
            if(await studentRepository.Exists(studentId))
            {
                var updateSudent = await studentRepository.UpdateStudentAsync(studentId, mapper.Map<DataModels.Student>(result));
                if(updateSudent != null)
                {
                    return Ok(mapper.Map<Student>(updateSudent));
                }
            }            
                return NotFound();           

        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
                var deleteStudent = await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(deleteStudent));
                
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/addstudent")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentResult result)
        {
            var student = await studentRepository.AddStudent(mapper.Map<DataModels.Student>(result));
            return CreatedAtAction(nameof(GetStudetAsync), new { studentId = student.Id },
                mapper.Map<Student>(student));
        }
    }
}
