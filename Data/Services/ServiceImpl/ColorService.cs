using Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.ServiceImpl
{
    public class ColorService : IColorService
    {
        private readonly TGClothesDbContext db = new TGClothesDbContext();

        public List<Color> GetAll()
        {
            return db.Colors.ToList();
        }

        public Color GetColorById(long id)
        {
            return db.Colors.Find(id);
        }

        public long Insert(Color color)
        {
            db.Colors.Add(color);
            db.SaveChanges();
            return color.Id;
        }

        //public void Update(Color color)
        //{
        //    var existing = db.Colors.Find(color.Id);
        //    if (existing != null)
        //    {
        //        existing.Name = color.Name;
        //        existing.CodeColor = color.CodeColor;
        //        db.SaveChanges();
        //    }
        //}
        public bool Update(Color size)
        {
            try
            {
                var data = db.Colors.Find(size.Id);
                data.Name = size.Name;
                data.CodeColor = size.CodeColor;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public void Delete(long id)
        //{
        //    var color = db.Colors.Find(id);
        //    if (color != null)
        //    {
        //        db.Colors.Remove(color);
        //        db.SaveChanges();
        //    }

        public bool Delete(long id)
        {
            try
            {
                var color = db.Colors.Find(id);
                db.Colors.Remove(color);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
