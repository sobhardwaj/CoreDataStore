using System.Collections.Generic;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreDataStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class DataEventRecordsController : Controller
    {
        private readonly IDataAccessProvider _dataEventRecordRepository;

        public DataEventRecordsController(IDataAccessProvider dataEventRecordRepository)
        {
            _dataEventRecordRepository = dataEventRecordRepository;
        }


        [HttpGet]
        public IEnumerable<DataEventRecord> Get()
        {
            return _dataEventRecordRepository.GetAll();
        }

        [HttpGet("{id}")]
        public DataEventRecord Get(long id)
        {
            return _dataEventRecordRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]DataEventRecord value)
        {
            _dataEventRecordRepository.Post(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]DataEventRecord value)
        {
            _dataEventRecordRepository.Put(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataEventRecordRepository.Delete(id);
        }
    }
}
