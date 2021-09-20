using Dto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Interface
{
    public interface IQualificationListRepository
    {
        void AddQulification(QualificationListDTO dto);
        void UpdateQulification(QualificationListDTO dto);
        void DeleteQulification(long id);
        QualificationListDTO GetByQualificationID(long id);
        List<DropDownModel> AllQualificationDropDown();
    }
}
