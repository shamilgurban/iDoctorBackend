﻿
namespace iDoctor.Application.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
