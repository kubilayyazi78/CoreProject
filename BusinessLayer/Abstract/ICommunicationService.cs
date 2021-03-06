using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommunicationService : IGenericService<Communication>
    {
        List<Communication> GetInboxListByWriter(int id);
        List<Communication> GetSendBoxListByWriter(int id);
    }
}
