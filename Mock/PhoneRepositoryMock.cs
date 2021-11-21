using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WPFTestApp.Model;

namespace WPFTestApp.Mock
{
    class PhoneRepositoryMock : IRepository<Phone>
    {
        private List<Phone> _phonesStore;

        public PhoneRepositoryMock()
        {
            _phonesStore = new List<Phone>()
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public void Add(Phone entity)
        {
            _phonesStore.Add(entity);
        }

        public void Delete(Phone entity)
        {
            _phonesStore.Remove(entity);
        }

        public void Edit(Phone entity)
        {
            _phonesStore.Remove(entity);
        }

        public Phone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> List()
        {
            return _phonesStore.AsEnumerable();
        }

        public IEnumerable<Phone> List(Func<Phone, bool> predicate)
        {
            return _phonesStore.Where(predicate).AsEnumerable();
        }
    }
}
