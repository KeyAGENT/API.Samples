using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KeyAgent.API.Models;
using KeyAgent.API.Models.Order;
using KeyAgent.API.Models.Order.Asset;
using KeyAgent.API.Models.Order.People.KeyHolder;
using KeyAgent.API.Models.Order.Product;
using KeyAgent.API.Models.Order.Property;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static async void RequestAssetSelection(long orderReference, Guid[] selectedAssets)
        {
            var assetRequest = new AssetSelectionRequest
            {
                ProductType = EnProductType.Photos,
                AssetIds = new List<Guid>
                {
                    new Guid("ID_FROM_PREVIOUS_UPDATE"),
                    new Guid("ANOTHER_ID_FROM_PREVIOUS_UPDATE")
                }.ToArray()
            };

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                //note that the orderReference is passed as part of the URL
                var response =
                    await client.PostAsJsonAsync<AssetSelectionRequest>($"https://api.keyagent-portal.co.uk/api/order/{orderReference}/assetselection",
                        assetRequest);

                //report any errors back to the calling code
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            }
        }

        static async void RequestPhotoProduct(long orderReference)
        {
            var productRequest = new PhotosProduct
            {
                Quantity = 12
            };

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                //note that the orderReference is passed as part of the URL
                var response =
                    await client.PostAsJsonAsync<PhotosProduct>($"https://api.keyagent-portal.co.uk/api/order/{orderReference}/photos",
                        productRequest);

                //report any errors back to the calling code
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            }
        }

        static async void RequestEpcProduct(long orderReference)
        {
            var productRequest = new EpcProduct
            {
               NumberOfBedrooms = 5,
                PrintedCopies = 1
            };

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                //note that the orderReference is passed as part of the URL
                var response =
                    await client.PostAsJsonAsync<EpcProduct>($"https://api.keyagent-portal.co.uk/api/order/{orderReference}/epc",
                        productRequest);

                //report any errors back to the calling code
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            }
        }

        static async void RequestFloorplanProduct(long orderReference)
        {
            var productRequest = new FloorplanProduct
            {
                FloorPlan2D = true,
                FloorPlan3D = false
            };

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                //note that the orderReference is passed as part of the URL
                var response =
                    await client.PostAsJsonAsync<FloorplanProduct>($"https://api.keyagent-portal.co.uk/api/order/{orderReference}/floorplan",
                        productRequest);

                //report any errors back to the calling code
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            }
        }

        static async void RequestPropertyDescriptionProduct(long orderReference)
        {
            var productRequest = new PropertyDescriptionProduct();

            using (var client = new HttpClient())
            {
                //POST the data as JSON to the KeyAGENT API
                //note that the orderReference is passed as part of the URL
                var response =
                    await client.PostAsJsonAsync<PropertyDescriptionProduct>($"https://api.keyagent-portal.co.uk/api/order/{orderReference}/propertydescription",
                        productRequest);

                //report any errors back to the calling code
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            }
        }

        static async void RequestOrderAsync()
        {
            //build up the order request from your own data
            var orderRequest = new OrderRequest
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
                Property = new Property
                {
                    Bedrooms = 5,
                    PropertyType = EnPropertyType.House,
                    SquareFootage = 4800,
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
                    await client.PostAsJsonAsync<OrderRequest>("https://api.keyagent-portal.co.uk/api/order",
                        orderRequest);

                //report any errors back to the calling code
                if (!orderResponse.IsSuccessStatusCode) throw new Exception(orderResponse.ReasonPhrase);
            }
        }
    }
}
