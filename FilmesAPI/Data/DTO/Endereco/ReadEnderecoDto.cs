﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}
