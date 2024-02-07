using libData.Abstract;
using libEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libData.Concrete
{
    public class bookRepo : Irepository
    {
        public List<books> GetAll()
        {
            using (var db = new libContext())
            {
                return db.books.ToList();
            }
        }
        public void Create(books entity)
        {
            using (var context = new libContext())
            {
                context.Set<books>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new libContext())
            {
                context.books.Remove(GetByIdAsync(id));
                context.SaveChanges();
            }
        }
        public void Delete(books entity)
        {
            using (var db = new libContext())
            {
                var book = db.books;
                book.Remove(entity);
                db.SaveChanges();

            }
        }



        public books GetByIdAsync(int id)
        {


            using (var context = new libContext())
            {
                books book = context.books.FirstOrDefault(p => p.BookId == id);
                return book;
            }

        }

        public void Update(books entity)
        {
            using (var context = new libContext())
            {
                var entityToUpdate = context.books.FirstOrDefault(e => e.BookId == entity.BookId);

                if (entityToUpdate != null)
                {

                    entityToUpdate.konum = entity.konum;
                    entityToUpdate.kitapAdi = entity.kitapAdi;
                    entityToUpdate.YazarAdi = entity.YazarAdi;

                    context.SaveChanges();
                }
            }
        }
    }
}

