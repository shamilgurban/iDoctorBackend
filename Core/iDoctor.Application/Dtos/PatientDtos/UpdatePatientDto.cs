﻿
using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Dtos.PatientDtos
{
    public class UpdatePatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? HealthRecord { get; set; }
        public IFormFile? Image { get; set; }
    }
}