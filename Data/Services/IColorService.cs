using Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetColorById(long id);
        long Insert(Color color);
        bool Update(Color color);
        bool Delete(long id);
    }
}
