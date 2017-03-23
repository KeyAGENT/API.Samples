using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KeyAgent.API.Models;
using KeyAgent.API.Models.Order;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static async void RequestOrderAsync()
        {
            //build up the order request from your own data
            var orderRequest = new OrderPostRequest
            {
                BranchId = "E123456",
                IntegratorsReference = "YOUR_UNIQUE_REFERENCE",
                KeyHolder = new KeyHolder
                {
                    CurrentHolder = EnKeyHolder.Other,
                    OtherKeyHolder = new Contact
                    {
                        Email = "john.smith@keyagent.co.uk",
                        Title = EnTitle.Mr,
                        Forename = "John",
                        Surname = "Smith",
                        Mobile = "07123456789",
                        Phone = "02012345678"
                    }
                },
                Property = new OrderProperty
                {
                    NumberOfBedrooms = 5,
                    PropertyType = EnPropertyType.House,
                    SquareFootage = EnSquareFootage.Above2000,
                    Address = new Address
                    {
                        Line1 = "The Maples",
                        Line2 = "Elmley Road",
                        Line3 = "Ashton under Hill",
                        City = "Evesham",
                        Province = "Worcestershire",
                        PostalCode = "WR11 7SW"
                    }
                }
            };

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                var orderResponse =
                    await client.PostAsJsonAsync<OrderPostRequest>("https://api.keyagent-portal.co.uk/api/order",
                        orderRequest);

                //report any errors back to the calling code
                if (!orderResponse.IsSuccessStatusCode) throw new Exception(orderResponse.ReasonPhrase);
            }
        }
    }
}
