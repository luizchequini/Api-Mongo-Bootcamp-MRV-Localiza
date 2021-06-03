using System;

namespace Api_Mongo_Bootcamp_MRV_Localiza.Model
{
    public class InfectadoDTO
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}