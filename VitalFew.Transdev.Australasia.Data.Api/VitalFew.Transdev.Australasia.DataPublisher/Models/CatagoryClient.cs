using System;

namespace VitalFew.Transdev.Australasia.DataPublisher.Models
{
    public class CatagoryClient
    {
        public int Id { get; set; }

        public Guid ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientToken { get; set; }

        public string ClientStatus { get; set; }
    }
}