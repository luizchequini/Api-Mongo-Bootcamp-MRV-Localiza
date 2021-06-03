using Api_Mongo_Bootcamp_MRV_Localiza.Data.Collections;
using Api_Mongo_Bootcamp_MRV_Localiza.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_Mongo_Bootcamp_MRV_Localiza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadoCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadoCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadoCollection.InsertOne(infectado);
            return StatusCode(201, "Infectado adicionado com sucesso!");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadoCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }
    }
}