using AutoMapper;
using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Infrastructure.AutoMapper
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Song, SongModel>()
                .ForMember(d => d.RatingByUser, s => s.MapFrom(m => 0)).ReverseMap();

        }
    }
}
