using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UygulamaORM.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class  //classları kullanabilir anlamın a gelir
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        //tek bir sorgu satırı çalışsın diye
        T GetFirstOrDefault(Expression<Func<T,bool>> filter, string? includeProperrties = null);
        //sorgu satırının bir liste halinde gelmesini sağlamak için kullandık bu komut satırı //GETOFFİRST veGETALL metotları direkt crud işlemlerinin read yani select seçme getirme işlemleini yapar.func  dediğimiz aslında bizim action resultlarımızı tanımlayan bir komut satırıdır.bu tanımlamada expression kullanarak yaparız.

        IEnumerable<T> GetAll(Expression<Func<T,bool>>?filter=null,string? includeProperties=null);
        
        void RemoveRange(IEnumerable<T> entities);
        //bu metotu yazmamızım sebebi ise eğer id silersek herhangi bir tablodan diğer tablonun foreign olan alanların silinmesini otomatik olarak sağlaması için yazdık(sqldeki cascade mantığı)


    }
 
}
