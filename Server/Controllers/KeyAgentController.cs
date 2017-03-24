using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KeyAgent.API.Models.Order;
using KeyAgent.API.Models.Order.Asset;
using KeyAgent.API.Models.Order.Product;

namespace Server.Controllers
{
    [RoutePrefix("api/KeyAgent")]
    public class KeyAgentController : ApiController
    {
        [HttpPost]
        [Route("OrderStatusUpdate")]
        public void OrderUpdate(OrderStatusUpdate update)
        {
            //update your record as per the posted update
        }

        [HttpPost]
        [Route("OrderProduct")]
        public void ProductUpdate(OrderProduct product)
        {
            //update your record as per the posted update
        }

        [HttpPost]
        [Route("SupplierUpdate")]
        public void SupplierUpdate(SupplierUpdate update)
        {
            //update your record as per the posted update
        }

        [HttpPost]
        [Route("Appointment")]
        public void AppointmentUpdate(Appointment appointment)
        {
            //update your record as per the posted update
        }

        [HttpPost]
        [Route("AssetUpdate")]
        public void AssetUpdate(AssetUpdate update)
        {
            //update your record as per the posted update
        }
    }
}
