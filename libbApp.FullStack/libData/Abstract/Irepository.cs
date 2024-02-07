using libEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace libData.Abstract
{
    internal interface Irepository
    {
       
        books GetByIdAsync(int id);

        List<books> GetAll();

        void Create(books entity);

        void Update(books entity);
        void Delete(books entity);
    }
}
