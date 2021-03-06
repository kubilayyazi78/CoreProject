using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommunicationRepository : GenericRepository<Communication>, ICommunicationDal
    {
        public List<Communication> GetInboxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Communications.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }

        public List<Communication> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Communications.Include(x => x.ReceiverUser).Where(x => x.SenderId == id).ToList();
            }
        }
    }
}
