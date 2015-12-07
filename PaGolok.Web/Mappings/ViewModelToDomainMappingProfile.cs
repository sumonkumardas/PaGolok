using AutoMapper;
using PaGolok.Entities;
using PaGolok.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaGolok.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        

        protected override void Configure()
        {
            //Mapper.CreateMap<MovieViewModel, Movie>()
            //    //.ForMember(m => m.Image, map => map.Ignore())
            //    .ForMember(m => m.Genre, map => map.Ignore());
        }

        //public override string ProfileName
        //{
        //    get { return "ViewModelToDomainMappings"; }
        //}
    }
}