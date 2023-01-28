using AutoMapper;
using ProjectMambaExam.DTOs.CardDTOs;
using ProjectMambaExam.DTOs.SettingDTOs;
using ProjectMambaExam.Models;
using ProjectMambaExam.Services;

namespace ProjectMambaExam.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Card, CardGetDto>();
            CreateMap<CardPostDto, Card>();
            CreateMap<Card, CardGetDto>();
            CreateMap<Setting, SettingGetDto>();
            CreateMap<SettingPostDto, Setting>();
            CreateMap<Setting, SettingService>();
        }
    }
}
