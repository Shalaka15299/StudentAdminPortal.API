using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using DataModels = StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentResult, DataModels.Student>
    {
        public void Process(AddStudentResult source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                Id=Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
