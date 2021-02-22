using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Web.ViewModels
{
    public class PortfolioViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public IFormFile File { get; set; }
    }
}