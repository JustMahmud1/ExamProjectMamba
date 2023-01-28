using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMambaExam.DAL;
using ProjectMambaExam.DTOs.CardDTOs;
using ProjectMambaExam.Models;
using System.Diagnostics;

namespace ProjectMambaExam.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Card> cards = _context.Cards.ToList();
            List<CardGetDto> cardGetDtos = _mapper.Map<List<CardGetDto>>(cards);
            return View(cardGetDtos);
        }


    }
}