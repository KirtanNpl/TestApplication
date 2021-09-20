using Bussiness.Services.Interface;
using Dto.DTO;
using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    public class QualificationListController : Controller
    {
        private readonly IQualificationListRepository _qualificationListRepo;
        private readonly IBaseRepository<QualificationList> _qualificationList;
        public QualificationListController(IQualificationListRepository qualificationListRepo, IBaseRepository<QualificationList> qualificationList)
        {
            _qualificationListRepo = qualificationListRepo;
            _qualificationList = qualificationList;

        }
        public IActionResult Index()
        {
            var list = _qualificationList.getQueryable().ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult SaveQualification()
        {

           
            return View();
        }

        [HttpPost]
        public IActionResult SaveQualification(QualificationListDTO dto)
        {
            try
            {


                _qualificationListRepo.AddQulification(dto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult UpdateQualification(long id)
        {
            try
            {
              
                if (id > 0)
                {
                    var data = _qualificationListRepo.GetByQualificationID(id);
                    return View(data);
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult UpdateQualification(QualificationListDTO dto)
        {
            try
            {



                _qualificationListRepo.UpdateQulification(dto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult DeleteQualification(long id)
        {
            try
            {
                if (id > 0)
                {
                    _qualificationListRepo.DeleteQulification(id);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
