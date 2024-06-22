using AutoMapper;
using Hospital.Core;
using Hospital.Core.Interfaces;
using Hospital.Web.Areas.Admin.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public HospitalController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int pagenumber = 1,int size=5)
        {
            int pagesize = 5;
            var data = await _uow._hospitalRepo.GetAllAsync(pagenumber, pagesize);
            var dto = _mapper.Map<List<HospitalInfoDto>>(data);
            ViewBag.pagesize = pagesize;
            ViewBag.pagenumber = pagenumber;
            int totalHSP = await _uow._hospitalRepo.totalHospitalsAsync();
            ViewBag.totalPages = (int) Math.Ceiling((decimal)totalHSP/ pagesize);
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _uow._hospitalRepo.GetHospitalByIdAsync(id);
            var dto = _mapper.Map<HospitalInfoDto>(model);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HospitalInfoDto model)
        {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("key", "error");
                return View(model);
            }
            var obj = _mapper.Map<HospitalInfo>(model);
            _uow._hospitalRepo.UpdateHospital(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _uow._hospitalRepo.GetHospitalByIdAsync(id);
            _uow._hospitalRepo.DeleteHospital(model);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HospitalInfoDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("key", "error");
                return View(model);
            }
            var obj = _mapper.Map<HospitalInfo>(model);
            await _uow._hospitalRepo.AddHospitalAsync(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _uow._hospitalRepo.GetHospitalByIdAsync(id);
            var dto = _mapper.Map<HospitalInfoDto>(model);
            return View(dto);
        }
    }
}
