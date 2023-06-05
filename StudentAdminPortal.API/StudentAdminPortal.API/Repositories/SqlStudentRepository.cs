using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Context;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext context;

        public SqlStudentRepository(StudentAdminDbContext context)
        {
            this.context = context;
        }
               
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudentAsync(Guid studentId, Student student)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.DatOfBirth = student.DatOfBirth;
                existingStudent.Email = student.Email;
                existingStudent.Mobile = student.Mobile;
                existingStudent.GenderId = student.GenderId;
                existingStudent.Address.PhysicalAddress = student.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = student.Address.PostalAddress;

                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            var student = await GetStudentAsync(studentId);
            if(student !=null)
            {
                context.Student.Remove(student);
                await context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var stud =await context.Student.AddAsync(student);
            await context.SaveChangesAsync();
            return stud.Entity;
        }
    }
}
