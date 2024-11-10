using Aplication.Models.Request;
using Aplication.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models.Mappings
{
    public interface IBillMapping
    {
        Bill MapBillRequestToEntity(BillRequest billRequest);
        BillResponse MapBillToResponse(Bill bill);
        Bill UpdateBillFromRequest(Bill bill, BillRequest billRequest);
    }
}
