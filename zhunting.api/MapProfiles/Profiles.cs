using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;

namespace zhunting.api.MapProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Gallery, GalleryDTO>()
                .ForMember(d => d.Images, o => o.MapFrom(s => s.Images.Select(c => c.Link)))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsDeleted, o => o.MapFrom(s => s.IsDeleted));
        }
    }
}
