using AutoMapper;
using Loan_WebServices.DTOs;
using Loan_WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loan_WebServices.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Loan, LoanDto>();
            Mapper.CreateMap<LoanDto, Loan>();

        }
    }
}