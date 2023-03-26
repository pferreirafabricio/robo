using Application.InputModels;
using Application.Services.Interfaces;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/robot/[action]")]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;

        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var robot = _robotService.GetById(id);

            return Ok(robot);
        }

        [HttpGet("{id}")]
        public IActionResult GetHead(int id)
        {
            var head = _robotService.GetHead(id);

            return Ok(head);
        }

        [HttpGet("{id}")]
        public IActionResult GetArms(int id)
        {
            var arms = _robotService.GetArms(id);

            return Ok(arms);
        }

        [HttpPost]
        public IActionResult Create()
        {
            var createdId = _robotService.Create();

            return Ok(createdId);
        }

        [HttpPost]
        public IActionResult RotateHead([FromBody] RotateHeadInputModel inputModel)
        {
            try
            {
                _robotService.RotateHead(inputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InclineHead([FromBody] InclineHeadInputModel inputModel)
        {
            try
            {
                _robotService.InclineHead(inputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RotateArmElbow([FromBody] RotateArmElbowInputModel inputModel)
        {
            try
            {
                _robotService.ChangeElbowState(inputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RotateArmWrist([FromBody] RotateArmWristInputModel inputModel)
        {
            try
            {
                _robotService.RotateArmWrist(inputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}