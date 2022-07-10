using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace BlazeUrl.Data;
public class UrlModel
{    public string? Short { get; set; }
    public string? Long { get; set; }
}