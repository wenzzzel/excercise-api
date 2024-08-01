using excercise_api.Models;
using excercise_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace excercise_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExcercisesController : ControllerBase
{
    private readonly IRecordRepository _recordRepository;

    public ExcercisesController(IRecordRepository excerciseRepository)
    {
        _recordRepository = excerciseRepository;
    }

    [HttpGet]
    public IEnumerable<RecordDto> Get() => _recordRepository.GetRecords();

    [HttpPost]
    public void Post([FromBody] RecordDto input) => _recordRepository.AddRecord(input);
}
