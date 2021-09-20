using Bussiness.Services.Interface;
using Dto.DTO;
using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementation
{
   public class QualificationListService: IQualificationListRepository
    {
        private readonly IBaseRepository<QualificationList> _QuaificationRepo;
        public QualificationListService(IBaseRepository<QualificationList> QuaificationRepo)
        {
            _QuaificationRepo = QuaificationRepo;
        }
        public void AddQulification(QualificationListDTO dto)
        {
            var mapData = MapFromDTOtoEntity(new QualificationList(), dto);
            _QuaificationRepo.Insert(mapData);
            

        }

        public void UpdateQulification(QualificationListDTO dto)
        {
            var data = _QuaificationRepo.getById(dto.id);
            var mapData = MapFromDTOtoEntity(data, dto);
            _QuaificationRepo.Update(mapData);
           


        }

        public void DeleteQulification(long id)
        {
            if (id > 0)
            {
                var dataToDelete = _QuaificationRepo.getById(id);
                _QuaificationRepo.Delete(dataToDelete);

            }

        }
        public List<DropDownModel> AllQualificationDropDown()
        {

            try
            {
                var allqualification = _QuaificationRepo.getQueryable().Select(a => new DropDownModel { Id = a.Id, DisplayName = a.Q_Name }).ToList();
                return allqualification;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public QualificationListDTO GetByQualificationID(long id)
        {
            var data = _QuaificationRepo.getById(id);
            var mappeddata = MapFromEnitytoDTO(data, new QualificationListDTO());
            return mappeddata;
        }
        public QualificationList MapFromDTOtoEntity(QualificationList entity, QualificationListDTO dto)
        {
            entity.Q_Name = dto.Q_Name;
            return entity;

        }

        public QualificationListDTO MapFromEnitytoDTO(QualificationList entity, QualificationListDTO dto)
        {
            dto.id = entity.Id;
            dto.Q_Name = entity.Q_Name;

            return dto;

        }
    }
}
