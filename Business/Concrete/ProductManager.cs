using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Ekle(Product product)
        {
            _productDal.Add(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.GetById(x=>x.Id==productId);
            
        }

        public void Guncelle(Product product)
        {
            _productDal.Update(product);
        }

        public Product IdBul(Product product)
        {
            return _productDal.GetId(product);
            
        }

        public void Sil(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> UrunListele()
        {
            return _productDal.GetAll();
        }
    }
}
