using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMambaExam.DAL;
using ProjectMambaExam.DTOs.SettingDTOs;
using ProjectMambaExam.Models;

namespace ProjectMambaExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            SettingGetDto settingGetDto = _mapper.Map<SettingGetDto>(setting);
            return View(settingGetDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            Setting setting = await _context.Settings.FindAsync(Id);
            SettingUpdateDto settingUpdateDto = new SettingUpdateDto()
            {
                settingGetDto = _mapper.Map<SettingGetDto>(setting)
            };
            return View(settingUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SettingUpdateDto settingUpdateDto)
        {
            Setting? setting = await _context.Settings.FindAsync(settingUpdateDto.settingGetDto.Id);
            setting.PhoneNumber=settingUpdateDto.settingPostDto.PhoneNumber;
            setting.Email = settingUpdateDto.settingPostDto.Email;
            setting.Address = settingUpdateDto.settingPostDto.Address;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
