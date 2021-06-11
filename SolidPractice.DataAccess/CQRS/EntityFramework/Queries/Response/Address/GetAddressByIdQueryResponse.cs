using System;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address
{
    public class GetAddressByIdQueryResponse : QueryResponseBase
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public DateTime Created { get; set; }

        //ADRESİN AİT OLDUĞU MÜŞTERİ
        public Customer Customer { get; set; }


        public GetAddressByIdQueryResponse(bool isSuccess):base(isSuccess) 
        {
            
        }


        public GetAddressByIdQueryResponse():base()
        {
            
        }
    }
}