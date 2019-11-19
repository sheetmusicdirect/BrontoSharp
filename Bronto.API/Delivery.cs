using Bronto.API.BrontoService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bronto.API
{
    public class Delivery : BrontoApiClass
    {

        public Delivery(LoginSession session) : base(session)
        {
            this.Timeout = TimeSpan.FromMinutes(15);
        }

        public BrontoResult Add(deliveryObject delivery)
        {
            return Add(new deliveryObject[] { delivery });
        }

        public BrontoResult Add(IEnumerable<deliveryObject> deliveries)
        {
            using (BrontoSoapPortTypeClient client = BrontoSoapClient.Create(Timeout))
            {
                writeResult response = client.addDeliveries(session.SessionHeader, deliveries.ToArray());
                return BrontoResult.Create(response);
            }
        }
    }
}
