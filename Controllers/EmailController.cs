using EmailNotification.Domain.Dtos;
using EmailNotification.Domain.Entities;
using EmailNotification.Domain.Models;
using EmailNotification.Infrastructures.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmailNotification.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IRepositoryService _service;

    public EmailController(IEmailService emailService, IRepositoryService service)
    {
        _emailService = emailService;
        _service = service;
    }

    [HttpPost("send")]
    public async Task<ApiResponse<EmailLogDto>> SendEmail([FromBody] EmailLogDto request)
    {
        if (!ModelState.IsValid)
        {
            return new ApiResponse<EmailLogDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Invalid request.",
                Data = null
            };
        }

        try
        {
            // Kirim email dan dapatkan body HTML yang sudah diproses
            var emailLog = request.ConvertToEntity();
            string finalHtmlBody = await _emailService.SendEmailAsync(emailLog);
            emailLog.Body = finalHtmlBody;

            // Simpan log ke database
            var result = await _service.SaveEmailLog(emailLog, new CancellationToken());
            if (!result.Succeeded)
                throw new Exception(result.Errors.FirstOrDefault());

            return new ApiResponse<EmailLogDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Email sent and logged successfully!",
                Data = request
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<EmailLogDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Data = null
            };
        }
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetEmailHistory()
    {
        try
        {
            var histories = await _service.GetEmailLogs();

            return Ok(new ApiResponse<List<EmailLog>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = string.Empty,
                Data = histories
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<List<EmailLog>>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
                Data = null
            });
        }
    }
}
