using AutoMapper;
using Hospital.Core.Interfaces;
using Hospital.Core;
using Microsoft.AspNetCore.Mvc;
using Hospital.Web.Areas.Admin.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ContactController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int pagenumber = 1, int size = 5)
        {
            int pagesize = 5;
            var data = await _uow._contactRepo.GetAll(pagenumber, pagesize);
            var dto = _mapper.Map<List<ContactDto>>(data);
            ViewBag.pagesize = pagesize;
            ViewBag.pagenumber = pagenumber;
            int totalHSP = await _uow._contactRepo.totalAsync();
            ViewBag.totalPages = (int)Math.Ceiling((decimal)totalHSP / pagesize);
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _uow._contactRepo.GetByIdAsync(id);
            var dto = _mapper.Map<ContactDto>(model);
            var hospitals = await _uow._hospitalRepo.GetAllNamesAndIdAsync();
            ViewBag.hospitals = new SelectList(hospitals,"Id" , "Name", model.HospitalId);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("key", "error");
                var hospitals = await _uow._hospitalRepo.GetAllNamesAndIdAsync();
                ViewBag.hospitals = new SelectList(hospitals, "Id", "Name", model.HospitalId);
                return View(model);
            }
            var obj = _mapper.Map<Contact>(model);
            var hosp = await _uow._hospitalRepo.GetHospitalByIdAsync(obj.HospitalId);
            if (hosp == null)
            {
                return View(model);
            }
            obj.Hospital = hosp;
            _uow._contactRepo.Update(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _uow._contactRepo.GetByIdAsync(id);
            _uow._contactRepo.Delete(model);
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
        public async Task<IActionResult> Create(ContactDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("key", "error");
                return View(model);
            }
            var obj = _mapper.Map<Contact>(model);
            var hosp = await _uow._hospitalRepo.GetHospitalByIdAsync(obj.HospitalId);
            if (hosp == null) { 
                return View(model);
            }
            obj.Hospital = hosp;
            await _uow._contactRepo.AddAsync(obj);
            await _uow.saveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _uow._contactRepo.GetByIdAsync(id);
            var dto = _mapper.Map<ContactDto>(model);  
            return View(dto);
        }

    }
}
