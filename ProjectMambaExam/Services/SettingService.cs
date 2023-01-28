using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectMambaExam.DAL;
using ProjectMambaExam.DTOs.SettingDTOs;
using ProjectMambaExam.Models;

namespace ProjectMambaExam.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SettingGetDto GetSettings()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            SettingGetDto settingGet = _mapper.Map<SettingGetDto>(setting);
            return settingGet;
        }
    }
}
