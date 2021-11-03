using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issuing.Application.Dto.Card
{
    public class CardStatusUpdateRequest
    {
        public int CardId { get; set; }
        public short StatusCode { get; set; }
    }
}
