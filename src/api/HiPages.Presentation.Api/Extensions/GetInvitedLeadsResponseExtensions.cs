﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HiPages.Presentation.Api.InvitedLeads;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HiPages.Presentation.Api.Extensions
{
    // haven't tried any existing hal client libraries yet, so for now will do manual 
    // conversion to HAL format
    public static class GetInvitedLeadsResponseExtensions
    {
        public static dynamic ToHal(
            this GetInvitedLeadsResponse response,
            HttpRequest request)
        {
            var host = $"{request.Scheme}://{request.Host}";
            var halObject = new Dictionary<string, object>();
            halObject.Add("_links", new Dictionary<string, object>
            {
                { 
                    "self",
                    new Dictionary<string, object>
                    {
                        { "href", $"{host}/api/leads/invited" },
                        { "method", "GET" }
                    }
                }
            });

            var embedded = response
                .Data
                .ToList()
                .Select(lead =>
                {
                    var stringObject = JsonConvert.SerializeObject(lead, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });

                    var dictObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringObject);

                    dictObject.Add("_links", new Dictionary<string, object>
                    {
                        {
                            "accept",
                            new Dictionary<string, object>
                            {
                                {"href", $"{host}/api/leads/accepted/{lead.Id}"},
                                {"method", "POST"}
                            }
                        },
                        {
                            "decline",
                            new Dictionary<string, object>
                            {
                                {"href", $"{host}/api/leads/invited/{lead.Id}"},
                                {"method", "DELETE"}
                            }
                        }
                    });

                    return dictObject;
                });

            halObject.Add("_embedded", new Dictionary<string, object>
            {
                { "leads", embedded.ToArray() }
            });

            return halObject;
        }
    }
}
