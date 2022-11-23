using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        void Ekle(Product product);
        void Sil(Product product);
        void Guncelle(Product product);
        List<Product> UrunListele();
        Product IdBul(Product product);
        Product GetById(int productId);
    }
}
