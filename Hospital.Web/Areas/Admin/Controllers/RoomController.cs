using AutoMapper;
using Hospital.Core.Interfaces;
using Hospital.Core;
using Microsoft.AspNetCore.Mvc;
using Hospital.Web.Areas.Admin.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public RoomController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int pagenumber = 1, int size = 5)
        {
            int pagesize = 5;
            var data = await _uow._roomRepo.GetAll(pagenumber, pagesize);
            var dto = _mapper.Map<List<RoomDto>>(data);
            ViewBag.pagesize = pagesize;
            ViewBag.pagenumber = pagenumber;
            int totalHSP = await _uow._roomRepo.totalAsync();
            ViewBag.totalPages = (int)Math.Ceiling((decimal)totalHSP / pagesize);
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _uow._roomRepo.GetByIdAsync(id);
            var dto = _mapper.Map<RoomDto>(model);
            var hospitals = await _uow._hospitalRepo.GetAllNamesAndIdAsync();
            ViewBag.hospitals = new SelectList(hospitals,"Id" , "Name", model.HospitalId);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("key", "error");
                var hospitals = await _uow._hospitalRepo.GetAllNamesAndIdAsync();
                ViewBag.hospitals = new SelectList(hospitals, "Id", "Name", model.HospitalId);
                return View(model);
            }
            var obj = _mapper.Map<Room>(model);
            var hosp = await _uow._hospitalRepo.GetHospitalByIdAsync(obj.HospitalId);
            if (hosp == null)
            {
                return View(model);
            }
            obj.Hospital = hosp;
            _uow._roomRepo.Update(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _uow._roomRepo.GetByIdAsync(id);
            _uow._roomRepo.Delete(model);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var hospitals = await _uow._hospitalRepo.GetAllNamesAndIdAsync();
            ViewBag.hospitals = new SelectList(hospitals, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("key", "error");
                return View(model);
            }
            var obj = _mapper.Map<Room>(model);
            var hosp = await _uow._hospitalRepo.GetHospitalByIdAsync(obj.HospitalId);
            if (hosp == null) { 
                return View(model);
            }
            obj.Hospital = hosp;
            await _uow._roomRepo.AddAsync(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _uow._roomRepo.GetByIdAsync(id);
            var dto = _mapper.Map<RoomDto>(model);  
            return View(dto);
        }

    }
}
