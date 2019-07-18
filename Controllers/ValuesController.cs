// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;

// namespace kitchenex.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class ValuesController : ControllerBase
//   {
//     private readonly ValueRepository _repo;
//     public ValuesController(ValueRepository repo)
//     {
//       _repo = repo;
//     }
//     // GET api/values
//     [HttpGet]
//     public ActionResult<IEnumerable<Value>> Get()
//     {
//       try
//       {
//         return Ok(_repo.GetAll());
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }

//     // GET api/values/5
//     [HttpGet("{id}")]
//     public ActionResult<Value> Get(int id)
//     {
//       try
//       {
//         return Ok(_repo.GetById(id));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }

//     // POST api/values
//     [HttpPost]
//     public ActionResult Post([FromBody] Value value)
//     {
//       try
//       {
//         return Ok(_repo.Create(value));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }

//     // PUT api/values/5
//     [HttpPut("{id}")]
//     public ActionResult Put(int id, [FromBody] Value value)
//     {
//       try
//       {
//         value.Id = id;
//         return Ok(_repo.Update(value));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }

//     // DELETE api/values/5
//     [HttpDelete("{id}")]
//     public ActionResult<string> Delete(int id)
//     {
//       try
//       {
//         return Ok(_repo.Delete(id));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }
//   }
// }
