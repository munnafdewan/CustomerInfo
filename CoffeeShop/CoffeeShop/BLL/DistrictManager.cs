using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;
using CoffeeShop.Model;
using System.Windows.Forms;

namespace CoffeeShop.BLL
{
   public class DistrictManager
    {

        DistrictRepository _districtRepository = new DistrictRepository();
        public bool Add(District district)
        {
            return _districtRepository.Add(district);
        }

        public List<District> loadCombo()
        {
            return _districtRepository.loadCombo();
        }
    }
}
