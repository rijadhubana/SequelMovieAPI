﻿using Microsoft.AspNetCore.Mvc;
using SequelMovieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SequelMovieAPI.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        public T Insert(TInsert request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public T Update(int id, [FromBody] TUpdate request)
        {
            return _service.Update(id, request);
        }
        [HttpDelete("{Id}")]
        public T Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
