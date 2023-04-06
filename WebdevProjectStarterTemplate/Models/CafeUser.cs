using System;
using System.ComponentModel.DataAnnotations;


namespace WebdevProjectStarterTemplate.Models;

public class CafeUser
{
    public int UniqueGuid { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required, MinLength(8)]
    public string Password { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }

    public string Location { get; set; }
    public DateTime Date { get; set; }
}