﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Profiles.AfterMaps;
using dataModel= StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<dataModel.Student, Student>()
                .ReverseMap();

            CreateMap<dataModel.Address, Address>()
                .ReverseMap();

            CreateMap<dataModel.Gender, Gender>()
                .ReverseMap();

            CreateMap<UpdateStudentResult, dataModel.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();

            CreateMap<AddStudentResult, dataModel.Student>()
                .AfterMap<AddStudentRequestAfterMap>();
                
        }
    }
}
