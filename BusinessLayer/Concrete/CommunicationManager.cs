using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommunicationManager : ICommunicationService
    {
        private ICommunicationDal _communicationDal;

        public CommunicationManager(ICommunicationDal messageDal)
        {
            _communicationDal = messageDal;
        }

        public void Add(Communication entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Communication entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Communication entity)
        {
            throw new NotImplementedException();
        }

        public List<Communication> GetList()
        {
            return _communicationDal.GetListAll();
        }

        public Communication GetById(int id)
        {
            return _communicationDal.GetById(id);
        }

        public List<Communication> GetInboxListByWriter(int id)
        {
            return _communicationDal.GetListWithMessageByWriter(id);
        }

    }
}
