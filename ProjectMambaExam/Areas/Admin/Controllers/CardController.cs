using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMambaExam.DAL;
using ProjectMambaExam.DTOs.CardDTOs;
using ProjectMambaExam.Extensions;
using ProjectMambaExam.Models;
using System.Data;

namespace ProjectMambaExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CardController(AppDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public IActionResult Index()
        {
            List<Card> cards = _context.Cards.ToList();
            List<CardGetDto> cardGetDtos = _mapper.Map<List<CardGetDto>>(cards);
            return View(cardGetDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CardPostDto cardPostDto)
        {
            Card card = _mapper.Map<Card>(cardPostDto);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fields can't be null");
                return View();
            }
            card.Image = cardPostDto.File.CreateFile(_environment.WebRootPath, "assets/img/team");
            _context.Cards.Add(card);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int Id)
        {
            Card card = await _context.Cards.FindAsync(Id);
            CardUpdateDto cardUpdateDto = new CardUpdateDto()
            {
                cardGetDto=_mapper.Map<CardGetDto>(card)
            };
            return View(cardUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CardUpdateDto cardUpdateDto)
        {
            Card? card = await _context.Cards.FindAsync(cardUpdateDto.cardGetDto.Id);

            card.Name = cardUpdateDto.cardPostDto.Name;
            card.Position = cardUpdateDto.cardPostDto.Position;
            if (cardUpdateDto.cardPostDto.File != null)
            {
                card.Image = cardUpdateDto.cardPostDto.File.CreateFile(_environment.WebRootPath, "assets/img/team");
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            Card card = await _context.Cards.FindAsync(Id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
